using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SampleApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Event_View());

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.StackTrace);

            }
        }
    }
}
