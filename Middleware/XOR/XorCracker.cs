using Middleware.proxyDecrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Middleware
{
    class XorCracker
    {
        private static List<string> keyList = new List<String>();

        public XorCracker(List<string> keyListParam)
        {
            keyList = keyListParam;
        }

        public STC_MSG Crack(STC_MSG msg)
        {
            string text = msg.data[1].ToString();

            // Then send those files to the JEE app
            ProjetService req = new ProjetService();

            string[] d = new string[5];

            Parallel.ForEach(keyList, (item) =>
            {
                string key = item;

                byte[] bytes = Encoding.ASCII.GetBytes(text);
                string[] binaryText = bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();

                byte[] bytesKey = Encoding.ASCII.GetBytes(key);
                string[] binaryKey = bytesKey.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();

                string txtDecode = "";
                for (int i = 0; i < binaryText.Length; i++)
                {
                    txtDecode += (char)Convert.ToInt16(XOR(binaryText[i], binaryKey[i % 4]), 2);
                }

                // 0 = file name
                d[0] = msg.data[0].ToString();
                // 1 = file content crypted
                d[1] = msg.data[1].ToString();
                // 2 = file content décrypted
                d[2] = txtDecode;
                // 3 = Key
                d[3] = key;
                msg.data = d;

                // Method to get trust value
                try
                {
                    // 4 = string result of JEE
                    d[4] = req.decodage(GenerateXml(msg));
                }
                catch (Exception e)
                {
                    throw new Exception("Code JEE error " + e);
                }
            });

            msg.data = d;
            return msg;
        }

        public string XOR(String text, String key)
        {
            String result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == key[i])
                {
                    result += "0";
                }
                else
                {
                    result += "1";
                }
            }
            return result;
        }

        private string GenerateXml(STC_MSG msg)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.AppendChild(docNode);

            XmlNode msgNode = doc.CreateElement("stcMSG");
            doc.AppendChild(msgNode);

            // op_statut
            XmlNode statutNode = doc.CreateElement("op_statut");
            statutNode.AppendChild(doc.CreateTextNode(msg.op_statut.ToString()));
            msgNode.AppendChild(statutNode);

            // op_name
            XmlNode opNameNode = doc.CreateElement("op_name");
            opNameNode.AppendChild(doc.CreateTextNode(msg.op_name.ToString()));
            msgNode.AppendChild(opNameNode);

            //op_info
            XmlNode infoNode = doc.CreateElement("op_info");
            infoNode.AppendChild(doc.CreateTextNode(msg.op_info.ToString()));
            msgNode.AppendChild(infoNode);

            //app_name
            XmlNode appNameNode = doc.CreateElement("app_name");
            appNameNode.AppendChild(doc.CreateTextNode(msg.app_name.ToString()));
            msgNode.AppendChild(appNameNode);

            // app_version
            XmlNode nameNode = doc.CreateElement("app_version");
            nameNode.AppendChild(doc.CreateTextNode(msg.app_version.ToString()));
            msgNode.AppendChild(nameNode);

            // app_token
            XmlNode appTokenNode = doc.CreateElement("app_token");
            appTokenNode.AppendChild(doc.CreateTextNode(msg.app_token.ToString()));
            msgNode.AppendChild(appTokenNode);

            // user_login
            XmlNode loginNode = doc.CreateElement("user_login");
            loginNode.AppendChild(doc.CreateTextNode(msg.user_login.ToString()));
            msgNode.AppendChild(loginNode);

            // user_psw
            XmlNode pwdNode = doc.CreateElement("user_psw");
            pwdNode.AppendChild(doc.CreateTextNode(msg.user_psw.ToString()));
            msgNode.AppendChild(pwdNode);

            // user_token
            XmlNode userTokenNode = doc.CreateElement("user_token");
            userTokenNode.AppendChild(doc.CreateTextNode(msg.user_token.ToString()));
            msgNode.AppendChild(userTokenNode);

            // data
            XmlNode dataNode = doc.CreateElement("data");
            msgNode.AppendChild(dataNode);

            if (msg.data != null)
            {
                // attributs
                XmlNode fileNode = doc.CreateElement("file");

                // Get name prop and value from the object

                XmlNode fileNameAttribute = doc.CreateElement("name");
                fileNameAttribute.AppendChild(doc.CreateTextNode(msg.data[0].ToString()));
                fileNode.AppendChild(fileNameAttribute);

                // Get text prop and value from the object
                XmlNode fileTextAttribute = doc.CreateElement("text");
                fileTextAttribute.AppendChild(doc.CreateTextNode(msg.data[2].ToString()));
                fileNode.AppendChild(fileTextAttribute);

                // Get text prop and value from the object
                XmlNode fileKeyAttribute = doc.CreateElement("key");
                fileKeyAttribute.AppendChild(doc.CreateTextNode(msg.data[3].ToString()));
                fileNode.AppendChild(fileKeyAttribute);

                dataNode.AppendChild(fileNode);
            }

            string xml = doc.InnerXml.ToString();

            return xml;
        }
    }
}
