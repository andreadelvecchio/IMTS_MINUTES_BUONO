using IMTS_MINUTES.BusinessLogic;
using IMTS_MINUTES.BusinessLogic.BLMinutes;
using IMTS_MINUTES.Forms.Minutes.Compila;
using System;
using System.Windows.Forms;

namespace IMTS_MINUTES.Forms.Minutes
{
    public partial class StartMinutes : Form
    {
        private int childFormNumber = 0;

        public StartMinutes()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Finestra " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void WriteMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            // WeaonsFormMode formMode = WeaonsFormMode.AddWeeapons;
            IMTS_MINUTES.Forms.Minutes.Compila.WriteMinutes childForm = new IMTS_MINUTES.Forms.Minutes.Compila.WriteMinutes(1);
            childForm.MdiParent = this;
            childForm.Text = "WriteMinutes";// + childFormNumber++;
            childForm.StartPosition = FormStartPosition.CenterScreen;

            childForm.Show();
           // childForm.MdiParent.ActiveMdiChild.Close();

            
        }

        private void PrintMinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            IMTS_MINUTES.Forms.Minutes.Compila.PrintMinutes childForm = new PrintMinutes();
            
            childForm.MdiParent = this;
            childForm.Text = "WriteMinutes";// + childFormNumber++;
            childForm.WindowState = FormWindowState.Maximized;
            //childForm.InitGrid();

           
            
           childForm.Show();
        }

        private void TestgrigliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //IMTS_MINUTES.Forms.Minutes.Compila.TestGrigliEditabile childForm = new IMTS_MINUTES.Forms.Minutes.Compila.TestGrigliEditabile();
            //childForm.MdiParent = this;
            //childForm.Text = "TestGrigliEditabile";// + childFormNumber++;
            //childForm.WindowState = FormWindowState.Maximized;
            //BLWriteMiutes bLWrite = new BLWriteMiutes();

            //if (bLWrite.GetMateriale_Container().Rows.Count == 0)
            //{
            //    bLWrite.InsertMaterialeWithTransaction(0, "", "", "", "", "", "", "", false, "", "", "", "");
                


            //}
            //childForm.Show();

        }

        private void ExportMinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure do you want export your work in zip file?", "Export files", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                BLZip blz = new BLZip();
                blz.ZipTabEsportabiliInZiPfile();
                MessageBox.Show("File is  zipped ready for export");
                SaveFileDialog openFileDialog = new SaveFileDialog();
                openFileDialog.InitialDirectory = Utils.getBasePathName;
                openFileDialog.Filter = "File zip (*.zip)|*.zip";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                }

            }
        }

        private void ImportMinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure do you want unzip the file and clean?", "Rebuild minute", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog.Filter = "File zip (*.zip)|*.zip";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = openFileDialog.FileName;
                    BLZip blz = new BLZip();
                    blz.UnzipFilenameInFolder(FileName);
                    MessageBox.Show("File Unzipped and project is clean, Minute Loaded");
                    IMTS_MINUTES.Forms.Minutes.Compila.WriteMinutes childForm = new IMTS_MINUTES.Forms.Minutes.Compila.WriteMinutes(0);
                    childForm.MdiParent = this;
                    childForm.Text = "WriteMinutes";// + childFormNumber++;
                    childForm.WindowState = FormWindowState.Maximized;

                    childForm.Show();
                }
            }

         

    }
}
}
