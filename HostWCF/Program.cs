using HostWCF.WCFService;
using System;
using System.ServiceModel;

namespace HostWCF
{
	class Program
	{
		static void Main(string[] args)
		{
			string address = "net.tcp://localhost:9000/Middleware/Auth";

			// Open the service and wait for calls.
			ChannelFactory<IAuth> factory = new ChannelFactory<IAuth>(new NetTcpBinding(SecurityMode.None));

			IAuth proxy = factory.CreateChannel(new EndpointAddress(address));

			try
			{
				// Step 2: Call the service operations.
				string login = "theo";
				string password = "123";
				string apppToken = "apptoken";

				string result = proxy.UserLogin(login, password, apppToken);

				Console.WriteLine("Token result : " + result);

				// Step 3: Close the client to gracefully close the connection and clean up resources.
				Console.WriteLine("\nPress <Enter> to terminate the client.");
				Console.ReadLine();
				factory.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}
	}
}