using System;
using System.Data;
using System.Data.SqlClient;

namespace Middleware
{
	internal class Database
	{
		private STC_MSG msg;

		private readonly SqlConnection cnx;

		public Database()
		{
			this.msg = new STC_MSG();
			this.cnx = new SqlConnection();

			//information about the remote server
			string server = "51.210.103.59";
			string port = "3306";
			string database = "ProjetDev_db";
			string username = "admincesi";
			string password = "cesiexia";

			// this.cnx.ConnectionString = "server=" + server + ";port=" + port + ";database=" + database + ";uid=" + username + ";pwd=" + password + ";";
			// string ConnectionString = "server=" + server + ":" + port + ";database=" + database + ";uid=" + username + ";pwd=" + password + ";";
			// this.cnx.ConnectionString = "Network Library=DBMSSOCN;Data Source=" + server + "," + port + ";Initial Catalog=" + database + ";User Id=" + username + ";Password=" + password + ";";
			this.cnx.ConnectionString = "Data Source=" + server + "," + port + ";Initial Catalog=" + database + ";User Id=" + username + ";Password=" + password + ";";
		}

		public STC_MSG SelectByLoginPsw(STC_MSG msg)
		{
			this.msg = msg;

			string log = msg.user_login;
			string psw = msg.user_psw;

			using(SqlConnection cnx = new SqlConnection(this.cnx.ConnectionString))
			{
				try
				{
					cnx.Open();

					//querie to check if the user's informations match
					SqlCommand sqlcmd = new SqlCommand("select count(1) from infouser where login=@login and pwd = sha1(@pwd)", this.cnx);
					sqlcmd.Parameters.AddWithValue("@login", log);
					sqlcmd.Parameters.AddWithValue("@pwd", psw);

					Console.Write("Response request SQL " + sqlcmd.ExecuteScalar());

					this.msg.op_statut = Convert.ToInt32(sqlcmd.ExecuteScalar()) == 1;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.ToString());
				}
			}

			return this.msg;
		}
	}
}