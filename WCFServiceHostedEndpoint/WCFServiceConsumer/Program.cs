using System;
using WCFWindowsServiceHost;

namespace WCFServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WCFServiceHost client = new WCFServiceHost();
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
