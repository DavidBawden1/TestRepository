using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
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
            X509Certificate2 cer = new X509Certificate2();
            cer.Import(@"C:\temp\cert.pfx", "passw0rd!", X509KeyStorageFlags.MachineKeySet);
            //X509Store store = new X509Store(StoreLocation.LocalMachine);
            //store.Certificates.Add(cer);

            //X509Certificate2Collection cers = store.Certificates.Find(X509FindType.FindBySubjectName, "WCFCert", false);
            //if (cers.Count > 0)
            //{
            //    cer = cers[0];
            //};
            //store.Close();
            //return;
            string httpAddress = $"https://localhost:8080/GetData";
            Uri addressUri = new Uri(httpAddress);
            Uri[] baseAddresses = new Uri[] { addressUri };
            ServiceHost host = new ServiceHost(typeof(WCFServiceHost), baseAddresses);
            BasicHttpBinding secureHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            secureHttpBinding.Name = "secureHttpBinding";
            secureHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            Type type = typeof(IWCFServiceHost);
            


            //var storeName = @"my"; //ConfigurationManager.AppSettings["certStoreName"];
            //StoreName configuredStorenmae;
            //Enum.TryParse(storeName, out configuredStorenmae);
            
            host.AddServiceEndpoint(type, secureHttpBinding, "WCFServiceHost");
            //host.Credentials.ServiceCertificate.SetCertificate("WCFCert");
            host.Credentials.ClientCertificate.Certificate = cer;

            try
            {
                Console.WriteLine("Attempting to open the service host.");
                host.Open();
                string address = host.Description.Endpoints[0].ListenUri.AbsoluteUri;
                Console.WriteLine("Listening @ {0}", address);
                Console.WriteLine("Press enter to close the service");
                host.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("A communication error occurred: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured: {0}", ex.Message);
            }
            finally
            {
                Console.ReadLine();

            }
        }
    }
}
