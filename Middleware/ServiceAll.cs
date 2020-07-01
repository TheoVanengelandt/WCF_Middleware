using Middleware.proxyDecrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Middleware
{
	class ServiceAll : IAuth, IDecrypt
	{
		private STC_MSG msg;

		public ServiceAll()
		{
			this.msg = new STC_MSG();
		}

		public STC_MSG Login(STC_MSG msg)
		{
			this.msg = msg;

			if (CheckRequest(this.msg))
			{
				if (msg.op_name == "authentifier")
				{
					this.msg = new CTRL_Auth().Exec(this.msg);
				}
				else
				{
					this.msg.op_info = "Operation invalid";
					this.msg.op_statut = false;
					this.msg.op_name = "";
				}
			}
			return this.msg;
		}

		public bool CheckRequest(STC_MSG msg)
		{
			if (msg.data != null)
			{
				int i = msg.data.Length;
				Console.WriteLine("Le message contient {0} donnée(s) spécifique(s)", i + 1);
			}
			else
			{
				Console.WriteLine("Le message ne contient pas de données spécifiques");
			}

			if (msg.app_token == "apptoken") // App token to change
			{

				if (msg.app_name == "Middleware") //tmp app_name
				{
					if (msg.app_version == "2.0") //tmp app_version
					{
						return true;
					}
					else
					{
						this.msg.op_info = "App version invalid";
						this.msg.op_statut = false;
						this.msg.app_version = "";
					}
				}
				else
				{
					this.msg.op_info = "This plateforme doesn't handle this application.";
					this.msg.op_statut = false;
					this.msg.app_name = "";
				}
			}
			else
			{
				this.msg.op_info = "App token invalid";
				this.msg.op_statut = false;
				this.msg.app_token = "";
			}

			this.msg.data = null;
			this.msg.op_name = "";
			this.msg.user_login = "";
			this.msg.user_psw = "";
			this.msg.user_token = "";

			return false;
		}

		public STC_MSG DecryptFiles(STC_MSG msg)
		{
			this.msg = msg;

			if (CheckRequest(this.msg))
			{
				if (msg.op_name == "decrypter")
				{
					if (CheckUserToken(this.msg))
					{
						// Method used to decrypt files
						// this.msg = DecryptClass.DecrytpMethod(this.msg);

						// Then send those files to the JEE app
						ProjetService req = new ProjetService();

						// Method to get trust value
						try
						{
							string res = req.decodage(GenerateXml(this.msg));

							this.msg.data[0] = res;
						}
						catch (Exception e)
						{
							throw new Exception("C'ets de la merde le code JEE = " + e);
						}
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

