namespace Schedule01
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
            this.cboState = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tmeStart
            // 
            this.tmeStart.Location = new System.Drawing.Point(29, 44);
            this.tmeStart.Name = "tmeStart";
            this.tmeStart.Size = new System.Drawing.Size(200, 20);
            this.tmeStart.TabIndex = 0;
            // 
            // tmeFinish
            // 
            this.tmeFinish.Location = new System.Drawing.Point(29, 70);
            this.tmeFinish.Name = "tmeFinish";
            this.tmeFinish.Size = new System.Drawing.Size(200, 20);
            this.tmeFinish.TabIndex = 1;
            // 
            // cboState
            // 
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "Hot Water",
            "Central Heating",
            "Wifi Update",
            "Inhibit"});
            this.cboState.Location = new System.Drawing.Point(29, 12);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(185, 21);
            this.cboState.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(49, 96);
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
            this.btnCancel.Location = new System.Drawing.Point(131, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmSlotDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 145);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.tmeFinish);
            this.Controls.Add(this.tmeStart);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(269, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(269, 183);
            this.Name = "frmSlotDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Schedule Slot...";
            this.Load += new System.EventHandler(this.frmSlotDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker tmeStart;
        private System.Windows.Forms.DateTimePicker tmeFinish;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}