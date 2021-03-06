﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Middleware
{
	class CTRL_Auth : ICTRL_Auth
	{
		private STC_MSG msg;
		private readonly Database db;

		public CTRL_Auth()
		{
			this.msg = new STC_MSG();
			this.db = new Database();
		}

		public STC_MSG Exec(STC_MSG msg)
		{
			this.msg = msg;

			// Set auth at false before db auth
			this.msg.op_statut = false;

			this.msg = this.db.SelectByLoginPsw(this.msg);

			if (this.msg.op_statut)
			// if (msg.user_login == "theo" && msg.user_psw =="123")
			{
				this.msg.op_info = "succes";
				this.msg.op_statut = true;
				this.msg.user_token = new Guid().ToString();
			}
			else
			{
				this.msg.op_info = "fail";
				this.msg.op_statut = false;
			}

			this.msg.app_name = null;
			this.msg.app_token = null;
			this.msg.app_version = null;
			this.msg.data = null;
			this.msg.op_name = null;
			this.msg.user_login = null;
			this.msg.user_psw = null;

			return this.msg;
		}
	}
}
