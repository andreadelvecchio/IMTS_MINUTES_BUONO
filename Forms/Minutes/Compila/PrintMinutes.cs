

using AxAcroPDFLib;
using IMTS_MINUTES.BusinessLogic;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.Windows.Documents;
using System.Windows.Forms;
 
using Paragraph = iTextSharp.text.Paragraph;

namespace IMTS_MINUTES.Forms.Minutes.Compila
{
    public partial class PrintMinutes : Form
    {
        public PrintMinutes( )
        {
            InitializeComponent();
            
        }


        private void PrintMinutes_Load(object sender, EventArgs e)
        {

            //pictureBox1.Load(Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\template\\stampe\\test1.jpg");
            BusinessLogic.BLMinutes.BLWriteMiutes blw = new BusinessLogic.BLMinutes.BLWriteMiutes();

            IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteRow row = blw.getMinuteRow();
            BLStampe bls = new BLStampe();
            bls.stampaPDFFA();
            //AxAcroPDFLib.AxAcroPDF pdf = new AxAcroPDFLib.AxAcroPDF();
            //pdf.Dock = System.Windows.Forms.DockStyle.Fill;
            //pdf.Enabled = true;
            //pdf.Location = new System.Drawing.Point(0, 0);
            //pdf.Name = "pdfReader";
            //pdf.OcxState = ((System.Windows.Forms.AxHost.State)(new System.ComponentModel.ComponentResourceManager(typeof(PrintMinutes)).GetObject("pdfReader.OcxState")));
            //pdf.TabIndex = 1;


            ////axAcroPDF.LoadFile(@"C\Users\SurfacePro\source\repos\IMTS_MINUTES\Template\stampe\VerbaleChiusura.pdf");
            // axAcroPDF1.src = @"C:\Users\SurfacePro\source\repos\IMTS_MINUTES\Template\stampe\VerbaleChiusura.pdf";
            //// Add pdf viewer to current form        
            //axAcroPDF1.Show();
            //pdf.LoadFile(Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\template\\stampe\\VerbaleChiusura.pdf");
            //pdf.setView("Fit");
            //pdf.Visible = true;
            string pdffile = @"C:\Users\SurfacePro\source\repos\IMTS_MINUTES\Template\stampe\VerbaleChiusura.pdf";
            webBrowser1.Navigate(pdffile);

            webBrowser1.Show();
            Process.Start("MicrosoftEdge.exe", pdffile);




        }
        private void Print(string printerName, string fileName)
        {
          
        }

        private void BNPrint_Click(object sender, EventArgs e)
        {
            PictureBox pb1 = new PictureBox();
            pb1.ImageLocation = Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\template\\stampe\\test1.jpg";
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;


        }
    }
}
