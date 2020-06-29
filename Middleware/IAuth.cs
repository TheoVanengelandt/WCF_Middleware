using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Middleware
{
	[ServiceContract]
	public interface IAuth
	{
		[OperationContract]
		string UserLogin(string userName, string password, string appToken);
		//string Login(LoginDataType loginData);
	}

	// Utilisez un contrat de données pour ajouter les types composites aux opérations de service.
	[DataContract]
	public class LoginDataType
	{
		[DataMember]
		public string Login { get; set; }

		[DataMember]
		public string Password { get; set; }

		[DataMember]
		public string AppToken { get; set; }
	}
}
