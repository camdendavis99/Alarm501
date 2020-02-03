namespace Alarm501
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxEditButton = new System.Windows.Forms.Button();
            this.uxAddButton = new System.Windows.Forms.Button();
            this.uxSnoozeButton = new System.Windows.Forms.Button();
            this.uxStopButton = new System.Windows.Forms.Button();
            this.uxAlarmList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // uxEditButton
            // 
            this.uxEditButton.Enabled = false;
            this.uxEditButton.Location = new System.Drawing.Point(28, 35);
            this.uxEditButton.Name = "uxEditButton";
            this.uxEditButton.Size = new System.Drawing.Size(83, 45);
            this.uxEditButton.TabIndex = 0;
            this.uxEditButton.Text = "Edit";
            this.uxEditButton.UseVisualStyleBackColor = true;
            this.uxEditButton.Click += new System.EventHandler(this.uxEditButton_Click);
            // 
            // uxAddButton
            // 
            this.uxAddButton.Location = new System.Drawing.Point(165, 35);
            this.uxAddButton.Name = "uxAddButton";
            this.uxAddButton.Size = new System.Drawing.Size(83, 45);
            this.uxAddButton.TabIndex = 1;
            this.uxAddButton.Text = "+";
            this.uxAddButton.UseVisualStyleBackColor = true;
            this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
            // 
            // uxSnoozeButton
            // 
            this.uxSnoozeButton.Enabled = false;
            this.uxSnoozeButton.Location = new System.Drawing.Point(28, 299);
            this.uxSnoozeButton.Name = "uxSnoozeButton";
            this.uxSnoozeButton.Size = new System.Drawing.Size(83, 45);
            this.uxSnoozeButton.TabIndex = 2;
            this.uxSnoozeButton.Text = "Snooze";
            this.uxSnoozeButton.UseVisualStyleBackColor = true;
            this.uxSnoozeButton.Click += new System.EventHandler(this.SnoozeButton_Click);
            // 
            // uxStopButton
            // 
            this.uxStopButton.Enabled = false;
            this.uxStopButton.Location = new System.Drawing.Point(165, 299);
            this.uxStopButton.Name = "uxStopButton";
            this.uxStopButton.Size = new System.Drawing.Size(83, 45);
            this.uxStopButton.TabIndex = 3;
            this.uxStopButton.Text = "Stop";
            this.uxStopButton.UseVisualStyleBackColor = true;
            this.uxStopButton.Click += new System.EventHandler(this.uxStopButton_Click);
            // 
            // uxAlarmList
            // 
            this.uxAlarmList.FormattingEnabled = true;
            this.uxAlarmList.ItemHeight = 16;
            this.uxAlarmList.Location = new System.Drawing.Point(28, 97);
            this.uxAlarmList.Name = "uxAlarmList";
            this.uxAlarmList.Size = new System.Drawing.Size(220, 180);
            this.uxAlarmList.TabIndex = 4;
            this.uxAlarmList.SelectedIndexChanged += new System.EventHandler(this.uxAlarmList_SelectedIndexChanged);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 374);
            this.Controls.Add(this.uxAlarmList);
            this.Controls.Add(this.uxStopButton);
            this.Controls.Add(this.uxSnoozeButton);
            this.Controls.Add(this.uxAddButton);
            this.Controls.Add(this.uxEditButton);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Alarm501";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveAlarms);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxEditButton;
        private System.Windows.Forms.Button uxAddButton;
        private System.Windows.Forms.Button uxSnoozeButton;
        private System.Windows.Forms.Button uxStopButton;
        private System.Windows.Forms.ListBox uxAlarmList;
    }
}

