namespace WinFormsApp1
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Management;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Create an instance of the EventLog class
            
            EventLog WHT = new EventLog("WHT");
            WHT.Source = "Windows Hardening Tool"; 
            WHT.WriteEntry("The tool is closing.", EventLogEntryType.Information);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // enables auto scripting

            autooutbox.Clear();
            autooutbox.Text = RunScript(box1.Text);
            autooutbox.Text = "Auto Script Enabled";
            textBox1.Visible = false;

            // log auto scripting

            EventLog WHT = new EventLog("WHT");
            WHT.Source = "Windows Hardening Tool";
            WHT.WriteEntry("Automatic Scripting Engaged", EventLogEntryType.Information);
        }

        private static string RunScript(string scriptText)
        {
            // create ps runspace

            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it

            runspace.Open();

            // create a pipeline and feed it the script text

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            pipeline.Commands.Add("Out-String");

            // run the script

            Collection <PSObject> results = pipeline.Invoke();

            // close the runspace

            runspace.Close();

            // turn the script result from objedcts into one string

            StringBuilder stringBuilder = new();
            foreach (PSObject psObject in results)
                stringBuilder.AppendLine(psObject.ToString());
            return stringBuilder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // disables Auto Scripting

            autooutbox.Clear();
            autooutbox.Text = RunScript(box2.Text);
            autooutbox.Text = "Auto Script Disabled";
            textBox1.Visible = true;

            // log automatic scripting disabled

            EventLog WHT = new EventLog("WHT");
            WHT.Source = "Windows Hardening Tool";
            WHT.WriteEntry("Automatic Scripting Disengaged", EventLogEntryType.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // test file to test file scripting capabillties

            string sfile = @"C:\Users\Liam_\Desktop\Dissertation\ps.ps1";
            string sfile2 = @"C:\Users\Liam_\Desktop\Dissertation\psuser.ps1";

            // checking if the tickboxes are checked

            object cb1 = checkBox1.CheckState;
            object cb2 = checkBox2.CheckState;
            object cb3 = checkBox3.CheckState;
            object cb4 = checkBox4.CheckState;
            object cb5 = checkBox5.CheckState;

            // if they are ticked run associated file 

            if (Convert.ToString(cb1) == "Checked")
            {
                Outbox.Text = RunScript(sfile);
            }
            if (Convert.ToString(cb2) == "Checked")
            {
                Outbox.Text = RunScript(sfile2);
            }

            // to add more .ps1 files

            if (Convert.ToString(cb3) == "Checked")
            {
                Outbox.Text = RunScript(sfile);
            }
            if (Convert.ToString(cb4) == "Checked")
            {
                Outbox.Text = RunScript(sfile);
            }
            if (Convert.ToString(cb5) == "Checked")
            {
                Outbox.Text = RunScript(sfile);
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // create a searcher to find the os info

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            // go through the search result

            foreach (ManagementObject os in searcher.Get())
            {
                // get the specified info

                string osversion = os["Caption"].ToString() + " " + os["Version"].ToString();
                string osarch = os["OSArchitecture"].ToString();
                DateTime lastBootUpTime = ManagementDateTimeConverter.ToDateTime(os["LastBootUpTime"].ToString());
                TimeSpan osup = DateTime.Now - lastBootUpTime;

                // define the file path

                string filename = "C:\\Users\\Liam_\\Desktop\\Dissertation\\system_report.csv";
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    // write the csv headers

                    sw.WriteLine("Operating System, Architecture, Uptime");

                    // write the os info

                    sw.WriteLine(osversion + "," + osarch + "," + osup);
                }
            }
        }
    }
}