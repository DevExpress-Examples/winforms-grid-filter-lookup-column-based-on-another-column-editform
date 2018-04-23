namespace FilterLookUpsEditForm
{
    partial class Form1
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
            this.btnSingle = new DevExpress.XtraEditors.SimpleButton();
            this.btnDiff = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnSingle
            // 
            this.btnSingle.Location = new System.Drawing.Point(36, 118);
            this.btnSingle.Name = "btnSingle";
            this.btnSingle.Size = new System.Drawing.Size(141, 90);
            this.btnSingle.TabIndex = 0;
            this.btnSingle.Text = "Single data source";
            this.btnSingle.Click += new System.EventHandler(this.btnSingle_Click);
            // 
            // btnDiff
            // 
            this.btnDiff.Location = new System.Drawing.Point(235, 118);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(141, 90);
            this.btnDiff.TabIndex = 1;
            this.btnDiff.Text = "Different data sources";
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 343);
            this.Controls.Add(this.btnDiff);
            this.Controls.Add(this.btnSingle);
            this.Name = "Form1";
            this.Text = "Filter LookUps";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSingle;
        private DevExpress.XtraEditors.SimpleButton btnDiff;

    }
}

