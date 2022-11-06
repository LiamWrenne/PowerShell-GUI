namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Button = new System.Windows.Forms.Button();
            this.Outbox = new System.Windows.Forms.TextBox();
            this.box1 = new System.Windows.Forms.TextBox();
            this.box2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Level1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.autooutbox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(1068, 74);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(249, 39);
            this.Button.TabIndex = 0;
            this.Button.Text = "Initialize";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // Outbox
            // 
            this.Outbox.Location = new System.Drawing.Point(40, 414);
            this.Outbox.Multiline = true;
            this.Outbox.Name = "Outbox";
            this.Outbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Outbox.Size = new System.Drawing.Size(1022, 308);
            this.Outbox.TabIndex = 1;
            // 
            // box1
            // 
            this.box1.Location = new System.Drawing.Point(791, 29);
            this.box1.Name = "box1";
            this.box1.ReadOnly = true;
            this.box1.Size = new System.Drawing.Size(526, 39);
            this.box1.TabIndex = 2;
            this.box1.Text = "Set-ExecutionPolicy -ExecutionPolicy Bypass";
            this.box1.Visible = false;
            // 
            // box2
            // 
            this.box2.Location = new System.Drawing.Point(791, 119);
            this.box2.Name = "box2";
            this.box2.ReadOnly = true;
            this.box2.Size = new System.Drawing.Size(526, 39);
            this.box2.TabIndex = 3;
            this.box2.Text = "Set-ExecutionPolicy -ExecutionPolicy Undefined";
            this.box2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1068, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Deactivate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(845, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Automated Script -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(845, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Automated Script -";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(40, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 36);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Get-Process";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(40, 115);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(194, 36);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Get-LocalUser";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(40, 157);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(159, 36);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(40, 199);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(159, 36);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(40, 241);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(159, 36);
            this.checkBox5.TabIndex = 12;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(40, 283);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(249, 39);
            this.button3.TabIndex = 13;
            this.button3.Text = "Run Selected Script";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Level1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1352, 40);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Level1ToolStripMenuItem
            // 
            this.Level1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.Level1ToolStripMenuItem.Name = "Level1ToolStripMenuItem";
            this.Level1ToolStripMenuItem.Size = new System.Drawing.Size(216, 36);
            this.Level1ToolStripMenuItem.Text = "Dropdown Menu";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 39);
            this.toolStripTextBox1.Text = "Level 1";
            // 
            // autooutbox
            // 
            this.autooutbox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.autooutbox.Location = new System.Drawing.Point(845, 241);
            this.autooutbox.Name = "autooutbox";
            this.autooutbox.ReadOnly = true;
            this.autooutbox.Size = new System.Drawing.Size(472, 39);
            this.autooutbox.TabIndex = 15;
            this.autooutbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(317, 304);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "\r\n\r\n------------------------->>\r\nPlease Allow for Automated scripting!\r\n---------" +
    "---------------->>\r\n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 758);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.autooutbox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.Outbox);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Button;
        private TextBox Outbox;
        private TextBox box1;
        private TextBox box2;
        private Button button1;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private Button button3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Level1ToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private TextBox autooutbox;
        private TextBox textBox1;
    }
}