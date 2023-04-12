using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraGrid_GroupByBox_HideBandLabel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ultraGrid1.DataSource = GetData();

            ultraGrid1.DisplayLayout.Bands[1].SortedColumns.Add("Message", false, true);

            ultraGrid1.DisplayLayout.GroupByBox.ShowBandLabels = ShowBandLabels.None;

            ultraGrid1.Rows.ExpandAll(true);
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(GetPrimary());
            ds.Tables.Add(GetChild());

            ds.Relations.Add(
                ds.Tables["Primary"].Columns["ID"],
                ds.Tables["Child"].Columns["ParentID"]);

            return ds;
        }

        public DataTable GetPrimary()
        {
            DataTable table = new DataTable("Primary");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Message", typeof(string));
            for (int i = 0; i < 5; i++)
            {
                table.Rows.Add(i, "Hello " + i);
            }
            table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };
            return table;
        }

        public DataTable GetChild()
        {
            DataTable table = new DataTable("Child");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("ParentID", typeof(int));
            table.Columns.Add("Message", typeof(string));
            for (int i = 0; i < 6; i++)
            {
                table.Rows.Add(i, i % 3, "Hello " + i % 3);
            }
            table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };
            return table;
        }
    }
}
