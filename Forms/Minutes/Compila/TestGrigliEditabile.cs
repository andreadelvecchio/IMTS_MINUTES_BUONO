using IMTS_MINUTES.BusinessLogic.BLMinutes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IMTS_MINUTES.Forms.Minutes.Compila
{
    public partial class TestGrigliEditabile : Form
    {
        string[] requiredFieldTB = new string[] { "Quantita_Materiale", "Valore_Materiale", "Lunghezza_Materiale", "Altezza_Materiale", "Profondita_Materiale", "Peso_Materiale", };
        string[] requiredFieldCB = new string[] { };
        string[] numericFieldMoreThanZeroTB = new string[] { "Quantita_Materiale" };
        string[] decimaFieldMoreThanZeroTB = new string[] { "Valore_Materiale", "Lunghezza_Materiale", "Altezza_Materiale", "Profondita_Materiale", "Peso_Materiale" };
 
        string[] notRequired = new string[] { "Descrizione_Materiale", "Matricola" };
      
        string[] requiredIfDangerousTB = new string[] { "UN_Code", "Peso_Pericoloso" };
        string[] requiredIfDangerousCB = new string[] { "Classe_Rischio", "Compatibilita" };

        string[] requiredIfDangerousCeckBox = new string[] { "Pericoloso" };
        Dictionary<string, bool> controlliValidati = new Dictionary<string, bool>();

        DataGridViewCellStyle csgray = new DataGridViewCellStyle();
        DataGridViewCellStyle csOrange = new DataGridViewCellStyle();
        DataGridViewCellStyle csWhite = new DataGridViewCellStyle();
        DataGridViewCellStyle csDisabled = new DataGridViewCellStyle();
        public TestGrigliEditabile()
        {
            InitializeComponent();
        }

        private void FillCombo()
        {
            BLAnagrafica BLA = new BLAnagrafica();


            foreach (DataGridViewColumn col in DGVMatContainer.Columns)
            {



                if (requiredIfDangerousCB.Contains(col.Name))
                {
                    if (col.Name == "Classe_Rischio")
                    {
                        DataGridViewComboBoxColumn cb1 = (DataGridViewComboBoxColumn)col;
                        cb1.DataSource = new BLAnagrafica().getClasseRischio();
                        cb1.DisplayMember = "Val_Classe_Rischio";
                        cb1.ValueMember = "Val_Classe_Rischio";
                        //cb1.Items.Add(" ");
                        cb1.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                    if (col.Name == "Compatibilita")
                    {
                        DataGridViewComboBoxColumn cb1 = (DataGridViewComboBoxColumn)col;
                        cb1.DataSource = new BLAnagrafica().getCompatibilita();
                        cb1.DisplayMember = "Val_Compatibilita";
                        cb1.ValueMember = "Val_Compatibilita";
                        //cb1.Items.Add(" ");
                        cb1.SortMode = DataGridViewColumnSortMode.Automatic;
                    }

                }

            }


        }
        private void TestGriglia_Load(object sender, EventArgs e)
        {
            FillCombo();
            BLWriteMiutes writeMinutes = new BLWriteMiutes();
            MinuteRow minuteRow = writeMinutes.getMinuteRow();
            
            csgray.BackColor = Color.LightGray;
            csgray.SelectionBackColor = Color.LightGray;

            //csgray.Font = font;

            csOrange.BackColor = Color.Orange;
            csOrange.SelectionBackColor = Color.Orange;
            //csOrange.Font = font;

            csWhite.BackColor = Color.White;
            csWhite.SelectionBackColor = Color.White;
            //csWhite.Font = font;

            csDisabled.BackColor = Color.DarkGray;
            csDisabled.SelectionBackColor = Color.DarkGray;
            
                //csDisabled.Font = font;
            DGVMatContainer.DataSource = writeMinutes.GetMateriale_Container();
            button1.Visible = true;



        }
        bool chechChange = true;
        private void DGVMatContainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BLWriteMiutes bLWrite = new BLWriteMiutes();

            if (DGVMatContainer.CurrentCell.OwningColumn.Name == ("Delete") && e.RowIndex != -1)
            {
                if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewButtonCell))
                {
                    bLWrite.DeleteMaterialeWithTransaction((Int32)DGVMatContainer.CurrentRow.Cells["Id_Materiale"].Value);
                    DGVMatContainer.DataSource = bLWrite.GetMateriale_Container();
                  
                }
            }
            if (DGVMatContainer.CurrentCell.OwningColumn.Name == ("Pericoloso") && e.RowIndex != -1)
            {
                if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    //((DataGridViewCheckBoxCell)DGVMatContainer.CurrentCell).Value
                    this.DGVMatContainer.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.CheckValueCell_Changed);
                    if (ValidateCurrentRow(DGVMatContainer.CurrentRow))
                    {
                        New_Row(null, null);
                       
                    }



                    }
            }
            button1.Visible = true;
        }
                DataGridViewRow bkupRow;
        private void New_Row(object sender, DataGridViewRowEventArgs e)
                    {
            try
                    {

                DataGridViewRow dvrc = DGVMatContainer.CurrentRow;

            Dictionary<string, object> keyValuePair = new Dictionary<string, object>();
            foreach (   DataGridViewCell cell in dvrc.Cells)
            {
              
                    //rowValues[cell.ColumnIndex] = cell.Value;
                    if(cell.OwningColumn.Name!="Pericoloso")
                        { 
                    keyValuePair.Add(cell.OwningColumn.Name, cell.Value);
                    }
                    else if (cell.GetType()==typeof(DataGridViewCheckBoxCell))

                    {
                        DataGridViewCheckBoxCell cellB = (DataGridViewCheckBoxCell)cell;
                        if ((bool)cellB.EditedFormattedValue == false)
                        {
                            keyValuePair.Add(cell.OwningColumn.Name, false);
                            cellB.Style=csDisabled;
                         
                        }
                        else
                        {
                            keyValuePair.Add(cell.OwningColumn.Name, true);
                        }

                    }else
                        if (cell.GetType() == typeof(DataGridViewComboBoxCell))

                    {
                        DataGridViewComboBoxCell cellB = (DataGridViewComboBoxCell)cell;
                       
                            keyValuePair.Add(cell.OwningColumn.Name, cellB.Value);
                       

                    }




                }

            object tempValue = null;
            //passeggero = Convert.ToInt32(rowValues[0]);
            keyValuePair.TryGetValue("Id_Materiale", out tempValue);
            Int32 idMateriale = Convert.ToInt32(tempValue);
            keyValuePair.TryGetValue("Quantita_Materiale", out tempValue);
            short qtaMateriale = Convert.ToInt16(tempValue);
            keyValuePair.TryGetValue("Descrizione_Materiale", out tempValue);
            string descMateriale = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Lunghezza_Materiale", out tempValue);
            string lungMateriale = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Altezza_Materiale", out tempValue);
            string altMateriale = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Profondita_Materiale", out tempValue);
            string profMateriale = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Peso_Materiale", out tempValue);
            string pesoMateriale = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Valore_Materiale", out tempValue);
            string ValoreMateriale = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Matricola", out tempValue);
            string Matricola = Convert.ToString(tempValue);
             
            keyValuePair.TryGetValue("Pericoloso", out tempValue);
         
            bool pericoloso = Convert.ToBoolean(tempValue);
            keyValuePair.TryGetValue("UN_Code", out tempValue);
            string unCode = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Classe_Rischio", out tempValue);
            string classeR = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Compatibilita", out tempValue);
            string compat = Convert.ToString(tempValue);
            keyValuePair.TryGetValue("Peso_Pericoloso", out tempValue);
            string pesoPericoloso = Convert.ToString(tempValue);

            BLWriteMiutes bLWrite = new BLWriteMiutes();
          


                LBLStatus.Visible = true;
                LBLStatus.Text = "Updating.....";
                LBLStatus.Refresh();

                
                if (bLWrite.updateMaterialeWithTransaction(idMateriale, qtaMateriale, Matricola, descMateriale, ValoreMateriale, lungMateriale, altMateriale, profMateriale, pesoMateriale, pericoloso, pesoPericoloso, unCode, classeR, compat))
                {  

                    DGVMatContainer.DataSource = bLWrite.GetMateriale_Container();
                   
                    DGVMatContainer.CurrentCell = DGVMatContainer.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().ElementAt(2);
                    //DGVMatContainer.AllowUserToAddRows = false;
                    this.DGVMatContainer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CheckValueCell_Changed);
                    this.DGVMatContainer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellEndEdit);
                    LBLStatus.Visible = false;
                    LBLStatus.Text = "Updating.....";
                    LBLStatus.Refresh();

                }
                else
            {
                int i= 0;


                DGVMatContainer.AllowUserToAddRows = false;
                    DGVMatContainer.Rows.OfType<DataGridViewRow>().Last().Selected = true;

                    this.DGVMatContainer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CheckValueCell_Changed);
                    MessageBox.Show("Check reuqired");

                return;
            }
            }
            catch (Exception ex){ }

        }
        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }
    
        private bool ValidateCurrentRow(DataGridViewRow row)
        {
            controlliValidati = new Dictionary<string, bool>();
            bool validated = true; ;
            foreach (DataGridViewCell e in row.Cells)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex != -1)
                {
 
                    object currControl = null; ;

                    DataGridViewCell currControl1 = (DataGridViewCell)DGVMatContainer[e.ColumnIndex, e.RowIndex];
                    if (currControl1.GetType() == typeof(DataGridViewTextBoxCell))
                        currControl = (DataGridViewTextBoxCell)currControl1;
                    if (currControl1.GetType() == typeof(DataGridViewCheckBoxCell))
                        currControl = (DataGridViewCheckBoxCell)currControl1;
                    if (currControl1.GetType() == typeof(DataGridViewComboBoxCell))
                        currControl = (DataGridViewComboBoxCell)currControl1;

                    if (requiredFieldTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || requiredIfDangerousCB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) && DGVMatContainer.Columns[e.ColumnIndex].Name != "UN_Code")
                    {


                        string currvaluecell = Convert.ToString(DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        if (currvaluecell != null)
                        {

                            if (numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                var isNumeric = false;
                                try
                                {
                                    Int32 isnumero = Convert.ToInt32(currvaluecell);
                                    isNumeric = true;
                                }
                                catch { isNumeric = false; }

                                 // isNumeric = Int32.TryParse(currvaluecell, out Int32 n);
                                if (!isNumeric)
                                {

                                    //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.EditedFormattedValue = String.Empty;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                                     



                                    validated = false;
                                }
                                else
                                    if (n < 0)
                                {
                                    // MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.EditedFormattedValue = String.Empty;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                          
                                    // SetValue(sender, e);
                                    validated = false;
                                }
                                else
                                {
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                                    validated = true;
                                }
                            }
                            if (decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                var isNumeric = false;
                                try
                                {
                                    Int32 isnumero = Convert.ToInt32(currvaluecell.Trim());
                                    isNumeric = true;
                                }
                                catch { isNumeric = false; }
                               
                                if (!isNumeric)
                                {
                                    // MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // currControl.EditedFormattedValue = String.Empty;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
         



                                    // SetValue(sender, e);
                                    validated = false;

                                }
                                else
                                    if (n < 0)
                                {
                                    //MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.Value = String.Empty;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                                     
                                    //SetValue(sender, e);
                                    validated = false;
                                }
                                else
                                {
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;
                                    validated = true;

                                }
                            }
                          
                            if (decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                var isNumeric = false;
                                try
                                {
                                    Int32 isnumero = Convert.ToInt32(currvaluecell.Trim());
                                    isNumeric = true;
                                }
                                catch { isNumeric = false; }
                                if (!isNumeric)
                                {
                                    // MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // currControl.EditedFormattedValue = String.Empty;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;




                                    // SetValue(sender, e);
                                    validated = false;

                                }
                                else
                                    if (n < 0)
                                {
                                    //MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.Value = String.Empty;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                                    //SetValue(sender, e);
                                    validated = false;
                                }
                                else
                                {
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;
                                    validated = true;

                                }
                            }


                        }
                        if (((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue== true))
                        {
                            if (requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                var isNumeric = false;
                                try
                                {
                                    Int32 isnumero = Convert.ToInt32(currvaluecell);
                                    isNumeric = true;
                                }
                                catch { isNumeric = false; }
                                if (!isNumeric)
                                {

                                    //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.EditedFormattedValue = String.Empty;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;




                                    validated = false;
                                }
                                else
                                    if (n < 0)
                                {
                                    // MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.EditedFormattedValue = String.Empty;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                                    // SetValue(sender, e);
                                    validated = false;
                                }
                                else
                                {
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                                    validated = true;
                                }
                            }
                            if (DGVMatContainer.Columns[e.ColumnIndex].Name == "UN_Code")
                        {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                var isNumeric = false;
                                try
                                {
                                    Int32 isnumero = Convert.ToInt32(((DataGridViewTextBoxCell)currControl).EditedFormattedValue.ToString().Trim());
                                    isNumeric = true;
                                }
                                catch { isNumeric = false; }
                               
                            if (!isNumeric)
                            {
                                //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;


                                validated = false;
                            }
                            else
                                if (n < 0)
                            {
                                //MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                                // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bkupRow.Cells[e.ColumnIndex].Value;

                                validated = false;
                            }
                            else //siamo nela caso >=0
                            {
                                if ((n <= 4000 && n >= 0) || n == 8000)
                                {
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;//OK
                                        validated = true;
                                        // DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].Value = true;
                                    }
                                else
                                {
                                    // MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;


                                    validated = false;
                                }
                            }
                        }
                        if (requiredIfDangerousCB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                        {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                if (((DataGridViewComboBoxCell)currControl).EditedFormattedValue.ToString()=="")
                                {
                                    ((DataGridViewComboBoxCell)currControl).Style = csOrange;
                                    validated = false;
                                }
                                else
                                {
                                    ((DataGridViewComboBoxCell)currControl).Style = csWhite;
                                    validated = true;
                                }

                            }
                            if (notRequired.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;
                                validated = true;
                            }


                        }
                        else if (requiredIfDangerousCB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || DGVMatContainer.Columns[e.ColumnIndex].Name == "UN_Code"|| requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                        {
                           
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csDisabled;
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                            DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].Value = null;
                            DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].Value = null;
                            DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Compatibilita"].Value = "";
                            validated = true;
                          
                        }
                    }
                    else
                        {

                            validated = false;



                            //currControl.Focus();

                            //if (numericFieldMoreThanZeroTB.Contains(currControl.Name) || decimaFieldMoreThanZeroTB.Contains(currControl.Name)|| requiredIfDangerousTB.Contains(currControl.Name))

                        }
                        //if (numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                        //    cellcurrifwrongdecimalornumbervalue = "0";
                    }








                   

                   
                if(!notRequired.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) && !(DGVMatContainer.Columns[e.ColumnIndex].Name=="Delete")&& !(DGVMatContainer.Columns[e.ColumnIndex].Name == "Id_Materiale") && !(DGVMatContainer.Columns[e.ColumnIndex].Name == "Pericoloso"))
                { 
                if (!controlliValidati.ContainsKey(DGVMatContainer.Columns[e.ColumnIndex].Name))
                {
                    if (validated)
                    {
                        controlliValidati.Add(DGVMatContainer.Columns[e.ColumnIndex].Name, true);
                    }
                    else
                    {
                        controlliValidati.Add(DGVMatContainer.Columns[e.ColumnIndex].Name, false);
                    }
                }
                else//VALE L'ULTIMA VALIDAZIONE

                {
                    controlliValidati.Remove(DGVMatContainer.Columns[e.ColumnIndex].Name);
                    if (validated)
                    {
                        controlliValidati.Add(DGVMatContainer.Columns[e.ColumnIndex].Name, true);
                    }
                    else
                    {
                        controlliValidati.Add(DGVMatContainer.Columns[e.ColumnIndex].Name, false);
                    }
                }


            }
            }
            foreach (bool cv in controlliValidati.Values)
            {
                if (cv == false)
                    return false;
            }
                return true;  

        }

        //private void CheckValueCell_LEave(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex >= 0 && e.RowIndex != -1)
        //    {

        //        int roind = e.RowIndex;
        //        //if (e.rowindex > 0)
        //        //    roind;
        //        object currControl = null; ;

        //        DataGridViewCell currControl1 = (DataGridViewCell)DGVMatContainer[e.ColumnIndex, roind];
        //        if (currControl1.GetType() == typeof(DataGridViewTextBoxCell))
        //            currControl = (DataGridViewTextBoxCell)currControl1;
        //        if (currControl1.GetType() == typeof(DataGridViewCheckBoxCell))
        //            currControl = (DataGridViewCheckBoxCell)currControl1;
        //        if (currControl1.GetType() == typeof(DataGridViewComboBoxCell))
        //            currControl = (DataGridViewComboBoxCell)currControl1;
        //        string currvaluecell = Convert.ToString(DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value);
        //        if (numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
        //        {
        //            var isNumeric = Int32.TryParse(currvaluecell, out Int32 n);
        //            if (!isNumeric)
        //            {

        //                //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                //currControl.EditedFormattedValue = String.Empty;
        //                DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
        //               // DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";



                    
        //            }
        //            else
        //                if (n < 0)
        //            {
        //                // MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                //currControl.EditedFormattedValue = String.Empty;
        //                DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
        //                // DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";
        //                // SetValue(sender, e);

        //            }
        //            else
        //            {
        //                DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style.BackColor = Color.White;

        //            }
        //        }
        //        if (decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
        //        {
        //            var isNumeric = decimal.TryParse(currvaluecell.Trim(), out decimal n);
        //            if (!isNumeric)
        //            {
        //                //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                // currControl.EditedFormattedValue = String.Empty;
        //                DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
        //                // DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";



        //                // SetValue(sender, e);


        //            }
        //            else
        //                if (n < 0)
        //            {
        //                // MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                //currControl.Value = String.Empty;
        //                DGVMatContainer.Rows[roind ].Cells[e.ColumnIndex].Style = csOrange;
        //                //DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";
        //                //SetValue(sender, e);

        //            }
        //            else
        //            {
        //                DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csWhite;


        //            }
        //        }


        //        if (notRequired.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
        //        {
        //            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csWhite;

        //        }

        //    }
        //}

        private void Change_BGColor(object sender, DataGridViewCellEventArgs e)
        {
            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csgray;
            {
                if (DGVMatContainer.CurrentCell.ColumnIndex == 3)  //example-'Column index=4'
                {
                    DGVMatContainer.BeginEdit(true);
                }
            }

        }

        private void CheckValueCell_Changed(object sender, DataGridViewCellEventArgs e)
            {
          
            if (e.ColumnIndex >= 0 && e.RowIndex != -1)
            {
                int roind = e.RowIndex;
                //if (e.RowIndex > 0)
                //    roind--;
                object currControl = null; ;

                DataGridViewCell currControl1 = (DataGridViewCell)DGVMatContainer[e.ColumnIndex, roind];
                if (currControl1.GetType() == typeof(DataGridViewTextBoxCell))
                        currControl = (DataGridViewTextBoxCell)currControl1;
                if (currControl1.GetType() == typeof(DataGridViewCheckBoxCell))
                    currControl = (DataGridViewCheckBoxCell)currControl1;
                if (currControl1.GetType() == typeof(DataGridViewComboBoxCell))
                    currControl = (DataGridViewComboBoxCell)currControl1;
                string currvaluecell = Convert.ToString(DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value);
               
                    if (numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                    {
                        var isNumeric = Int32.TryParse(currvaluecell, out Int32 n);
                        if (!isNumeric)
                        {

                            MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //currControl.EditedFormattedValue = String.Empty;
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";




                        }
                        else
                            if (n < 0)
                        {
                            MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //currControl.EditedFormattedValue = String.Empty;
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";
                            // SetValue(sender, e);

                        }
                        else
                        {
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value.ToString().Replace(".", ",");
                        }
                    }
                    if (decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name)|| (requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))&& ((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue == true))
                    {
                        var isNumeric = decimal.TryParse(currvaluecell.Trim(), out decimal n);
                        if (!isNumeric)
                        {
                            MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // currControl.EditedFormattedValue = String.Empty;
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";



                            // SetValue(sender, e);


                        }
                        else
                            if (n < 0)
                        {
                            MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //currControl.Value = String.Empty;
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";
                            //SetValue(sender, e);

                        }
                        else
                        {
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csWhite;
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value.ToString().Replace(".", ",");

                    }
                    }
                    
                if (DGVMatContainer.Columns[e.ColumnIndex].Name == "UN_Code" && ((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue == true))
                {
                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                    var isNumeric = int.TryParse(((DataGridViewTextBoxCell)currControl).EditedFormattedValue.ToString().Trim().Trim(), out int n);
                    if (!isNumeric)
                    {
                        //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                        MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }
                    else
                        if (n < 0)
                    {
                        //MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                        // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bkupRow.Cells[e.ColumnIndex].Value;
                        MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else //siamo nela caso >=0
                    {
                        if ((n <= 4000 && n >= 0) || n == 8000)
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;//OK
                            DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value.ToString().Replace(".", ",");
                            // DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].Value = true;
                        }
                        else
                        {
                            // MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                            MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        }
                    }
                }

                if (notRequired.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                    {
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csWhite;

                    }

                }
 
            }



       
        private void activategrid(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DGVMatContainer.ClearSelection();//If you want
            BLWriteMiutes bLWrite = new BLWriteMiutes();
            DGVMatContainer.DataSource = bLWrite.GetMateriale_Container();
            DGVMatContainer.Rows.OfType<DataGridViewRow>().Last().Selected=true;
            if (ValidateCurrentRow(DGVMatContainer.Rows.OfType<DataGridViewRow>().Last()))
            {
                LBLStatus.Visible = true;
                LBLStatus.Text = "Updating.....";
                LBLStatus.Refresh();

                bLWrite.InsertMaterialeWithTransaction(0, "", "", "", "", "", "", "", false, "", "", "", "");
                DGVMatContainer.DataSource = bLWrite.GetMateriale_Container();
                LBLStatus.Visible = false;
                LBLStatus.Text = "Updating.....";
                LBLStatus.Refresh();
            }
            else
                MessageBox.Show("Impossibile inserire altra riga");
        }

        private void DGVMatContainer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BLWriteMiutes bLWrite = new BLWriteMiutes();

            if (ValidateCurrentRow(((DataGridView)sender).CurrentRow))
            {
                New_Row(sender, new DataGridViewRowEventArgs(DGVMatContainer.CurrentRow));
                DGVMatContainer.AllowUserToAddRows = false;
                this.DGVMatContainer.CellEndEdit -= new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellEndEdit);

            }
        }
    }
}
 