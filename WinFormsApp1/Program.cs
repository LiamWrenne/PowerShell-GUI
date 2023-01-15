namespace WinFormsApp1
{
    using System.Security.Principal;
    using System.Diagnostics;

    internal static class Program
    {
        //  the main entry point for the application.

        [STAThread]
        static void Main()
        {
            EventLog WHT = new("WHT")
            {
                Source = "Windows Hardening Tool"
            };
            WHT.WriteEntry("Starting the tool", EventLogEntryType.Information);

            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new(currentIdentity);
            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                // log sucessful access 
                
                WHT.WriteEntry("Passed Admin Check", EventLogEntryType.Information);
                
                // the user is a local admin
                // run the tool

                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());

            }
            else
            {
                // the user is not a local admin
                // show an error message

                MessageBox.Show("You must be a local administrator to run this tool.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // log falied access as an error

                WHT.WriteEntry("Failed Admin Check", EventLogEntryType.Error);

            }
        }
    }
}
