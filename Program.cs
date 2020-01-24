using IMTS_MINUTES.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMTS_MINUTES
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);
            if (BusinessLogic.BLTransactionManager.ReadAppStart().Equals("1"))
            {


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Forms.Minutes.StartMinutes st = new Forms.Minutes.StartMinutes();
                //
                //Form1 st = new Form1();
                st.WindowState = FormWindowState.Maximized;


                Application.Run(st);
            }
            else
            {
                if (MessageBox.Show("Impossible to start program, something wrong replace backupFiles and set App Start.", "Critical error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    //string cmdexePath = IMTS.BusinessLogic.Utils.getRestoreBactchPath;
                    ////notice the quotes around the below string...

                    ////the /K keeps the CMD window open - even if your windows app closes
                    //string cmdArguments = String.Format("/K {0}", cmdexePath);
                    //ProcessStartInfo psi = new ProcessStartInfo(cmdexePath, cmdArguments);
                    //Process p = new Process();

                    //p.StartInfo = psi;
                    //p.Start();

                }
            }

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception, display it, etc
            Exception ex = (Exception)e.ExceptionObject;
            BLExceptionHandler ble = new BLExceptionHandler();
            try
            {
                ble.WriteLog(DateTime.Now.ToShortDateString(), DateTime.Now, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "");
                MessageBox.Show("Exception raised and managed but Application will be closed. See log for more details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("UnhandledException Application will be closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Application.Exit();
        }

        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            try
            {
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
                    "with the following information:\n\n";
                errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
                if (DialogResult.OK == MessageBox.Show(errorMsg, title, MessageBoxButtons.OK,
                                MessageBoxIcon.Stop))
                    return DialogResult.Abort;
                else
                    return DialogResult.Abort;
            }
            catch { return DialogResult.Abort; }
            finally
            {
                Application.Exit();
            }
        }
        private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
            }
            catch
            {

                MessageBox.Show("Fatal Windows Forms Error",
                    "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);


            }

            // Exits the program when the user clicks Abort.
            finally
            {

                Application.Exit();
            }
        }

    }
}
