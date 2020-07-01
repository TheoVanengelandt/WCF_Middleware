using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WCFServiceWebRole1
{
	public class WebRole : RoleEntryPoint
	{
		private static ServiceHost host;
		private static ServiceHost host2;

		public override bool OnStart()
		{
			WebRole.Headup();
			WebRole.Ini_serv();

			return base.OnStart();
		}

		static void Headup()
		{
			Console.ForegroundColor = ConsoleColor.Green; // Console style
			Console.WriteLine("****************************************");
			Console.WriteLine("**                                    **");
			Console.WriteLine("**        Server Middleware 3.0       **");
			Console.WriteLine("**                                    **");
			Console.WriteLine("****************************************\n\n");
		}

		static void Ini_serv()
		{
			int i;

			WebRole.host = new ServiceHost(typeof (Auth), new Uri("http://localhost:8000/Middleware/Auth"));
			WebRole.host2 = new ServiceHost(typeof (Decrypt), new Uri("http://localhost:8000/Middleware/Decrypt"));

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Initialisation du serveur...veuillez patienter");

			try
			{
				host.Open();
				Console.WriteLine("<--Serveur ouvert-->\n");

				for (i = 0; i < host.Description.Endpoints.Count; i++)
				{
					Console.ForegroundColor = ConsoleColor.Green; // Console style
					Console.WriteLine("Description du service {0}", i); // Console style
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

			try
			{
				host2.Open();
				Console.WriteLine("<--Serveur ouvert-->\n");

				for (i = 0; i < host2.Description.Endpoints.Count; i++)
				{
					Console.ForegroundColor = ConsoleColor.Green; // Console style
					Console.WriteLine("Description du service {0}", i);

					Console.ForegroundColor = ConsoleColor.Yellow;  // Console style
					Console.WriteLine("Uri : " + host2.Description.Endpoints[i].ListenUri.Host);
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
				Console.WriteLine("\n" + host2.State.ToString());
			}
		}
	}
}
