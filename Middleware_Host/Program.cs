using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Middleware_Host
{
	class Program
	{
		private static ServiceHost host;
		private static ServiceHost host2;

		static void Main(string[] args)
		{
			Program.Headup();
			// Program.Ini_serv();
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

			Program.host = new ServiceHost(typeof(Middleware.Auth));
			Program.host2 = new ServiceHost(typeof(Middleware.Decrypt));

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Initialisation du serveur...veuillez patienter");

			try
			{
				/*
				host.Open();
				host2.Open();
				*/
				Console.WriteLine("<--Serveur ouvert-->\n");

				for (i = 0; i < host.Description.Endpoints.Count; i++)
				{
					Console.ForegroundColor = ConsoleColor.Green; // Console style
					Console.WriteLine("Description du service {0}", i);

					Console.ForegroundColor = ConsoleColor.Yellow; // Console style
					Console.WriteLine("host Adresse : " + host.Description.Endpoints[i].Address);
					Console.WriteLine("host Uri : " + host.Description.Endpoints[i].ListenUri.Host);

					Console.WriteLine("host2 Adresse : " + host2.Description.Endpoints[i].Address);
					Console.WriteLine("host2 Uri : " + host2.Description.Endpoints[i].ListenUri.Host);
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
				Console.WriteLine("\n" + host2.State.ToString());
			}
		}
	}
}