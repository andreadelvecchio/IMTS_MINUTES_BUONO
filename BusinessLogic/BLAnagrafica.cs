 
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Data;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
 
 
 
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using IMTS_MINUTES.BusinessLogic;
 
using IMTS_MINUTES.DataBase;

namespace IMTS_MINUTES
{
    class BLAnagrafica
    {

        internal IMTS_MINUTES.DataBase.IMTSDB_NEW.Tipologia_ContainerDataTable getContainers()
        {
            try
            {
                IMTS_MINUTES.DataBase.IMTSDB_NEW dataSet = new IMTS_MINUTES.DataBase.IMTSDB_NEW();
                dataSet.ReadXml(Utils.getBasePathName + "Tipologia_Container.xml", System.Data.XmlReadMode.IgnoreSchema);
                return dataSet.Tipologia_Container;
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
        internal DataView getCompatibilita()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(Utils.getBasePathName + "Compatibilita.xml", XmlReadMode.ReadSchema);
            DataView dv = dataSet.Tables[0].DefaultView;
            dv.Sort = "Val_Compatibilita asc";
            return dv;
        }
        internal DataView getClasseRischio()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(Utils.getBasePathName + "Classe_Rischio.xml", XmlReadMode.ReadSchema);
            DataView dv = dataSet.Tables[0].DefaultView;
            dv.Sort = "Val_Classe_Rischio asc";
            return dv;
        }
    }
}

 