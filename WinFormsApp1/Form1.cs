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
    using System.Reflection;
    using System.Xml.Linq;
    using System.Formats.Asn1;
    using System.Globalization;
    using System;
    using System.Linq;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // ! identifies not null, avoids a warning
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing!);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Create an instance of the EventLog class

            EventLog WHT = new("WHT")
            {
                Source = "Windows Hardening Tool"
            };
            WHT.WriteEntry("The tool is closing.", EventLogEntryType.Information);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // enables auto scripting

            autooutbox.Text = RunScript(box1.Text);
            autooutbox.Text = "Auto Script Enabled";
            textBox1.Visible = false;

            // log auto scripting

            EventLog WHT = new("WHT")
            {
                Source = "Windows Hardening Tool"
            };
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

            Collection<PSObject> results = pipeline.Invoke();

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

            autooutbox.Text = RunScript(box2.Text);
            autooutbox.Text = "Auto Script Disabled";
            textBox1.Visible = true;

            // log automatic scripting disabled

            EventLog WHT = new("WHT")
            {
                Source = "Windows Hardening Tool"
            };
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
                Outbox.Text += RunScript(sfile);
            }
            if (Convert.ToString(cb2) == "Checked")
            {
                Outbox.Text += RunScript(sfile2);
            }

            // to add more .ps1 files

            if (Convert.ToString(cb3) == "Checked")
            {

            }
            if (Convert.ToString(cb4) == "Checked")
            {

            }
            if (Convert.ToString(cb5) == "Checked")
            {

            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to use this tool to collect info, this will be stored locally", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                FolderBrowserDialog folderBrowserDialog = new();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // get folder path

                    string folderPath = folderBrowserDialog.SelectedPath;

                    {
                        // create a searcher to find the info

                        ManagementObjectSearcher searcher = new("SELECT * FROM Win32_OperatingSystem");

                        // go through result

                        foreach (ManagementObject info in searcher.Get().Cast<ManagementObject>())
                        {
                            // get the os info ! avoids a null warning

                            string osversion = info["Caption"].ToString() + " " + info["Version"].ToString();
                            string osarch = info["OSArchitecture"].ToString()!;
                            DateTime lastbootuptime = ManagementDateTimeConverter.ToDateTime(info["LastBootUpTime"].ToString());
                            TimeSpan osup = DateTime.Now - lastbootuptime;

                            if (File.Exists(folderPath + "\\WHT_OS_Report.csv"))
                            {

                                File.Move(folderPath + "\\WHT_OS_Report.csv", folderPath + "\\WHT_OS_Report_History.csv");

                                using StreamWriter sw = new(folderPath + "\\WHT_OS_Report.csv");

                                sw.WriteLine("Operating System, Architecture, Up-time (Days:Hours:Minutes:Seconds)");

                                sw.WriteLine(osversion + "," + osarch + "," + osup);
                            }

                            else
                            {
                                using StreamWriter sw = new(folderPath + "\\WHT_OS_Report.csv");

                                sw.WriteLine("Operating System, Architecture, Up-time (Days:Hours:Minutes:Seconds)");

                                sw.WriteLine(osversion + "," + osarch + "," + osup);
                            }

                            // let the user know it has been successful

                            Outbox.Text += "OS info scan complete";
                        }
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                // cancel
            }
            else
            {
                // cancel
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // clear text 
            Outbox.Clear();
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            // advanced options

            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
            checkBox5.Visible = true;
            button3.Visible = true;
        }

        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to use this tool to collect info, this will be stored locally", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                FolderBrowserDialog folderBrowserDialog = new();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // get folder path

                    string folderPath = folderBrowserDialog.SelectedPath;
                    {
                        // search for sytem info

                        ManagementObjectSearcher syssearcher = new("SELECT * FROM Win32_ComputerSystem");

                        // go through the search result

                        foreach (ManagementObject info in syssearcher.Get().Cast<ManagementObject>())
                        {
                            // get system info ! avoids a warning

                            string sysman = info["Manufacturer"].ToString()!;
                            string mod = info["Model"].ToString()!;
                            string name = info["Name"].ToString()!;
                            string systype = info["SystemType"].ToString()!;

                            if (File.Exists(folderPath + "\\ WHT_SYS_Report.csv"))
                            {
                                File.Move(folderPath + "\\ WHT_SYS_Report.csv", folderPath + "\\ WHT_SYS_Report_History.csv");

                                using StreamWriter sw = new(folderPath + "\\ WHT_SYS_Report.csv");

                                sw.WriteLine("Manufacturer, Model, Name, Type");

                                sw.WriteLine(sysman + "," + mod + "," + name + "," + systype);
                            }

                            else
                            {
                                using StreamWriter sw = new(folderPath + "\\ WHT_SYS_Report.csv");

                                sw.WriteLine("Manufacturer, Model, Name, Type");

                                sw.WriteLine(sysman + "," + mod + "," + name + "," + systype);
                            }
                            Outbox.Text += "System info scan complete";
                        }
                    }
                }
                else if (result == DialogResult.No)
                {
                    // cancel
                }
                else
                {
                    // cancel
                }
            }
        }

        private void toolStripTextBox6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to apply Windows Swcurity Baseline?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                FolderBrowserDialog folderBrowserDialog = new();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string baselinefolderPath = folderBrowserDialog.SelectedPath;
                    {
                        Outbox.Text += RunScript(baselinefolderPath + "\\Scripts" + "\\psuser.ps1");
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                // cancel
            }
            else
            {
                // cancel
            }
        }
        //
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            string output;
            string sfile2 = @"C:\Users\Liam_\Desktop\Dissertation\psuser.ps1";
            string ps = @"C:\Users\Liam_\Desktop\Dissertation\" + "\\psout.csv";
            


            output = RunScript(sfile2);

            using StreamWriter sw = new(ps);

            sw.Write(output);

            sw.Close();

            var reader = new StreamReader(ps);

            // want to remove first few lines to allow a choice what to add or remove etc
            int linesremove = 3;
            var fulltext = reader.ReadToEnd();
            string[] lines = fulltext.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string outlines = string.Join("\n", lines.Skip(linesremove));
            reader.Close();

            var newlines = outlines.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> correctlines = new List<string>();
            foreach (string line in newlines)
            {
                string togetrid = "False";
                if (!line.Contains(togetrid))
                {
                    correctlines.Add(line.Trim());
                }
            }

            if (correctlines.Count > 0)
            {
                correctlines.RemoveAll(line => string.IsNullOrWhiteSpace(line));

                // Display a list of the correct lines and allow the user to select one or more
                var selectedLines = MessageBox.Show($"Here is a list of current users:\n\n{string.Join("\n", correctlines)}\n\nIt is recommended to only have the required users typically an Admin account and a standard user account.", "Current Users", MessageBoxButtons.OKCancel);

                if (selectedLines == DialogResult.OK)
                {
                    // User clicked OK, so keep the selected lines
                    List<string> selectedUsernames = new List<string>();

                    foreach (string line in correctlines)
                    {
                        DialogResult result = MessageBox.Show($"Select which user(s) you want to keep:\n\n{line}\n\nIt is recommended to only have the required users typically an Admin account and a standard user account. We will then check those that are kept meet requirements.", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            var userword = line.Split()[0].Trim();

                            string sfile5 = $"Get-LocalUser -Name {userword} | Select-Object PasswordLastSet, PasswordExpires, PasswordRequired, PasswordChangeable, PasswordComplexity";
                            Outbox.Text += RunScript(sfile5);

                            selectedUsernames.Add(line);
                        }
                        else if (result == DialogResult.No)
                        {
                            var userword = line.Split()[0].Trim();

                            using (var searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_UserAccount WHERE Name='{userword}'"))
                            {
                                 
                                foreach (ManagementObject user in searcher.Get())
                                {
                                    string? username = user["Name"].ToString();
                                    string sfile3 = $"Remove-LocalUser -Name {username} -ErrorAction Stop";
                                    RunScript(sfile3);
                                    Outbox.Text += "Sucessfully Deleted User: " + username;
                                }
                            }
                        }
                        else
                        {
                            // cancel

                        }
                    }
                }
                else
                {
                    // User clicked Cancel, so do nothing
                }
            }
            else
            {
                // There are no correct lines, so do nothing
            }
        }
    }
}