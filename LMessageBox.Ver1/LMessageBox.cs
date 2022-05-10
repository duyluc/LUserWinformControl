using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMessageBox.Ver1
{
    public partial class LMessageBox : Form
    {
        Timer blinding;
        bool light = false;
        string Message = "";
        string MessageLevel = "";
        bool result = false;

        public LMessageBox(string _message, string messagelevel)
        {
            InitializeComponent();
            this.BackColor = Color.Green;
            this.Display.Text = _message;
            this.LEVEL.Text = messagelevel;
            blinding = new Timer();
            blinding.Interval = 500;
            blinding.Tick += Blinding_Tick;
            blinding.Start();
        }

        static public bool Show(string Message, string MessageLevel)
        {
            LMessageBox l = new LMessageBox(Message, MessageLevel);
            l.ShowDialog();
            return l.result;
        }

        private void Blinding_Tick(object sender, EventArgs e)
        {
            light = !light;
            if (light)
            {
                this.BackColor = Color.Red;
            }
            else
            {
                this.BackColor = Color.Green;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.result = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.result = false;
            this.Close();
        }
    }
}
