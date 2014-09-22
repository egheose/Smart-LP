using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input; 

namespace SmartLabelWindowws
{
    public partial class Printersetting : Form
    {
        PrintRobot robot;
        public Printersetting()
        {
            robot = new PrintRobot();

            InitializeComponent();
        }

        private void Printersetting_Load(object sender, EventArgs e)
        {
            int chosenSize = robot.getChosenSize();


            if (chosenSize == 50)
            {
                radioGroup1.SelectedIndex = 1;
            }
            else
            {
                radioGroup1.SelectedIndex = 0;
            }


            int index = 0;
            string savedPrinter = robot.getSavedPrinter();

            InstalledPrintersCMB.DataSource = robot.getPrinters();

            //check if the guy saved any printer and make it selected
            if (savedPrinter != "")
            {

                foreach (string item in InstalledPrintersCMB.Items)
                {

                    if (item == savedPrinter)
                    {
                        InstalledPrintersCMB.SelectedIndex = index;
                        break;
                    }
                    index += 1;
                }

            }

            checkEdit1.Checked = robot.isAlwaysPrintFirstGRN;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            robot.savePrinterSetting(InstalledPrintersCMB.SelectedValue.ToString());
            robot.saveChosenSize(Convert.ToInt32(radioGroup1.EditValue));

            
                this.Close();

             

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            robot.isAlwaysPrintFirstGRN = ((DevExpress.XtraEditors.CheckEdit)sender).Checked;
        }
    }
}
