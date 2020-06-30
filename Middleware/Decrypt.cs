using Middleware.ServiceJava;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace Middleware
{
	class Decrypt : IDecrypt
	{
		private STC_MSG msg;

		public Decrypt()
		{
			this.msg = new STC_MSG();
		}

		public STC_MSG DecryptFiles(STC_MSG msg)
		{
			this.msg = msg;

			if (new Auth().CheckRequest(this.msg))
			{
				if (msg.op_name == "decrypter")
				{
					if(CheckUserToken(this.msg))
					{
						// Method used to decrypt files
						// this.msg = DecryptClass.DecrytpMethod(this.msg);

						// Then send those files to the JEE app
						ProjetEndpointClient req = new ProjetEndpointClient();

						// Method to get trust value
						req.decodage(GenerateXml(this.msg));
					}
					else
					{
						this.msg.op_info = "User token invalid";
						this.msg.user_token = "";
					}
				}
				else
				{
					this.msg.op_info = "Operation invalid";
					this.msg.op_statut = false;
					this.msg.op_name = "";
				}
			}

			return msg;
		}

		private bool CheckUserToken(STC_MSG msg)
		{

			// L'orchestration et la gestion transactionnelle doivent être mise en oeuvre ici.
			/* To handle with database connection
			int count = -1;

			this.sql = new SQL_Request();
			this.msg = this.sql.SelectByUserToken(this.msg);

			this.msg.data = new object[2] { this.msg.data[0], (object)"resultat" };
			this.msg = this.db.GetRows(this.msg);

			count = ((System.Data.DataTable)this.msg.data[0]).Rows.Count;

			if (count == 1)
			*/
			if (true)
			{
				this.msg.op_info = "succes";
				this.msg.op_statut = true;
			}
			else
			{
				this.msg.op_info = "fail";
				this.msg.op_statut = false;
			}

			return this.msg.op_statut;
		}

		private string GenerateXml (STC_MSG msg)
		{
			/*
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
			XmlNode nameNode = doc.CreateElement("op_name");
			nameNode.AppendChild(doc.CreateTextNode(msg.op_name.ToString()));
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

			// attributs
			for (int fileIndex = 0; fileIndex <= msg.data.Length; fileIndex++)
			{
				XmlNode fileNode = doc.CreateElement("file");

				Json JsonFile = JsonSerializer.Serialize<File>(msg.data[fileIndex]);

				XmlAttribute fileNameAttribute = doc.CreateAttribute("name");
				fileNameAttribute.Value = msg.data[fileIndex].ToString();
				fileNode.Attributes.Append(fileNameAttribute);

				XmlAttribute fileTextAttribute = doc.CreateAttribute("text");
				fileTextAttribute.Value = "01";
				fileNode.Attributes.Append(fileTextAttribute);

				dataNode.AppendChild(fileNode);
			}
			*/

			XmlSerializer xsSubmit = new XmlSerializer(typeof(STC_MSG));
			var xml = "";

			using (var sww = new System.IO.StringWriter())
			{
				using (XmlWriter writer = XmlWriter.Create(sww))
				{
					xsSubmit.Serialize(writer, this.msg);
					xml = sww.ToString(); // Your XML
				}
			}

			return xml;
		}
	}
}
