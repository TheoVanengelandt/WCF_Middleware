using HostWCF.WCFService;
using System;
using System.ServiceModel;

namespace HostWCF
{
	class Program
	{
		static void Main(string[] args)
		{
			// URI of the service using tcp connection
			// WARNING ! To run the Middleware, the app should be in Admin mode
			string address = "net.tcp://localhost:9000/Middleware/Auth";

			// Start a tcp connection using ChannelFactory class
			ChannelFactory<IAuth> factory = new ChannelFactory<IAuth>(new NetTcpBinding(SecurityMode.None));

			// Open the proxy service and wait for calls.
			IAuth proxy = factory.CreateChannel(new EndpointAddress(address));

			try
			{
				
				string login = "theo";
				string password = "123";
				string apppToken = "apptoken";

				// Call the service operations.
				string result = proxy.UserLogin(login, password, apppToken);
				Console.WriteLine("Token result : " + result);

				// Close the client to gracefully close the connection and clean up resources.
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