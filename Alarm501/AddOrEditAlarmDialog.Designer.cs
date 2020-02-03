namespace Alarm501
{
    partial class AddOrEditAlarmDialog
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.uxTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uxCancelButton = new System.Windows.Forms.Button();
            this.uxSetButton = new System.Windows.Forms.Button();
            this.uxOnButton = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // uxTimePicker
            // 
            this.uxTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uxTimePicker.Location = new System.Drawing.Point(21, 28);
            this.uxTimePicker.Name = "uxTimePicker";
            this.uxTimePicker.Size = new System.Drawing.Size(161, 22);
            this.uxTimePicker.TabIndex = 0;
            this.uxTimePicker.Value = new System.DateTime(2020, 2, 2, 0, 0, 0, 0);
            // 
            // uxCancelButton
            // 
            this.uxCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCancelButton.Location = new System.Drawing.Point(21, 75);
            this.uxCancelButton.Name = "uxCancelButton";
            this.uxCancelButton.Size = new System.Drawing.Size(87, 46);
            this.uxCancelButton.TabIndex = 2;
            this.uxCancelButton.Text = "Cancel";
            this.uxCancelButton.UseVisualStyleBackColor = true;
            // 
            // uxSetButton
            // 
            this.uxSetButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxSetButton.Location = new System.Drawing.Point(169, 75);
            this.uxSetButton.Name = "uxSetButton";
            this.uxSetButton.Size = new System.Drawing.Size(87, 46);
            this.uxSetButton.TabIndex = 3;
            this.uxSetButton.Text = "Set";
            this.uxSetButton.UseVisualStyleBackColor = true;
            // 
            // uxOnButton
            // 
            this.uxOnButton.AutoSize = true;
            this.uxOnButton.Checked = true;
            this.uxOnButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uxOnButton.Location = new System.Drawing.Point(205, 29);
            this.uxOnButton.Name = "uxOnButton";
            this.uxOnButton.Size = new System.Drawing.Size(49, 21);
            this.uxOnButton.TabIndex = 4;
            this.uxOnButton.Text = "On";
            this.uxOnButton.UseVisualStyleBackColor = true;
            // 
            // AddOrEditAlarmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 143);
            this.Controls.Add(this.uxOnButton);
            this.Controls.Add(this.uxSetButton);
            this.Controls.Add(this.uxCancelButton);
            this.Controls.Add(this.uxTimePicker);
            this.MaximizeBox = false;
            this.Name = "AddOrEditAlarmDialog";
            this.Text = "Add/Edit Alarm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DateTimePicker uxTimePicker;
        private System.Windows.Forms.Button uxCancelButton;
        private System.Windows.Forms.Button uxSetButton;
        private System.Windows.Forms.CheckBox uxOnButton;
    }
}