using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMTS_MINUTES.BusinessLogic
{
    internal static class BLTransactionManager
    {
        internal static string  ReadAppStart()
        {
            return System.IO.File.ReadAllText(Utils.getBasePathName + "AppStart.txt");

        }
        private  static void WriteAppStartToOK()
        {
            System.IO.File.WriteAllText(Utils.getBasePathName + "AppStart.txt", "1");
            
    }
        private static void WriteAppStartToKO()
        {
            System.IO.File.WriteAllText(Utils.getBasePathName + "AppStart.txt", "0");

        }
        internal static bool ExecuteTransaction(IMTS_MINUTES.DataBase.IMTSDB_NEW ds, string[] tableName)
        {
            try
            {
                foreach (string tbName in tableName)
                {

                    ds.Tables[tbName].WriteXml(Utils.getBasePathName + tbName + ".xml", XmlWriteMode.WriteSchema);
                }
                
              

                return true;
            }
            catch
            {
                //inchioda il programma
                WriteAppStartToKO();
                return false;

            }
        }
        internal static bool ClearTransaction(IMTS_MINUTES.DataBase.IMTSDB_NEW ds, string[] tableName)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(Utils.getBasePathName + "BackUp\\");
                foreach (string filePath in filePaths)
                    File.Delete(filePath);
                
                foreach (string tbName in tableName)
                {

                    ds.Tables[tbName].WriteXml(Utils.getBasePathName + "BackUp\\" + tbName + ".xmlBAK", XmlWriteMode.WriteSchema);
                }
                
                return true;
            }
            catch
            {
                //inchioda il programma
                WriteAppStartToKO();
                return false;

            }
        }
    }
}
