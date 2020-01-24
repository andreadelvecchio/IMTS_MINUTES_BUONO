using IMTS_MINUTES.BusinessLogic.BLMinutes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace IMTS_MINUTES.Forms.Minutes.Compila
{
    partial class WriteMinutes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

       #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.classeRischioDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compatibilitaDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PNContenitore = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.PNGrid = new System.Windows.Forms.Panel();
            this.DGVMatContainer = new System.Windows.Forms.DataGridView();
            this.Id_Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantita_Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione_Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lunghezza_Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Altezza_Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profondita_Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso_Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valore_Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pericoloso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UN_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classe_Rischio = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Compatibilita = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Peso_Pericoloso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.materialeContainerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iMTSDB_NEW = new IMTS_MINUTES.DataBase.IMTSDB_NEW();
            this.label8 = new System.Windows.Forms.Label();
            this.LBLStatus = new System.Windows.Forms.Label();
            this.LBLDestinatoal = new System.Windows.Forms.Label();
            this.LBLChiusuraDinamica = new System.Windows.Forms.Label();
            this.TBdestinatoAl = new System.Windows.Forms.TextBox();
            this.TBTotalValue = new System.Windows.Forms.TextBox();
            this.TBCHisuraContainer = new System.Windows.Forms.TextBox();
            this.TBTotalQTY = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.MBIndateCommission = new System.Windows.Forms.MaskedTextBox();
            this.GBCommissione = new System.Windows.Forms.GroupBox();
            this.LBLMember = new System.Windows.Forms.Label();
            this.TBMember = new System.Windows.Forms.TextBox();
            this.LBLSegretario = new System.Windows.Forms.Label();
            this.TBCommSegretario = new System.Windows.Forms.TextBox();
            this.LBLCommPresident = new System.Windows.Forms.Label();
            this.TBCommPresidente = new System.Windows.Forms.TextBox();
            this.LBLCommissione = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBDestination = new System.Windows.Forms.TextBox();
            this.TBVector = new System.Windows.Forms.TextBox();
            this.TBStoccaggio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TBRepMittente = new System.Windows.Forms.TextBox();
            this.LBLSiaNoto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GBHeader = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LBLSituatoPresso = new System.Windows.Forms.Label();
            this.TBCaserma = new System.Windows.Forms.TextBox();
            this.LBLValore = new System.Windows.Forms.Label();
            this.MBDateMinute = new System.Windows.Forms.MaskedTextBox();
            this.TBPresso = new System.Windows.Forms.TextBox();
            this.LBLPresso = new System.Windows.Forms.Label();
            this.LBLDate = new System.Windows.Forms.Label();
            this.TBTara = new System.Windows.Forms.TextBox();
            this.LBLTara = new System.Windows.Forms.Label();
            this.TBSNPlates = new System.Windows.Forms.TextBox();
            this.LBLSNPlates = new System.Windows.Forms.Label();
            this.CBContainerType = new System.Windows.Forms.ComboBox();
            this.LBLNCopie = new System.Windows.Forms.Label();
            this.LBLType = new System.Windows.Forms.Label();
            this.TBNcopie = new System.Windows.Forms.TextBox();
            this.TBMinuteNR = new System.Windows.Forms.TextBox();
            this.LBLVerbaleNr = new System.Windows.Forms.Label();
            this.TBOrdineGiorno = new System.Windows.Forms.TextBox();
            this.TBTOtalWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BNSaveModify = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GBVEHicle = new System.Windows.Forms.GroupBox();
            this.LBLTipoCarburante = new System.Windows.Forms.Label();
            this.LBLNumneroTelaio = new System.Windows.Forms.Label();
            this.TBTipoCarburante = new System.Windows.Forms.TextBox();
            this.TBTelaioNR = new System.Windows.Forms.TextBox();
            this.LBLAnnoCostruzione = new System.Windows.Forms.Label();
            this.TBMatMotore = new System.Windows.Forms.TextBox();
            this.TBAnnoCostruzione = new System.Windows.Forms.TextBox();
            this.LBLMatEngine = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.MTBDataChiusura = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TBLuogoChiususra = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TBResponsabileChiususra = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.TBValore = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.classeRischioDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compatibilitaDataTableBindingSource)).BeginInit();
            this.PNContenitore.SuspendLayout();
            this.PNGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMatContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialeContainerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMTSDB_NEW)).BeginInit();
            this.GBCommissione.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GBHeader.SuspendLayout();
            this.GBVEHicle.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // classeRischioDataTableBindingSource
            // 
            this.classeRischioDataTableBindingSource.DataSource = typeof(IMTS_MINUTES.DataBase.IMTSDB_NEW.Classe_RischioDataTable);
            // 
            // compatibilitaDataTableBindingSource
            // 
            this.compatibilitaDataTableBindingSource.DataSource = typeof(IMTS_MINUTES.DataBase.IMTSDB_NEW.CompatibilitaDataTable);
            // 
            // PNContenitore
            // 
            this.PNContenitore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PNContenitore.Controls.Add(this.label19);
            this.PNContenitore.Controls.Add(this.PNGrid);
            this.PNContenitore.Controls.Add(this.label8);
            this.PNContenitore.Controls.Add(this.LBLStatus);
            this.PNContenitore.Controls.Add(this.LBLDestinatoal);
            this.PNContenitore.Controls.Add(this.LBLChiusuraDinamica);
            this.PNContenitore.Controls.Add(this.TBdestinatoAl);
            this.PNContenitore.Controls.Add(this.TBTotalValue);
            this.PNContenitore.Controls.Add(this.TBCHisuraContainer);
            this.PNContenitore.Controls.Add(this.TBTotalQTY);
            this.PNContenitore.Controls.Add(this.label45);
            this.PNContenitore.Controls.Add(this.MBIndateCommission);
            this.PNContenitore.Controls.Add(this.GBCommissione);
            this.PNContenitore.Controls.Add(this.LBLCommissione);
            this.PNContenitore.Controls.Add(this.groupBox1);
            this.PNContenitore.Controls.Add(this.LBLSiaNoto);
            this.PNContenitore.Controls.Add(this.label5);
            this.PNContenitore.Controls.Add(this.GBHeader);
            this.PNContenitore.Controls.Add(this.TBOrdineGiorno);
            this.PNContenitore.Controls.Add(this.TBTOtalWeight);
            this.PNContenitore.Controls.Add(this.label3);
            this.PNContenitore.Controls.Add(this.BNSaveModify);
            this.PNContenitore.Controls.Add(this.label2);
            this.PNContenitore.Controls.Add(this.GBVEHicle);
            this.PNContenitore.Controls.Add(this.button1);
            this.PNContenitore.Controls.Add(this.groupBox2);
            this.PNContenitore.Controls.Add(this.groupBox3);
            this.PNContenitore.Controls.Add(this.groupBox6);
            this.PNContenitore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNContenitore.Location = new System.Drawing.Point(0, 0);
            this.PNContenitore.Name = "PNContenitore";
            this.PNContenitore.Size = new System.Drawing.Size(2740, 1589);
            this.PNContenitore.TabIndex = 2;
            this.PNContenitore.Paint += new System.Windows.Forms.PaintEventHandler(this.PNContenitore_Paint);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(822, 320);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(97, 25);
            this.label19.TabIndex = 312;
            this.label19.Text = "Seal NR.";
            this.label19.Click += new System.EventHandler(this.Label19_Click_1);
            // 
            // PNGrid
            // 
            this.PNGrid.Controls.Add(this.DGVMatContainer);
            this.PNGrid.Location = new System.Drawing.Point(3, 1073);
            this.PNGrid.Name = "PNGrid";
            this.PNGrid.Size = new System.Drawing.Size(1953, 231);
            this.PNGrid.TabIndex = 250;
            // 
            // DGVMatContainer
            // 
            this.DGVMatContainer.AllowUserToAddRows = false;
            this.DGVMatContainer.AllowUserToDeleteRows = false;
            this.DGVMatContainer.AllowUserToResizeColumns = false;
            this.DGVMatContainer.AllowUserToResizeRows = false;
            this.DGVMatContainer.AutoGenerateColumns = false;
            this.DGVMatContainer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVMatContainer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVMatContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMatContainer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Materiale,
            this.Quantita_Materiale,
            this.Descrizione_Materiale,
            this.Lunghezza_Materiale,
            this.Altezza_Materiale,
            this.Profondita_Materiale,
            this.Peso_Materiale,
            this.Valore_Materiale,
            this.Matricola,
            this.Pericoloso,
            this.UN_Code,
            this.Classe_Rischio,
            this.Compatibilita,
            this.Peso_Pericoloso,
            this.Delete});
            this.DGVMatContainer.DataSource = this.materialeContainerBindingSource;
            this.DGVMatContainer.Location = new System.Drawing.Point(0, 0);
            this.DGVMatContainer.MultiSelect = false;
            this.DGVMatContainer.Name = "DGVMatContainer";
            this.DGVMatContainer.RowHeadersWidth = 82;
            this.DGVMatContainer.RowTemplate.Height = 33;
            this.DGVMatContainer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGVMatContainer.Size = new System.Drawing.Size(1953, 231);
            this.DGVMatContainer.TabIndex = 301;
            this.DGVMatContainer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellContentClick);
            this.DGVMatContainer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellEndEdit);
            this.DGVMatContainer.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.EnterField_Event);
            this.DGVMatContainer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVMatContainer_CellFormatting_1);
            this.DGVMatContainer.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellValidated);
            this.DGVMatContainer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellEndEdit);
            // 
            // Id_Materiale
            // 
            this.Id_Materiale.DataPropertyName = "Id_Materiale";
            this.Id_Materiale.HeaderText = "Id_Materiale";
            this.Id_Materiale.MinimumWidth = 10;
            this.Id_Materiale.Name = "Id_Materiale";
            this.Id_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id_Materiale.Visible = false;
            // 
            // Quantita_Materiale
            // 
            this.Quantita_Materiale.DataPropertyName = "Quantità_Materiale";
            dataGridViewCellStyle1.NullValue = "-1";
            this.Quantita_Materiale.DefaultCellStyle = dataGridViewCellStyle1;
            this.Quantita_Materiale.HeaderText = "QTY Mat";
            this.Quantita_Materiale.MinimumWidth = 10;
            this.Quantita_Materiale.Name = "Quantita_Materiale";
            this.Quantita_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Descrizione_Materiale
            // 
            this.Descrizione_Materiale.DataPropertyName = "Descrizione_Materiale";
            dataGridViewCellStyle2.NullValue = null;
            this.Descrizione_Materiale.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descrizione_Materiale.HeaderText = "Description";
            this.Descrizione_Materiale.MinimumWidth = 10;
            this.Descrizione_Materiale.Name = "Descrizione_Materiale";
            this.Descrizione_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lunghezza_Materiale
            // 
            this.Lunghezza_Materiale.DataPropertyName = "Lunghezza_Materiale";
            dataGridViewCellStyle3.NullValue = null;
            this.Lunghezza_Materiale.DefaultCellStyle = dataGridViewCellStyle3;
            this.Lunghezza_Materiale.HeaderText = "Width";
            this.Lunghezza_Materiale.MinimumWidth = 10;
            this.Lunghezza_Materiale.Name = "Lunghezza_Materiale";
            this.Lunghezza_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Altezza_Materiale
            // 
            this.Altezza_Materiale.DataPropertyName = "Altezza_Materiale";
            dataGridViewCellStyle4.NullValue = null;
            this.Altezza_Materiale.DefaultCellStyle = dataGridViewCellStyle4;
            this.Altezza_Materiale.HeaderText = "Height";
            this.Altezza_Materiale.MinimumWidth = 10;
            this.Altezza_Materiale.Name = "Altezza_Materiale";
            this.Altezza_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Profondita_Materiale
            // 
            this.Profondita_Materiale.DataPropertyName = "Profondita_Materiale";
            dataGridViewCellStyle5.NullValue = null;
            this.Profondita_Materiale.DefaultCellStyle = dataGridViewCellStyle5;
            this.Profondita_Materiale.HeaderText = "Length";
            this.Profondita_Materiale.MinimumWidth = 10;
            this.Profondita_Materiale.Name = "Profondita_Materiale";
            this.Profondita_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Peso_Materiale
            // 
            this.Peso_Materiale.DataPropertyName = "Peso_Materiale";
            dataGridViewCellStyle6.NullValue = null;
            this.Peso_Materiale.DefaultCellStyle = dataGridViewCellStyle6;
            this.Peso_Materiale.HeaderText = "Weight";
            this.Peso_Materiale.MinimumWidth = 10;
            this.Peso_Materiale.Name = "Peso_Materiale";
            this.Peso_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Valore_Materiale
            // 
            this.Valore_Materiale.DataPropertyName = "Valore_Materiale";
            dataGridViewCellStyle7.NullValue = null;
            this.Valore_Materiale.DefaultCellStyle = dataGridViewCellStyle7;
            this.Valore_Materiale.HeaderText = "Value";
            this.Valore_Materiale.MinimumWidth = 10;
            this.Valore_Materiale.Name = "Valore_Materiale";
            this.Valore_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Matricola
            // 
            this.Matricola.DataPropertyName = "Matricola";
            this.Matricola.HeaderText = "Ser.Number";
            this.Matricola.MinimumWidth = 10;
            this.Matricola.Name = "Matricola";
            this.Matricola.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pericoloso
            // 
            this.Pericoloso.DataPropertyName = "Dangerous";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Pericoloso.DefaultCellStyle = dataGridViewCellStyle8;
            this.Pericoloso.HeaderText = "Dangerous";
            this.Pericoloso.MinimumWidth = 10;
            this.Pericoloso.Name = "Pericoloso";
            // 
            // UN_Code
            // 
            this.UN_Code.DataPropertyName = "UN_Code";
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            this.UN_Code.DefaultCellStyle = dataGridViewCellStyle9;
            this.UN_Code.HeaderText = "UN_Code";
            this.UN_Code.MinimumWidth = 10;
            this.UN_Code.Name = "UN_Code";
            this.UN_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Classe_Rischio
            // 
            this.Classe_Rischio.DataPropertyName = "Classe_Rischio";
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Window;
            this.Classe_Rischio.DefaultCellStyle = dataGridViewCellStyle10;
            this.Classe_Rischio.DisplayStyleForCurrentCellOnly = true;
            this.Classe_Rischio.HeaderText = "Risk classes";
            this.Classe_Rischio.MinimumWidth = 10;
            this.Classe_Rischio.Name = "Classe_Rischio";
            this.Classe_Rischio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Compatibilita
            // 
            this.Compatibilita.DataPropertyName = "Compatibilita";
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Window;
            this.Compatibilita.DefaultCellStyle = dataGridViewCellStyle11;
            this.Compatibilita.DisplayStyleForCurrentCellOnly = true;
            this.Compatibilita.HeaderText = "Compatibility";
            this.Compatibilita.MinimumWidth = 10;
            this.Compatibilita.Name = "Compatibilita";
            this.Compatibilita.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Peso_Pericoloso
            // 
            this.Peso_Pericoloso.DataPropertyName = "Peso_Pericoloso";
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            this.Peso_Pericoloso.DefaultCellStyle = dataGridViewCellStyle12;
            this.Peso_Pericoloso.HeaderText = "Dangerous Weight";
            this.Peso_Pericoloso.MinimumWidth = 10;
            this.Peso_Pericoloso.Name = "Peso_Pericoloso";
            this.Peso_Pericoloso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 10;
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // materialeContainerBindingSource
            // 
            this.materialeContainerBindingSource.DataMember = "Materiale_Container";
            this.materialeContainerBindingSource.DataSource = this.iMTSDB_NEW;
            // 
            // iMTSDB_NEW
            // 
            this.iMTSDB_NEW.DataSetName = "IMTSDB_NEW";
            this.iMTSDB_NEW.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(822, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 25);
            this.label8.TabIndex = 310;
            this.label8.Text = "Order NR.";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // LBLStatus
            // 
            this.LBLStatus.AutoSize = true;
            this.LBLStatus.ForeColor = System.Drawing.Color.Red;
            this.LBLStatus.Location = new System.Drawing.Point(3, 1045);
            this.LBLStatus.Name = "LBLStatus";
            this.LBLStatus.Size = new System.Drawing.Size(73, 25);
            this.LBLStatus.TabIndex = 4;
            this.LBLStatus.Text = "Status";
            // 
            // LBLDestinatoal
            // 
            this.LBLDestinatoal.AutoSize = true;
            this.LBLDestinatoal.Location = new System.Drawing.Point(1157, 320);
            this.LBLDestinatoal.Name = "LBLDestinatoal";
            this.LBLDestinatoal.Size = new System.Drawing.Size(139, 25);
            this.LBLDestinatoal.TabIndex = 309;
            this.LBLDestinatoal.Text = "Destinated to";
            this.LBLDestinatoal.Click += new System.EventHandler(this.LBLDestinatoal_Click);
            // 
            // LBLChiusuraDinamica
            // 
            this.LBLChiusuraDinamica.AutoSize = true;
            this.LBLChiusuraDinamica.Location = new System.Drawing.Point(60, 354);
            this.LBLChiusuraDinamica.Name = "LBLChiusuraDinamica";
            this.LBLChiusuraDinamica.Size = new System.Drawing.Size(0, 25);
            this.LBLChiusuraDinamica.TabIndex = 99;
            // 
            // TBdestinatoAl
            // 
            this.TBdestinatoAl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBdestinatoAl.Location = new System.Drawing.Point(1162, 348);
            this.TBdestinatoAl.MaxLength = 12;
            this.TBdestinatoAl.Name = "TBdestinatoAl";
            this.TBdestinatoAl.Size = new System.Drawing.Size(450, 31);
            this.TBdestinatoAl.TabIndex = 305;
            this.TBdestinatoAl.TextChanged += new System.EventHandler(this.TBdestinatoAl_TextChanged);
            // 
            // TBTotalValue
            // 
            this.TBTotalValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBTotalValue.Location = new System.Drawing.Point(1102, 1341);
            this.TBTotalValue.MaxLength = 15;
            this.TBTotalValue.Name = "TBTotalValue";
            this.TBTotalValue.ReadOnly = true;
            this.TBTotalValue.Size = new System.Drawing.Size(250, 31);
            this.TBTotalValue.TabIndex = 97;
            this.TBTotalValue.Text = "0";
            // 
            // TBCHisuraContainer
            // 
            this.TBCHisuraContainer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBCHisuraContainer.Location = new System.Drawing.Point(827, 348);
            this.TBCHisuraContainer.MaxLength = 15;
            this.TBCHisuraContainer.Name = "TBCHisuraContainer";
            this.TBCHisuraContainer.Size = new System.Drawing.Size(300, 31);
            this.TBCHisuraContainer.TabIndex = 304;
            this.TBCHisuraContainer.TextChanged += new System.EventHandler(this.TBCHisuraContainer_TextChanged_1);
            // 
            // TBTotalQTY
            // 
            this.TBTotalQTY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBTotalQTY.Location = new System.Drawing.Point(497, 1341);
            this.TBTotalQTY.MaxLength = 15;
            this.TBTotalQTY.Name = "TBTotalQTY";
            this.TBTotalQTY.ReadOnly = true;
            this.TBTotalQTY.Size = new System.Drawing.Size(250, 31);
            this.TBTotalQTY.TabIndex = 96;
            this.TBTotalQTY.Text = "0";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(1063, 237);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(80, 25);
            this.label45.TabIndex = 306;
            this.label45.Text = "In Date";
            this.label45.Click += new System.EventHandler(this.Label45_Click);
            // 
            // MBIndateCommission
            // 
            this.MBIndateCommission.Location = new System.Drawing.Point(1068, 265);
            this.MBIndateCommission.Mask = "00/00/0000";
            this.MBIndateCommission.Name = "MBIndateCommission";
            this.MBIndateCommission.Size = new System.Drawing.Size(140, 31);
            this.MBIndateCommission.TabIndex = 303;
            this.MBIndateCommission.ValidatingType = typeof(System.DateTime);
            this.MBIndateCommission.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MBIndateCommission_MaskInputRejected);
            // 
            // GBCommissione
            // 
            this.GBCommissione.Controls.Add(this.LBLMember);
            this.GBCommissione.Controls.Add(this.TBMember);
            this.GBCommissione.Controls.Add(this.LBLSegretario);
            this.GBCommissione.Controls.Add(this.TBCommSegretario);
            this.GBCommissione.Controls.Add(this.LBLCommPresident);
            this.GBCommissione.Controls.Add(this.TBCommPresidente);
            this.GBCommissione.Location = new System.Drawing.Point(449, 764);
            this.GBCommissione.Name = "GBCommissione";
            this.GBCommissione.Size = new System.Drawing.Size(525, 282);
            this.GBCommissione.TabIndex = 250;
            this.GBCommissione.TabStop = false;
            this.GBCommissione.Text = "COMMISSION";
            this.GBCommissione.Enter += new System.EventHandler(this.GBCommissione_Enter);
            // 
            // LBLMember
            // 
            this.LBLMember.AutoSize = true;
            this.LBLMember.Location = new System.Drawing.Point(33, 181);
            this.LBLMember.Name = "LBLMember";
            this.LBLMember.Size = new System.Drawing.Size(90, 25);
            this.LBLMember.TabIndex = 81;
            this.LBLMember.Text = "Member";
            // 
            // TBMember
            // 
            this.TBMember.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBMember.Location = new System.Drawing.Point(28, 209);
            this.TBMember.MaxLength = 50;
            this.TBMember.Name = "TBMember";
            this.TBMember.Size = new System.Drawing.Size(450, 31);
            this.TBMember.TabIndex = 23;
            // 
            // LBLSegretario
            // 
            this.LBLSegretario.AutoSize = true;
            this.LBLSegretario.Location = new System.Drawing.Point(23, 112);
            this.LBLSegretario.Name = "LBLSegretario";
            this.LBLSegretario.Size = new System.Drawing.Size(104, 25);
            this.LBLSegretario.TabIndex = 79;
            this.LBLSegretario.Text = "Secretary";
            // 
            // TBCommSegretario
            // 
            this.TBCommSegretario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBCommSegretario.Location = new System.Drawing.Point(28, 140);
            this.TBCommSegretario.MaxLength = 50;
            this.TBCommSegretario.Name = "TBCommSegretario";
            this.TBCommSegretario.Size = new System.Drawing.Size(450, 31);
            this.TBCommSegretario.TabIndex = 22;
            // 
            // LBLCommPresident
            // 
            this.LBLCommPresident.AutoSize = true;
            this.LBLCommPresident.Location = new System.Drawing.Point(23, 33);
            this.LBLCommPresident.Name = "LBLCommPresident";
            this.LBLCommPresident.Size = new System.Drawing.Size(103, 25);
            this.LBLCommPresident.TabIndex = 77;
            this.LBLCommPresident.Text = "President";
            // 
            // TBCommPresidente
            // 
            this.TBCommPresidente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBCommPresidente.Location = new System.Drawing.Point(28, 61);
            this.TBCommPresidente.MaxLength = 50;
            this.TBCommPresidente.Name = "TBCommPresidente";
            this.TBCommPresidente.Size = new System.Drawing.Size(450, 31);
            this.TBCommPresidente.TabIndex = 21;
            // 
            // LBLCommissione
            // 
            this.LBLCommissione.AutoSize = true;
            this.LBLCommissione.Location = new System.Drawing.Point(158, 271);
            this.LBLCommissione.Name = "LBLCommissione";
            this.LBLCommissione.Size = new System.Drawing.Size(634, 25);
            this.LBLCommissione.TabIndex = 308;
            this.LBLCommissione.Text = "The subscriver commission named with riferiment at day of order.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBDestination);
            this.groupBox1.Controls.Add(this.TBVector);
            this.groupBox1.Controls.Add(this.TBStoccaggio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TBRepMittente);
            this.groupBox1.Location = new System.Drawing.Point(449, 415);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 329);
            this.groupBox1.TabIndex = 150;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MOVEMENT INFORMATION";
            // 
            // TBDestination
            // 
            this.TBDestination.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBDestination.Location = new System.Drawing.Point(31, 127);
            this.TBDestination.MaxLength = 50;
            this.TBDestination.Name = "TBDestination";
            this.TBDestination.Size = new System.Drawing.Size(450, 31);
            this.TBDestination.TabIndex = 14;
            // 
            // TBVector
            // 
            this.TBVector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBVector.Location = new System.Drawing.Point(28, 269);
            this.TBVector.MaxLength = 50;
            this.TBVector.Name = "TBVector";
            this.TBVector.Size = new System.Drawing.Size(450, 31);
            this.TBVector.TabIndex = 16;
            // 
            // TBStoccaggio
            // 
            this.TBStoccaggio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBStoccaggio.Location = new System.Drawing.Point(28, 198);
            this.TBStoccaggio.MaxLength = 50;
            this.TBStoccaggio.Name = "TBStoccaggio";
            this.TBStoccaggio.Size = new System.Drawing.Size(450, 31);
            this.TBStoccaggio.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 25);
            this.label6.TabIndex = 75;
            this.label6.Text = "Transporter vector";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 25);
            this.label9.TabIndex = 73;
            this.label9.Text = "Stockage terminal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 25);
            this.label10.TabIndex = 71;
            this.label10.Text = "Destination place";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 25);
            this.label11.TabIndex = 69;
            this.label11.Text = "Sender department";
            // 
            // TBRepMittente
            // 
            this.TBRepMittente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBRepMittente.Location = new System.Drawing.Point(31, 55);
            this.TBRepMittente.MaxLength = 50;
            this.TBRepMittente.Name = "TBRepMittente";
            this.TBRepMittente.Size = new System.Drawing.Size(450, 31);
            this.TBRepMittente.TabIndex = 13;
            // 
            // LBLSiaNoto
            // 
            this.LBLSiaNoto.AutoSize = true;
            this.LBLSiaNoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLSiaNoto.Location = new System.Drawing.Point(857, 191);
            this.LBLSiaNoto.Name = "LBLSiaNoto";
            this.LBLSiaNoto.Size = new System.Drawing.Size(358, 46);
            this.LBLSiaNoto.TabIndex = 307;
            this.LBLSiaNoto.Text = "It becomes known";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1097, 1313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 95;
            this.label5.Text = "Total value";
            // 
            // GBHeader
            // 
            this.GBHeader.Controls.Add(this.label22);
            this.GBHeader.Controls.Add(this.TBValore);
            this.GBHeader.Controls.Add(this.label4);
            this.GBHeader.Controls.Add(this.LBLSituatoPresso);
            this.GBHeader.Controls.Add(this.TBCaserma);
            this.GBHeader.Controls.Add(this.LBLValore);
            this.GBHeader.Controls.Add(this.MBDateMinute);
            this.GBHeader.Controls.Add(this.TBPresso);
            this.GBHeader.Controls.Add(this.LBLPresso);
            this.GBHeader.Controls.Add(this.LBLDate);
            this.GBHeader.Controls.Add(this.TBTara);
            this.GBHeader.Controls.Add(this.LBLTara);
            this.GBHeader.Controls.Add(this.TBSNPlates);
            this.GBHeader.Controls.Add(this.LBLSNPlates);
            this.GBHeader.Controls.Add(this.CBContainerType);
            this.GBHeader.Controls.Add(this.LBLNCopie);
            this.GBHeader.Controls.Add(this.LBLType);
            this.GBHeader.Controls.Add(this.TBNcopie);
            this.GBHeader.Controls.Add(this.TBMinuteNR);
            this.GBHeader.Controls.Add(this.LBLVerbaleNr);
            this.GBHeader.Location = new System.Drawing.Point(12, 3);
            this.GBHeader.Name = "GBHeader";
            this.GBHeader.Size = new System.Drawing.Size(1929, 185);
            this.GBHeader.TabIndex = 311;
            this.GBHeader.TabStop = false;
            this.GBHeader.Text = "Header";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1340, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 68;
            this.label4.Text = "Tare";
            // 
            // LBLSituatoPresso
            // 
            this.LBLSituatoPresso.AutoSize = true;
            this.LBLSituatoPresso.Location = new System.Drawing.Point(1140, 112);
            this.LBLSituatoPresso.Name = "LBLSituatoPresso";
            this.LBLSituatoPresso.Size = new System.Drawing.Size(118, 25);
            this.LBLSituatoPresso.TabIndex = 67;
            this.LBLSituatoPresso.Text = "In barracks";
            // 
            // TBCaserma
            // 
            this.TBCaserma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBCaserma.Location = new System.Drawing.Point(1145, 140);
            this.TBCaserma.MaxLength = 255;
            this.TBCaserma.Name = "TBCaserma";
            this.TBCaserma.Size = new System.Drawing.Size(450, 31);
            this.TBCaserma.TabIndex = 8;
            // 
            // LBLValore
            // 
            this.LBLValore.AutoSize = true;
            this.LBLValore.Location = new System.Drawing.Point(2244, 27);
            this.LBLValore.Name = "LBLValore";
            this.LBLValore.Size = new System.Drawing.Size(67, 25);
            this.LBLValore.TabIndex = 64;
            this.LBLValore.Text = "Value";
            // 
            // MBDateMinute
            // 
            this.MBDateMinute.Location = new System.Drawing.Point(29, 140);
            this.MBDateMinute.Mask = "00/00/0000";
            this.MBDateMinute.Name = "MBDateMinute";
            this.MBDateMinute.Size = new System.Drawing.Size(140, 31);
            this.MBDateMinute.TabIndex = 6;
            this.MBDateMinute.ValidatingType = typeof(System.DateTime);
            // 
            // TBPresso
            // 
            this.TBPresso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBPresso.Location = new System.Drawing.Point(380, 140);
            this.TBPresso.MaxLength = 100;
            this.TBPresso.Name = "TBPresso";
            this.TBPresso.Size = new System.Drawing.Size(450, 31);
            this.TBPresso.TabIndex = 7;
            // 
            // LBLPresso
            // 
            this.LBLPresso.AutoSize = true;
            this.LBLPresso.Location = new System.Drawing.Point(380, 112);
            this.LBLPresso.Name = "LBLPresso";
            this.LBLPresso.Size = new System.Drawing.Size(32, 25);
            this.LBLPresso.TabIndex = 26;
            this.LBLPresso.Text = "At";
            // 
            // LBLDate
            // 
            this.LBLDate.AutoSize = true;
            this.LBLDate.Location = new System.Drawing.Point(24, 112);
            this.LBLDate.Name = "LBLDate";
            this.LBLDate.Size = new System.Drawing.Size(80, 25);
            this.LBLDate.TabIndex = 3;
            this.LBLDate.Text = "In Date";
            // 
            // TBTara
            // 
            this.TBTara.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBTara.Location = new System.Drawing.Point(1345, 57);
            this.TBTara.MaxLength = 15;
            this.TBTara.Name = "TBTara";
            this.TBTara.Size = new System.Drawing.Size(140, 31);
            this.TBTara.TabIndex = 4;
            this.TBTara.Text = "0";
            // 
            // LBLTara
            // 
            this.LBLTara.AutoSize = true;
            this.LBLTara.Location = new System.Drawing.Point(1931, 25);
            this.LBLTara.Name = "LBLTara";
            this.LBLTara.Size = new System.Drawing.Size(56, 25);
            this.LBLTara.TabIndex = 62;
            this.LBLTara.Text = "Tare";
            // 
            // TBSNPlates
            // 
            this.TBSNPlates.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBSNPlates.Location = new System.Drawing.Point(1144, 57);
            this.TBSNPlates.MaxLength = 15;
            this.TBSNPlates.Name = "TBSNPlates";
            this.TBSNPlates.Size = new System.Drawing.Size(140, 31);
            this.TBSNPlates.TabIndex = 3;
            // 
            // LBLSNPlates
            // 
            this.LBLSNPlates.AutoSize = true;
            this.LBLSNPlates.Location = new System.Drawing.Point(1139, 29);
            this.LBLSNPlates.Name = "LBLSNPlates";
            this.LBLSNPlates.Size = new System.Drawing.Size(156, 25);
            this.LBLSNPlates.TabIndex = 60;
            this.LBLSNPlates.Text = "S/N-Plates NR.";
            // 
            // CBContainerType
            // 
            this.CBContainerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBContainerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBContainerType.BackColor = System.Drawing.SystemColors.Window;
            this.CBContainerType.FormattingEnabled = true;
            this.CBContainerType.ItemHeight = 25;
            this.CBContainerType.Location = new System.Drawing.Point(552, 55);
            this.CBContainerType.Name = "CBContainerType";
            this.CBContainerType.Size = new System.Drawing.Size(519, 33);
            this.CBContainerType.TabIndex = 2;
            this.CBContainerType.SelectedIndexChanged += new System.EventHandler(this.change_tara);
            // 
            // LBLNCopie
            // 
            this.LBLNCopie.AutoSize = true;
            this.LBLNCopie.Location = new System.Drawing.Point(24, 27);
            this.LBLNCopie.Name = "LBLNCopie";
            this.LBLNCopie.Size = new System.Drawing.Size(104, 25);
            this.LBLNCopie.TabIndex = 3;
            this.LBLNCopie.Text = "Copy NR.";
            // 
            // LBLType
            // 
            this.LBLType.AutoSize = true;
            this.LBLType.Location = new System.Drawing.Point(547, 27);
            this.LBLType.Name = "LBLType";
            this.LBLType.Size = new System.Drawing.Size(152, 25);
            this.LBLType.TabIndex = 58;
            this.LBLType.Text = "Container type";
            // 
            // TBNcopie
            // 
            this.TBNcopie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBNcopie.Location = new System.Drawing.Point(29, 55);
            this.TBNcopie.MaxLength = 2;
            this.TBNcopie.Name = "TBNcopie";
            this.TBNcopie.Size = new System.Drawing.Size(140, 31);
            this.TBNcopie.TabIndex = 0;
            this.TBNcopie.Text = "1";
            // 
            // TBMinuteNR
            // 
            this.TBMinuteNR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBMinuteNR.Location = new System.Drawing.Point(380, 55);
            this.TBMinuteNR.MaxLength = 15;
            this.TBMinuteNR.Name = "TBMinuteNR";
            this.TBMinuteNR.Size = new System.Drawing.Size(140, 31);
            this.TBMinuteNR.TabIndex = 1;
            this.TBMinuteNR.Text = "1";
            // 
            // LBLVerbaleNr
            // 
            this.LBLVerbaleNr.AutoSize = true;
            this.LBLVerbaleNr.Location = new System.Drawing.Point(375, 27);
            this.LBLVerbaleNr.Name = "LBLVerbaleNr";
            this.LBLVerbaleNr.Size = new System.Drawing.Size(130, 25);
            this.LBLVerbaleNr.TabIndex = 26;
            this.LBLVerbaleNr.Text = "Minutes NR.";
            // 
            // TBOrdineGiorno
            // 
            this.TBOrdineGiorno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBOrdineGiorno.Location = new System.Drawing.Point(827, 265);
            this.TBOrdineGiorno.MaxLength = 15;
            this.TBOrdineGiorno.Name = "TBOrdineGiorno";
            this.TBOrdineGiorno.Size = new System.Drawing.Size(140, 31);
            this.TBOrdineGiorno.TabIndex = 302;
            this.TBOrdineGiorno.TextChanged += new System.EventHandler(this.TBOrdineGiorno_TextChanged);
            // 
            // TBTOtalWeight
            // 
            this.TBTOtalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBTOtalWeight.Location = new System.Drawing.Point(795, 1341);
            this.TBTOtalWeight.MaxLength = 15;
            this.TBTOtalWeight.Name = "TBTOtalWeight";
            this.TBTOtalWeight.ReadOnly = true;
            this.TBTOtalWeight.Size = new System.Drawing.Size(250, 31);
            this.TBTOtalWeight.TabIndex = 92;
            this.TBTOtalWeight.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(790, 1313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 93;
            this.label3.Text = "Total weight";
            // 
            // BNSaveModify
            // 
            this.BNSaveModify.Location = new System.Drawing.Point(994, 986);
            this.BNSaveModify.Name = "BNSaveModify";
            this.BNSaveModify.Size = new System.Drawing.Size(189, 57);
            this.BNSaveModify.TabIndex = 120;
            this.BNSaveModify.Text = "Save Modify";
            this.BNSaveModify.UseVisualStyleBackColor = true;
            this.BNSaveModify.Click += new System.EventHandler(this.BNSaveModify_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 1313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 69;
            this.label2.Text = "QTY tot.";
            // 
            // GBVEHicle
            // 
            this.GBVEHicle.Controls.Add(this.LBLTipoCarburante);
            this.GBVEHicle.Controls.Add(this.LBLNumneroTelaio);
            this.GBVEHicle.Controls.Add(this.TBTipoCarburante);
            this.GBVEHicle.Controls.Add(this.TBTelaioNR);
            this.GBVEHicle.Controls.Add(this.LBLAnnoCostruzione);
            this.GBVEHicle.Controls.Add(this.TBMatMotore);
            this.GBVEHicle.Controls.Add(this.TBAnnoCostruzione);
            this.GBVEHicle.Controls.Add(this.LBLMatEngine);
            this.GBVEHicle.Location = new System.Drawing.Point(994, 415);
            this.GBVEHicle.Name = "GBVEHicle";
            this.GBVEHicle.Size = new System.Drawing.Size(518, 329);
            this.GBVEHicle.TabIndex = 200;
            this.GBVEHicle.TabStop = false;
            this.GBVEHicle.Text = "VEICHLE";
            // 
            // LBLTipoCarburante
            // 
            this.LBLTipoCarburante.AutoSize = true;
            this.LBLTipoCarburante.Location = new System.Drawing.Point(14, 241);
            this.LBLTipoCarburante.Name = "LBLTipoCarburante";
            this.LBLTipoCarburante.Size = new System.Drawing.Size(101, 25);
            this.LBLTipoCarburante.TabIndex = 83;
            this.LBLTipoCarburante.Text = "Fuel type";
            // 
            // LBLNumneroTelaio
            // 
            this.LBLNumneroTelaio.AutoSize = true;
            this.LBLNumneroTelaio.Location = new System.Drawing.Point(14, 27);
            this.LBLNumneroTelaio.Name = "LBLNumneroTelaio";
            this.LBLNumneroTelaio.Size = new System.Drawing.Size(131, 25);
            this.LBLNumneroTelaio.TabIndex = 77;
            this.LBLNumneroTelaio.Text = "Chassis NR.";
            // 
            // TBTipoCarburante
            // 
            this.TBTipoCarburante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBTipoCarburante.Location = new System.Drawing.Point(19, 269);
            this.TBTipoCarburante.MaxLength = 50;
            this.TBTipoCarburante.Name = "TBTipoCarburante";
            this.TBTipoCarburante.Size = new System.Drawing.Size(450, 31);
            this.TBTipoCarburante.TabIndex = 20;
            // 
            // TBTelaioNR
            // 
            this.TBTelaioNR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBTelaioNR.Location = new System.Drawing.Point(19, 55);
            this.TBTelaioNR.MaxLength = 50;
            this.TBTelaioNR.Name = "TBTelaioNR";
            this.TBTelaioNR.Size = new System.Drawing.Size(450, 31);
            this.TBTelaioNR.TabIndex = 17;
            // 
            // LBLAnnoCostruzione
            // 
            this.LBLAnnoCostruzione.AutoSize = true;
            this.LBLAnnoCostruzione.Location = new System.Drawing.Point(14, 170);
            this.LBLAnnoCostruzione.Name = "LBLAnnoCostruzione";
            this.LBLAnnoCostruzione.Size = new System.Drawing.Size(132, 25);
            this.LBLAnnoCostruzione.TabIndex = 81;
            this.LBLAnnoCostruzione.Text = "Builded year";
            // 
            // TBMatMotore
            // 
            this.TBMatMotore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBMatMotore.Location = new System.Drawing.Point(19, 127);
            this.TBMatMotore.MaxLength = 50;
            this.TBMatMotore.Name = "TBMatMotore";
            this.TBMatMotore.Size = new System.Drawing.Size(450, 31);
            this.TBMatMotore.TabIndex = 18;
            // 
            // TBAnnoCostruzione
            // 
            this.TBAnnoCostruzione.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBAnnoCostruzione.Location = new System.Drawing.Point(19, 198);
            this.TBAnnoCostruzione.MaxLength = 15;
            this.TBAnnoCostruzione.Name = "TBAnnoCostruzione";
            this.TBAnnoCostruzione.Size = new System.Drawing.Size(450, 31);
            this.TBAnnoCostruzione.TabIndex = 19;
            // 
            // LBLMatEngine
            // 
            this.LBLMatEngine.AutoSize = true;
            this.LBLMatEngine.Location = new System.Drawing.Point(14, 99);
            this.LBLMatEngine.Name = "LBLMatEngine";
            this.LBLMatEngine.Size = new System.Drawing.Size(120, 25);
            this.LBLMatEngine.TabIndex = 79;
            this.LBLMatEngine.Text = "S/N Engine";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1393, 1322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 50);
            this.button1.TabIndex = 100;
            this.button1.Text = "Add New Row";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.MTBDataChiusura);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.TBLuogoChiususra);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.TBResponsabileChiususra);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(994, 764);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(743, 216);
            this.groupBox2.TabIndex = 300;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CLOSURE";
            this.groupBox2.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(490, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 25);
            this.label14.TabIndex = 82;
            this.label14.Text = "In date,";
            // 
            // MTBDataChiusura
            // 
            this.MTBDataChiusura.Location = new System.Drawing.Point(579, 134);
            this.MTBDataChiusura.Mask = "00/00/0000";
            this.MTBDataChiusura.Name = "MTBDataChiusura";
            this.MTBDataChiusura.Size = new System.Drawing.Size(140, 31);
            this.MTBDataChiusura.TabIndex = 26;
            this.MTBDataChiusura.ValidatingType = typeof(System.DateTime);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(574, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 25);
            this.label15.TabIndex = 81;
            this.label15.Text = "Date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 112);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 25);
            this.label16.TabIndex = 79;
            this.label16.Text = "Place";
            // 
            // TBLuogoChiususra
            // 
            this.TBLuogoChiususra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBLuogoChiususra.Location = new System.Drawing.Point(19, 140);
            this.TBLuogoChiususra.MaxLength = 50;
            this.TBLuogoChiususra.Name = "TBLuogoChiususra";
            this.TBLuogoChiususra.Size = new System.Drawing.Size(450, 31);
            this.TBLuogoChiususra.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 25);
            this.label17.TabIndex = 77;
            this.label17.Text = "Responsable";
            // 
            // TBResponsabileChiususra
            // 
            this.TBResponsabileChiususra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBResponsabileChiususra.Location = new System.Drawing.Point(19, 61);
            this.TBResponsabileChiususra.MaxLength = 50;
            this.TBResponsabileChiususra.Name = "TBResponsabileChiususra";
            this.TBResponsabileChiususra.Size = new System.Drawing.Size(450, 31);
            this.TBResponsabileChiususra.TabIndex = 24;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Location = new System.Drawing.Point(-545, -12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(525, 282);
            this.groupBox4.TabIndex = 250;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "COMMISSION";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(33, 181);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 25);
            this.label18.TabIndex = 81;
            this.label18.Text = "Member";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 25);
            this.label20.TabIndex = 79;
            this.label20.Text = "Secretary";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 33);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 25);
            this.label21.TabIndex = 77;
            this.label21.Text = "President";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(994, 415);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(518, 329);
            this.groupBox3.TabIndex = 200;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "VEICHLE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 83;
            this.label1.Text = "Fuel type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 25);
            this.label7.TabIndex = 77;
            this.label7.Text = "Chassis NR.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 25);
            this.label12.TabIndex = 81;
            this.label12.Text = "Builded year";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 25);
            this.label13.TabIndex = 79;
            this.label13.Text = "S/N Engine";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Location = new System.Drawing.Point(449, 415);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(525, 329);
            this.groupBox6.TabIndex = 150;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "MOVEMENT INFORMATION";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(26, 241);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(188, 25);
            this.label26.TabIndex = 75;
            this.label26.Text = "Transporter vector";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(26, 170);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(184, 25);
            this.label27.TabIndex = 73;
            this.label27.Text = "Stockage terminal";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(26, 99);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(178, 25);
            this.label28.TabIndex = 71;
            this.label28.Text = "Destination place";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(26, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(195, 25);
            this.label29.TabIndex = 69;
            this.label29.Text = "Sender department";
            // 
            // textBox6
            // 
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox6.Location = new System.Drawing.Point(28, 140);
            this.textBox6.MaxLength = 50;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(450, 31);
            this.textBox6.TabIndex = 22;
            // 
            // TBValore
            // 
            this.TBValore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBValore.Location = new System.Drawing.Point(1511, 57);
            this.TBValore.MaxLength = 15;
            this.TBValore.Name = "TBValore";
            this.TBValore.Size = new System.Drawing.Size(140, 31);
            this.TBValore.TabIndex = 69;
            this.TBValore.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1506, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 25);
            this.label22.TabIndex = 70;
            this.label22.Text = "Value";
            // 
            // WriteMinutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2740, 1589);
            this.Controls.Add(this.PNContenitore);
            this.Name = "WriteMinutes";
            this.Text = "WriteMinutes";
            this.Load += new System.EventHandler(this.WriteMinutes_Load);
            this.Enter += new System.EventHandler(this.EnterField_Event);
            this.Leave += new System.EventHandler(this.LeaveField_Event);
            ((System.ComponentModel.ISupportInitialize)(this.classeRischioDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compatibilitaDataTableBindingSource)).EndInit();
            this.PNContenitore.ResumeLayout(false);
            this.PNContenitore.PerformLayout();
            this.PNGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMatContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialeContainerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMTSDB_NEW)).EndInit();
            this.GBCommissione.ResumeLayout(false);
            this.GBCommissione.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GBHeader.ResumeLayout(false);
            this.GBHeader.PerformLayout();
            this.GBVEHicle.ResumeLayout(false);
            this.GBVEHicle.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

      

        #endregion
        private System.Windows.Forms.BindingSource materialeContainerBindingSource;
        private DataBase.IMTSDB_NEW iMTSDB_NEW;
        private System.Windows.Forms.BindingSource classeRischioDataTableBindingSource;
        private System.Windows.Forms.BindingSource compatibilitaDataTableBindingSource;
        private System.Windows.Forms.Panel PNContenitore;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox GBVEHicle;
        private System.Windows.Forms.Label LBLTipoCarburante;
        private System.Windows.Forms.Label LBLNumneroTelaio;
        private System.Windows.Forms.TextBox TBTipoCarburante;
        private System.Windows.Forms.TextBox TBTelaioNR;
        private System.Windows.Forms.Label LBLAnnoCostruzione;
        private System.Windows.Forms.TextBox TBMatMotore;
        private System.Windows.Forms.TextBox TBAnnoCostruzione;
        private System.Windows.Forms.Label LBLMatEngine;
        private System.Windows.Forms.GroupBox GBCommissione;
        private System.Windows.Forms.Label LBLMember;
        private System.Windows.Forms.TextBox TBMember;
        private System.Windows.Forms.Label LBLSegretario;
        private System.Windows.Forms.TextBox TBCommSegretario;
        private System.Windows.Forms.Label LBLCommPresident;
        private System.Windows.Forms.TextBox TBCommPresidente;
        private System.Windows.Forms.Button BNSaveModify;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBTotalValue;
        private System.Windows.Forms.TextBox TBTotalQTY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBTOtalWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBLChiusuraDinamica;
        private System.Windows.Forms.Label LBLStatus;
        private System.Windows.Forms.Panel PNGrid;
        private System.Windows.Forms.DataGridView DGVMatContainer;
        private GroupBox groupBox1;
        private TextBox TBDestination;
        private TextBox TBVector;
        private TextBox TBStoccaggio;
        private Label label6;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox TBRepMittente;
        private GroupBox groupBox2;
        private Label label14;
        private MaskedTextBox MTBDataChiusura;
        private Label label15;
        private Label label16;
        private TextBox TBLuogoChiususra;
        private Label label17;
        private TextBox TBResponsabileChiususra;
        private DataGridViewTextBoxColumn Id_Materiale;
        private DataGridViewTextBoxColumn Quantita_Materiale;
        private DataGridViewTextBoxColumn Descrizione_Materiale;
        private DataGridViewTextBoxColumn Lunghezza_Materiale;
        private DataGridViewTextBoxColumn Altezza_Materiale;
        private DataGridViewTextBoxColumn Profondita_Materiale;
        private DataGridViewTextBoxColumn Peso_Materiale;
        private DataGridViewTextBoxColumn Valore_Materiale;
        private DataGridViewTextBoxColumn Matricola;
        private DataGridViewCheckBoxColumn Pericoloso;
        private DataGridViewTextBoxColumn UN_Code;
        private DataGridViewComboBoxColumn Classe_Rischio;
        private DataGridViewComboBoxColumn Compatibilita;
        private DataGridViewTextBoxColumn Peso_Pericoloso;
        private DataGridViewButtonColumn Delete;
        private GroupBox groupBox6;
        
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
         
        private GroupBox groupBox4;
        private Label label18;
        
        private Label label20;
        private TextBox textBox6;
        private Label label21;
       
        private GroupBox groupBox3;
        private Label label1;
        private Label label7;
       
        private Label label12;
        
        private Label label13;
        private Label label19;
        private Label label8;
        private Label LBLDestinatoal;
        private TextBox TBdestinatoAl;
        private TextBox TBCHisuraContainer;
        private Label label45;
        private MaskedTextBox MBIndateCommission;
        private Label LBLCommissione;
        private Label LBLSiaNoto;
        private GroupBox GBHeader;
        private Label LBLSituatoPresso;
        private TextBox TBCaserma;
        private Label LBLValore;
        private MaskedTextBox MBDateMinute;
        private TextBox TBPresso;
        private Label LBLPresso;
        private Label LBLDate;
        private TextBox TBTara;
        private Label LBLTara;
        private TextBox TBSNPlates;
        private Label LBLSNPlates;
        private ComboBox CBContainerType;
        private Label LBLNCopie;
        private Label LBLType;
        private TextBox TBNcopie;
        private TextBox TBMinuteNR;
        private Label LBLVerbaleNr;
        private TextBox TBOrdineGiorno;
        private Label label4;
        private Label label22;
        private TextBox TBValore;
    }
}