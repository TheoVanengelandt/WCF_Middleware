using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceWebRole1
{
	[ServiceContract]
	public interface IDecrypt
	{
		[OperationContract]
		STC_MSG DecryptFiles(STC_MSG msg);
	}
}
