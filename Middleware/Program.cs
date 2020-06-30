using System;
using System.ServiceModel;

namespace Middleware
{
	class Program
	{
		private static ServiceHost host;

		static void Main(string[] args)
		{
			Program.Headup();
			Program.Ini_serv();
			Console.Read();
		}

		static void Headup()
		{
			Console.ForegroundColor = ConsoleColor.Green; // Console style
			Console.WriteLine("****************************************");
			Console.WriteLine("**                                    **");
			Console.WriteLine("**        Server Middleware 1.0       **");
			Console.WriteLine("**                                    **");
			Console.WriteLine("****************************************\n\n");
		}

		static void Ini_serv()
		{
			int i;

			Program.host = new ServiceHost(typeof(Auth));

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Initialisation du serveur...veuillez patienter");

			try
			{
				host.Open();
				Console.WriteLine("<--Serveur ouvert-->\n");

				for (i = 0; i < host.Description.Endpoints.Count; i++)
				{
					Console.ForegroundColor = ConsoleColor.Green; // Console style
					Console.WriteLine("Description du service {0}", i);

					Console.ForegroundColor = ConsoleColor.Yellow; // Console style
					Console.WriteLine("Adresse : " + host.Description.Endpoints[i].Address);
					Console.WriteLine("Binding : " + host.Description.Endpoints[i].Binding);
					Console.WriteLine("Contract Type : " + host.Description.Endpoints[i].Contract.ContractType);
					Console.WriteLine("Contract Name : " + host.Description.Endpoints[i].Contract.Name);
					Console.WriteLine("Uri : " + host.Description.Endpoints[i].ListenUri.Host);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				Console.WriteLine("\n<--  Fin de l'initialisation  -->");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\n" + host.State.ToString());
			}


		}
	}
}
