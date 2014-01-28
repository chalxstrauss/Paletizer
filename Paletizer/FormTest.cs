using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Paletizer
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string barcodeSSC = BarCode.BarcodeConverter128.StringToBarcode("00086050069001910526") + MainForm.FNC1 + BarCode.BarcodeConverter128.StringToBarcode("11060721") + MainForm.FNC1 + BarCode.BarcodeConverter128.StringToBarcode("10987364");

            daReport.DaPrintDocument daPrintDocument = new daReport.DaPrintDocument();
            Hashtable parameters = new Hashtable(); 
            //parameters.Add("parameter21", barcodeSSC);
            //parameters.Add("parameter21", MainForm.FNC1 + BarCode.BarcodeConverter128.StringToBarcode("00086050069001914887"));
            parameters.Add("parameter21", BarCode.BarcodeConverter128.StringToBarcode("310203360010201204251349"));
            /*
            AeromiumBarcodes abarcode = new AeromiumBarcodes();
            abarcode.BarcodeSymbology = AeromiumBarcodes.BarcodeEnum.UCCEAN;
            //abarcode.InputText = "(00)086050069001918492";
            abarcode.InputText = "(3102)033600(10)201204251349";
            abarcode.generate();
            string outputstr = abarcode.EncodedOuput;
            */
            //Font fontz = new Font("FontCode128H3_TR", 26);
            //textbox.Text = outputstr;
            //textbox.Font = fontz;

            //parameters.Add("parameter22", outputstr /*BarCode.BarcodeConverter128.StringToBarcode("00086050069001914887")*/);
            
            daPrintDocument.setXML("PaletaLabelItm.xml");

            /*
            // set .xml file for printing
            if (kolicina_na_paleti.Length <= 7)
            {
                daPrintDocument.setXML("PaletaLabel.xml");
            }
            else
            {
                daPrintDocument.setXML("PaletaLabelS.xml");
            }*/

            daPrintDocument.SetParameters(parameters);

            // print preview
            /*
            printPreviewDialog1.Document = daPrintDocument;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog(this);
            */

            daPrintDocument.PrinterSettings.Copies = 1;
            daPrintDocument.Print();
        }
    }
}
