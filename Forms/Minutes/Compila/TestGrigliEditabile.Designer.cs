namespace IMTS_MINUTES.Forms.Minutes.Compila
{
    partial class TestGrigliEditabile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.button1 = new System.Windows.Forms.Button();
            this.LBLStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMatContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVMatContainer
            // 
            this.DGVMatContainer.AllowUserToAddRows = false;
            this.DGVMatContainer.AllowUserToDeleteRows = false;
            this.DGVMatContainer.AllowUserToResizeColumns = false;
            this.DGVMatContainer.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVMatContainer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.DGVMatContainer.Location = new System.Drawing.Point(-2, 85);
            this.DGVMatContainer.MultiSelect = false;
            this.DGVMatContainer.Name = "DGVMatContainer";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVMatContainer.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVMatContainer.RowHeadersWidth = 82;
            this.DGVMatContainer.RowTemplate.Height = 33;
            this.DGVMatContainer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVMatContainer.Size = new System.Drawing.Size(2581, 231);
            this.DGVMatContainer.TabIndex = 1;
            this.DGVMatContainer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellContentClick);
            this.DGVMatContainer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMatContainer_CellEndEdit);
            this.DGVMatContainer.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Change_BGColor);
            this.DGVMatContainer.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.activategrid);
            this.DGVMatContainer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CheckValueCell_Changed);
            this.DGVMatContainer.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.New_Row);
            // 
            // Id_Materiale
            // 
            this.Id_Materiale.DataPropertyName = "Id_Materiale";
            this.Id_Materiale.HeaderText = "Id_Materiale";
            this.Id_Materiale.MinimumWidth = 10;
            this.Id_Materiale.Name = "Id_Materiale";
            this.Id_Materiale.Visible = false;
            // 
            // Quantita_Materiale
            // 
            this.Quantita_Materiale.DataPropertyName = "Quantità_Materiale";
            this.Quantita_Materiale.HeaderText = "Quantità_Materiale";
            this.Quantita_Materiale.MinimumWidth = 10;
            this.Quantita_Materiale.Name = "Quantita_Materiale";
            this.Quantita_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Descrizione_Materiale
            // 
            this.Descrizione_Materiale.DataPropertyName = "Descrizione_Materiale";
            this.Descrizione_Materiale.HeaderText = "Descrizione_Materiale";
            this.Descrizione_Materiale.MinimumWidth = 10;
            this.Descrizione_Materiale.Name = "Descrizione_Materiale";
            this.Descrizione_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lunghezza_Materiale
            // 
            this.Lunghezza_Materiale.DataPropertyName = "Lunghezza_Materiale";
            this.Lunghezza_Materiale.HeaderText = "Lunghezza_Materiale";
            this.Lunghezza_Materiale.MinimumWidth = 10;
            this.Lunghezza_Materiale.Name = "Lunghezza_Materiale";
            this.Lunghezza_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Altezza_Materiale
            // 
            this.Altezza_Materiale.DataPropertyName = "Altezza_Materiale";
            this.Altezza_Materiale.HeaderText = "Altezza_Materiale";
            this.Altezza_Materiale.MinimumWidth = 10;
            this.Altezza_Materiale.Name = "Altezza_Materiale";
            this.Altezza_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Profondita_Materiale
            // 
            this.Profondita_Materiale.DataPropertyName = "Profondita_Materiale";
            this.Profondita_Materiale.HeaderText = "Profondita_Materiale";
            this.Profondita_Materiale.MinimumWidth = 10;
            this.Profondita_Materiale.Name = "Profondita_Materiale";
            this.Profondita_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Peso_Materiale
            // 
            this.Peso_Materiale.DataPropertyName = "Peso_Materiale";
            this.Peso_Materiale.HeaderText = "Peso_Materiale";
            this.Peso_Materiale.MinimumWidth = 10;
            this.Peso_Materiale.Name = "Peso_Materiale";
            this.Peso_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Valore_Materiale
            // 
            this.Valore_Materiale.DataPropertyName = "Valore_Materiale";
            this.Valore_Materiale.HeaderText = "Valore_Materiale";
            this.Valore_Materiale.MinimumWidth = 10;
            this.Valore_Materiale.Name = "Valore_Materiale";
            this.Valore_Materiale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Matricola
            // 
            this.Matricola.DataPropertyName = "Matricola";
            this.Matricola.HeaderText = "Matricola";
            this.Matricola.MinimumWidth = 10;
            this.Matricola.Name = "Matricola";
            this.Matricola.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pericoloso
            // 
            this.Pericoloso.DataPropertyName = "Dangerous";
            this.Pericoloso.HeaderText = "Dangerous";
            this.Pericoloso.MinimumWidth = 10;
            this.Pericoloso.Name = "Pericoloso";
            // 
            // UN_Code
            // 
            this.UN_Code.DataPropertyName = "UN_Code";
            this.UN_Code.HeaderText = "UN_Code";
            this.UN_Code.MinimumWidth = 10;
            this.UN_Code.Name = "UN_Code";
            this.UN_Code.ReadOnly = true;
            this.UN_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Classe_Rischio
            // 
            this.Classe_Rischio.DataPropertyName = "Classe_Rischio";
            this.Classe_Rischio.DisplayStyleForCurrentCellOnly = true;
            this.Classe_Rischio.HeaderText = "Classe_Rischio";
            this.Classe_Rischio.MinimumWidth = 10;
            this.Classe_Rischio.Name = "Classe_Rischio";
            this.Classe_Rischio.ReadOnly = true;
            this.Classe_Rischio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Compatibilita
            // 
            this.Compatibilita.DataPropertyName = "Compatibilita";
            this.Compatibilita.DisplayStyleForCurrentCellOnly = true;
            this.Compatibilita.HeaderText = "Compatibilita";
            this.Compatibilita.MinimumWidth = 10;
            this.Compatibilita.Name = "Compatibilita";
            this.Compatibilita.ReadOnly = true;
            this.Compatibilita.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Peso_Pericoloso
            // 
            this.Peso_Pericoloso.DataPropertyName = "Peso_Pericoloso";
            this.Peso_Pericoloso.HeaderText = "Peso_Pericoloso";
            this.Peso_Pericoloso.MinimumWidth = 10;
            this.Peso_Pericoloso.Name = "Peso_Pericoloso";
            this.Peso_Pericoloso.ReadOnly = true;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(963, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 74);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // LBLStatus
            // 
            this.LBLStatus.AutoSize = true;
            this.LBLStatus.ForeColor = System.Drawing.Color.Red;
            this.LBLStatus.Location = new System.Drawing.Point(13, 54);
            this.LBLStatus.Name = "LBLStatus";
            this.LBLStatus.Size = new System.Drawing.Size(70, 25);
            this.LBLStatus.TabIndex = 3;
            this.LBLStatus.Text = "label1";
            this.LBLStatus.Visible = false;
            // 
            // TestGrigliEditabile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2194, 450);
            this.Controls.Add(this.LBLStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DGVMatContainer);
            this.Name = "TestGrigliEditabile";
            this.Text = "TestGrigliEditabile";
            this.Load += new System.EventHandler(this.TestGriglia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMatContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVMatContainer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantita_Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione_Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lunghezza_Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Altezza_Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profondita_Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso_Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valore_Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricola;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pericoloso;
        private System.Windows.Forms.DataGridViewTextBoxColumn UN_Code;
        private System.Windows.Forms.DataGridViewComboBoxColumn Classe_Rischio;
        private System.Windows.Forms.DataGridViewComboBoxColumn Compatibilita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso_Pericoloso;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label LBLStatus;
    }
}