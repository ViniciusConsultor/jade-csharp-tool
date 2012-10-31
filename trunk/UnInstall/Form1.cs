using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnInstall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sysroot = AppDomain.CurrentDomain.BaseDirectory;

            System.Diagnostics.Process.Start(sysroot + "\\msiexe.exe", "/x {8EA1C379-CF3A-463B-A0D7-C020BC5EDA5A} /qr");
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
