﻿namespace WinFormsApp1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Level1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox6 = new System.Windows.Forms.ToolStripTextBox();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox5 = new System.Windows.Forms.ToolStripTextBox();
            this.autooutbox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button.Location = new System.Drawing.Point(1091, 23);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(249, 39);
            this.Button.TabIndex = 0;
            this.Button.Text = "Initialize";
            this.Button.UseVisualStyleBackColor = false;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // Outbox
            // 
            this.Outbox.BackColor = System.Drawing.SystemColors.Info;
            this.Outbox.Location = new System.Drawing.Point(12, 426);
            this.Outbox.Multiline = true;
            this.Outbox.Name = "Outbox";
            this.Outbox.ReadOnly = true;
            this.Outbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Outbox.Size = new System.Drawing.Size(1328, 320);
            this.Outbox.TabIndex = 1;
            // 
            // box1
            // 
            this.box1.Location = new System.Drawing.Point(814, 158);
            this.box1.Name = "box1";
            this.box1.ReadOnly = true;
            this.box1.Size = new System.Drawing.Size(526, 39);
            this.box1.TabIndex = 2;
            this.box1.Text = "Set-ExecutionPolicy -ExecutionPolicy Bypass";
            this.box1.Visible = false;
            // 
            // box2
            // 
            this.box2.Location = new System.Drawing.Point(814, 203);
            this.box2.Name = "box2";
            this.box2.ReadOnly = true;
            this.box2.Size = new System.Drawing.Size(526, 39);
            this.box2.TabIndex = 3;
            this.box2.Text = "Set-ExecutionPolicy -ExecutionPolicy Undefined";
            this.box2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(1091, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Deactivate";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(868, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Automated Script -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(868, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Automated Script -";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Level1ToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1352, 40);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Level1ToolStripMenuItem
            // 
            this.Level1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripTextBox3,
            this.toolStripTextBox6});
            this.Level1ToolStripMenuItem.Name = "Level1ToolStripMenuItem";
            this.Level1ToolStripMenuItem.Size = new System.Drawing.Size(251, 36);
            this.Level1ToolStripMenuItem.Text = "Configuration Menu";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(300, 39);
            this.toolStripTextBox1.Text = "Cyber Essentials";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.ReadOnly = true;
            this.toolStripTextBox3.Size = new System.Drawing.Size(300, 39);
            this.toolStripTextBox3.Text = "(Beta) IASME Assurance ";
            // 
            // toolStripTextBox6
            // 
            this.toolStripTextBox6.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripTextBox6.Name = "toolStripTextBox6";
            this.toolStripTextBox6.Size = new System.Drawing.Size(300, 39);
            this.toolStripTextBox6.Text = "(Beta) Windows Baseline";
            this.toolStripTextBox6.Click += new System.EventHandler(this.toolStripTextBox6_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.BackColor = System.Drawing.Color.DarkGray;
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2,
            this.toolStripTextBox5});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(271, 36);
            this.infoToolStripMenuItem.Text = "Information Gathering";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.ReadOnly = true;
            this.toolStripTextBox2.Size = new System.Drawing.Size(300, 39);
            this.toolStripTextBox2.Text = "OS information";
            this.toolStripTextBox2.Click += new System.EventHandler(this.toolStripTextBox2_Click);
            // 
            // toolStripTextBox5
            // 
            this.toolStripTextBox5.Name = "toolStripTextBox5";
            this.toolStripTextBox5.ReadOnly = true;
            this.toolStripTextBox5.Size = new System.Drawing.Size(300, 39);
            this.toolStripTextBox5.Text = "System information";
            this.toolStripTextBox5.Click += new System.EventHandler(this.toolStripTextBox5_Click);
            // 
            // autooutbox
            // 
            this.autooutbox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.autooutbox.Location = new System.Drawing.Point(868, 115);
            this.autooutbox.Name = "autooutbox";
            this.autooutbox.ReadOnly = true;
            this.autooutbox.Size = new System.Drawing.Size(472, 39);
            this.autooutbox.TabIndex = 15;
            this.autooutbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(591, 322);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "\r\n\r\n------------------------->>\r\nPlease Allow for Automated scripting!\r\n---------" +
    "---------------->>\r\n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Location = new System.Drawing.Point(1204, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 50);
            this.button2.TabIndex = 17;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1352, 758);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.autooutbox);
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
            this.Text = "WHT";
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Level1ToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private TextBox autooutbox;
        private TextBox textBox1;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripTextBox toolStripTextBox3;
        private Button button2;
        private ToolStripTextBox toolStripTextBox5;
        private ToolStripTextBox toolStripTextBox6;
    }
}