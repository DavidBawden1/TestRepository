using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertificateOidFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            X509Store store = new X509Store("MY", StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            for (int i = 0; i < collection.Count; i++)
            {
                foreach (X509Extension extension in collection[i].Extensions)
                {
                    Console.WriteLine(extension.Oid.FriendlyName + "(" + extension.Oid.Value + ")");


                    if (extension.Oid.FriendlyName == "Key Usage")
                    {
                        X509KeyUsageExtension ext = (X509KeyUsageExtension)extension;
                        Console.WriteLine(ext.KeyUsages);
                    }

                    if (extension.Oid.FriendlyName == "Basic Constraints")
                    {
                        X509BasicConstraintsExtension ext = (X509BasicConstraintsExtension)extension;
                        Console.WriteLine(ext.CertificateAuthority);
                        Console.WriteLine(ext.HasPathLengthConstraint);
                        Console.WriteLine(ext.PathLengthConstraint);
                    }

                    if (extension.Oid.FriendlyName == "Subject Key Identifier")
                    {
                        X509SubjectKeyIdentifierExtension ext = (X509SubjectKeyIdentifierExtension)extension;
                        Console.WriteLine(ext.SubjectKeyIdentifier);
                    }

                    if (extension.Oid.FriendlyName == "Enhanced Key Usage")
                    {
                        X509EnhancedKeyUsageExtension ext = (X509EnhancedKeyUsageExtension)extension;
                        OidCollection oids = ext.EnhancedKeyUsages;
                        foreach (Oid oid in oids)
                        {
                            Console.WriteLine(oid.FriendlyName + "(" + oid.Value + ")");
                        }
                    }
                }
            }
            store.Close();

            Console.ReadKey();
        }
    }
}
