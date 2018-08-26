namespace Schedule
{
    partial class frmSlotDialog
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
            this.tmeStart = new System.Windows.Forms.DateTimePicker();
            this.tmeFinish = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFinish = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.cbxHW = new System.Windows.Forms.CheckBox();
            this.cbxCH = new System.Windows.Forms.CheckBox();
            this.cbxWF = new System.Windows.Forms.CheckBox();
            this.cbxIH = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tmeStart
            // 
            this.tmeStart.Location = new System.Drawing.Point(67, 69);
            this.tmeStart.Name = "tmeStart";
            this.tmeStart.Size = new System.Drawing.Size(171, 20);
            this.tmeStart.TabIndex = 0;
            // 
            // tmeFinish
            // 
            this.tmeFinish.Location = new System.Drawing.Point(67, 102);
            this.tmeFinish.Name = "tmeFinish";
            this.tmeFinish.Size = new System.Drawing.Size(171, 20);
            this.tmeFinish.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(44, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(126, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Location = new System.Drawing.Point(5, 102);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(56, 13);
            this.lblFinish.TabIndex = 6;
            this.lblFinish.Text = "End TIme:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(5, 69);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(58, 13);
            this.lblStart.TabIndex = 7;
            this.lblStart.Text = "Start Time:";
            // 
            // cbxHW
            // 
            this.cbxHW.AutoSize = true;
            this.cbxHW.Location = new System.Drawing.Point(26, 13);
            this.cbxHW.Name = "cbxHW";
            this.cbxHW.Size = new System.Drawing.Size(75, 17);
            this.cbxHW.TabIndex = 8;
            this.cbxHW.Text = "Hot Water";
            this.cbxHW.UseVisualStyleBackColor = true;
            // 
            // cbxCH
            // 
            this.cbxCH.AutoSize = true;
            this.cbxCH.Location = new System.Drawing.Point(119, 13);
            this.cbxCH.Name = "cbxCH";
            this.cbxCH.Size = new System.Drawing.Size(99, 17);
            this.cbxCH.TabIndex = 9;
            this.cbxCH.Text = "Central Heating";
            this.cbxCH.UseVisualStyleBackColor = true;
            // 
            // cbxWF
            // 
            this.cbxWF.AutoSize = true;
            this.cbxWF.Location = new System.Drawing.Point(26, 36);
            this.cbxWF.Name = "cbxWF";
            this.cbxWF.Size = new System.Drawing.Size(80, 17);
            this.cbxWF.TabIndex = 10;
            this.cbxWF.Text = "Wifi Enable";
            this.cbxWF.UseVisualStyleBackColor = true;
            // 
            // cbxIH
            // 
            this.cbxIH.AutoSize = true;
            this.cbxIH.Location = new System.Drawing.Point(119, 36);
            this.cbxIH.Name = "cbxIH";
            this.cbxIH.Size = new System.Drawing.Size(54, 17);
            this.cbxIH.TabIndex = 11;
            this.cbxIH.Text = "Inhibit";
            this.cbxIH.UseVisualStyleBackColor = true;
            // 
            // frmSlotDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 168);
            this.Controls.Add(this.cbxIH);
            this.Controls.Add(this.cbxWF);
            this.Controls.Add(this.cbxCH);
            this.Controls.Add(this.cbxHW);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblFinish);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tmeFinish);
            this.Controls.Add(this.tmeStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSlotDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Schedule Slot...";
            this.Load += new System.EventHandler(this.frmSlotDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker tmeStart;
        private System.Windows.Forms.DateTimePicker tmeFinish;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFinish;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.CheckBox cbxHW;
        private System.Windows.Forms.CheckBox cbxCH;
        private System.Windows.Forms.CheckBox cbxWF;
        private System.Windows.Forms.CheckBox cbxIH;
    }
}