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
            this.Button = new System.Windows.Forms.Button();
            this.Outbox = new System.Windows.Forms.TextBox();
            this.Inbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(1068, 74);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(249, 39);
            this.Button.TabIndex = 0;
            this.Button.Text = "PowerShell";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // Outbox
            // 
            this.Outbox.Location = new System.Drawing.Point(40, 412);
            this.Outbox.Multiline = true;
            this.Outbox.Name = "Outbox";
            this.Outbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Outbox.Size = new System.Drawing.Size(647, 310);
            this.Outbox.TabIndex = 1;
            // 
            // Inbox
            // 
            this.Inbox.Location = new System.Drawing.Point(176, 29);
            this.Inbox.Name = "Inbox";
            this.Inbox.Size = new System.Drawing.Size(1141, 39);
            this.Inbox.TabIndex = 2;
            this.Inbox.Text = "Set-ExecutionPolicy -ExecutionPolicy Undefined";
            this.Inbox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Command:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 758);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Inbox);
            this.Controls.Add(this.Outbox);
            this.Controls.Add(this.Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Button;
        private TextBox Outbox;
        private TextBox Inbox;
        private Label label1;
    }
}