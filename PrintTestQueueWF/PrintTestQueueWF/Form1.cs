using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintTestQueueWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString(("dddd" + ("," + "MM-dd-yyyy")));
            timer1.Interval = 1000;
            timer1.Enabled = true;

            timer2.Interval = 1000;
            timer2.Enabled = true;

            tbInfo.Text = "Retrieving printer queue information using WMI";
            tbInfo.Text += Environment.NewLine + "==================================";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Query printer queue
            ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_PrintJob");
            ManagementObjectSearcher query1 = new ManagementObjectSearcher(oq);
            ManagementObjectCollection queryCollection1 = query1.Get();
            foreach (ManagementObject mo in queryCollection1)
            {
                tbInfo.Text += "\r\n Printer Driver : " + mo["DriverName"].ToString();
                tbInfo.Text += "\r\n Document Name : " + mo["Document"].ToString();
                tbInfo.Text += "\r\n Document Owner : " + mo["Owner"].ToString();
                tbInfo.Text += "\r\n ==================================";
            }
        }
    }
}
