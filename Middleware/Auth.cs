using System;
using System.ServiceModel;

namespace Middleware
{
	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
	// REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
	public class Auth : Middleware.IAuth
	{
		string UserToken = string.Empty;

		//Method to validate user token
		public bool IsValidateUser()
		{
			//Getting the user token from client request  
			if (OperationContext.Current.IncomingMessageHeaders.FindHeader("TokenHeader", "TokenNameSpace") == -1)
			{
				return false;
			}

			string userIdentityToken = Convert.ToString(OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("TokenHeader", "TokenNameSpace"));

			//Authenticating user with token, if it is validated then returning employee data  
			return userIdentityToken == UserToken;
		}

		//Method to validate user creadentials and the app token
		public string UserLogin(string userName, string password, string appToken)
		{
			if (appToken != "apptoken")
			{
				throw new Exception("Invalid app token");
			}

			//Validating user with static values, you can validate from database  
			if (userName == "theo" && password == "123")
			{
				//If user is validated then returning current session id as user token  
				UserToken = Guid.NewGuid().ToString();
			}
			else
			{
				throw new Exception("Invalid credentials");
			}

			return UserToken;
		}

		//Check if content of the request is not null
		public string Login(LoginDataType loginData)
		{
			if (loginData == null)
			{
				throw new ArgumentNullException("loginData null");
			}

			return UserLogin(loginData.Login, loginData.Password, loginData.AppToken);
		}
	}
}
