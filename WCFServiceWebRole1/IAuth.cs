using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceWebRole1
{
	[ServiceContract]
	public interface IAuth
	{
		[OperationContract]
		STC_MSG Login(STC_MSG msg);
	}
}
