 
using IMTS_MINUTES.BusinessLogic;
using IMTS_MINUTES.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
 

namespace IMTS_MINUTES.BusinessLogic.BLMinutes
{
    class BLWriteMiutes
    {
       internal IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable GetMateriale_Container()
        {
            
            IMTSDB_NEW dataSet = new IMTSDB_NEW();
            dataSet.ReadXml(Utils.getBasePathName + "Materiale_Container.xml", System.Data.XmlReadMode.IgnoreSchema);
            return dataSet.Materiale_Container;
        }


        internal bool InsertMaterialeWithTransaction(int qty,  string matricola, string descrizione, string valore, string lunghezza, string altezza, string profondita, string peso, bool pericoloso, string pesoDG, string unCode, string classeRischio, string compatibilita)
        {

       IMTSDB_NEW ds1 = new  IMTSDB_NEW();

            NumberFormatInfo provider = new NumberFormatInfo();

            provider.NumberDecimalSeparator = ",";


            //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;
            IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable materiale_ContainersDT;
            try
            {
                BLAnagrafica bla = new BLAnagrafica();
               // DataView nazioni = bla.getNazionalita();
                ds1.ReadXml(Utils.getBasePathName + "Materiale_Container.xml", XmlReadMode.IgnoreSchema);
                string[] involvedTable = { "Materiale_Container" };
                if (!BLTransactionManager.ClearTransaction(ds1, involvedTable))
                    return false;
                materiale_ContainersDT = ds1.Materiale_Container;

                IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerRow matcontRow = materiale_ContainersDT.NewMateriale_ContainerRow();
                matcontRow.Altezza_Materiale = altezza;
                matcontRow.Classe_Rischio = classeRischio;
                matcontRow.Compatibilita = compatibilita;
                matcontRow.Dangerous = pericoloso;
                matcontRow.Descrizione_Materiale = descrizione;
                matcontRow.Lunghezza_Materiale = lunghezza;
                matcontRow.Matricola = matricola;
                matcontRow.Peso_Materiale = peso;
                matcontRow.Peso_Pericoloso = pesoDG;
                matcontRow.Profondita_Materiale = profondita;
                matcontRow.Valore_Materiale = valore;
                matcontRow.UN_Code = null;
                matcontRow.Quantità_Materiale =qty.ToString();
              
                materiale_ContainersDT.AddMateriale_ContainerRow(matcontRow);
                if (BLTransactionManager.ExecuteTransaction(ds1, involvedTable))

                    return true;
                else
                    return false;

            }

            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    return false;
                else
                    throw ex;
            }







        }
        internal bool commitNewROw(IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable dt)
        {

            
            IMTSDB_NEW ds1 = new IMTSDB_NEW();

            NumberFormatInfo provider = new NumberFormatInfo();

            provider.NumberDecimalSeparator = ",";


            //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;
           
            try
            {
                dt.WriteXml(Utils.getBasePathName + "Materiale_Container.xml", XmlWriteMode.WriteSchema);
                return true;
            }


             

            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    return false;
                else
                    throw ex;
            }
}


        internal bool updateMaterialeWithTransaction(Int32 idMatContainer,int qty, string matricola, string descrizione, string valore, string lunghezza, string altezza, string profondita, string peso, bool pericoloso, string pesoDG, string unCode, string classeRischio, string compatibilita)
        {


          

           IMTSDB_NEW ds1 = new IMTSDB_NEW();

            NumberFormatInfo provider = new NumberFormatInfo();

            provider.NumberDecimalSeparator = ",";


            //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;
            IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable materiale_ContainersDT;
            try
            {

              
                ds1.ReadXml(Utils.getBasePathName + "Materiale_Container.xml", XmlReadMode.IgnoreSchema);
                string[] involvedTable = { "Materiale_Container" };
                if (!BLTransactionManager.ClearTransaction(ds1, involvedTable))
                    return false;
                materiale_ContainersDT = ds1.Materiale_Container;

                IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerRow matcontRow = (IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerRow) materiale_ContainersDT.Select("Id_Materiale=" + idMatContainer).FirstOrDefault();
                matcontRow.Altezza_Materiale = altezza;
                matcontRow.Classe_Rischio = classeRischio;
                matcontRow.Compatibilita = compatibilita;
                matcontRow.Dangerous = pericoloso;
                matcontRow.Descrizione_Materiale = descrizione;
                matcontRow.Lunghezza_Materiale = lunghezza;
                matcontRow.Matricola = matricola;
                matcontRow.Peso_Materiale = peso;
                matcontRow.Peso_Pericoloso = pesoDG;
                matcontRow.Profondita_Materiale = profondita;
                matcontRow.Quantità_Materiale = qty.ToString();
                 matcontRow.Id_Materiale = idMatContainer;
                matcontRow.Valore_Materiale = valore;
                matcontRow.UN_Code = unCode;
                matcontRow.Dangerous = pericoloso;

                materiale_ContainersDT.AcceptChanges();
                if (BLTransactionManager.ExecuteTransaction(ds1, involvedTable))

                    return true;
                else
                    return false;

            }


            

            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    return false;
                else
                    throw ex;
            }



}

        internal bool InsertMinuteWithTransaction(int qtyCopie, string verbaeNR, Int32 descrizioneComtainer, string MatricolaTarga, string Tara, string valore, DateTime dataVerbale, string pressoLuogo, string presoCserma, string odgNR, DateTime Data_Provvedimento, string nomeContainerChiusura, string destinationTo, string sender , string destinationplace, string terminal, string vector ,string telaioNR, string snMotore,string annoCostruzione,string tipoCarburante,string presidenteCommissione, string segretarioCommissione, string membroCommissione,string respChiusura,string luogoChiusura,DateTime dataChiusura)
        {

            IMTSDB_NEW ds1 = new IMTSDB_NEW();

            NumberFormatInfo provider = new NumberFormatInfo();

            provider.NumberDecimalSeparator = ",";


            //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;
            IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteDataTable minutes;
            try
            {
                BLAnagrafica bla = new BLAnagrafica();
                // DataView nazioni = bla.getNazionalita();
                ds1.ReadXml(Utils.getBasePathName + "Minute.xml", XmlReadMode.IgnoreSchema);
                string[] involvedTable = { "Minute" };
                if (!BLTransactionManager.ClearTransaction(ds1, involvedTable))
                    return false;
                minutes = ds1.Minute;

                IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteRow minuteRow = minutes.NewMinuteRow ();
                minuteRow.Anno_Costruzione = annoCostruzione;
                minuteRow.Container_Descrizione =   bla.getContainers().Select("Id_TypeContainer=" + descrizioneComtainer.ToString())[0][1].ToString();  
                minuteRow.Data_Acquisizione_Verbale = dataVerbale;
                minuteRow.Data_Chiusura = dataChiusura;
                minuteRow.Data_Provvedimento = Data_Provvedimento;
                minuteRow.Ordine_Giorno_NR = odgNR;
                minuteRow.Presidente_Commissione = presidenteCommissione;
                minuteRow.Presso_Caserma = presoCserma;
                minuteRow.Presso_Luogo = pressoLuogo;
                minuteRow.Responsabile_Chiusura = respChiusura;
                minuteRow.Segretario_Commissione = segretarioCommissione;
                minuteRow.SNMotore = snMotore;
                minuteRow.Tara = Tara;
                minuteRow.Telaio = telaioNR;
                minuteRow.Terminale_Stoccaggio = terminal;
                minuteRow.Tipo_Carburante = tipoCarburante;
                minuteRow.Valore = valore;
                minuteRow.Verbale_Number = verbaeNR;
                minuteRow.Vettore_Trasporto = vector;
                minuteRow._Matricola_targa = MatricolaTarga;
                minuteRow.NCopie = qtyCopie;
                minuteRow.Mittente = sender;
                minuteRow.Destinazione_Container = destinationplace;
                minuteRow.Destinazione = destinationTo;
                minuteRow.Operazione_Container = nomeContainerChiusura;
                minuteRow.Luogo_Chiusura = luogoChiusura;
                minuteRow.Membro_Commissione = membroCommissione;
                minutes.AddMinuteRow(minuteRow);
                if (BLTransactionManager.ExecuteTransaction(ds1, involvedTable))

                    return true;
                else
                    return false;


            }

            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    return false;
                else
                    throw ex;
            }








        }

        internal bool UpdateMinuteWithTransaction(Int32 idMinute,int qtyCopie, string verbaeNR, Int32 descrizioneComtainer, string MatricolaTarga, string Tara, string valore, DateTime dataVerbale, string pressoLuogo, string presoCserma, string odgNR, DateTime Data_Provvedimento, string nomeContainerChiusura, string destinationTo, string sender, string destinationplace, string terminal, string vector, string telaioNR, string snMotore, string annoCostruzione, string tipoCarburante, string presidenteCommissione, string segretarioCommissione, string membroCommissione, string respChiusura, string luogoChiusura, DateTime dataChiusura)
        {

            IMTSDB_NEW ds1 = new IMTSDB_NEW();

            NumberFormatInfo provider = new NumberFormatInfo();

            provider.NumberDecimalSeparator = ",";


            //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;
            IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteDataTable minutes;
            try
            {
                BLAnagrafica bla = new BLAnagrafica();
                // DataView nazioni = bla.getNazionalita();
                ds1.ReadXml(Utils.getBasePathName + "Minute.xml", XmlReadMode.IgnoreSchema);
                string[] involvedTable = { "Minute" };
                if (!BLTransactionManager.ClearTransaction(ds1, involvedTable))
                    return false;
                minutes = ds1.Minute;

                IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteRow minuteRow = (IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteRow)minutes.Select("Id_Miniute=" + idMinute).FirstOrDefault();
                minuteRow.Anno_Costruzione = annoCostruzione;
                minuteRow.Container_Descrizione = bla.getContainers().Select("Id_TypeContainer=" + descrizioneComtainer.ToString())[0][1].ToString();
                minuteRow.Data_Acquisizione_Verbale = dataVerbale;
                minuteRow.Data_Chiusura = dataChiusura;
                minuteRow.Data_Provvedimento = Data_Provvedimento;
                minuteRow.Ordine_Giorno_NR = odgNR;
                minuteRow.Presidente_Commissione = presidenteCommissione;
                minuteRow.Presso_Caserma = presoCserma;
                minuteRow.Presso_Luogo = pressoLuogo;
                minuteRow.Responsabile_Chiusura = respChiusura;
                minuteRow.Segretario_Commissione = segretarioCommissione;
                minuteRow.SNMotore = snMotore;
                minuteRow.Tara = Tara;
                minuteRow.Telaio = telaioNR;
                minuteRow.Terminale_Stoccaggio = terminal;
                minuteRow.Tipo_Carburante = tipoCarburante;
                minuteRow.Valore = valore;
                minuteRow.Verbale_Number = verbaeNR;
                minuteRow.Vettore_Trasporto = vector;
                minuteRow._Matricola_targa = MatricolaTarga;
                minuteRow.NCopie = qtyCopie;
                minuteRow.Mittente = sender;
                minuteRow.Destinazione_Container = destinationplace;
                minuteRow.Destinazione = destinationTo;
                minuteRow.Operazione_Container = nomeContainerChiusura;
                minuteRow.Luogo_Chiusura = luogoChiusura;
                minuteRow.Membro_Commissione = membroCommissione;
                minutes.AcceptChanges();
                if (BLTransactionManager.ExecuteTransaction(ds1, involvedTable))

                    return true;
                else
                    return false;


            }

            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    return false;
                else
                    throw ex;
            }







        }
        internal IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteRow getMinuteRow()
        {
            try
            {
                 IMTSDB_NEW ds1 = new IMTSDB_NEW();
                ds1.ReadXml(Utils.getBasePathName + "Minute.xml", System.Data.XmlReadMode.ReadSchema);
                //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;
                IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteDataTable ammDT = ds1.Minute;
               


                return(IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteRow) ammDT.Rows[0];
            }

            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    throw ex;
                else
                    throw ex;
            }
        }

        internal bool isMinutesEmpty()
        {
            try
            {
                IMTSDB_NEW ds1 = new IMTSDB_NEW();
                ds1.ReadXml(Utils.getBasePathName + "Minute.xml", System.Data.XmlReadMode.ReadSchema);
                //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;
                IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteDataTable ammDT = ds1.Minute;



                return ammDT.Rows.Count==0?true:false;
            }

            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    throw ex;
                else
                    throw ex;
            }
        }
        internal bool updatMinteWithTransaction(Int32 idMatContainer, int qty, string matricola, string descrizione, string valore, string lunghezza, string altezza, string profondita, string peso, bool pericoloso, string pesoDG, string unCode, string classeRischio, string compatibilita)
        {




            IMTSDB_NEW ds1 = new IMTSDB_NEW();

            NumberFormatInfo provider = new NumberFormatInfo();

            provider.NumberDecimalSeparator = ",";


            //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;
            IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable materiale_ContainersDT;
            try
            {


                ds1.ReadXml(Utils.getBasePathName + "Materiale_Container.xml", XmlReadMode.IgnoreSchema);
                string[] involvedTable = { "Materiale_Container" };
                if (!BLTransactionManager.ClearTransaction(ds1, involvedTable))
                    return false;
                materiale_ContainersDT = ds1.Materiale_Container;

                IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerRow matcontRow = (IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerRow)materiale_ContainersDT.Select("Id_Materiale=" + idMatContainer).FirstOrDefault();
                matcontRow.Altezza_Materiale = altezza;
                matcontRow.Classe_Rischio = classeRischio;
                matcontRow.Compatibilita = compatibilita;
                matcontRow.Dangerous = pericoloso;
                matcontRow.Descrizione_Materiale = descrizione;
                matcontRow.Lunghezza_Materiale = lunghezza;
                matcontRow.Matricola = matricola;
                matcontRow.Peso_Materiale = peso;
                matcontRow.Peso_Pericoloso = pesoDG;
                matcontRow.Profondita_Materiale = profondita;
                matcontRow.Quantità_Materiale = qty.ToString();
                matcontRow.Id_Materiale = idMatContainer;
                matcontRow.Valore_Materiale = valore;
                matcontRow.UN_Code = unCode;
                matcontRow.Dangerous = pericoloso;

                materiale_ContainersDT.AcceptChanges();
                if (BLTransactionManager.ExecuteTransaction(ds1, involvedTable))

                    return true;
                else
                    return false;


            }

            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    return false;
                else
                    throw ex;
            }



        }

        internal bool DeleteMaterialeWithTransaction(Int32 idMateriale)
        {


            //devo inserire prima il documento se non c'è o se c'è
            IMTS_MINUTES.DataBase.IMTSDB_NEW ds1 = new IMTS_MINUTES.DataBase.IMTSDB_NEW();

            //Int32 idPasseggero = ds.Tables[0].Rows.Count + 1;

            try
            {


                IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable waDT;

                ds1.ReadXml(Utils.getBasePathName + "Materiale_Container.xml", System.Data.XmlReadMode.ReadSchema);
                string[] involvedTable = { "Materiale_Container" };
                if (!BLTransactionManager.ClearTransaction(ds1, involvedTable))
                    return false;

                waDT = ds1.Materiale_Container;



                waDT.Select("Id_Materiale=" + idMateriale).FirstOrDefault().Delete();
                if (BLTransactionManager.ExecuteTransaction(ds1, involvedTable))

                    return true;
                else
                    throw new Exception("Errore transazione");
            }
            catch (Exception ex)
            {
                BLExceptionHandler bLException = new BLExceptionHandler();
                if (bLException.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), ""))
                    return false;
                else
                    throw ex;
            }

        }

    }
}
