using System;
using System.Runtime.Serialization;

namespace Middleware
{
	[DataContract]
	public struct STC_MSG
	{
		[DataMember]
		public bool op_statut;

		[DataMember]
		public string op_name;

		[DataMember]
		public string op_info;

		[DataMember]
		public string app_name;

		[DataMember]
		public string app_version;

		[DataMember]
		public string app_token;

		[DataMember]
		public string user_login;

		[DataMember]
		public string user_psw;

		[DataMember]
		public string user_token;

		[DataMember]
		public object[] data;
	}
}
