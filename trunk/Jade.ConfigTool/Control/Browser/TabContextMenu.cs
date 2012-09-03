using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Jade.Forms;
namespace Com.iFLYTEK.WinForms.Browser
{
    public partial class TabContextMenu : ContextMenu
    {

        public TabContextMenu()
        {
            InitializeComponent();
            InitMenuItem();
        }

        private void InitMenuItem()
        {

        }


        public TabContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
