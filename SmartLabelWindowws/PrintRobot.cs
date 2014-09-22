using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace SmartLabelWindowws
{
    class PrintRobot
    {
        private Font printFont;
        private StreamReader streamToPrint;
        //rectfItemSmallY  rectfDescSmallY smallTextFont

        public Int32 rectfItemY
        {
            get
            {
                return getChosenSize() == 50 ? 72 : 150; //check the size that was chosen and decide what to return for the rectangle
            }
        }
        public Int32 rectfDescY
        {
            get
            {
                return getChosenSize() == 50 ? 82 : 170; //check the size that was chosen and decide what to return for the rectangle
            }
        }
        public Int32 TextFont
        {
            get
            {
                return getChosenSize() == 50 ? 8 : 13; //check the size that was chosen and decide what to return for the rectangle
            }
        }
        public Int32 Barcodescale
        {
            get
            {
                return getChosenSize() == 50 ? 1 : 2; //check the size that was chosen and decide what to return for the rectangle
            }
        }

        public bool isAlwaysPrintFirstGRN
        {
            get
            {
                return Properties.Settings.Default.isAlwaysPrintFirstGRN;
                 
            }
            set
            {
                Properties.Settings.Default.isAlwaysPrintFirstGRN = value;
            }
        }
        public List<string> getPrinters()
        {
            List<string> PrinterCollections = new List<string>();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                PrinterCollections.Add(printer);
            }
            return PrinterCollections;
        }
        public string DoPrint(short copies, string barcodeToPrint)
        {
            try
            {

                //byte[] imageBytes = Convert.FromBase64String(barcodeToPrint);
                //MemoryStream streamToPrint = new MemoryStream(imageBytes, 0, imageBytes.Length);

                //printFont = new Font("Arial", 10);
                //PrintDocument pd = new PrintDocument();
                //pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                //pd.PrinterSettings.Copies = copies;
                //pd.Print();
                PrintDocument recordDoc;
                // Create the document and name it
                recordDoc = new PrintDocument();
                recordDoc.DocumentName = "Customer Receipt";
                recordDoc.PrintPage += new PrintPageEventHandler(this.PrintReceiptPage);
                // Preview document
                //  dlgPreview.Document = recordDoc;
                //   dlgPreview.ShowDialog();
                // Dispose of document when done printing
                recordDoc.Dispose();

                return "..printing";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {
                // streamToPrint.Close();
            }



        }
        public Int32 getChosenSize()
        {
            int chosenSize = Properties.Settings.Default.size;

            return chosenSize == 0 ? 50 : chosenSize; //return default printer if none has been chosen by any user
        }

        public void saveChosenSize(int size)
        {
            Properties.Settings.Default.size = size;
            Properties.Settings.Default.Save();
        }

        private void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            string message = "print text";
            int y;
            // Print receipt
            Font myFont = new Font("Times New Roman", 15, FontStyle.Bold);
            y = e.MarginBounds.Y;
            e.Graphics.DrawString(message, myFont, Brushes.DarkRed, e.MarginBounds.X, y);
        }

        //private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        //{
        //    float linesPerPage = 0;
        //    float yPos = 0;
        //    int count = 0;
        //    float leftMargin = ev.MarginBounds.Left;
        //    float topMargin = ev.MarginBounds.Top;
        //    string line = null;

        //    // Calculate the number of lines per page.
        //    linesPerPage = ev.MarginBounds.Height /  printFont.GetHeight(ev.Graphics);

        //    // Print each line of the file. 
        //    while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
        //    {
        //        yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
        //        ev.Graphics.DrawString(line, printFont, Brushes.Black,leftMargin, yPos, new StringFormat());
        //        count++;
        //    }

        //    // If more lines exist, print another page. 
        //    if (line != null)
        //        ev.HasMorePages = true;
        //    else
        //        ev.HasMorePages = false;
        //}


        public string getDefaultPrinter() //systems default printer
        {
            PrinterSettings settings = new PrinterSettings();
            return (settings.PrinterName);

        }

        public void savePrinterSetting(string chosenPrinter)
        {
            Properties.Settings.Default.printer = chosenPrinter;
            Properties.Settings.Default.Save();
        }
        public string getSavedPrinter()
        {
            string chosenPrinter = Properties.Settings.Default.printer;

            return string.IsNullOrEmpty(chosenPrinter) ? getDefaultPrinter() : chosenPrinter; //return default printer if none has been chosen by any user
        }

    }

}
