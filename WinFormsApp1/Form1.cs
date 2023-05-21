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

                            EventLog WHT = new("WHT")
                            {
                                Source = "Windows Hardening Tool"
                            };
                            WHT.WriteEntry("OS info scan complete", EventLogEntryType.Information);
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

                            EventLog WHT = new("WHT")
                            {
                                Source = "Windows Hardening Tool"
                            };
                            WHT.WriteEntry("System info scan complete", EventLogEntryType.Information);
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

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            DialogResult firstresult = MessageBox.Show("Please select the folder path where the PowerShell Scripts is stored", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (firstresult == DialogResult.Yes)
            {
                FolderBrowserDialog folderBrowserDialog = new();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // get folder path

                    string folderPath = folderBrowserDialog.SelectedPath;

                    // Set the file paths for the PowerShell script and the output CSV file
                    string sfile2 = folderPath + "/psuser.ps1";
                    string ps = folderPath + "/psout.csv";

                    // Run the PowerShell script and capture the output
                    string output = RunScript(sfile2);

                    // Write the output to the CSV file
                    using StreamWriter sw = new(ps);
                    sw.Write(output);
                    sw.Close();

                    // Read the CSV file and remove the first few lines
                    int linesremove = 3;
                    var reader = new StreamReader(ps);
                    var fulltext = reader.ReadToEnd();
                    string[] lines = fulltext.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    string outlines = string.Join("\n", lines.Skip(linesremove));
                    reader.Close();

                    // Process the remaining lines and filter out lines containing "False"
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

                    // Check if there are any correct lines
                    if (correctlines.Count > 0)
                    {
                        // Remove empty lines from the list of correct lines
                        correctlines.RemoveAll(line => string.IsNullOrWhiteSpace(line));

                        // Display the list of correct lines and allow the user to select one or more
                        var selectedLines = MessageBox.Show($"Here is a list of current users:\n\n{string.Join("\n", correctlines)}\n\nIt is recommended to only have the required users typically an Admin account and a standard user account.", "Current Users", MessageBoxButtons.OKCancel);

                        // Process the selected lines
                        if (selectedLines == DialogResult.OK)
                        {
                            // User clicked OK, so keep the selected lines
                            List<string> selectedUsernames = new List<string>();
                            foreach (string line in correctlines)
                            {
                                // Prompt the user to confirm whether to keep or remove the user
                                DialogResult result = MessageBox.Show($"Select which user(s) you want to keep:\n\n{line}\n\nIt is recommended to only have the required users typically an Admin account and a standard user account. We will then check those that are kept meet requirements.", "Confirmation", MessageBoxButtons.YesNoCancel);

                                if (result == DialogResult.Yes)
                                {
                                    // Get information about the selected user using PowerShell
                                    var userword = line.Split()[0].Trim();
                                    string sfile5 = $"Get-LocalUser -Name {userword} | Select-Object PasswordLastSet, PasswordExpires, PasswordRequired, PasswordChangeable, PasswordComplexity";
                                    Outbox.Text = $"Here is some info on this account: {userword} ";
                                    Outbox.Text += RunScript(sfile5);

                                    // Add the selected line to the list of selected usernames
                                    selectedUsernames.Add(line);
                                }
                                else if (result == DialogResult.No)
                                {
                                    // Remove the user using PowerShell
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
                            // cancel
                        }
                    }
                    else
                    {
                        // no correct lines, cancel
                    }

                    DialogResult results = MessageBox.Show($"Would you like to De-bloat your machine? This will unistall various unesseray applications from your device. (Recommended to use on a new device as other apps may be unistalled.)", "Confirmation", MessageBoxButtons.YesNoCancel);

                    if (results == DialogResult.Yes)
                    {
                        string bloatpath = folderPath + "/ps.ps1";
                        Outbox.Text += RunScript(bloatpath);
                    }
                    else if (results == DialogResult.No)
                    {
                        // cancel
                    }
                    else
                    {
                        // cancel
                    }

                    DialogResult lastresult = MessageBox.Show("Would you like to disable autorun features?", "Confirmation", MessageBoxButtons.YesNoCancel);

                    if (results == DialogResult.Yes)
                    {
                        string autorun = folderPath + "/autorun.ps1/";
                        Outbox.Text += RunScript(autorun);
                    }
                    else if (results == DialogResult.No)
                    {
                        // cancel
                    }
                    else
                    {
                        // cancel
                    }

                    Outbox.Text += "Cyber Essenetials Hardening Complete!";

                    EventLog WHT = new("WHT")
                    {
                        Source = "Windows Hardening Tool"
                    };
                    WHT.WriteEntry("Cyber Essenetials Hardening Complete!", EventLogEntryType.Information);


                }
            }
        }
    }
}