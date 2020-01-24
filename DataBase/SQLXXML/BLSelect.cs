using IMTS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMTS.DataBase;
using System.Reflection;
using static IMTS.DataBase.IMTSDB_NEW;

namespace IMTS.DataBase.SQLXXML
{
    class BLSelect
    {


        //todo fillGenericDrFromDRView non posizionale con i column name!
        public Anagrafica_Personale_Doc_PaxRow fillGenericDrNONPOSIZIONALEFromDRView(DataRow vrowOne, DataRow vrowMany, bool partiallyFill, ref IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable JaggedDT)
        {
            Anagrafica_Personale_Doc_PaxRow anprow = JaggedDT.NewAnagrafica_Personale_Doc_PaxRow();
            anprow.BeginEdit();
            int k = 0;
            for (int h = 0; h < anprow.ItemArray.Length; h++)
            {
                if (h < vrowOne.ItemArray.Length)
                {

                    if (anprow.Table.Columns[h].DataType == typeof(int)&& (anprow.Table.Columns[h].ColumnName== vrowOne.Table.Columns[h].ColumnName ))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowOne.Field<int>(h)))
                                anprow[h] = Convert.ToInt32(vrowOne.Field<int>(h));
                            else
                                anprow[h] = 0;
                        }
                        catch { }
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(string) && (anprow.Table.Columns[h].ColumnName == vrowOne.Table.Columns[h].ColumnName))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowOne.Field<string>(h)))
                                anprow[h] = Convert.ToString(vrowOne.Field<string>(h));

                            else
                                anprow[h] = String.Empty;
                        }
                        catch { }
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(DateTime) && (anprow.Table.Columns[h].ColumnName == vrowOne.Table.Columns[h].ColumnName))
                    {

                        if (!DBNull.Value.Equals(vrowOne.Field<string>(h)))
                            anprow[h] = Convert.ToDateTime(vrowOne.Field<string>(h));

                        else
                            anprow[h] = DateTime.MinValue;
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(short) && (anprow.Table.Columns[h].ColumnName == vrowOne.Table.Columns[h].ColumnName))
                    {

                        if (!DBNull.Value.Equals(vrowOne.Field<short>(h)))
                            anprow[h] = Convert.ToUInt16(vrowOne.Field<short>(h));

                        else
                            anprow[h] = 0;
                    }
                }



                else
                   if (h < vrowOne.ItemArray.Length + vrowMany.ItemArray.Length && h > vrowOne.ItemArray.Length - 1)
                {

                    if (anprow.Table.Columns[h].DataType == typeof(int) && (anprow.Table.Columns[h].ColumnName == vrowMany.Table.Columns[k].ColumnName))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowMany.Field<int>(k)))
                                anprow[h] = Convert.ToInt32(vrowMany.Field<int>(k));
                            else
                                anprow[h] = 0;
                        }
                        catch
                        {

                        }
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(string) && (anprow.Table.Columns[h].ColumnName == vrowMany.Table.Columns[k].ColumnName))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowMany.Field<string>(k)))
                                anprow[h] = Convert.ToString(vrowMany.Field<string>(k));

                            else
                                anprow[h] = String.Empty;
                        }
                        catch { }
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(DateTime) && (anprow.Table.Columns[h].ColumnName == vrowMany.Table.Columns[k].ColumnName))
                    {

                        if (!DBNull.Value.Equals(vrowMany.Field<string>(k)))
                            anprow[h] = Convert.ToDateTime(vrowMany.Field<string>(k));

                        else
                            anprow[h] = DateTime.MinValue;
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(short) && (anprow.Table.Columns[h].ColumnName == vrowMany.Table.Columns[k].ColumnName))
                    {

                        if (!DBNull.Value.Equals(vrowMany.Field<short>(k)))
                            anprow[h] = Convert.ToUInt16(vrowMany.Field<short>(k));

                        else
                            anprow[h] = 0;
                    }

                    k++;

                }

            }
            anprow.EndEdit();
            JaggedDT.AddAnagrafica_Personale_Doc_PaxRow(anprow);
            JaggedDT.AcceptChanges();

            return anprow;


        }
        public Anagrafica_Personale_Doc_PaxRow fillGenericDrFromDRView(DataRow vrowOne, DataRow vrowMany, bool partiallyFill, ref IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable JaggedDT)
        {
            Anagrafica_Personale_Doc_PaxRow anprow = JaggedDT.NewAnagrafica_Personale_Doc_PaxRow();
            anprow.BeginEdit();
            int k = 0;
            for (int h = 0; h < anprow.ItemArray.Length; h++)
            {
                if (h < vrowOne.ItemArray.Length)
                {

                    if (anprow.Table.Columns[h].DataType == typeof(int))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowOne.Field<int>(h)))
                                anprow[h] = Convert.ToInt32(vrowOne.Field<int>(h));
                            else
                                anprow[h] = 0;
                        }
                        catch { }
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(string))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowOne.Field<string>(h)))
                                anprow[h] = Convert.ToString(vrowOne.Field<string>(h));

                            else
                                anprow[h] = String.Empty;
                        }
                        catch { }
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(DateTime))
                    {

                        if (!DBNull.Value.Equals(vrowOne.Field<string>(h)))
                            anprow[h] = Convert.ToDateTime(vrowOne.Field<string>(h));

                        else
                            anprow[h] = DateTime.MinValue;
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(short))
                    {

                        if (!DBNull.Value.Equals(vrowOne.Field<short>(h)))
                            anprow[h] = Convert.ToUInt16(vrowOne.Field<short>(h));

                        else
                            anprow[h] = 0;
                    }
                }



                else
                   if (h < vrowOne.ItemArray.Length + vrowMany.ItemArray.Length && h > vrowOne.ItemArray.Length-1)
                { 
                     
                    if (anprow.Table.Columns[h].DataType == typeof(int))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowMany.Field<int>(k)))
                                anprow[h] = Convert.ToInt32(vrowMany.Field<int>(k));
                            else
                                anprow[h] = 0;
                        }
                        catch {

                        }
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(string))
                    {
                        try
                        {
                            if (!DBNull.Value.Equals(vrowMany.Field<string>(k)))
                                anprow[h] = Convert.ToString(vrowMany.Field<string>(k));

                            else
                                anprow[h] = String.Empty;
                        }
                        catch { }
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(DateTime))
                    {

                        if (!DBNull.Value.Equals(vrowMany.Field<string>(k)))
                            anprow[h] = Convert.ToDateTime(vrowMany.Field<string>(k));

                        else
                            anprow[h] = DateTime.MinValue;
                    }
                    if (anprow.Table.Columns[h].DataType == typeof(short))
                    {

                        if (!DBNull.Value.Equals(vrowMany.Field<short>(k)))
                            anprow[h] = Convert.ToUInt16(vrowMany.Field<short>(k));

                        else
                            anprow[h] = 0;
                    }
                    
                    k++;

                }

            }
            anprow.EndEdit();
            JaggedDT.AddAnagrafica_Personale_Doc_PaxRow(anprow);
            JaggedDT.AcceptChanges();

            return anprow;


        }
        //public object selectOneToManyIntReferencesTB(DataTable DTOne, DataTable DTMany, string filterDBOne, string filterDTMany, string keyDTOne, string keyDMany, Type tpkey, bool isDistinct, object typeofMergeDT, object dtMerge)
        //{
        //    Assembly assembly = Assembly.LoadFrom(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\IMTS.exe");
        //    // Assembly assembly = Assembly.GetExecutingAssembly();



        //    //Activator.CreateInstance(type);
        //    object dtMergeTable = assembly.CreateInstance("IMTSDB_NEW.Anagrafica_PersonaleDataTable");
        //    DataTable dtMergeTable1 = new IMTSDB_NEW.Anagrafica_PersonaleDataTable();
        //    DataTable dt = DTOne;
        //    DataView dv = dt.DefaultView;
        //    dv.RowFilter = filterDBOne;
        //    dv.Sort = keyDTOne + " ASC";
        //    //dv.ApplyDefaultSort = true;

        //    DataTable dt1 = DTMany;
        //    DataView dv1 = dt1.DefaultView;
        //    dv1.RowFilter = filterDTMany;
        //    dv1.Sort = keyDMany + " ASC";

        //    StringBuilder anagRowFilterGiant = new StringBuilder();
        //    bool first = false;
        //    List<int> anagRowFilterGiantList = new List<int>();
        //    //int[] anagRowFilterGiantArray = new int[dv1.Count];
        //    //int k = 0;
        //    foreach (DataRowView vrowdp in dv1)
        //    {

        //        //anagRowFilterGiant.Append(vrowdp.Row.Field<int>("Id_Anagrafica_Pax")+"#");
        //        if (!anagRowFilterGiantList.Contains(vrowdp.Row.Field<int>(keyDMany)))
        //            anagRowFilterGiantList.Add(vrowdp.Row.Field<int>(keyDMany));
        //        //anagRowFilterGiantArray[k] = vrowdp.Row.Field<int>("Id_Anagrafica_Pax");
        //        //k++;
        //        //first = true;


        //    }
        //    anagRowFilterGiantList.Sort();
        //    object dvAnagFiltrato = assembly.CreateInstance("Anagrafica_PersonaleDataTable");
        //    int idanagVisistato = 0;
        //    int idanagPrecedente = 0;
        //    bool isfirstanag = true;
        //    foreach (DataRowView vrowAp in dv)
        //    {
        //        if (isfirstanag)
        //        {

        //            idanagVisistato = vrowAp.Row.Field<Int32>(keyDTOne);
        //            idanagPrecedente = vrowAp.Row.Field<Int32>(keyDTOne);
        //        }
        //        else
        //        {
        //            idanagVisistato = vrowAp.Row.Field<Int32>(keyDTOne);
        //        }
        //        if (idanagVisistato != idanagPrecedente || isfirstanag)
        //        {
        //            isfirstanag = false;

        //            if (anagRowFilterGiantList.Contains(vrowAp.Row.Field<int>(keyDTOne)))
        //            //if (anagRowFilterGiantArray.Contains(vrowAp.Row.Field<int>("Id_Personale")))
        //            {

        //                // IMTSDB_NEW.Anagrafica_PersonaleRow anprow = dvAnagFiltrato.NewAnagrafica_PersonaleRow();

        //                DataRow anprowtoaadd = dtMergeTable1.Rows.Add();
        //                // fillGenericDrFromDRView(ref anprowtoaadd, vrowAp,ref dtMergeTable1,7,null,false);
        //                //((DataTable)dtMergeTable).NewRow();

        //                //((DataTable)dvAnagFiltrato).Rows.Add(anprowtoaddd);



        //            }
        //        }
        //        else
        //        {
        //            idanagPrecedente = idanagVisistato;
        //            isfirstanag = true;
        //        }
        //    }


        //   //dv1.Sort = "Id_Anagrafica_Pax ASC";
        //   ((DataTable)dvAnagFiltrato).DefaultView.ApplyDefaultSort = true;
        //    DataView dvGeneric;//= new DataView();
        //    dvGeneric = ((DataTable)dvAnagFiltrato).DefaultView;
        //    dvGeneric.ApplyDefaultSort = true;
        //    int idanagpaxVisistato = 0;
        //    int idanagpaxPrecedente = 0;
        //    bool isfirst = true;
        //    foreach (DataRowView vrowdp in dv1)
        //    {





        //        dvGeneric.Sort = keyDTOne + " ASC";

        //        dvGeneric.RowFilter = keyDTOne + vrowdp.Row.Field<Int32>(keyDMany);
        //        // int count=dvGeneric.Find(vrowdp.Row.Field<Int32>("Id_Anagrafica_Pax"));
        //        //dt.Rows.fi
        //        //DataRowView[] dvGenericColl = dvGeneric.FindRows(count); 


        //        foreach (DataRowView vrowAp in dvGeneric)
        //        {
        //            if (isfirst)
        //            {

        //                idanagpaxVisistato = vrowdp.Row.Field<Int32>(keyDMany);
        //                idanagpaxPrecedente = vrowdp.Row.Field<Int32>(keyDMany);
        //            }
        //            else
        //            {
        //                idanagpaxVisistato = vrowdp.Row.Field<Int32>(keyDMany);
        //            }
        //            if (idanagpaxVisistato != idanagpaxPrecedente || isfirst)
        //            {
        //                isfirst = false;

        //                //dvGeneric.RowFilter = "Id_Personale=" + vrowdp.Row.Field<Int32>("Id_Anagrafica_Pax");
        //                if (vrowAp.Row.Field<int>(keyDTOne) == vrowdp.Row.Field<Int32>(keyDMany))
        //                {
        //                    DataRow anprow1 = ((DataTable)dtMergeTable).NewRow();
        //                    //fillGenericDrFromDRView(ref anprow, vrowAp,);


        //                    ((DataTable)dtMergeTable).Rows.Add(anprow1);
        //                }
        //            }
        //            else if (vrowdp.Row.Field<Int32>(keyDMany) > anagRowFilterGiantList.Last())
        //                return ((DataTable)dtMergeTable).DefaultView;

        //            else
        //            {
        //                idanagpaxPrecedente = idanagpaxVisistato;
        //                // isfirst = true;
        //            }

        //        }

        //    }
        //    DataView mergeDV = ((DataTable)dtMergeTable).DefaultView;
        //    //mergeDV.RowFilter= "SELECT DISTINCT Id_Personale,Cognome,Nome,Data_Nascita,Luogo_Nascita,Nationality,Rank,Serv";
        //    return mergeDV;


        //}

        public Anagrafica_Personale_Doc_PaxDataTable prodottoCartesianoIntelligeteTabelle(DataTable dt1,DataTable dt2)
        {
            IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable dtMergeTable = new IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable();
            IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable dtPassaggio= new IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable();
            List<int> elementiInseritiChiavi = new List<int>();

            foreach (DataRow dr1 in dt1.Rows)

            {
                foreach (DataRow dr2 in dt2.Select("Id_Anagrafica_Pax="+dr1.Field<int>("Id_Personale").ToString()))
                {
                    if (dr1.Field<int>("Id_Personale") == dr2.Field<int>("Id_Anagrafica_Pax")&&!elementiInseritiChiavi.Contains(dr1.Field<int>("Id_Personale")))
                    {

                       fillGenericDrNONPOSIZIONALEFromDRView(dr1, dr2, false, ref dtPassaggio);
                       
                        
                    elementiInseritiChiavi.Add(dr1.Field<int>("Id_Personale"));
                    }
                }
            }
            return dtPassaggio;
        }

        public Anagrafica_Personale_Doc_PaxDataTable prodottoCartesianoIntelligeteDataview(DataView dt1, DataView dt2)
        {
            IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable dtMergeTable = new IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable();
            IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable dtPassaggio = new IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable();
            List<int> elementiInseritiChiavi = new List<int>();

            foreach (DataRowView dr1 in dt1)

            {
                foreach (DataRowView dr2 in dt2)
                {
                    if (dr1.Row.Field<int>("Id_Personale") == dr2.Row.Field<int>("Id_Anagrafica_Pax") && !elementiInseritiChiavi.Contains(dr1.Row.Field<int>("Id_Personale")))
                    {
                        fillGenericDrNONPOSIZIONALEFromDRView(dr1.Row, dr2.Row, false, ref dtPassaggio);


                        elementiInseritiChiavi.Add(dr1.Row.Field<int>("Id_Personale"));
                    }
                }
            }
            return dtPassaggio;
        }
        public Anagrafica_Personale_Doc_PaxDataTable selectOneToManyIntReferencesConProdCartesiano(DataTable DTOne, DataTable DTMany)
        {
            Assembly assembly = Assembly.LoadFrom(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\IMTS.exe");
            // Assembly assembly = Assembly.GetExecutingAssembly();
            assembly.CreateInstance("IMTSDB_NEW.Anagrafica_PersonaleDataTable");


            //Activator.CreateInstance(type);
            IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable dtMergeTable = new IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable();
            
            DataTable dt = DTOne;
            DataView dv = dt.DefaultView;
            

            DataTable dt1 = DTMany;
            DataView dv1 = new DataView();
            dtMergeTable = prodottoCartesianoIntelligeteTabelle(DTOne, DTMany);

            
            return dtMergeTable;



        }
            public object selectOneToManyIntReferencesTB1(DataTable DTOne, DataTable DTMany, string filterDBOne, string filterDTMany, string keyDTOne, string keyDMany, Type tpkey, bool isDistinct, object typeofMergeDT, object dtMerge, int totColumn)
        {
            Assembly assembly = Assembly.LoadFrom(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\IMTS.exe");
            // Assembly assembly = Assembly.GetExecutingAssembly();
            assembly.CreateInstance("IMTSDB_NEW.Anagrafica_PersonaleDataTable");


            //Activator.CreateInstance(type);
            IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable dtMergeTable = new IMTSDB_NEW.Anagrafica_Personale_Doc_PaxDataTable();
            DataTable dt = DTOne;
            DataView dv = dt.DefaultView;
            //dv.ApplyDefaultSort = true;


//            //prrova commento
            dv.Sort = keyDTOne + " ASC";
           dv.RowFilter = filterDBOne;

           //dv.ApplyDefaultSort = true;

            DataTable dt1 = DTMany;
            DataView dv1 = new DataView();

          dv1 = dt1.DefaultView;
            //            //dv1.ApplyDefaultSort = true;

            dv1.Sort = keyDMany + ",Id_Documento ASC";
            dv1.RowFilter = filterDTMany;
            //            //dv1.RowStateFilter=DataViewRowState.
            ////fine prova commento



            //lista delle chiavi tablella many che hanno sperato il filtro quindi buone
            List<int> dtFilterGiantList = new List<int>();
            foreach (DataRowView vrowdp in dv1)
            {

                //anagRowFilterGiant.Append(vrowdp.Row.Field<int>("Id_Anagrafica_Pax")+"#");
                if (!dtFilterGiantList.Contains(vrowdp.Row.Field<int>(keyDMany)))
                    dtFilterGiantList.Add(vrowdp.Row.Field<int>(keyDMany));
                //anagRowFilterGiantArray[k] = vrowdp.Row.Field<int>("Id_Anagrafica_Pax");
                //k++;
                //first = true;
            }

            List<int> dtFilterGiantListAnag = new List<int>();
            foreach (DataRowView vrowdp in dv)
            {

                //anagRowFilterGiant.Append(vrowdp.Row.Field<int>("Id_Anagrafica_Pax")+"#");
                if (!dtFilterGiantListAnag.Contains(vrowdp.Row.Field<int>(keyDTOne)))
                    dtFilterGiantListAnag.Add(vrowdp.Row.Field<int>(keyDTOne));
                //anagRowFilterGiantArray[k] = vrowdp.Row.Field<int>("Id_Anagrafica_Pax");
                //k++;
                //first = true;
            }
            DataRow[] associated = null;
             DataRow[] associatedFiltered = null;
            DataRow[] associatedDP = null;
            DataRow[] associatedDPFiterred = null;
            List<int> elementiInseritiChiavi = new List<int>();
            foreach (int key in dtFilterGiantList)
            {



                associated = dt.Select("Id_Personale=" + key);

                associatedDP = dt1.Select("Id_Anagrafica_Pax=" + key);



                associatedFiltered = associated.CopyToDataTable().Select(filterDBOne);
                associatedDPFiterred = associatedDP.CopyToDataTable().Select(filterDTMany);
                
                    for (int k = 0; k <= associatedFiltered.Length-1; k++)
                    // foreach (DataRow rowresult in associatedFiltered)
                    {
                        for (int i = 0; i < associatedDPFiterred.Length-1; i++)
                            if (associatedFiltered[k].Field<int>("Id_Personale") == associatedDPFiterred[i].Field<int>("Id_Anagrafica_Pax") && !elementiInseritiChiavi.Contains(key))
                            {
                                dtMergeTable.AddAnagrafica_Personale_Doc_PaxRow(fillGenericDrFromDRView(associatedFiltered[k], associatedDPFiterred[i], false, ref dtMergeTable));
                                dtMergeTable.AcceptChanges();
                                elementiInseritiChiavi.Add(key);
                            }
                    }
                
                    for (int k = 0; k < associatedDPFiterred.Length-1; k++)
                    // foreach (DataRow rowresult in associatedFiltered)
                    {
                        for (int i = 0; i < associatedFiltered.Length-1; i++)
                            if (associatedDPFiterred[k].Field<int>("Id_Anagrafica_Pax") == associatedFiltered[i].Field<int>("Id_Personale") && !elementiInseritiChiavi.Contains(key))
                            {
                                dtMergeTable.AddAnagrafica_Personale_Doc_PaxRow(fillGenericDrFromDRView(associatedFiltered[i], associatedDPFiterred[k], false, ref dtMergeTable));
                                dtMergeTable.AcceptChanges();
                                elementiInseritiChiavi.Add(key);
                            }

                    }

            }
            foreach (int key in dtFilterGiantListAnag)
            {



                associated = dt.Select("Id_Personale=" + key);

                associatedDP = dt1.Select("Id_Anagrafica_Pax=" + key);



                associatedFiltered = associated.CopyToDataTable().Select(filterDBOne);
                associatedDPFiterred = associatedDP.CopyToDataTable().Select(filterDTMany);

                for (int k = 0; k <= associatedFiltered.Length - 1; k++)
                // foreach (DataRow rowresult in associatedFiltered)
                {
                    for (int i = 0; i < associatedDPFiterred.Length - 1; i++)
                        if (associatedFiltered[k].Field<int>("Id_Personale") == associatedDPFiterred[i].Field<int>("Id_Anagrafica_Pax") && !elementiInseritiChiavi.Contains(key))
                        {
                            dtMergeTable.AddAnagrafica_Personale_Doc_PaxRow(fillGenericDrFromDRView(associatedFiltered[k], associatedDPFiterred[i], false, ref dtMergeTable));
                            dtMergeTable.AcceptChanges();
                            elementiInseritiChiavi.Add(key);
                        }
                }

                for (int k = 0; k < associatedDPFiterred.Length - 1; k++)
                // foreach (DataRow rowresult in associatedFiltered)
                {
                    for (int i = 0; i < associatedFiltered.Length - 1; i++)
                        if (associatedDPFiterred[k].Field<int>("Id_Anagrafica_Pax") == associatedFiltered[i].Field<int>("Id_Personale") && !elementiInseritiChiavi.Contains(key))
                        {
                            dtMergeTable.AddAnagrafica_Personale_Doc_PaxRow(fillGenericDrFromDRView(associatedFiltered[i], associatedDPFiterred[k], false, ref dtMergeTable));
                            dtMergeTable.AcceptChanges();
                            elementiInseritiChiavi.Add(key);
                        }

                }

            }

            return dtMergeTable;
            }

            }


        }
   

//DataRow anprow = dtMergeTable.NewRow();
//fillGenericDrFromDRView(ref anprow, vrowAp);

//if (!DBNull.Value.Equals(vrowAp.Row.Field<int>("Id_Personale")))
//    anprow.Id_Personale = vrowAp.Row.Field<int>("Id_Personale");
//else
//    anprow.Id_Personale = 0;
//if (!DBNull.Value.Equals(vrowAp.Row.Field<string>("Cognome")))
//    anprow.Cognome = vrowAp.Row.Field<string>("Cognome");
//else
//    anprow.Cognome = String.Empty;
//if (!DBNull.Value.Equals(vrowAp.Row.Field<string>("Nome")))
//    anprow.Nome = vrowAp.Row.Field<string>("Nome");
//else
//    anprow.Nome = String.Empty;
//if (!DBNull.Value.Equals(vrowAp.Row.Field<string>("Data_Nascita")))
//    anprow.Data_Nascita = vrowAp.Row.Field<string>("Data_Nascita");
//else
//    anprow.Data_Nascita = String.Empty;
//if (!DBNull.Value.Equals(vrowAp.Row.Field<string>("Luogo_Nascita")))
//    anprow.Luogo_Nascita = vrowAp.Row.Field<string>("Luogo_Nascita");
//else
//    anprow.Luogo_Nascita = String.Empty;
//if (!DBNull.Value.Equals(vrowAp.Row.Field<int>("Nationality")))
//    anprow.Nationality = vrowAp.Row.Field<int>("Nationality").ToString();
//else
//    anprow.Nationality = String.Empty;
//if (!DBNull.Value.Equals(vrowAp.Row.Field<int>("Rank")))
//    anprow.Rank = vrowAp.Row.Field<int>("Rank");
//else
//    anprow.Rank = 0;
//if (!DBNull.Value.Equals(vrowAp.Row.Field<int>("Rank")))
//    anprow.Serv = vrowAp.Row.Field<int>("Serv");
//else
//    anprow.Serv = 0;

//dvAnagFiltrato.AddAnagrafica_PersonaleRow(anprow);
