using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Middleware
{
	interface ICTRL_Auth
	{
		STC_MSG Exec(STC_MSG msg);
	}
}
