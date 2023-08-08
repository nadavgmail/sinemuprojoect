using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectProducts("select [מחירון דגים  חודש דצמבר],F2 as [תאור פריט],F5 as [מחיר טלה],F6 as [מעדי הטלה] from  [דגים$]", dataGridView1);
           // selectProducts("select * from  [דגים$]", dataGridView1);

        }
        private void selectProducts(string sql, DataGridView grid)
        {
            //string constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Documents and Settings\nadav\Desktop\מחירון, בשר דצמבר 2009.xls"";Extended Properties=""Excel 12.0;HDR=YES""";
            string constr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""\\gotecsrv\מסמכים\PUBLIC\פרוייקט מחירונים\מחירון, בשר דצמבר 2009.xls"";Extended Properties=""Excel 8.0;HDR=YES""";

            DataSet ds = new DataSet();
            //string sql = "select * from [בקר$]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, constr);
            adapter.Fill(ds, "bakar");
            grid.DataSource = ds.Tables["bakar"];
        }
    }
}
