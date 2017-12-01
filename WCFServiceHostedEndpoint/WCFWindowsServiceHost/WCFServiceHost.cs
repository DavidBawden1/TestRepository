using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;

namespace WCFWindowsServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WCFServiceHost : IWCFServiceHost
    {
        public string GetData()
        {
            return string.Format("Hello world");
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void StartWCFService()
        {
            string httpAddress = $"https://localhost:80/GetData";
            Uri addressUri = new Uri(httpAddress);
            Uri[] baseAddresses = new Uri[] { addressUri };

            ServiceHost host = new ServiceHost(typeof(WCFServiceHost), baseAddresses);
            BasicHttpBinding secureHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            secureHttpBinding.Name = "secureHttpBinding";
            secureHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            Type type = typeof(IWCFServiceHost);

            host.AddServiceEndpoint(type, secureHttpBinding, "WCFServiceHost");
            host.Credentials.ServiceCertificate.SetCertificate("cert-2017-11-30-12-33-35", StoreLocation.LocalMachine, StoreName.My);

            try
            {
                Console.WriteLine("Attempting to open the service host.");
                host.Open();
                string address = host.Description.Endpoints[0].ListenUri.AbsoluteUri;
                Console.WriteLine("Listening @ {0}", address);
                Console.WriteLine("Press enter to close the service");
                Console.ReadLine();
                host.Close();
            }
            catch(CommunicationException ex)
            {
                Console.WriteLine("A communication error occurred: {0}", ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An unknown error occured: {0}", ex.Message);
            }
        }
    }
}
