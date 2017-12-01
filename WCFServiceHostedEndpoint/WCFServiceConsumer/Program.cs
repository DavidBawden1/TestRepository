using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceConsumer.WCFServiceHost;

namespace WCFServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WCFServiceHostClient client = new WCFServiceHostClient();
                string helloWorldMessage = client.GetData();
                Console.WriteLine(helloWorldMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
