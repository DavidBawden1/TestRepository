using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFWindowsServiceHost;

namespace ServiceRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            new WCFServiceHost().StartWCFService();

            Console.ReadKey();
                
        }
    }
}
