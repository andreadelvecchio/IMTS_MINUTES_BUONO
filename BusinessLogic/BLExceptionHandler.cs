using IMTS_MINUTES.BusinessLogic;
using IMTS_MINUTES.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace IMTS_MINUTES.BusinessLogic

{
    internal class BLExceptionHandler
    {
         
        private void OpenLogFile(string ShortDate)
        {
            if (!File.Exists(Utils.logFilePath + ShortDate.Replace("/", "_") + ".xml"))
            { 
               FileStream fs= File.Create(Utils.logFilePath + ShortDate.Replace("/", "_") + ".xml");
                fs.Close();
                IMTS_MINUTES.DataBase.IMTSDB_NEW.Exception_HandlerDataTable dt = new IMTS_MINUTES.DataBase.IMTSDB_NEW.Exception_HandlerDataTable();
                dt.WriteXml(Utils.logFilePath + ShortDate.Replace("/", "_") + ".xml", System.Data.XmlWriteMode.IgnoreSchema, false);
               
            }

            //return File.ReadAllText(Utils.logFilePath + ShortDate + ".xml");
        }
        internal bool WriteLog(string ShortDate,DateTime timeStamp,string message,string  source,string stackTrace,string targetSite,  string function)
        {
            try
            {
                string path = ShortDate.Replace("/", "_");
                OpenLogFile(ShortDate);
                IMTS_MINUTES.DataBase.IMTSDB_NEW.Exception_HandlerDataTable dt = new IMTS_MINUTES.DataBase.IMTSDB_NEW.Exception_HandlerDataTable();
                dt.ReadXml(Utils.logFilePath + path + ".xml");
                IMTS_MINUTES.DataBase.IMTSDB_NEW.Exception_HandlerRow handlerRow = dt.NewException_HandlerRow();
                handlerRow.Timestamp = timeStamp;
                handlerRow.Message = message;
                handlerRow.Source = source;
                handlerRow.StackTrace = stackTrace;
                handlerRow.TargetSite = targetSite;
                handlerRow.Function = function;
                dt.AddException_HandlerRow(handlerRow);
                dt.WriteXml(Utils.logFilePath + path + ".xml", System.Data.XmlWriteMode.IgnoreSchema, false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        internal string ReadLogFile(string ShortDate)
        {
            if (File.Exists(Utils.logFilePath + ShortDate.Replace("/", "_") + ".xml"))
            {
                return File.ReadAllText(Utils.logFilePath + ShortDate.Replace("/", "_") + ".xml");

            } else
                return "";

            //return File.ReadAllText(Utils.logFilePath + ShortDate + ".xml");
        }

    }
}
