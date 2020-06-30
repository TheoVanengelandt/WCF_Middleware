using System;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Middleware
{
    public class Auth : IAuth
	{
		private STC_MSG msg;

		public Auth()
		{
			this.msg = new STC_MSG();
		}

		[PrincipalPermission(SecurityAction.Demand, Role = @"BUILTIN\Utilisateurs")]
		public STC_MSG Login(STC_MSG msg)
		{

			OperationContext context = OperationContext.Current;
			MessageProperties msgProp = context.IncomingMessageProperties;
			RemoteEndpointMessageProperty remoteProp = msgProp[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
			ServiceSecurityContext ssc = ServiceSecurityContext.Current;

			
			Console.ForegroundColor = ConsoleColor.Blue; 
			Console.WriteLine("Demande entrente : " + "<" + ssc.WindowsIdentity.Name + ">" + ssc.WindowsIdentity.User);
			Console.WriteLine("Adresse cliente : " + remoteProp.Address);
			Console.WriteLine("Port client : " + remoteProp.Port);
			Console.WriteLine("Détail du message ->");
			Console.WriteLine("Application cliente : " + msg.app_name);
			Console.WriteLine("Application token : " + msg.app_token);
			Console.WriteLine("Application version : " + msg.app_version);
			Console.WriteLine("Opération info : " + msg.op_info);
			Console.WriteLine("Opération nom : " + msg.op_name);
			Console.WriteLine("Opération statut : " + msg.op_statut);
			Console.WriteLine("Utilisteur login : " + msg.user_login);
			Console.WriteLine("Utilisteur password : " + msg.user_psw);
			Console.WriteLine("Utilisteur token : " + msg.user_token);

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

				if (msg.op_name == "authentifier")
				{
					this.msg = msg;
					if (msg.app_name == "Middleware") //tmp app_name
					{
						if (msg.app_version == "2.0") //tmp app_version
						{
							if (msg.op_name == "authentifier") //tmp op_name
							{
								this.msg = new CTRL_Auth().Exec(this.msg);
							}
						}
					}
				}
			}
			else
			{
				this.msg.app_name = "";
				this.msg.app_token = "";
				this.msg.app_version = "";
				this.msg.data = null;
				this.msg.op_info = "Cette application n'est pas prise en charge par la plateforme.";
				this.msg.op_name = "";
				this.msg.op_statut = false;
				this.msg.user_login = "";
				this.msg.user_psw = "";
				this.msg.user_token = "";
			}
			return this.msg;
		}
	}
}
