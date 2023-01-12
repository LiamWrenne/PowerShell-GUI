namespace WinFormsApp1
{
    using System.Security.Principal;
    using System.Security.Permissions;
    using System.Diagnostics;
    using Microsoft.VisualBasic.Logging;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EventLog WHT = new EventLog("WHT");
            WHT.Source = "Windows Hardening Tool";
            WHT.WriteEntry("Starting the tool...", EventLogEntryType.Information);

            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(currentIdentity);
            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                // log sucessful access 
                
                WHT.WriteEntry("Passed Admin Check", EventLogEntryType.Information);
                
                // the user is a local administrator
                // run the tool

                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());

            }
            else
            {
                // the user is not a local administrator
                // show an error message

                MessageBox.Show("You must be a local administrator to run this tool.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // log error message

                WHT.WriteEntry("Failed Admin Check", EventLogEntryType.Error);

            }
        }
    }
}
