using System;
using System.ServiceModel;

namespace Middleware
{
	public class Auth : IAuth
	{
		string UserToken = string.Empty;

		// Method to validate user token
		public bool IsValidateUser()
		{
			//Getting the user token from client request  
			if (OperationContext.Current.IncomingMessageHeaders.FindHeader("TokenHeader", "TokenNameSpace") == -1)
			{
				return false;
			}

			string userIdentityToken = Convert.ToString(OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("TokenHeader", "TokenNameSpace"));

			// Authenticating user with token
			return userIdentityToken == UserToken;
		}

		// Method to validate user creadentials and the app token
		public string UserLogin(string userName, string password, string appToken)
		{
			if (appToken != "apptoken")
			{
				throw new Exception("Invalid app token");
			}

			//Validating user with static values, will be change by data from database  
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

		// NOT USED YET
		// Check if content of the request is not null
		public string Login(LoginDataType loginData)
		{
			if (loginData == null)
			{
				throw new ArgumentNullException("Data login null");
			}

			return UserLogin(loginData.Login, loginData.Password, loginData.AppToken);
		}
	}
}
