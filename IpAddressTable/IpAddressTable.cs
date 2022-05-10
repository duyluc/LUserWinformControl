using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpAddressTable
{
    public partial class IpAddressTable : UserControl
    {
        public DataBaseProvider DbProvider { get; set; }

        public event EventHandler TableChanged;
        public void OnTableChanged()
        {
            List<string> iplist = new List<string>();
            foreach (DataGridViewRow row in this.Datagridview.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    iplist.Add(row.Cells[0].Value.ToString());
                }
            }
            TableChanged?.Invoke(iplist, EventArgs.Empty);
            try
            {
                this.DbProvider.WriteTable(iplist);
            }
            catch (Exception t)
            {
                throw t;
            }
        }

        public IpAddressTable()
        {
            InitializeComponent();
            btnAdd.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.BorderSize = 0;
            this.Datagridview.CellValueChanged += Datagridview_CellValueChanged;

        }

        public void Initial(string dbname)
        {
            this.DbProvider = new DataBaseProvider($"{dbname}");
            ClientIp[] _ipList;
            try
            {
                _ipList = this.DbProvider.GetTable();
                foreach(ClientIp i in _ipList)
                {
                    DataGridViewRow newrow = new DataGridViewRow();
                    DataGridViewTextBoxCell ipaddresscell = new DataGridViewTextBoxCell();
                    ipaddresscell.Value = i.IP;
                    DataGridViewCheckBoxCell statuscell = new DataGridViewCheckBoxCell();
                    statuscell.Value = false;
                    newrow.Cells.AddRange(new DataGridViewCell[] { ipaddresscell, statuscell });
                    this.Datagridview.Rows.Add(newrow);
                }
            }
            catch (Exception t)
            {
                throw t;
            }
        }

        private void Datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            OnTableChanged();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow newrow = new DataGridViewRow();
            DataGridViewTextBoxCell ipaddresscell = new DataGridViewTextBoxCell();
            ipaddresscell.Value = null;
            DataGridViewCheckBoxCell statuscell = new DataGridViewCheckBoxCell();
            statuscell.Value = false;
            newrow.Cells.AddRange(new DataGridViewCell[] { ipaddresscell, statuscell });
            this.Datagridview.Rows.Add(newrow);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.Datagridview.SelectedRows.Count <= 0) return;
            var selectedrow = this.Datagridview.SelectedRows[0];
            if (selectedrow == null) return;
            if(selectedrow.Cells[0].Value != null)
                if(MessageBox.Show($"Delete Client: {selectedrow.Cells[0].Value.ToString()}","Warning",MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            this.Datagridview.Rows.Remove(selectedrow);
            OnTableChanged();
        }
    }
}
