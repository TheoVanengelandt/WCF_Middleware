using System;
using System.ServiceModel;

namespace Middleware
{
	[ServiceContract]
	public interface IAuth
	{
		[OperationContract]
		STC_MSG Login(STC_MSG msg);
	}
}
