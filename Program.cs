using System;
using System.Windows.Forms;
using System.Threading;
namespace TrapezeAndSimpsonIntegral
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Global catch
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalCatch);
            // Run form
            Application.Run(new MainForm());
        }

        private static void GlobalCatch(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
