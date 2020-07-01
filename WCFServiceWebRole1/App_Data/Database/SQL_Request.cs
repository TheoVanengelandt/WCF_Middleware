namespace WCFServiceWebRole1
{
	class SQL_Request
	{
		private STC_MSG msg;

		private string rq_sql;
		/*
		private int id;
		private string nom;
		private string prenom;
		*/
		private string psw;
		private string log;

		public SQL_Request()
		{
			this.msg = new STC_MSG();
		}

		public STC_MSG SelectByLoginPsw(STC_MSG msg)
		{
			this.msg = msg;
			this.log = msg.user_login;
			this.psw = msg.user_psw;

			rq_sql = "SELECT id, nom, prenom FROM tb_personne WHERE (login = '" + log + "') AND (psw = '" + psw + "');";

			this.msg.data = new object[1] { (object)rq_sql };

			return this.msg;
		}
	}
}
