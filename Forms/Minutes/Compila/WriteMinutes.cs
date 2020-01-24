
using IMTS_MINUTES.BusinessLogic;
using IMTS_MINUTES.BusinessLogic.BLMinutes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace IMTS_MINUTES.Forms.Minutes.Compila
{
    
    public partial class WriteMinutes : Form
    {
        internal Int32 totqty = 0;
        internal decimal totWeight = 0;
        internal decimal totValue = 0;
        IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable currentDT = new IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable();
        string[] requiredFieldTB = new string[] { "Quantita_Materiale", "Valore_Materiale", "Lunghezza_Materiale", "Altezza_Materiale", "Profondita_Materiale", "Peso_Materiale", };
       
        string[] numericFieldMoreThanZeroTB = new string[] { "Quantita_Materiale" };
        string[] decimaFieldMoreThanZeroTB = new string[] { "Valore_Materiale", "Lunghezza_Materiale", "Altezza_Materiale", "Profondita_Materiale", "Peso_Materiale" };
        string[] notRequired = new string[] { "Descrizione_Materiale", "Matricola" };

        string[] requiredIfDangerousTB = new string[] { "UN_Code", "Peso_Pericoloso" };
        string[] requiredIfDangerousCB = new string[] { "Classe_Rischio", "Compatibilita" };

        //REQUIRED FIELD ADN not REQUIRED OF FORM
        string[] requiredFieldTBFORM = new string[] { "ALL" };
        string[] requiredFieldCBFORM = new string[] { "CBContainerType" };
        string[] numericFieldMoreThanZeroTBFORM = new string[] { "TBNcopie", "TBMinuteNR" };
        string[] decimaFieldMoreThanZeroTBFORM = new string[] { "TBValore"  };
        string[] requiredIfDangerousCeckBox = new string[] { "Pericoloso" };
        string[] notRequiredFORM = new string[] {   };

        

        //end

        Dictionary<string, bool> controlliValidati = new Dictionary<string, bool>();
        bool cellcurribolean = false;
   
        DataGridViewCellStyle csgray = new DataGridViewCellStyle();
        DataGridViewCellStyle csOrange = new DataGridViewCellStyle();
        DataGridViewCellStyle csWhite= new DataGridViewCellStyle();
        DataGridViewCellStyle csDisabled = new DataGridViewCellStyle();
        Int32 statoForm = 0;
        public WriteMinutes(Int32 StatoForm)
        {
            InitializeComponent();
            statoForm = StatoForm;
        }
   
        bool doevent = true;
        bool validated = true;
     
     


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
            CBContainerType.DataSource = BLA.getContainers();
            CBContainerType.DisplayMember = "Desc_TypeContainer";
            CBContainerType.ValueMember = "Id_TypeContainer";
            CBContainerType.SelectedIndex = -1;

        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        private void LeaveField_Event(object sender, EventArgs e)
        {
           
                if (sender.GetType() == typeof(ComboBox))
                {
                    ComboBox currControl = (ComboBox)sender;
                    if (  requiredFieldCBFORM.Contains(currControl.Name))
                        if (currControl.SelectedIndex != -1 || currControl.FindStringExact(currControl.SelectedText) != -1)
                        {

                            currControl.BackColor = Color.White;
                        }
                        else
                        {
                            //currControl.Focus();

                        }
                }

            if (sender.GetType() == typeof(MaskedTextBox))
            {

                MaskedTextBox currControl = (MaskedTextBox)sender;
                if (currControl.Text.Trim() != "")
                {
                    currControl.BackColor = Color.White;
                }
                else
                    currControl.BackColor = Color.White;

            }
                if (sender.GetType() == typeof(TextBox))
            {

                TextBox currControl = (TextBox)sender;

                if (requiredFieldTBFORM.Contains("ALL") || numericFieldMoreThanZeroTBFORM.Contains(currControl.Name) || decimaFieldMoreThanZeroTB.Contains(currControl.Name))
                {
                    if (currControl.Text.Trim() != "")
                    {
                        if (numericFieldMoreThanZeroTBFORM.Contains(currControl.Name))
                        {
                            Int32 isnumero = 0;
                            var isNumeric = false;
                            try
                            {
                                  isnumero = Convert.ToInt16(currControl.Text.Trim());
                                isNumeric = true;
                            }
                            catch { isNumeric = false; }
                       
                            if (!isNumeric)
                            {
                                MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                currControl.Text = String.Empty;
                                currControl.BackColor = Color.Orange;
                                currControl.Text = "0";
                                //currControl.Focus();

                            }
                            else
                                if (isnumero < 0)
                            {
                                MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                currControl.Text = String.Empty;
                                currControl.BackColor = Color.Orange;
                                currControl.Text = "0";
                                // currControl.Focus();
                            }
                            else { currControl.BackColor = Color.White; }
                        }
                        if (decimaFieldMoreThanZeroTBFORM.Contains(currControl.Name))
                        {
                            decimal isnumero = 0;
                            var isNumeric = false;
                            try
                            {
                                isnumero = Convert.ToDecimal(currControl.Text.Trim());
                                isNumeric = true;
                            }
                            catch { isNumeric = false; }
                            if (!isNumeric)
                            {
                                MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                currControl.Text = String.Empty;
                                currControl.BackColor = Color.Orange;
                                currControl.Text = "0";
                                //currControl.Focus();

                            }
                            else
                                if (isnumero < 0)
                            {
                                MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                currControl.Text = String.Empty;
                                currControl.BackColor = Color.Orange;
                                currControl.Text = "0";
                                // currControl.Focus();
                            }
                            else { currControl.BackColor = Color.White; }
                        }
                        if (requiredFieldTBFORM.Contains(currControl.Name))
                            currControl.BackColor = Color.White;
                    }
                    else
                    {




                        if (numericFieldMoreThanZeroTBFORM.Contains(currControl.Name) || decimaFieldMoreThanZeroTB.Contains(currControl.Name))
                            currControl.Text = "0";
                        currControl.Focus();

                        //if (numericFieldMoreThanZeroTB.Contains(currControl.Name) || decimaFieldMoreThanZeroTB.Contains(currControl.Name)|| requiredIfDangerousTB.Contains(currControl.Name))

                    }
                    if (requiredFieldTBFORM.Contains("ALL"))
                    {
                        if (currControl.Text.Trim() != "")
                        {
                            currControl.BackColor = Color.White;
                        }



                    }

                    if (notRequired.Contains(currControl.Name))
                    {
                        currControl.BackColor = Color.White;
                    }
                }
            }
        }


        private bool checkIsDecima(string value)
        {
            decimal isnumero = 0;
            var isNumeric = false;
            try
            {
                isnumero = Convert.ToDecimal(value);
                isNumeric = true;
            }
            catch { isNumeric = false; }
            if (!isNumeric)
            {
                return false;
            }
            else
                if (isnumero <= 0)
            {
                return false;
            }
            else
                return true;
        }
        private bool checkIsNumeric(string value)
        {
            Int32 isnumero = 0;
            var isNumeric = false;
            try
            {
                isnumero = Convert.ToInt16(value);
                isNumeric = true;
            }
            catch { isNumeric = false; }

            if (!isNumeric)
            {
                return false;
            }
            else
                if (isnumero <= 0)
            {
                return false;
            }
            else
                return true;
        }
        private void EnterField_Event(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBox))
            {
                ComboBox currControl = (ComboBox)sender;
                currControl.BackColor = Color.LightGray;
            }
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox currControl = (TextBox)sender;
                currControl.BackColor = Color.LightGray;
            }
        }
        private void ChangeGBColorRequiredAndSetEvent()
        {
            var controlRQTB = GetAll(this, typeof(TextBox));
            var controlRQCB = GetAll(this, typeof(ComboBox));
            var controlRQMTB = GetAll(this, typeof(MaskedTextBox));
           
            foreach (TextBox control1 in controlRQTB)
            {

                TextBox control = (TextBox)control1;
                if (notRequired.Contains(control.Name))
                {
                    control.BackColor = Color.White;
                }
                else
                {
                    if (requiredFieldTBFORM.Contains("ALL") && control.Text.Trim() == "" )
                        control.BackColor = Color.Orange;
                    else

                        control.BackColor = Color.White;
                    if (numericFieldMoreThanZeroTBFORM.Contains(control.Name)  &&!checkIsNumeric(control.Text.Trim()))
                        control.BackColor = Color.Orange;
                    
                    if (decimaFieldMoreThanZeroTBFORM.Contains(control.Name) && !checkIsDecima(control.Text.Trim()) ) 
                        control.BackColor = Color.Orange;
                    



                }
                control.Enter += new System.EventHandler(this.EnterField_Event);
                control.Leave += new System.EventHandler(this.LeaveField_Event);
                // control.Enter+=
            }
            foreach (Control control1 in controlRQCB)
            {
                ComboBox control = (ComboBox)control1;
                if (requiredFieldCBFORM.Contains(control.Name) && control.SelectedIndex == -1)
                {
                    control.BackColor = Color.Orange;
                }
                else
                    control.BackColor = Color.White;
                control.Enter += new System.EventHandler(this.EnterField_Event);
                control.Leave += new System.EventHandler(this.LeaveField_Event);
            }
            foreach (Control control1 in controlRQMTB)
            {
                MaskedTextBox control = (MaskedTextBox)control1;
                if (notRequired.Contains(control.Name))
                {
                    control.BackColor = Color.White;
                }
                else
                {
                    if (requiredFieldTBFORM.Contains("All") && control.Text.Trim() == "")
                    {
                        control.BackColor = Color.Orange;
                        control.Mask = " 00/00/0000";
                        control.BackColor = Color.Orange;
                    }else
                        control.BackColor = Color.White;


                }
              
                control.Enter += new System.EventHandler(this.EnterField_Event);
                control.Leave += new System.EventHandler(this.lfbirthdate);

            }
        }

       
        private void lfbirthdate(object sender, EventArgs e)
        {
            MaskedTextBox ctrl = ((MaskedTextBox)(sender));
            if (ctrl.MaskCompleted)
            {

                DateTime data = DateTime.MinValue;
                var validDae = false;
                try
                {
                    data = Convert.ToDateTime(ctrl.Text.Trim());
                    validDae = true;
                }
                catch { validDae = false; }
               
                if (validDae)
                {
                    if (ctrl.Text.Trim() != String.Empty)
                    {
                        ctrl.BackColor = Color.White;
                    }
                    else
                    {
                        ctrl.BackColor = Color.Orange;
                    }
                    ctrl.Refresh();
                }
                else
                {
                    MessageBox.Show("InvalidDate", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctrl.Focus();
                    ctrl.BackColor = Color.Orange;
                }

            }
            else
            {

                ctrl.Focus();
                ctrl.BackColor = Color.Orange;
            }

        }

       
        private void WriteMinutes_Load(object sender, EventArgs e)
        {
            FillCombo();
            BLWriteMiutes writeMinutes = new BLWriteMiutes();
            if (statoForm ==0)
            {
                try
            {

                    IMTS_MINUTES.DataBase.IMTSDB_NEW.MinuteRow minuteRow = writeMinutes.getMinuteRow();
                if (minuteRow != null)
                {

                    //carico la form

                    TBAnnoCostruzione.Text = minuteRow.Anno_Costruzione;
                    TBCaserma.Text = minuteRow.Presso_Caserma;
                    TBCHisuraContainer.Text = minuteRow.Operazione_Container;
                    TBCommPresidente.Text = minuteRow.Presidente_Commissione;
                    TBCommSegretario.Text = minuteRow.Segretario_Commissione;
                    TBDestination.Text = minuteRow.Destinazione;
                    TBdestinatoAl.Text = minuteRow.Destinazione_Container;
                    TBLuogoChiususra.Text = minuteRow.Luogo_Chiusura;
                    TBMatMotore.Text = minuteRow.SNMotore;
                    TBMember.Text = minuteRow.Membro_Commissione;
                    TBMinuteNR.Text = minuteRow.Verbale_Number;
                    TBNcopie.Text = minuteRow.NCopie.ToString();
                    TBOrdineGiorno.Text = minuteRow.Ordine_Giorno_NR;
                    TBPresso.Text = minuteRow.Presso_Luogo;
                    TBRepMittente.Text = minuteRow.Mittente;
                    TBResponsabileChiususra.Text = minuteRow.Responsabile_Chiusura;
                    TBSNPlates.Text = minuteRow._Matricola_targa;
                    TBStoccaggio.Text = minuteRow.Terminale_Stoccaggio;
                    TBTara.Text = minuteRow.Tara;
                    TBTelaioNR.Text = minuteRow.Telaio;
                    TBTipoCarburante.Text = minuteRow.Tipo_Carburante;
                    TBValore.Text = minuteRow.Valore;
                    TBVector.Text = minuteRow.Vettore_Trasporto;
                    LBLChiusuraDinamica.Text = "To closure of container : " + minuteRow.Container_Descrizione + " with Seal NR.";
                    MBDateMinute.Text = minuteRow.Data_Acquisizione_Verbale.ToShortDateString();
                    MBIndateCommission.Text = minuteRow.Data_Provvedimento.ToShortDateString();
                    MTBDataChiusura.Text = minuteRow.Data_Chiusura.ToShortDateString();
                    CBContainerType.SelectedIndex = CBContainerType.FindString(minuteRow.Container_Descrizione);
                        DGVMatContainer.DataSource = writeMinutes.GetMateriale_Container();
                        CaclcolaTotali(writeMinutes.GetMateriale_Container());
                        Int32 getLastIdInDataTable = writeMinutes.GetMateriale_Container().Last().Id_Materiale;
                        DataGridViewRow last = null;


                        foreach (DataGridViewRow row in DGVMatContainer.Rows)
                        {
                            if ((Int32)row.Cells["Id_Materiale"].Value == getLastIdInDataTable)
                            {
                                //if (ValidateCurrentRow(row))
                                //    valedate = true;
                                last = row;

                            }
                        }
                        last.Cells["Quantita_Materiale"].Selected = true;

                    }
            }
            catch
            {
              
                //dsStatici.Materiale_Container.WriteXml(Utils.getBasePathName + "Materiale_Container.xml", XmlWriteMode.WriteSchema); 
            }
        }
        else if(statoForm==1)
            {
                IMTS_MINUTES.DataBase.IMTSDB_NEW dsStatici = new IMTS_MINUTES.DataBase.IMTSDB_NEW();
                dsStatici.Minute.WriteXml(Utils.getBasePathName + "Minute.xml", XmlWriteMode.WriteSchema);
                dsStatici.Minute.WriteXml(Utils.getBasePathName + "Materiale_Container.xml", XmlWriteMode.WriteSchema);
            }
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
          

        



            ChangeGBColorRequiredAndSetEvent(); //cambio colore ai campi obbligatori;
            SetDecimalTB();
            TBNcopie.Focus();
            //TBNcopie.BackColor = Color.LightGray;

           



        }
        private void SetDecimalTB()
        {
            var controlRQCB = GetAll(this, typeof(TextBox));
            foreach (TextBox control1 in controlRQCB)
            {

                if (decimaFieldMoreThanZeroTBFORM.Contains(control1.Name))
                    control1.TextChanged += new EventHandler(TBDecimal_EvChanged);
            }
        }
        private void TBDecimal_EvChanged(object sender, EventArgs e)
        {
            TextBox cerrTb = (TextBox)sender;
            cerrTb.Text = cerrTb.Text.Replace(".", ",");
            cerrTb.SelectionStart = cerrTb.Text.Length;
            //cerrTb.Focus();
        }
        

 
 
        private void EnterField_Event(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewTextBoxCell
            //if (sender.GetType() == typeof(ComboBox))
            //{
            //    ComboBox currControl = (ComboBox)sender;
            //    currControl.BackColor = Color.LightGray;
            //}
            if (doevent)
            { 
                if (requiredFieldTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name)||requiredIfDangerousCeckBox.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))

            {
                //DGVMatContainer.Rows[e.RowIndex].Cells[DGVMatContainer.Columns[e.ColumnIndex].Name].Style.SelectionBackColor = Color.LightGray;
                //    DGVMatContainer.Rows[e.RowIndex].Cells["Quantita_Materiale"].Style.SelectionBackColor = Color.LightGray;
                    if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewTextBoxCell))
                    {

                        DataGridViewTextBoxCell currCell = (DataGridViewTextBoxCell)DGVMatContainer.CurrentCell;
                        
                        currCell.Style = csgray;

                    }
                    if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
                    {

                        DataGridViewCheckBoxCell currCell = (DataGridViewCheckBoxCell)DGVMatContainer.CurrentCell;
                        DataGridViewCellStyle cs = new DataGridViewCellStyle();
                       // DGVMatContainer. .CurrentCell = DGVMatContainer.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().ElementAt(e.ColumnIndex+1);
                        currCell.Style = csgray;
                        currCell.Value = false;
                    }

                   
             
                        if (((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].Value))
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csDisabled;
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                            if (DGVMatContainer.Columns[e.ColumnIndex].Name == "UN_Code")
                                DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].ReadOnly = true;
                            if (DGVMatContainer.Columns[e.ColumnIndex].Name == "Peso_Pericoloso")
                                DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].ReadOnly = true;
                            if (DGVMatContainer.Columns[e.ColumnIndex].Name == "Classe_Rischio")
                                DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].ReadOnly = true;
                            if (DGVMatContainer.Columns[e.ColumnIndex].Name == "Classe_Rischio")
                                DGVMatContainer.Rows[e.RowIndex].Cells["Compatibilita"].ReadOnly = true;
                        }
                    }
             
            }
        }

        private void LeaveField_Event(object sender, DataGridViewCellEventArgs e)
        {

            // SetValue(sender,e);


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

                if (requiredFieldTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) && DGVMatContainer.Columns[e.ColumnIndex].Name != "UN_Code")
                {


                    string currvaluecell = Convert.ToString(DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (currvaluecell != null)
                    {

                        if (numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                        {
                            var isNumeric = false;
                            Int32 numero = 0;
                            try
                            {
                                numero = Convert.ToInt32(currvaluecell);
                                isNumeric = true;
                            }
                            catch { isNumeric = false; }
                            if (!isNumeric)
                            {
                                
                                MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //currControl.EditedFormattedValue = String.Empty;
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";



                                 validated = false;
                            }
                            else
                                if (numero < 0)
                            {
                                MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //currControl.EditedFormattedValue = String.Empty;
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                                // SetValue(sender, e);
                                validated = false;
                            }
                            else { DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                                
                            }
                        }
                        if (decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                        {
                             
                            var isNumeric = false;
                            decimal numero = 0;
                            try
                            {
                                numero = Convert.ToDecimal(currvaluecell.Trim());
                                isNumeric = true;
                            }
                            catch { isNumeric = false; }
                            if (!isNumeric)
                            {
                                MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                // currControl.EditedFormattedValue = String.Empty;
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;



                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                                // SetValue(sender, e);
                                validated = false;

                            }
                            else
                                if (numero < 0)
                            {
                                MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //currControl.Value = String.Empty;
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                                //SetValue(sender, e);
                                validated = false;
                            }
                            else
                            {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;
                                
                            
                            }
                        }


                        if (notRequired.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;
                           
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
       

                     
                    if (DGVMatContainer.Columns[e.ColumnIndex].Name == "Pericoloso")
                    {
                        DataGridViewCheckBoxCell currControlCB = (DataGridViewCheckBoxCell)currControl1;
                        if ((bool)currControlCB.EditedFormattedValue == false)
                            if (cellcurribolean)
                            {
                                cellcurribolean = false;
                                currControlCB.Value = false;
                         
                                // currControlCB.DataGridView.Refresh();

                                // DGVMatContainer.EditingControl.Refresh();
                            }
                            else
                            {
                                cellcurribolean = true;
                                currControlCB.Value = true;
                                //currControlCB.DataGridView.Refresh();
                               

                            }
                        // if (DGVMatContainer.Rows[e.RowIndex + 1].IsNewRow)
                        //DGVMatContainer.Rows.RemoveAt(e.RowIndex + 1);
                        //    DGVMatContainer.Refresh();

                    }


                    //    if (requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                    //    { 

                    //        var isNumeric = decimal.TryParse(((DataGridViewTextBoxCell)currControl).EditedFormattedValue.ToString().Trim(), out decimal n);
                    //    if (!isNumeric)
                    //    {
                    //        MessageBox.Show("Invalid decimal number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Orange;

                    //        cellcurrifwrongdecimalornumbervalue = "0";

                    //    }
                    //    else
                    //        if (n < 0)
                    //    {
                    //        MessageBox.Show("number  must be more than 0 and decimal separated with .", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Orange;

                    //        cellcurrifwrongdecimalornumbervalue = "0";
                    //    }
                    //    else { DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; }
                    //}
                    //else
                    if (DGVMatContainer.Columns[e.ColumnIndex].Name == "UN_Code")
                    {
                       
                    var isNumeric = false;
                    Int32 numero = 0;
                    try
                    {
                        numero = Convert.ToInt32(((DataGridViewTextBoxCell)currControl).EditedFormattedValue.ToString().Trim());
                        isNumeric = true;
                    }
                    catch { isNumeric = false; }
                    if (!isNumeric)
                        {
                            MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                        DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                        validated = false;
                        }
                        else
                            if (numero < 0)
                        {
                            MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                        DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                        validated = false;
                        }
                        else //siamo nela caso >=0
                        {
                            if ((numero <= 4000 && numero >= 0) || numero == 8000)
                            {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;//OK
                            //DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].Value = true;
                            }
                            else
                            {
                                MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                            DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                            validated = true;
                            }
                        }
                    }

                    //  } //if (notRequired.Contains(currControl.Name))
                    //{
                    //    currControl.BackColor = Color.White;
                    //}
                    ///DGVMatContainer.EndEdit();
                }
               
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

 

        private void SetValue(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool ValidateBeforeInsertOrUpdateIntem()
        {
            bool result = true;
           

                        var controlsTb = GetAll(this, typeof(TextBox));
                        foreach (TextBox control in controlsTb)
                        {

                if (!(control.BackColor == Color.White))
                {
                    result = false;

                }
                


                        }

                        var controlscb = GetAll(this, typeof(MaskedTextBox));
                        foreach (MaskedTextBox control in controlscb)
                        {
                           
                                if (!(control.BackColor == Color.White))
                                {
                                    result = false;

                }
               
            }
                        var controlscb1 = GetAll(this, typeof(ComboBox));
                        foreach (ComboBox control in controlscb1)
                        {

                            if (requiredFieldCBFORM.Contains(control.Name))
                                if (!(control.BackColor == Color.White))
                                {
                                    result = false;

                    }
                    


            }


            return result;
                    
          
        }

        public void CaclcolaTotali(IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerDataTable dt)
        {
            totqty = 0;
            totValue = 0;
            totWeight = 0;
               CultureInfo cultures =new CultureInfo("it-IT");
            float num = float.Parse("1,5", cultures.NumberFormat);
            foreach (IMTS_MINUTES.DataBase.IMTSDB_NEW.Materiale_ContainerRow row in dt)
            {
                totqty += Convert.ToInt32(row.Quantità_Materiale, cultures.NumberFormat);
                if(row.Peso_Pericoloso!="")
                totWeight += Convert.ToDecimal(row.Peso_Materiale, cultures.NumberFormat)+ Convert.ToDecimal(row.Peso_Pericoloso, cultures.NumberFormat);
                else if (row.Peso_Materiale != "")
                    totWeight += Convert.ToDecimal(row.Peso_Materiale, cultures.NumberFormat)  ;
                if (row.Valore_Materiale != "")
                    totValue += Convert.ToDecimal(row.Valore_Materiale, cultures.NumberFormat);

            }
            TBTotalQTY.Text = Convert.ToString(totqty, cultures.NumberFormat);
            TBTotalValue.Text = Convert.ToString(totValue, cultures.NumberFormat); 
            TBTOtalWeight.Text = Convert.ToString(totWeight, cultures.NumberFormat);
            
            Totali.totqty = totqty;
            Totali.totValue = totValue;
            Totali.totWeight = totWeight;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DGVMatContainer.CellEndEdit -= new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellEndEdit);
            DGVMatContainer.ClearSelection();//If you want
            BLWriteMiutes bLWrite = new BLWriteMiutes();
            DGVMatContainer.DataSource = bLWrite.GetMateriale_Container();
            CaclcolaTotali(bLWrite.GetMateriale_Container());
            Int32 getLastIdInDataTable = 0;
            bool valedate = false;
            DataGridViewRow last = null;
            bool valedate1 = false;
            if (DGVMatContainer.Rows.Count > 0)
            {
                 getLastIdInDataTable = bLWrite.GetMateriale_Container().Last().Id_Materiale;
              
                foreach (DataGridViewRow row in DGVMatContainer.Rows)
                {
                    if ((Int32)row.Cells["Id_Materiale"].Value == getLastIdInDataTable)
                    {
                        //if (ValidateCurrentRow(row))
                        //    valedate = true;
                        last = row;
                        valedate = true;
                    }
                }


                //if (ValidateCurrentRow(DGVMatContainer.CurrentRow))
                if (ValidateCurrentRow(last))
                    valedate1 = true;
            }
            else
            {
                valedate = true;
                valedate1 = true;
            }
            // DGVMatContainer.Rows.OfType<DataGridViewRow>().Last().Selected = true;
            if (valedate&&valedate1)
            {
                LBLStatus.Visible = true;
                LBLStatus.Text = "Updating.....";
                LBLStatus.Refresh();

                bLWrite.InsertMaterialeWithTransaction(0, "", "", "", "", "", "", "", false, "", "", "", "");
                 getLastIdInDataTable = bLWrite.GetMateriale_Container().Last().Id_Materiale;
                DGVMatContainer.DataSource = bLWrite.GetMateriale_Container();
                LBLStatus.Visible = false;
                LBLStatus.Text = "Updating.....";
                LBLStatus.Refresh();
                foreach (DataGridViewRow row in DGVMatContainer.Rows)
                {
                    if ((Int32)row.Cells["Id_Materiale"].Value == getLastIdInDataTable)
                    {

                        last = row;
                        valedate = true;
                    }
                }
                // InitNewRow(last,false);
                 
                 last .Cells["Quantita_Materiale"].Selected = true;
                 
            }
            else
                MessageBox.Show("Impossibile inserire altra riga");
          
            DGVMatContainer.Refresh();
            this.DGVMatContainer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellEndEdit);
        }
        
            
        private void DGVMatContainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            BLWriteMiutes bLWrite = new BLWriteMiutes();
            if (DGVMatContainer.Rows.Count > 0)
            {
                if (DGVMatContainer.CurrentCell.OwningColumn.Name == ("Delete") && e.RowIndex != -1)
                {
                    if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewButtonCell))
                    {
                        bLWrite.DeleteMaterialeWithTransaction((Int32)DGVMatContainer.CurrentRow.Cells["Id_Materiale"].Value);
                        DGVMatContainer.DataSource = bLWrite.GetMateriale_Container();
                        CaclcolaTotali(bLWrite.GetMateriale_Container());
                        return;

                    }
                }
                if (DGVMatContainer.CurrentCell.OwningColumn.Name == ("Pericoloso") && e.RowIndex != -1)
                {
                    if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
                    {

                        if ((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue)
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].ReadOnly = false;
                            DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].ReadOnly = false;
                            DGVMatContainer.Rows[e.RowIndex].Cells["Compatibilita"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Compatibilita"].ReadOnly = false;
                            DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].ReadOnly = false;
                        }
                        else
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].ReadOnly = true;
                            DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].ReadOnly = true;
                            DGVMatContainer.Rows[e.RowIndex].Cells["Compatibilita"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Compatibilita"].ReadOnly = true;
                            DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].ReadOnly = true;
                        }
                        //DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].Value = DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue;


                    }

                }

                if (DGVMatContainer.CurrentCell.OwningColumn.Name == ("UN_Code") && e.RowIndex != -1)
                {
                    if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
                    {

                        if (!(bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue)
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].ReadOnly = true;
                        }





                    }

                }
                if (DGVMatContainer.CurrentCell.OwningColumn.Name == ("Classe_Rischio") && e.RowIndex != -1)
                {
                    if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
                    {

                        if (!(bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue)
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].ReadOnly = true;
                        }





                    }

                }
                if (DGVMatContainer.CurrentCell.OwningColumn.Name == ("Compatibilita") && e.RowIndex != -1)
                {
                    if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
                    {

                        if (!(bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue)
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells["Comatibilita"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Comatibilita"].ReadOnly = true;
                        }





                    }

                }
                if (DGVMatContainer.CurrentCell.OwningColumn.Name == ("Peso_Pericoloso") && e.RowIndex != -1)
                {
                    if (DGVMatContainer.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
                    {

                        if (!(bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue)
                        {
                            DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].Value = "";
                            DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].ReadOnly = true;
                        }




                    }

                }
            }
        }
        private void New_Row(object sender, DataGridViewRowEventArgs e)
        {
            try
            {

                DataGridViewRow dvrc = DGVMatContainer.CurrentRow;

                Dictionary<string, object> keyValuePair = new Dictionary<string, object>();
                foreach (DataGridViewCell cell in dvrc.Cells)
                {

                    //rowValues[cell.ColumnIndex] = cell.Value;
                    if (cell.OwningColumn.Name != "Pericoloso")
                    {
                        keyValuePair.Add(cell.OwningColumn.Name, cell.Value);
                    }
                    else if (cell.GetType() == typeof(DataGridViewCheckBoxCell))

                    {
                        DataGridViewCheckBoxCell cellB = (DataGridViewCheckBoxCell)cell;
                        if ((bool)cellB.EditedFormattedValue == false)
                        {
                            keyValuePair.Add(cell.OwningColumn.Name, false);
                            cellB.Style = csDisabled;

                        }
                        else
                        {
                            keyValuePair.Add(cell.OwningColumn.Name, true);
                        }

                    }
                    else
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
                    CaclcolaTotali(bLWrite.GetMateriale_Container());
                    DGVMatContainer.CurrentCell = DGVMatContainer.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().ElementAt(2);
                    //DGVMatContainer.AllowUserToAddRows = false;
                 
                    LBLStatus.Visible = false;
                    LBLStatus.Text = "Updating.....";
                    LBLStatus.Refresh();

                }
                else
                {
                    int i = 0;


                    DGVMatContainer.AllowUserToAddRows = false;
                    DGVMatContainer.Rows.OfType<DataGridViewRow>().Last().Selected = true;

                  
                    MessageBox.Show("Check reuqired");

                    return;
                }
            }
            catch (Exception ex) { }

        }

        private void BNSaveModify_Click(object sender, EventArgs e)
        {
            BLWriteMiutes blw = new BLWriteMiutes();
            if (ValidateBeforeInsertOrUpdateIntem())
            {
                if (blw.isMinutesEmpty())
                {

                    if (MessageBox.Show(ConfirmMessgeForm.AddMinute, "Add Minute", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        if (blw.InsertMinuteWithTransaction(Convert.ToInt32(TBNcopie.Text.Trim()), TBMinuteNR.Text.Trim(), (Int32)CBContainerType.SelectedValue, TBSNPlates.Text.Trim(), TBTara.Text.Trim(), TBValore.Text.Trim(), Convert.ToDateTime(MBDateMinute.Text.Trim()), TBPresso.Text.Trim(), TBCaserma.Text.Trim(), TBOrdineGiorno.Text.Trim(), Convert.ToDateTime(MBIndateCommission.Text.Trim()), TBCHisuraContainer.Text.Trim(), TBdestinatoAl.Text.Trim(), TBRepMittente.Text.Trim(), TBDestination.Text.Trim(), TBStoccaggio.Text.Trim(), TBVector.Text.Trim(), TBTelaioNR.Text.Trim(), TBMatMotore.Text.Trim(), TBAnnoCostruzione.Text.Trim(), TBTipoCarburante.Text.Trim(), TBCommPresidente.Text.Trim(), TBCommSegretario.Text.Trim(), TBMember.Text.Trim(), TBResponsabileChiususra.Text.Trim(), TBLuogoChiususra.Text.Trim(), Convert.ToDateTime(MTBDataChiusura.Text.Trim())))
                        {
                            MessageBox.Show(ResultMessgeForm.InsertOk, "Commit executed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(WarningMessgeForm.InsertFailed, "RollBack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                }
                else
                   if (MessageBox.Show(ConfirmMessgeForm.UpdateMinute, "Update Minute", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    if (blw.UpdateMinuteWithTransaction(blw.getMinuteRow().Id_Miniute, Convert.ToInt32(TBNcopie.Text.Trim()), TBMinuteNR.Text.Trim(), (Int32)CBContainerType.SelectedValue, TBSNPlates.Text.Trim(), TBTara.Text.Trim(), TBValore.Text.Trim(), Convert.ToDateTime(MBDateMinute.Text.Trim()), TBPresso.Text.Trim(), TBCaserma.Text.Trim(), TBOrdineGiorno.Text.Trim(), Convert.ToDateTime(MBIndateCommission.Text.Trim()), TBCHisuraContainer.Text.Trim(), TBdestinatoAl.Text.Trim(), TBRepMittente.Text.Trim(), TBDestination.Text.Trim(), TBStoccaggio.Text.Trim(), TBVector.Text.Trim(), TBTelaioNR.Text.Trim(), TBMatMotore.Text.Trim(), TBAnnoCostruzione.Text.Trim(), TBTipoCarburante.Text.Trim(), TBCommPresidente.Text.Trim(), TBCommSegretario.Text.Trim(), TBMember.Text.Trim(), TBResponsabileChiususra.Text.Trim(), TBLuogoChiususra.Text.Trim(), Convert.ToDateTime(MTBDataChiusura.Text.Trim())))
                    {
                        MessageBox.Show(ResultMessgeForm.UpdateOk, "Commit executed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(WarningMessgeForm.UpdateFailed, "RollBack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
            }

            else
                MessageBox.Show(WarningMessgeForm.FieldsRequired, "Fields required", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void change_tara(object sender, EventArgs e)
        {
            if(CBContainerType!=null)
            if ((int)CBContainerType.SelectedIndex>0)
            {
                BLAnagrafica bla = new BLAnagrafica();
                TBTara.Text = bla.getContainers().Select("Id_TypeContainer=" + CBContainerType.SelectedValue)[0][5].ToString();
                LBLChiusuraDinamica.Text = "To closure of container : " + bla.getContainers().Select("Id_TypeContainer=" + CBContainerType.SelectedValue)[0][1].ToString() + " with Seal NR.";                // If we also wanted to get the displayed text we could use
                // the SelectedItem item property:
                // string s = ((USState)ListBox1.SelectedItem).LongName;
            }
           
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
            bool validateDangerous = true;
            bool validated = true;
           if(row!=null)
            foreach (DataGridViewCell e in row.Cells)
            {
               if(e.ColumnIndex!=-1 && e.RowIndex!=-1)
                { 
                    object currControl = null; ;

                    DataGridViewCell currControl1 = (DataGridViewCell)DGVMatContainer[e.ColumnIndex, e.RowIndex];
                    if (currControl1.GetType() == typeof(DataGridViewTextBoxCell))
                        currControl = (DataGridViewTextBoxCell)currControl1;
                    if (currControl1.GetType() == typeof(DataGridViewCheckBoxCell))
                        currControl = (DataGridViewCheckBoxCell)currControl1;
                    if (currControl1.GetType() == typeof(DataGridViewComboBoxCell))
                        currControl = (DataGridViewComboBoxCell)currControl1;

                    if (requiredFieldTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || requiredIfDangerousCB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name)  )
                    {


                        string currvaluecell = Convert.ToString(DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        if (currvaluecell != null)
                        {

                            if (numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                    var isNumeric = false;
                                    Int32 numero = 0;
                                    try
                                    {
                                        numero = Convert.ToInt32(currvaluecell.Trim());
                                        isNumeric = true;
                                    }
                                    catch { isNumeric = false; }
                                    if (!isNumeric)
                                {

                                    //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.EditedFormattedValue = String.Empty;
                                   // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;




                                    validated = false;
                                }
                                else
                                    if (numero < 0)
                                {
                                    // MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.EditedFormattedValue = String.Empty;
                                   // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                                    // SetValue(sender, e);
                                    validated = false;
                                }
                                else
                                {
                                   /// DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                                    validated = true;
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
                                            return false;
                                        }
                                    }
                                }
                            }
                            if (decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                        
                                    var isNumeric = false;
                                    decimal numero = 0;
                                    try
                                    {
                                        numero = Convert.ToDecimal(currvaluecell.Trim());
                                        isNumeric = true;
                                    }
                                    catch { isNumeric = false; }
                                    if (!isNumeric)
                                {
                                    // MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // currControl.EditedFormattedValue = String.Empty;
                                   // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;




                                    // SetValue(sender, e);
                                    validated = false;

                                }
                                else
                                    if (numero < 0)
                                {
                                    //MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.Value = String.Empty;
                                   // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                                    //SetValue(sender, e);
                                    validated = false;
                                }
                                else
                                {
                                    validated = true;
                                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;
                                    if (!controlliValidati.ContainsKey(DGVMatContainer.Columns[e.ColumnIndex].Name))
                                    {


                                        if (validated)
                                        {
                                            controlliValidati.Add(DGVMatContainer.Columns[e.ColumnIndex].Name, true);
                                        }
                                        else
                                        {
                                            controlliValidati.Add(DGVMatContainer.Columns[e.ColumnIndex].Name, false);
                                            return false;
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
                                            return false;
                                        }
                                    }


                                }
                            }

                            if (decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                               
                                    var isNumeric = false;
                                    decimal numero = 0;
                                    try
                                    {
                                        numero = Convert.ToDecimal(currvaluecell.Trim());
                                        isNumeric = true;
                                    }
                                    catch { isNumeric = false; }
                                    if (!isNumeric)
                                {
                                    // MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // currControl.EditedFormattedValue = String.Empty;
                                   // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;




                                    // SetValue(sender, e);
                                    validated = false;

                                }
                                else
                                    if (numero < 0)
                                {
                                    //MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.Value = String.Empty;
                                   // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                                    //SetValue(sender, e);
                                    validated = false;
                                }
                                else
                                {
                                    validated = true;
                                    //DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;
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
                                            return false;
                                        }
                                    }


                                }
                            }


                        }
                        if (((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].Value ))
                        {
                            if (requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                 
                                    var isNumeric = false;
                                    Int32 numero = 0;
                                    try
                                    {
                                        numero = Convert.ToInt32(currvaluecell);
                                        isNumeric = true;
                                    }
                                    catch { isNumeric = false; }
                                    if (!isNumeric)
                                {

                                    //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //currControl.EditedFormattedValue = String.Empty;
                                   // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;




                                    validated = false;
                                }
                                else
                                    if (numero < 0)
                                {
                                        // MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        //currControl.EditedFormattedValue = String.Empty;
                                        // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;

                                        // SetValue(sender, e);
                                        validated = false;
                                }
                                else
                                {
                                    validated = true;
                                        // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
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
                                            return false;
                                        }
                                    }

                                }
                            }
                            else
                                validated = false;
                            if (DGVMatContainer.Columns[e.ColumnIndex].Name == "UN_Code" && currvaluecell != "")
                            {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                    var isNumeric = false;
                                    Int32 numero = 0;
                                    try
                                    {
                                        numero = Convert.ToInt32(((DataGridViewTextBoxCell)currControl).EditedFormattedValue.ToString().Trim());
                                        isNumeric = true;
                                    }
                                    catch { isNumeric = false; }
                                    
                                if (!isNumeric)
                                {
                                    //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                  //  DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;


                                    validated = false;
                                }
                                else
                                    if (numero < 0)
                                {
                                        //MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                                        // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bkupRow.Cells[e.ColumnIndex].Value;

                                        validated = false;
                                }
                                else //siamo nela caso >=0
                                {
                                    validated = true;
                                    if ((numero <= 4000 && numero >= 0) || numero == 8000)
                                    {
                                            // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;//OK
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
                                                return false;
                                            }
                                        }

                                        // DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].Value = true;
                                    }
                                    else
                                    {
                                            // MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;


                                            validated = false;
                                    }
                                }
                            }
                            else
                                validated = false;
                            if (requiredIfDangerousCB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                if (((DataGridViewComboBoxCell)currControl).EditedFormattedValue.ToString() == "")
                                {
                                        // ((DataGridViewComboBoxCell)currControl).Style = csOrange;
                                        validated = false;
                                }
                                else
                                {
                                    validated = true;
                                        // ((DataGridViewComboBoxCell)currControl).Style = csWhite;
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
                                            return false;
                                        }
                                    }

                                }

                            }
                            else
                                validated = false;
                            if (notRequired.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                            {
                                validated = true;
                                    // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csWhite;
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
                                        return false;
                                    }
                                }

                            }


                            if (DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                                validated = false;
                        }
                        else
                        if (requiredIfDangerousCB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) )
                        {

                            //DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csDisabled;
                            //DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                            //    if (DGVMatContainer.Columns[e.ColumnIndex].Name == "UN_Code")
                            //        DGVMatContainer.Rows[e.RowIndex].Cells["UN_Code"].ReadOnly = true;
                            //    if (DGVMatContainer.Columns[e.ColumnIndex].Name == "Peso_Pericoloso")
                            //        DGVMatContainer.Rows[e.RowIndex].Cells["Peso_Pericoloso"].ReadOnly = true;
                            //    if (DGVMatContainer.Columns[e.ColumnIndex].Name == "Classe_Rischio")
                            //        DGVMatContainer.Rows[e.RowIndex].Cells["Classe_Rischio"].ReadOnly = true;
                            //    if (DGVMatContainer.Columns[e.ColumnIndex].Name == "Classe_Rischio")
                            //        DGVMatContainer.Rows[e.RowIndex].Cells["Compatibilita"].ReadOnly = true;
                                validateDangerous = false;

                        }
                        else { validateDangerous = true; }




                    }


                //currControl.Focus{

                //if (numericFieldMoreThanZeroTB.Contains(currControl.Name) || decimaFieldMoreThanZeroTB.Contains(currControl.Name)|| requiredIfDangerousTB.Contains(currControl.Name))


                //if (numericFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                //    cellcurrifwrongdecimalornumbervalue = "0";









            }
                //if (!(bool)DGVMatContainer.Rows[e.RowIndex].Cells["pericoloso"].EditedFormattedValue == true)

                //{
               

            }
            if (row != null)
            {
                if ((bool)row.Cells["Pericoloso"].EditedFormattedValue == true)
                {
                    if (controlliValidati.Count == 10)
                    {
                        foreach (bool cv in controlliValidati.Values)
                        {
                            if (cv == false)
                                return false;
                        }

                    }
                    else return false;



                }
                else
                if (!(bool)row.Cells["Pericoloso"].EditedFormattedValue == true)
                {
                    if (controlliValidati.Count ==6)
                    {
                        foreach (bool cv in controlliValidati.Values)
                        {
                            if (cv == false)
                                return false;
                        }

                    }
                    else return false;



                }
            }
            return true;

        }

      

        private void DGVMatContainer_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void DGVMatContainer_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Tab)
            {
                this.DGVMatContainer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellEndEdit);
               
            }
        }

        private void DGVMatContainer_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            
            if (!(this.DGVMatContainer.Columns[e.ColumnIndex].Name == "Pericoloso"))
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
                    
                        var isNumeric = false;
                        Int32 numero = 0;
                        try
                        {
                            numero = Convert.ToInt32(currvaluecell);
                            isNumeric = true;
                        }
                        catch { isNumeric = false; }
                        if (!isNumeric)
                    {

                        MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //currControl.EditedFormattedValue = String.Empty;
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";




                    }
                    else
                        if (numero < 0)
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
                if (decimaFieldMoreThanZeroTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name) || (requiredIfDangerousTB.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name)) && ((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue == true))
                {
                   
                        var isNumeric = false;
                        decimal numero = 0;
                        try
                        {
                            numero = Convert.ToDecimal(currvaluecell.Trim());
                            isNumeric = true;
                        }
                        catch { isNumeric = false; }
                        if (!isNumeric)
                    {
                        MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // currControl.EditedFormattedValue = String.Empty;
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";



                        // SetValue(sender, e);


                    }
                    else
                        if (numero < 0)
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
                if( (bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue == true)
                        { 
                if (DGVMatContainer.Columns[e.ColumnIndex].Name == "UN_Code")//&& ((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue == true))
                {
                    DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                    
                            var isNumeric = false;
                            Int32 numero = 0;
                            try
                            {
                                numero = Convert.ToInt32(((DataGridViewTextBoxCell)currControl).EditedFormattedValue.ToString().Trim());
                                isNumeric = true;
                            }
                            catch { isNumeric = false; }
                            if (!isNumeric)
                    {
                        //MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                        MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }
                    else
                        if (numero < 0)
                    {
                        //MessageBox.Show("number  must be more than 0", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = csOrange;
                        // DGVMatContainer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bkupRow.Cells[e.ColumnIndex].Value;
                        MessageBox.Show("number  must be between 0 and 4000 or 8000", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else //siamo nela caso >=0
                    {
                        if ((numero <= 4000 && numero >= 0) || numero == 8000)
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
                if (DGVMatContainer.Columns[e.ColumnIndex].Name == "Peso_Pericoloso")// && ((bool)DGVMatContainer.Rows[e.RowIndex].Cells["Pericoloso"].EditedFormattedValue == true))
                {
                            var isNumeric = false;
                            
                            decimal numero = 0;
                            try
                            {
                                numero = Convert.ToDecimal(currvaluecell.Trim());
                                isNumeric = true;
                            }
                            catch { isNumeric = false; }
                            if (!isNumeric)
                    {
                        MessageBox.Show("Invalid number", "Wrong Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // currControl.EditedFormattedValue = String.Empty;
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csOrange;
                        DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Value = "0";



                        // SetValue(sender, e);


                    }
                    else
                        if (numero < 0)
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
                    }
                    if (notRequired.Contains(DGVMatContainer.Columns[e.ColumnIndex].Name))
                {
                    DGVMatContainer.Rows[roind].Cells[e.ColumnIndex].Style = csWhite;

                }

            }

        }


        private void DGVMatContainer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BLWriteMiutes bLWrite = new BLWriteMiutes();
            // if (!(this.DGVMatContainer.Columns[e.ColumnIndex].Name == "Pericoloso"))
           if (! (DGVMatContainer.Columns[e.ColumnIndex].Name == "Pericoloso"))
           if (DGVMatContainer.Rows.Count>0)
                if (ValidateCurrentRow(DGVMatContainer.CurrentRow))
            {
                New_Row(sender, new DataGridViewRowEventArgs(DGVMatContainer.CurrentRow));
                DGVMatContainer.AllowUserToAddRows = false;

            }
        }




        private void changeColorCell(object sender, DataGridViewBindingCompleteEventArgs e1)
        {
            doevent = false;
            // SetRequired();
            foreach (DataGridViewRow row in DGVMatContainer.Rows)
            {
                int maxcol = row.Cells.Count;


                DataGridView dataGridViewCell = (DataGridView)sender;
                foreach (DataGridViewCell e in row.Cells)
                {
                    bool isWhite = false;




                    if (notRequired.Contains(dataGridViewCell.Columns[e.ColumnIndex].Name))
                    {
                        if (e.Value != null && e.Value != DBNull.Value)
                            e.Style = csWhite;
                    }

                }

            }
        }

      

        private void DGVMatContainer_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (DGVMatContainer.Rows.Count > 0)
            {  
            if (requiredFieldTB.Contains(this.DGVMatContainer.Columns[e.ColumnIndex].Name) || requiredIfDangerousCeckBox.Contains(this.DGVMatContainer.Columns[e.ColumnIndex].Name))

                {
                    //DGVMatContainer.Rows[e.RowIndex].Cells[DGVMatContainer.Columns[e.ColumnIndex].Name].Style.SelectionBackColor = Color.LightGray;
                    //    DGVMatContainer.Rows[e.RowIndex].Cells["Quantita_Materiale"].Style.SelectionBackColor = Color.LightGray;

                    DGVMatContainer[e.ColumnIndex, e.RowIndex].Style = csOrange;
                   

                    if (((bool)DGVMatContainer["Pericoloso", e.RowIndex].Value))
                    {


                        if (DGVMatContainer[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "UN_Code")
                            DGVMatContainer["UN_Code", e.RowIndex].ReadOnly = true;
                        if (DGVMatContainer[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Peso_Pericoloso")
                            DGVMatContainer["Peso_Pericoloso", e.RowIndex].ReadOnly = true;
                        if (DGVMatContainer[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Classe_Rischio")
                            DGVMatContainer["Classe_Rischio", e.RowIndex].ReadOnly = true;
                        if (DGVMatContainer[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Compatibilita")
                            DGVMatContainer["Compatibilita", e.RowIndex].ReadOnly = true;


                    }
                    else
                    {
                        if (DGVMatContainer[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "UN_Code")
                            DGVMatContainer["UN_Code", e.RowIndex].ReadOnly = false;
                        if (DGVMatContainer[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Peso_Pericoloso")
                            DGVMatContainer["Peso_Pericoloso", e.RowIndex].ReadOnly = false;
                        if (DGVMatContainer[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Classe_Rischio")
                            DGVMatContainer["Classe_Rischio", e.RowIndex].ReadOnly = false;
                        if (DGVMatContainer[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Compatibilita")
                            DGVMatContainer["Compatibilita", e.RowIndex].ReadOnly = false;
                    }
                }
            }
        }

        private void PNContenitore_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void TBCHisuraContainer_TextChanged(object sender, EventArgs e)
        {

        }

        private void GBCommissione_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void TBOrdineGiorno_TextChanged(object sender, EventArgs e)
        {

        }

        private void MBIndateCommission_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void LBLDestinatoal_Click(object sender, EventArgs e)
        {

        }

        private void TBdestinatoAl_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBCHisuraContainer_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Label19_Click_1(object sender, EventArgs e)
        {

        }

        private void Label45_Click(object sender, EventArgs e)
        {

        }
    }
    public static class WarningMessgeForm
    {

        public static string UpdateFailed = "Impossible to execute update";
        public static string InsertFailed = "Impossible to execute insert";
        public static string DeleteFailed = "Impossible toexecute delete";
        public static string FieldsRequired = "Please check required fields";




    }

    public static class ResultMessgeForm
    {

        public static string UpdateOk = "Update execute successfully!";
        public static string InsertOk = "Insert execute successfully!";
        public static string DeleteOk = "Delete execute successfully!";




    }
    public static class ConfirmMessgeForm
    {

        public static string AddMinute = "Are you sure, do you want  add new Minute?";
     
        public static string UpdateMinute = "Are you sure, do you want  update this  Minute";
     

       




    }
}
