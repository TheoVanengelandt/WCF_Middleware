using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Middleware
{
    class Decrypt : IDecrypt
    {
        private STC_MSG msg;

        public Decrypt()
        {
            this.msg = new STC_MSG();
        }

        public STC_MSG DecryptFiles(STC_MSG msg)
        {
            this.msg = msg;

            if (new Auth().CheckRequest(this.msg))
            {
                if (msg.op_name == "decrypter")
                {
                    if (CheckUserToken(this.msg))
                    {
						// Method used to decrypt files
						Semaphore _pool = new Semaphore(0, 6);

						List<string> keyList = new GenKey().GetList();

						Task.Factory.StartNew(() => {
							_pool.WaitOne();

							this.msg = new XorCracker(keyList).Crack(msg);

							_pool.Release();
						});
                    }
                    else
                    {
                        this.msg.op_info = "User token invalid";
                        this.msg.user_token = "";
                    }
                }
                else
                {
                    this.msg.op_info = "Operation invalid";
                    this.msg.op_statut = false;
                    this.msg.op_name = "";
                }
            }

            return msg;
        }

        private bool CheckUserToken(STC_MSG msg)
        {

            // L'orchestration et la gestion transactionnelle doivent être mise en oeuvre ici.
            /* To handle with database connection
			int count = -1;

			this.sql = new SQL_Request();
			this.msg = this.sql.SelectByUserToken(this.msg);

			this.msg.data = new object[2] { this.msg.data[0], (object)"resultat" };
			this.msg = this.db.GetRows(this.msg);

			count = ((System.Data.DataTable)this.msg.data[0]).Rows.Count;

			if (count == 1)
			*/
            if (true)
            {
                this.msg.op_info = "succes";
                this.msg.op_statut = true;
            }
            else
            {
                this.msg.op_info = "fail";
                this.msg.op_statut = false;
            }

            return this.msg.op_statut;
        }
    }
}
