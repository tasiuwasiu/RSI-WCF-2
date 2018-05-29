using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:40013/");
            ServiceHost mojHost = new ServiceHost(typeof(Service1), baseAddress);
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.TransferMode = TransferMode.Streamed;
            binding.MaxReceivedMessageSize = 20000000;
            binding.MaxBufferSize = 20000000;

            try
            {
                ServiceEndpoint endpoint = mojHost.AddServiceEndpoint(typeof(IService1), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                mojHost.Description.Behaviors.Add(smb);
                mojHost.Open();
                Console.WriteLine("Serwis jest uruchomiony");
                
                Console.ReadLine();
                mojHost.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("Wyjatek: {0}", e.Message);
                mojHost.Abort();
            }



        }
    }
}
