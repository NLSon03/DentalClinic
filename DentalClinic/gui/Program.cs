using DentalClinic;
using gui.PatientForm;
using gui.PatientForm.CompletingMedInvoiceForm;
using gui.PatientForm.PrescriptionForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm.LoginForm());
        }
    }
}
