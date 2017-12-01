using System;
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

            try
            {
                host.StartWCFService();
                MessageBox.Show("Service Running ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
