using System;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.ServiceModel;

namespace Middleware
{
	[ServiceContract]
	public interface IAuth
	{
		//"Do It" -> HTTP PUT  
		[OperationContract]
		string UserLogin(string userName, string password, string appToken);
		//string Login(LoginDataType loginData);
	}

	// Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
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
