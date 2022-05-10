using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMessageBox;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread __ = new Thread(test);
            Thread _ = new Thread(() =>
            {
                bool result = LMessageBox.Ver1.LMessageBox.Show("Error", "Warning");
                MessageBox.Show(result.ToString());
            });
            _.IsBackground = false;
            _.Start();
            Thread.Sleep(5000);
            _.Abort();
        }

        public void test()
        {
            Thread _ = new Thread(() =>
            {
                bool result = LMessageBox.Ver1.LMessageBox.Show("Error", "Warning");
                MessageBox.Show(result.ToString());
            });
            _.IsBackground = true;
            _.Start();
        }
    }
}
