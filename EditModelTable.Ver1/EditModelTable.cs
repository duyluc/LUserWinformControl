using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace EditModelTable.Ver1
{
    public partial class EditModelTable: UserControl
    {
        private PropertyInfo[] PropertyInfo { get; set; }
        private Type ModelType { get; set; }
        public EditModelTable()
        {
            InitializeComponent();
            this.Datagridview.Columns[0].Width = 80;
        }

        public void SetModel(Type _modelType)
        {
            this.ModelType = _modelType;
            this.PropertyInfo = _modelType.GetProperties();
            foreach (PropertyInfo p in this.PropertyInfo)
            {
                DataGridViewRow newrow = new DataGridViewRow();
                DataGridViewTextBoxCell namecell = new DataGridViewTextBoxCell();
                namecell.Value = p.Name;
                DataGridViewCell valuecell = null;
                if (p.PropertyType == typeof(bool))
                {
                    valuecell = new DataGridViewCheckBoxCell();
                    valuecell.Value = false;
                }
                else
                {
                    valuecell = new DataGridViewTextBoxCell();
                    valuecell.Value = null;
                }
                valuecell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newrow.Cells.Add(namecell);
                newrow.Cells.Add(valuecell);
                this.Datagridview.Rows.Add(newrow);
            }
        }

        public Dictionary<string,object> GetModelProperties()
        {
            Dictionary<string, object> propertiesValue = new Dictionary<string, object>();
            int i = 0;
            foreach(PropertyInfo p in PropertyInfo)
            {
                object propertyvalue = this.Datagridview.Rows[i].Cells[1].Value;
                if (propertyvalue == null) throw new ArgumentNullException();
                if(p.PropertyType != typeof(bool))
                {
                    string value = (string)(propertyvalue);
                    if(p.PropertyType == typeof(string))
                    {
                        propertyvalue = value;
                    }
                    if (p.PropertyType == typeof(int))
                    {
                        propertyvalue = int.Parse(value);
                    }
                    if (p.PropertyType == typeof(Int16))
                    {
                        propertyvalue = Int16.Parse(value);
                    }
                    if (p.PropertyType == typeof(Int64))
                    {
                        propertyvalue = Int64.Parse(value);
                    }
                    if (p.PropertyType == typeof(float))
                    {
                        propertyvalue = float.Parse(value);
                    }
                    if (p.PropertyType == typeof(double))
                    {
                        propertyvalue = double.Parse(value);
                    }
                }
                propertiesValue.Add(p.Name, propertyvalue);
                i++;
            }
            return propertiesValue;
        }
        private void Datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1) return;
            int rowindex = e.RowIndex;
            if (rowindex < 0) return;
            if (this.Datagridview.Rows[rowindex].Cells[1].Value == null) return;
            if (this.Datagridview.Rows[rowindex].Cells[1].FormattedValueType == typeof(bool)) return;
            string value = (string)this.Datagridview.Rows[rowindex].Cells[1].Value;
            Type celltype = this.PropertyInfo[rowindex].PropertyType;
            try
            {
                if (celltype == typeof(int))
                {
                    if (!int.TryParse(value, out int _t)) throw new Exception();
                }
                if (celltype == typeof(Int16))
                {
                    if (!Int16.TryParse(value, out Int16 _t)) throw new Exception();
                }
                if (celltype == typeof(Int64))
                {
                    if (!Int64.TryParse(value, out Int64 _t)) throw new Exception();
                }
                if (celltype == typeof(float))
                {
                    if (!float.TryParse(value, out float _t)) throw new Exception();
                }
                if (celltype == typeof(double))
                {
                    if (!double.TryParse(value, out double _t)) throw new Exception();
                }
            }
            catch
            {
                this.Datagridview.Rows[rowindex].Cells[1].Value = null;
                MessageBox.Show("Value is Invalid!");
            }
        }
    }
}
