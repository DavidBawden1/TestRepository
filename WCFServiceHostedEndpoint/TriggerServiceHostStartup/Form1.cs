using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFWindowsServiceHost;

namespace TriggerServiceHostStartup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartWCFServiceButton_Click(object sender, EventArgs e)
        {
            WCFServiceHost host = new WCFServiceHost();
            host.StartWCFService();
        }
    }
}
