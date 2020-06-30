using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Middleware
{
	[ServiceContract]
	public interface IDecrypt
	{
		[OperationContract]
		STC_MSG DecryptFiles(STC_MSG msg);
	}
}
