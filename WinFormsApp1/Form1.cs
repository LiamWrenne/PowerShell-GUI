namespace WinFormsApp1
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Text;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //Enables Auto Scripting

            autooutbox.Clear();
            autooutbox.Text = RunScript(box1.Text);
            autooutbox.Text = "Auto Script Enabled";
            textBox1.Visible = false;
        }

        private static string RunScript(string scriptText)
        {
            // create Powershell runspace

            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it

            runspace.Open();

            // create a pipeline and feed it the script text

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            pipeline.Commands.Add("Out-String");

            // execute the script

            Collection <PSObject> results = pipeline.Invoke();

            // close the runspace

            runspace.Close();

            // convert the script result into a single string

            StringBuilder stringBuilder = new();
            foreach (PSObject psObject in results)
                stringBuilder.AppendLine(psObject.ToString());
            return stringBuilder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Disables Auto Scripting

            autooutbox.Clear();
            autooutbox.Text = RunScript(box2.Text);
            autooutbox.Text = "Auto Script Disabled";
            textBox1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Test File to test file scripting capabillties

            string sfile = @"C:\Users\Liam_\Desktop\Dissertation\ps.ps1";
            string sfile2 = @"C:\Users\Liam_\Desktop\Dissertation\psuser.ps1";

            //Checking if the Tickboxes are checked

            object cb1 = checkBox1.CheckState;
            object cb2 = checkBox2.CheckState;
            object cb3 = checkBox3.CheckState;
            object cb4 = checkBox4.CheckState;
            object cb5 = checkBox5.CheckState;

            //If they are ticked run associated file 

            if (Convert.ToString(cb1) == "Checked")
            {
                Outbox.Text = RunScript(sfile);
            }
            if (Convert.ToString(cb2) == "Checked")
            {
                Outbox.Text = RunScript(sfile2);
            }
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
    }
}