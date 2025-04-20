using System.Diagnostics;

namespace Power
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            Process currentProcess = Process.GetCurrentProcess();
            if (Process.GetProcessesByName(currentProcess.ProcessName).Length > 1)
            {
                MessageBox.Show("La aplicaci�n ya est� en ejecuci�n.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}