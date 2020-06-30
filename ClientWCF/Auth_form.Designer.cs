namespace ClientWCF
{
	partial class Auth_form
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_login = new System.Windows.Forms.TextBox();
			this.txt_password = new System.Windows.Forms.TextBox();
			this.txt_information = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(273, 142);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(273, 203);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(298, 379);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Response";
			// 
			// txt_login
			// 
			this.txt_login.Location = new System.Drawing.Point(378, 139);
			this.txt_login.Name = "txt_login";
			this.txt_login.Size = new System.Drawing.Size(523, 20);
			this.txt_login.TabIndex = 3;
			// 
			// txt_password
			// 
			this.txt_password.Location = new System.Drawing.Point(378, 200);
			this.txt_password.Name = "txt_password";
			this.txt_password.Size = new System.Drawing.Size(523, 20);
			this.txt_password.TabIndex = 4;
			// 
			// txt_information
			// 
			this.txt_information.Location = new System.Drawing.Point(378, 376);
			this.txt_information.Name = "txt_information";
			this.txt_information.Size = new System.Drawing.Size(523, 20);
			this.txt_information.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(564, 260);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(148, 30);
			this.button1.TabIndex = 6;
			this.button1.Text = "Login";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Btn_go_Click);
			// 
			// Auth_form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1065, 543);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txt_information);
			this.Controls.Add(this.txt_password);
			this.Controls.Add(this.txt_login);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Auth_form";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_login;
		private System.Windows.Forms.TextBox txt_password;
		private System.Windows.Forms.TextBox txt_information;
		private System.Windows.Forms.Button button1;
	}
}

