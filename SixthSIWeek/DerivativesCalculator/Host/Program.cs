using DerivativesCalculatorService.App_Code;
using System;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        public static void Main(string[] args)
        {
			try
			{
				Type serviceType = typeof(Calculator);

				using (ServiceHost host = new ServiceHost(serviceType))
				{
					host.Open();
					Console.WriteLine("The derivative calculator is running.");

					foreach (var address in host.BaseAddresses)
					{
						Console.WriteLine($"Base address: {address.ToString()}");
					}
					Console.WriteLine($"Host is running...Press Enter to stop.");
					Console.ReadLine();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception occured. {ex.Message}");
			}
			Console.WriteLine("Service is stopped.");
			Console.ReadLine();
        }
    }
}
