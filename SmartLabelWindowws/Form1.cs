using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;
namespace SmartLabelWindowws
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Code128BarcodeDraw bdf = BarcodeDrawFactory.Code128WithChecksum;

            pictureBox1.Image = bdf.Draw(textBox1.Text, 20);

            DataTable GRN= new RobotTableAdapters.Sp_GRN_GrnByPoNumTableAdapter().GetData(Convert.ToInt32(textBox1.Text));

            foreach (DataRow row in GRN.Rows)
            {
                treeView1.Nodes.Add("GRN: " + row["GRN_No"].ToString());               
            }
        }

        

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            int lenght = e.Node.Text.Length;
            string GRN_No_str = e.Node.Text.Substring(5, lenght - 5);
            
            int GRN_No= Convert.ToInt32(GRN_No_str);

            DataTable itemsongrn= new RobotTableAdapters.Sp_GRN_GrnByPoNum_itemsTableAdapter().GetData(GRN_No);

            dataGridView1.DataSource = itemsongrn;
            
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }
    }
}
