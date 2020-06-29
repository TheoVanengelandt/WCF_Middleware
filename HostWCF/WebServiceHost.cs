using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostWCF
{
	class WebServiceHost
	{
		public WebServiceHost(object singletonInstance, params Uri[] baseAddresses)
		{
			Uri[] baseAddresses = { new Uri("http://localhost/one"), new Uri("http://localhost/two") };
			WebServiceHost host = new WebServiceHost(typeof(CalcService), baseAddresses);
		}
	}
}
