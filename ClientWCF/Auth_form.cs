using System;
using System.Windows.Forms;
using ClientWCF.proxy;

namespace ClientWCF
{
	public partial class Auth_form : Form
	{
		private STC_MSG msg;
		private AuthClient client;

		public Auth_form()
		{
			InitializeComponent();

			this.msg = new STC_MSG();
			this.client = new AuthClient("authTcp");

		}

		private void Btn_go_Click(object sender, EventArgs e)
		{
			this.txt_information.Clear();

			if ((this.txt_login.Text != "") && (this.txt_password.Text != ""))
			{
				this.msg.user_login = this.txt_login.Text;
				this.msg.user_psw = this.txt_password.Text;

				M_auhentifier(this.msg);

				if (this.msg.op_statut == true)
				{
					this.txt_information.Text = "Vous êtes connectés";
				}
				else
				{
					this.txt_information.Text = "Vous n'êtes pas connectés";
				}
			}
			else
			{
				this.txt_information.Text = "Veuillez renseigner tous les champs";
			}
		}

		private void M_auhentifier(STC_MSG msg)
		{
			this.msg = msg;
			this.msg.op_name = "authentifier";
			this.msg.app_name = "Middleware";
			this.msg.app_token = "apptoken";
			this.msg.app_version = "2.0";
			this.msg.op_info = "Demande de service de l'application 1 de version 2.0";

			this.msg = this.client.Login(this.msg);
		}
	}
}
