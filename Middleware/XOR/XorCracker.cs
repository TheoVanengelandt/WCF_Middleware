using Middleware.proxyDecrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

			foreach (string item in keyList)
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

				// Method to get trust value
				try
				{
					msg.data[2] = req.decodage(GenerateXml(msg)); ;
				}
				catch (Exception e)
				{
					throw new Exception("Code JEE error " + e);
				}
			}

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
			loginNode.AppendChild(doc.CreateTextNode(msg.user_login != null ? msg.user_login.ToString() : "null"));
			msgNode.AppendChild(loginNode);

			// user_psw
			XmlNode pwdNode = doc.CreateElement("user_psw");
			pwdNode.AppendChild(doc.CreateTextNode(msg.user_psw != null ? msg.user_psw.ToString() : "null"));
			msgNode.AppendChild(pwdNode);

			// user_token
			XmlNode userTokenNode = doc.CreateElement("user_token");
			userTokenNode.AppendChild(doc.CreateTextNode(msg.user_token != null ? msg.user_token.ToString() : "null"));
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
				fileTextAttribute.AppendChild(doc.CreateTextNode(msg.data[1].ToString()));
				fileNode.AppendChild(fileTextAttribute);

				dataNode.AppendChild(fileNode);
			}

			string xml = doc.InnerXml.ToString();
			// xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?> <stcMSG> 	<op_statut>true</op_statut> 	<op_name>operation</op_name> 	<op_info>info</op_info> 	<app_name>name</app_name> 	<app_version>version</app_version> 	<app_token>token</app_token> 	<user_login>login</user_login> 	<user_psw>psw</user_psw> 	<user_token>token</user_token> 	<data>         <text> 				Mr et Mrs Dursley, qui habitaient au 4, Privet Drive, avaient toujours affirme avec la plus 				grande fierte qu'ils etaient parfaitement normaux, merci pour eux. Jamais quiconque n'aurait 				imagine qu'ils puissent se trouver impliques dans quoi que ce soit d'etrange ou de mysterieux. 				Ils n'avaient pas de temps à perdre avec des sornettes. 				Mr Dursley dirigeait la Grunnings, une entreprise qui fabriquait des perceuses. C'etait un 				homme grand et massif, qui n'avait pratiquement pas de cou, mais possedait en revanche une 				moustache de belle taille. Mrs Dursley, quant à elle, etait mince et blonde et disposait d'un 				cou deux fois plus long que la moyenne, ce qui lui etait fort utile pour espionner ses voisins en 				regardant par-dessus les clôtures des jardins. Les Dursley avaient un petit garçon prenomme 				Dudley et c'etait à leurs yeux le plus bel enfant du monde. 				Les Dursley avaient tout ce qu'ils voulaient. La seule chose indesirable qu'ils possedaient, 				c'etait un secret dont ils craignaient plus que tout qu'on le decouvre un jour. Si jamais 				quiconque venait à entendre parler des Potter, ils etaient convaincus qu'ils ne s'en remettraient 				pas. Mrs Potter etait la sœur de Mrs Dursley, mais toutes deux ne s'etaient plus revues depuis 				des annees. En fait, Mrs Dursley faisait comme si elle etait fille unique, car sa sœur et son bon 				à rien de mari etaient aussi eloignes que possible de tout ce qui faisait un Dursley. Les 				Dursley tremblaient d'epouvante à la pensee de ce que diraient les voisins si par malheur les 				Potter se montraient dans leur rue. Ils savaient que les Potter, eux aussi, avaient un petit 				garçon, mais ils ne l'avaient jamais vu. Son existence constituait une raison supplementaire de 				tenir les Potter à distance: il n'etait pas question que le petit Dudley se mette à frequenter un 				enfant comme celui-là. 				Lorsque Mr et Mrs Dursley s'eveillèrent, au matin du mardi où commence cette histoire, il 				faisait gris et triste et rien dans le ciel nuageux ne laissait prevoir que des choses etranges et 				mysterieuses allaient bientôt se produire dans tout le pays. Mr Dursley fredonnait un air en 				nouant sa cravate la plus sinistre pour aller travailler et Mrs Dursley racontait d'un ton badin 				les derniers potins du quartier en s'efforçant d'installer sur sa chaise de bebe le jeune Dudley 				qui braillait de toute la force de ses poumons. 				Aucun d'eux ne remarqua le gros hibou au plumage mordore qui voleta devant la fenêtre. 				A huit heures et demie, Mr Dursley prit son attache-case, deposa un baiser sur la joue de Mrs 				Dursley et essaya d'embrasser Dudley, mais sans succès, car celui-ci etait en proie à une petite 				crise de colere et s'appliquait à jeter contre les murs de la pièce le contenu de son assiette de 				cereales.  		</text>         <name>nomdefichierquifaischier</name>     </data> </stcMSG>";

			return xml;
		}
	}
}
