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
using System.Drawing.Printing;
using System.IO;

namespace SmartLabelWindowws
{
    public partial class Form1 : Form
    {
        Code128BarcodeDraw bdf;
        Image barcode;
        PrintRobot PrinterRobot;
        String ItemcodeToAppend;
        String ItemDescriptionToAppend;

        public Form1()
        {
            InitializeComponent();
            bdf = BarcodeDrawFactory.Code128WithChecksum;
            PrinterRobot = new PrintRobot();
        }


        DataTable itemsongrn;

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
             

            string[] breakdown = e.Node.Text.Split(' ');

            int lenght = e.Node.Text.Length;
            string GRN_No_str = breakdown[1].ToString();

            int GRN_No = Convert.ToInt32(GRN_No_str); //gets the selected GRN no here

             itemsongrn = new RobotTableAdapters.Sp_GRN_GrnByPoNum_itemsTableAdapter().GetData(GRN_No);

            dataGridView1.DataSource = itemsongrn;

            //////////////////////////// PRINT HAPPENS HERE //////////////////////////////
            bool isPrinting;

            //if (textBox1.Text.Trim().Length == 0)
            //{
            //    lblstatus.Text = "PO number cannot be empty";
            //    return;
            //}
            lblstatus.Text = "..printing.";

            PrintDocument printDocument1 = null;

            foreach (DataRow row in itemsongrn.Rows)
            {
                ItemcodeToAppend = row["itemCode"].ToString();
                ItemDescriptionToAppend = row["Dscription"].ToString();
                string strcopies = row["Quantityon GRN"].ToString();
                // int intcopies = Convert.ToInt32(strcopies);
                short copies = Convert.ToInt16(strcopies);

                //forms the barcode
                barcode = bdf.Draw(ItemcodeToAppend, PrinterRobot.getChosenSize(), PrinterRobot.Barcodescale);

                //sets pictorbox1 to formed barcode
                pictureBox1.Image = barcode;

                printDocument1 = new PrintDocument();
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.PrinterSettings.PrinterName = PrinterRobot.getSavedPrinter();
                printDocument1.PrinterSettings.Copies = copies;

                printDocument1.Print();


            }
            printDocument1.Dispose(); lblstatus.Text = "";
             

            ///////////////////////////////////////////////////////////////////////////////rectfDesc


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            lblstatus.Text = "..printing";


            Bitmap b = new Bitmap(barcode);//retrieves the formed barcode
            RectangleF rectfItem = new RectangleF(12, PrinterRobot.rectfItemY, 0, 0);
            RectangleF rectfDesc = new RectangleF(12, PrinterRobot.rectfDescY, 0, 0);



            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.DrawString(ItemcodeToAppend, new Font("Thaoma", PrinterRobot.TextFont), Brushes.Black, rectfItem);
            e.Graphics.DrawString(ItemDescriptionToAppend, new Font("Thaoma", PrinterRobot.TextFont), Brushes.Black, rectfDesc);
            e.Graphics.Flush();

            barcode = b;
            
            e.Graphics.DrawImage(barcode, new Point(20, 20) );
            textBox1.Select();

        }
        //public string ImageToBase64(Image image)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        // Convert Image to byte[]
        //        image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        //        byte[] imageBytes = ms.ToArray();

        //        // Convert byte[] to Base64 String
        //        string base64String = Convert.ToBase64String(imageBytes);
        //        return base64String;
        //    }
        //}





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }

        private void choosePrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printersetting printerform = new Printersetting();
            printerform.Show(this);
        }




        private void MakeTreeView()
        {
            //reset the node
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes.Clear();
            }


            try
            {
                DataTable GRN = new RobotTableAdapters.Sp_GRN_GrnByPoNumTableAdapter().GetData(Convert.ToInt32(textBox1.Text));

                foreach (DataRow row in GRN.Rows)
                {

                    treeView1.Nodes.Add("GRN: " + row["GRN_No"].ToString() + " " + String.Format("{0:ddd, MMM d, yyyy}", Convert.ToDateTime(row["Docdate"].ToString())));
                }

                if (GRN.Rows.Count ==0)
                {
                    lblstatus.Text = "No GRN found for inputed PO number";
                }
            }
            catch (Exception exp)
            {
                lblstatus.Text = exp.Message;

            }
             
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblstatus.Text = "";
                MakeTreeView();
                this.textBox1.Text = "";

                if (PrinterRobot.isAlwaysPrintFirstGRN) //if the setting was chosen why not print atomatically
                {
                    treeView1_NodeMouseClick(e, new TreeNodeMouseClickEventArgs(treeView1.Nodes[0], MouseButtons.Right, 1, 1, 1));
                    
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

    

    }
}
