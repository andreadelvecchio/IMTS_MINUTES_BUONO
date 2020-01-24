 
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace IMTS_MINUTES.BusinessLogic
{
    class BLStampe
    {


        Int32 qtyT = 0;
        decimal weightT, valueT = 0;

       public class PageHeaderFooter : PdfPageEventHelper
{
    private readonly iTextSharp.text.Font _pageNumberFont = FontFactory.GetFont("Colibri", 8, Font.BOLD, BaseColor.BLACK);

            public override void OnEndPage(PdfWriter writer, Document document)
    {
        AddPageNumber(writer, document);
    }

    private void AddPageNumber(PdfWriter writer, Document document)
    {
        var text = writer.PageNumber.ToString();

        var numberTable = new PdfPTable(1);
                var numberCell = new Phrase(text, _pageNumberFont);

        numberTable.AddCell(numberCell);
        numberTable.TotalWidth = 50;
        numberTable.WriteSelectedRows(0, -1, document.Right - 80, document.Bottom + 20, writer.DirectContent);
    }
}

        public void CaclcolaTotali(IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable dt)
        {

            CultureInfo cultures = new CultureInfo("it-IT");
            float num = float.Parse("1,5", cultures.NumberFormat);
            foreach (IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerRow row in dt)
            {
                qtyT += Convert.ToInt32(row.Quantità_Materiale, cultures.NumberFormat);
                if (row.Peso_Pericoloso != "")
                    weightT += Convert.ToDecimal(row.Peso_Materiale, cultures.NumberFormat) + Convert.ToDecimal(row.Peso_Pericoloso, cultures.NumberFormat);
                else if (row.Peso_Materiale != "")
                    weightT += Convert.ToDecimal(row.Peso_Materiale, cultures.NumberFormat);
                if (row.Valore_Materiale != "")
                    valueT += Convert.ToDecimal(row.Valore_Materiale, cultures.NumberFormat);

            }
          
        }

        internal void stampaPDFFA()

        {

            try
            {
            

                using (System.IO.MemoryStream ms = new MemoryStream())
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
            IMTS_MINUTES.BusinessLogic.BLMinutes.BLWriteMiutes blw = new IMTS_MINUTES.BusinessLogic.BLMinutes.BLWriteMiutes();

                    IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteRow row = blw.getMinuteRow();


                    PdfWriter pdfw= PdfWriter.GetInstance(doc, new FileStream(Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\template\\stampe\\VerbaleChiusura.pdf", FileMode.Create));
                    pdfw.PageEvent = new PageHeaderFooter();
                    // step 3
                    doc.Open();

                    var Titolo = FontFactory.GetFont("Colibri", 16, Font.BOLD, BaseColor.BLACK);
                    var sottoTitolo = FontFactory.GetFont("Colibri", 14, Font.NORMAL, BaseColor.BLACK);
                    var testo = FontFactory.GetFont("Colibri", 8, Font.NORMAL, BaseColor.BLACK);
                    var TestoB = FontFactory.GetFont("Colibri", 8, Font.BOLD, BaseColor.BLACK);
                    var TitoloVerbale = FontFactory.GetFont("Colibri", 10, Font.BOLD, BaseColor.BLACK);
                    var noto = FontFactory.GetFont("Colibri", 12, Font.BOLD, BaseColor.BLACK);
                    var testoScheda = FontFactory.GetFont("Colibri", 10, Font.NORMAL, BaseColor.BLACK);
                    var testoSchedaBoxato = FontFactory.GetFont("Colibri", 12, Font.UNDERLINE, BaseColor.BLACK);
                    var intestazioneScheda = FontFactory.GetFont("Colibri", 12, Font.BOLD, BaseColor.BLACK);
                    var vuoto = FontFactory.GetFont("Colibri", 12, Font.NORMAL, BaseColor.BLACK);
                    // Stream inputImageStream = new MemoryStream(System.IO.File.ReadAllBytes( Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\Images\\logoCOI.jpg"));
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\Images\\logoCOI.jpg");

                    Paragraph paragraph = new Paragraph();
                    gif.Alignment = iTextSharp.text.Image.ALIGN_TOP;
                    gif.Alignment = Image.ALIGN_CENTER;
                    doc.Add(gif);
                    Chunk tit = new Chunk("COMANDO OPERATIVO di VERTICE INTERFORZE  \n", Titolo);
                    paragraph = new Paragraph();
                    doc.Add(paragraph);
                    paragraph = new Paragraph();
                    doc.Add(paragraph);
                    paragraph = new Paragraph();
                    Chunk Stit = new Chunk("VIA CENTOCELLE  NR 301   \n", sottoTitolo);
                    Chunk SStit = new Chunk("00175- ROMA  \n", sottoTitolo);
                    Phrase phrase = new Phrase();
                    phrase.Add(tit);
                    phrase.Add(Stit);
                    phrase.Add(SStit);
                   
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    doc.Add(paragraph);

                     paragraph = new Paragraph();
                    doc.Add(paragraph);
                    paragraph = new Paragraph();
                    doc.Add(paragraph);
                    paragraph = new Paragraph();
                    doc.Add(paragraph);

                    Chunk copia = new Chunk("Copia nr." + row.NCopie.ToString() + " / " + row.Data_Acquisizione_Verbale.ToShortDateString(), testo);
                    Chunk verbalenr = new Chunk("Verbale nr." + row.Verbale_Number.ToString(), testo);
                    Phrase lphrase = new Phrase();
                    Phrase rphrase = new Phrase();
                    Paragraph lparagraph = new Paragraph();
                    Paragraph rparagraph = new Paragraph();
                    lphrase.Add(copia);
                    lparagraph.Add(lphrase);
                    lparagraph.Alignment = Element.ALIGN_LEFT;
                    doc.Add(lparagraph);


                    rphrase.Add(verbalenr);
                    rparagraph.Add(rphrase);
                    rparagraph.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(rparagraph);

                    paragraph = new Paragraph("\n");
                    doc.Add(paragraph);
                    paragraph = new Paragraph();
                    doc.Add(paragraph);

                    Chunk titVerb = new Chunk("VERBALE CHIUSURA COLLI  \n", TitoloVerbale);
                    phrase = new Phrase();
                    phrase.Add(titVerb);
                    paragraph = new Paragraph();
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    doc.Add(paragraph);

                    Chunk TESTOb = new Chunk("In data " + row.Data_Provvedimento.ToShortDateString() + " presso " + row.Presso_Luogo + " situato presso la caserma "  + row.Presso_Caserma, TestoB);
                    phrase = new Phrase();
                   
                    paragraph = new Paragraph();
                    phrase.Add(TESTOb);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    doc.Add(paragraph);

                    Chunk noto1 = new Chunk(" \n SIA NOTO ", noto);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(noto1);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    doc.Add(paragraph);



                    Chunk testoNoto = new Chunk(" \n Che la sottotitolata commissione con supplemento all’ordine nr." + row.Ordine_Giorno_NR + " in data " + row.Data_Provvedimento.ToShortDateString() + " ha provveduto alla chiusura del " + row.Container_Descrizione + " con sigillo nr." + row._Matricola_targa + " destinato al " + row.Destinazione + " contenente materiale di proprietà dell’A.D. non destinato alla vendita o ad altri scopi di carattere commerciale, destinato al supporto de contingenti nazionali ovvero di rientro dalle Aree d’operazione.\n\n\n", testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(testoNoto);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;

                    doc.Add(paragraph);
                    Chunk skCaricamento = new Chunk("SHEDA CARICAMENTO PER                        \n\n", testoSchedaBoxato);
                    phrase = new Phrase();

                    paragraph = new Paragraph();

                    phrase.Add(skCaricamento);

                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_LEFT;
                    doc.Add(paragraph);


                    PdfPTable table = new PdfPTable(2);

                    //table.WidthPercentage = 95;
                    PdfPCell cell1 = new PdfPCell(new Paragraph(new Phrase(new Chunk("(Tipo materiale)", TestoB))));
                    PdfPCell cell2 = new PdfPCell(new Paragraph(new Phrase(new Chunk("(Targa / matricola o numenro collo)", TestoB))));

                    PdfPCell cell3 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Container_Descrizione, testoScheda))));
                    PdfPCell cell4 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row._Matricola_targa, testoScheda))));
                    table.AddCell(cell1);
                    table.AddCell(cell2);
                    table.AddCell(cell3);
                    table.AddCell(cell4);
                    paragraph = new Paragraph();

                    

                    paragraph.Add(table);

                    paragraph.Alignment = Element.ALIGN_CENTER;
                    doc.Add(table);

                    Chunk spazio = new Chunk("\n\n\n", testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();

                    phrase.Add(spazio);

                    paragraph.Add(phrase);

                    PdfPTable table1 = new PdfPTable(2);
                    table1.SetWidths(new int[] { 500, 500 });
                    //table.WidthPercentage = 95;



                    PdfPCell cell5 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Reparto Mittente (From)", TestoB))));
                    PdfPCell cell6 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Mittente, testo))));

                    PdfPCell cell7 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Reparto Destinatario(To)", TestoB))));
                    PdfPCell cell8 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Destinazione, testo))));

                    PdfPCell cell9 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Luogo Destinazione (to)", TestoB))));
                    PdfPCell cell10 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Destinazione_Container, testo))));

                    PdfPCell cell11 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Termiale di stoccaggio (Container terminal)", TestoB))));
                    PdfPCell cell12 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Terminale_Stoccaggio, testo))));


                    PdfPCell cell13 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Vettore (Mode of transport)", TestoB))));
                    PdfPCell cell14 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Vettore_Trasporto, testo))));

                    PdfPCell cell15 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Matricola sigillo (eventuale)", TestoB))));
                    PdfPCell cell16 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Operazione_Container, testo))));

                    table1.AddCell(cell5);
                    table1.AddCell(cell6);
                    table1.AddCell(cell7);
                    table1.AddCell(cell8);
                    table1.AddCell(cell9);
                    table1.AddCell(cell10);
                    table1.AddCell(cell11);
                    table1.AddCell(cell12);
                    table1.AddCell(cell13);
                    table1.AddCell(cell14);
                    table1.AddCell(cell15);
                    table1.AddCell(cell16);
                    table1.SpacingBefore = 20f;
                    doc.Add(table1);

                    PdfPTable table2 = new PdfPTable(2);
                    table2.SetWidths(new int[] { 500, 500 });
                    PdfPCell cell52 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Numero telaio (Chassis Number)", TestoB))));
                    PdfPCell cell62 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Telaio, testo))));
                    PdfPCell cell72 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Matricola motore (Engine number)", TestoB))));
                    PdfPCell cell82 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.SNMotore, testo))));

                    PdfPCell cell92 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Anno di costruzione (Year of construction)", TestoB))));
                    PdfPCell cell102 = new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Anno_Costruzione, testo))));

                    PdfPCell cell112 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Tipo di carburante(Type fuel)", TestoB))));
                    PdfPCell cell122= new PdfPCell(new Paragraph(new Phrase(new Chunk(row.Tipo_Carburante, testo))));

                    table2.AddCell(cell52);
                    table2.AddCell(cell62);
                    table2.AddCell(cell72);
                    table2.AddCell(cell82);
                    table2.AddCell(cell92);
                    table2.AddCell(cell102);
                    table2.AddCell(cell112);
                    table2.AddCell(cell122);

                    table2.SpacingBefore = 20f;
                    doc.Add(table2);
                    IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable matcont = blw.GetMateriale_Container();
                    CaclcolaTotali(matcont);

                    PdfPTable table3 = new PdfPTable(2);
                    table3.SetWidths(new int[] { 500, 500 });
                    CultureInfo cultures = new CultureInfo("it-IT");
                    PdfPCell cell53 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Peso totale (Total Weight)", TestoB))));
                    PdfPCell cell63 = new PdfPCell(new Paragraph(new Phrase(new Chunk(Convert.ToString(row.Tara, cultures.NumberFormat), testo))));
                    PdfPCell cell73 = new PdfPCell(new Paragraph(new Phrase(new Chunk("Valore(Value)", TestoB))));
                    PdfPCell cell83 = new PdfPCell(new Paragraph(new Phrase(new Chunk(Convert.ToString(row.Valore, cultures.NumberFormat), testo))));
                    table3.AddCell(cell53);
                    table3.AddCell(cell63);
                    table3.AddCell(cell73);
                    table3.AddCell(cell83);

                    table3.SpacingBefore = 20f;
                    doc.Add(table3);
                     
                    //costruisco tabellla materiale
                    PdfPTable table4 = new PdfPTable(7);
                    table4.SetWidths(new int[] {50,300,100,250,300,250,250 });
                  
                    PdfPCell cell54 = new PdfPCell(new Paragraph(new Phrase(new Chunk("NR.", TestoB))));
                    PdfPCell cell65 = new PdfPCell(new Paragraph(new Phrase(new Chunk("DENOMINAZIONE\nDESCRIPTION", TestoB))));
                    PdfPCell cell76 = new PdfPCell(new Paragraph(new Phrase(new Chunk("QTY'\n (QTY)", TestoB))));
                    PdfPCell cell87 = new PdfPCell(new Paragraph(new Phrase(new Chunk("PESO'\nWEIGHT", TestoB))));
                    PdfPCell cell88 = new PdfPCell(new Paragraph(new Phrase(new Chunk("VALORE COMMERCIALE\n (AMOUNT OF GOODS)", TestoB))));
                    PdfPCell cell89 = new PdfPCell(new Paragraph(new Phrase(new Chunk("MATRICOLA", TestoB))));
                    PdfPCell cell810 = new PdfPCell(new Paragraph(new Phrase(new Chunk("DANGEROUS", TestoB))));

                    table4.AddCell(cell54);
                    table4.AddCell(cell65);
                    table4.AddCell(cell76);
                    table4.AddCell(cell87);
                    table4.AddCell(cell88);
                    table4.AddCell(cell89);
                    table4.AddCell(cell810);

                   
                    int i = 1;
                    foreach (DataRow dr in matcont.Rows)
                    {

                        PdfPCell cell111  = new PdfPCell(new Paragraph(new Phrase(new Chunk(i.ToString(), testo))));
                        PdfPCell cell114 =new PdfPCell(new Paragraph(new Phrase(new Chunk(dr.ItemArray[2].ToString(), testo))));
                        PdfPCell cell113 = new PdfPCell(new Paragraph(new Phrase(new Chunk(dr.ItemArray[1].ToString(), testo))));
                        PdfPCell cell115 = new PdfPCell(new Paragraph(new Phrase(new Chunk(dr.ItemArray[6].ToString(), testo))));
                        PdfPCell cell116 = new PdfPCell(new Paragraph(new Phrase(new Chunk(dr.ItemArray[7].ToString(), testo))));
                        PdfPCell cell117 = new PdfPCell(new Paragraph(new Phrase(new Chunk(dr.ItemArray[8].ToString(), testo))));
                        PdfPCell cell119 = new PdfPCell(new Paragraph(new Phrase(new Chunk(dr.ItemArray[9].ToString(), testo))));

                        table4.AddCell(cell111);
                        table4.AddCell(cell114);
                        table4.AddCell(cell113);
                        table4.AddCell(cell115);
                        table4.AddCell(cell116);
                        table4.AddCell(cell117);
                        table4.AddCell(cell119);
                        i++;
                    }

                    table4.SpacingBefore = 20f;
                    doc.Add(table4);



                    PdfPTable table6 = new PdfPTable(5);
                    table6.SetWidths(new int[] {   100, 250, 300, 250, 250 });

                    PdfPCell cell545 = new PdfPCell(new Paragraph(new Phrase(new Chunk("", TestoB))));
                    PdfPCell cell655 = new PdfPCell(new Paragraph(new Phrase(new Chunk("TTOTAL", TestoB))));
                    PdfPCell cell765 = new PdfPCell(new Paragraph(new Phrase(new Chunk("QTY: "+Convert.ToString(qtyT, cultures.NumberFormat), testo))));
                    PdfPCell cell875 = new PdfPCell(new Paragraph(new Phrase(new Chunk("WEIGHT: "+Convert.ToString(weightT, cultures.NumberFormat), testo))));
                    PdfPCell cell885 = new PdfPCell(new Paragraph(new Phrase(new Chunk("VALUE: " + Convert.ToString(valueT, cultures.NumberFormat), testo))));


                    table6.AddCell(cell545);
                    table6.AddCell(cell655);
                    table6.AddCell(cell765);
                    table6.AddCell(cell875);
                    table6.AddCell(cell885);
                    table6.SpacingBefore = 10f;
                    doc.Add(table6);

                    Chunk testoRespo = new Chunk(" \nIn merito, il responsabil del caricamento:" + row.Responsabile_Chiusura,testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(testoRespo);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;

                    doc.Add(paragraph);
                    Chunk testdich = new Chunk("\n\n  DICHIARA",TestoB);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(testdich);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;

                    doc.Add(paragraph);

                    Chunk testdichiarazione = new Chunk("\nChe NON è stato caricato materiale diverso da quanto sopra elencato, 'sostanze stupefacenti o materiale illegale'. Si precisa, inoltre, che il presente verbale viene redatto in nr. "+row.NCopie+" di cui nr.1 (una) affissa all'interno e all'esterno del "+row.Container_Descrizione+".", testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(testdichiarazione);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_LEFT;

                    doc.Add(paragraph);




                    Chunk firmaRespo = new Chunk("\n"+ row.Responsabile_Chiusura + ", li "+row.Data_Chiusura.ToShortDateString()+"                                                                                                                           IL RESPONSABILE DEL CARICAMENTO", testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(firmaRespo);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_LEFT;

                    doc.Add(paragraph);

                    Chunk firmaRespo1 = new Chunk(  row.Responsabile_Chiusura, testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(firmaRespo1);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_RIGHT;

                    doc.Add(paragraph);

                    Chunk commissione = new Chunk("LA COMMISSIONE", testoSchedaBoxato);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(commissione);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;

                    doc.Add(paragraph);

                    Chunk firmacommissione = new Chunk("IL PRESIDENTE", testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(firmacommissione);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;

                    doc.Add(paragraph);


                    Chunk presidente = new Chunk( row.Presidente_Commissione, testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(presidente);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_CENTER;

                    doc.Add(paragraph);

                    Chunk membro = new Chunk("\nMEMBRO", testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(membro);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_LEFT;

                    doc.Add(paragraph);
                    Chunk firmamembro = new Chunk(row.Membro_Commissione, testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(firmamembro);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_LEFT;

                    doc.Add(paragraph);

                    Chunk memboroesegrrew = new Chunk("\nMEMBRO E SEGRETARIO", testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(memboroesegrrew);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_RIGHT;

                    doc.Add(paragraph);
                    Chunk memboroesegrrewfirma= new Chunk(  row.Membro_Commissione+" - "+row.Segretario_Commissione, testo);
                    phrase = new Phrase();

                    paragraph = new Paragraph();
                    phrase.Add(memboroesegrrewfirma);
                    paragraph.Add(phrase);
                    paragraph.Alignment = Element.ALIGN_RIGHT;

                    doc.Add(paragraph);


                    doc.Close();

                }




            }
            catch (Exception ex)
            {



            }


        }
        //private PdfPTable _stateTableFA(DateTime da, DateTime a, ref Double totale)
        //    {
        //        try
        //        {
        //    NumberFormatInfo provider = new NumberFormatInfo();

        //    provider.NumberDecimalSeparator = ",";
        //    string[] col = { "Cognome", "Ragione sociale", "Data Compilazione", "Data emissione", "PIVA", "Importo fattura", "Stato Fattura", "Stato Pagamento", "Data pagamento" };
        //    PdfPTable table = new PdfPTable(9);
        //    /*
        //    * default table width => 80%
        //    */
        //    table.WidthPercentage = 100;
        //    // then set the column's __relative__ widths
        //    table.SetWidths(new Single[] { 3, 4, 4, 4, 4, 3, 3, 3, 3 });
        //    /*
        //    * by default tables 'collapse' on surrounding elements,
        //    * so you need to explicitly add spacing
        //    */
        //    table.SpacingBefore = 10;
        //    BaseFont bfTimes = BaseFont.CreateFont();
        //    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.RED);
        //    for (int i = 0; i < col.Length; ++i)
        //    {
        //        PdfPCell cell = new PdfPCell(new Phrase(col[i], times));
        //        cell.BackgroundColor = new BaseColor(204, 204, 204);

        //        table.AddCell(cell);
        //    }


        //    //Int64 idFatture = Convert.ToInt64(Session.Contents["ID_FATTURA"]);


        //    foreach (var fattura in listaFatture)
        //    {
        //        PdfPCell cell = new PdfPCell(new Phrase(fattura.COGNOME_CLIENTE, times1));
        //        table.AddCell(cell);
        //        PdfPCell cell0 = new PdfPCell(new Phrase(fattura.RAGIONE_SOCIALE_CLIENTE, times1));
        //        table.AddCell(cell0);
        //        PdfPCell cell1 = new PdfPCell(new Phrase(Convert.ToDateTime(fattura.DATA_EMISSIONE).ToShortDateString(), times1));
        //        table.AddCell(cell1);
        //        PdfPCell cell2 = new PdfPCell(new Phrase(Convert.ToDateTime(fattura.DATA_COMPILAZIONE).ToShortDateString(), times1));
        //        table.AddCell(cell2);
        //        PdfPCell cell3 = new PdfPCell(new Phrase(fattura.PIVA_CLIENTE, times1));
        //        table.AddCell(cell3);
        //        PdfPCell cell4 = new PdfPCell(new Phrase(fattura.TOTALE_FATTURA, times1));
        //        Double totp = 0;
        //        //try
        //        //{
        //        totp = Convert.ToDouble(fattura.TOTALE_FATTURA, provider);
        //        // }
        //        // catch { }
        //        totale += Convert.ToDouble(fattura.TOTALE_FATTURA, provider);
        //        table.AddCell(cell4);

        //        string statoFattura = "";
        //        if (fattura.STATO_FATTURA == "E")
        //            statoFattura = "Emessa";
        //        else
        //            statoFattura = "Salvata";

        //        PdfPCell cell5 = new PdfPCell(new Phrase(statoFattura, times1));
        //        table.AddCell(cell5);
        //        PdfPCell cell7 = new PdfPCell(new Phrase(fattura.STATO_PAGAMENTO, times1));
        //        table.AddCell(cell7);
        //        string dataPagamento = "";
        //        if (fattura.DATA_PAGAMENTO != DateTime.MinValue)
        //            dataPagamento = Convert.ToDateTime(fattura.DATA_PAGAMENTO).ToShortDateString();

        //        PdfPCell cell6 = new PdfPCell(new Phrase(dataPagamento, times1));
        //        table.AddCell(cell6);

        //    }

        //    return table;

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}

        // }
    }
        }
