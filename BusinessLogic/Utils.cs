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

   
        internal static class Utils
    {
   
        internal static string getBasePathName =Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName+"\\Database\\DatiXML\\";
      
        internal static string logFilePath = Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\ExceptionHandler\\Log\\";
        internal static string imp = Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\Database\\DatiXML\\";
        internal static string Exp = Directory.GetParent(Application.ExecutablePath).Parent.Parent.FullName + "\\ImportExportMinutes\\";
        internal static void copy(DataRow vrowOne,ref DataRow destDR)
        {
            DataTable app = new DataTable();
         

            for (int h = 0; h < vrowOne.ItemArray.Length; h++)
            {
              

                    if (vrowOne.Table.Columns[h].DataType == typeof(int))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowOne.Field<int>(h)))
                            destDR[h] = Convert.ToInt32(vrowOne.Field<int>(h));
                            else
                            destDR[h] = 0;
                        }
                        catch { }
                    }
                    if (vrowOne.Table.Columns[h].DataType == typeof(string))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowOne.Field<string>(h)))
                            destDR[h] = Convert.ToString(vrowOne.Field<string>(h));

                            else
                            destDR[h] = String.Empty;
                        }
                        catch { }
                    }
                    if (vrowOne.Table.Columns[h].DataType == typeof(DateTime))
                    {

                    if (!DBNull.Value.Equals(vrowOne.Field<DateTime>(h)))
                        try
                        {
                            destDR[h] = Convert.ToDateTime(vrowOne.Field<DateTime>(h));
                        }
                        catch
                        { }
                    else
                        destDR[h] = DateTime.MinValue;
                    }
                    if (vrowOne.Table.Columns[h].DataType == typeof(short))
                    {

                        if (!DBNull.Value.Equals(vrowOne.Field<short>(h)))
                        destDR[h] = Convert.ToUInt16(vrowOne.Field<short>(h));

                        else
                        destDR[h] = 0;
                    }
                if (vrowOne.Table.Columns[h].DataType == typeof(decimal))
                {

                    if (!DBNull.Value.Equals(vrowOne.Field<decimal>(h)))
                        destDR[h] = Convert.ToDecimal(vrowOne.Field<decimal>(h));

                    else
                        destDR[h] = 0;
                }
                if (vrowOne.Table.Columns[h].DataType == typeof(bool))
                {

                    if (!DBNull.Value.Equals(vrowOne.Field<bool>(h)))
                        destDR[h] = Convert.ToBoolean(vrowOne.Field<bool>(h));

                    else
                        destDR[h] = 0;
                }
            }

 



           
            

           


        }

        internal static void DisposeAllButThis(Form parentForm)
        {
            foreach (Control frm1 in parentForm.Controls)
            {
                try {
                          Form frm = (Form)frm1;
                          if (frm.GetType() != parentForm.GetType()
                                                && frm != parentForm)
                             {
                                    frm.Close();
                                 }
                         }
                catch
                    { }
            }
        }

    }
}
