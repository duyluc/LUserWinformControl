using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_IpAddressTable.Ver1
{
    public partial class Test_IpAddressTable : Form
    {
        public Test_IpAddressTable()
        {
            InitializeComponent();
            this.IPTable.Initial(this.IPTable.Name);
        }
    }
}
