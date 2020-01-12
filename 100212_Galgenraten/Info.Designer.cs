namespace Galgenraten
{
    partial class frmInfo
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
            this.bnClose = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.hlWebsite = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // bnClose
            // 
            this.bnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.bnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.bnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.bnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.bnClose.Location = new System.Drawing.Point(90, 94);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(80, 28);
            this.bnClose.TabIndex = 0;
            this.bnClose.Text = "OK";
            this.bnClose.UseVisualStyleBackColor = true;
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.lbInfo.Location = new System.Drawing.Point(12, 9);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(219, 32);
            this.lbInfo.TabIndex = 1;
            this.lbInfo.Text = "Galgenraten Version 1.01\r\nCopyright©Kai Gartenschläger, 2010";
            // 
            // hlWebsite
            // 
            this.hlWebsite.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hlWebsite.AutoSize = true;
            this.hlWebsite.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hlWebsite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.hlWebsite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.hlWebsite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.hlWebsite.Location = new System.Drawing.Point(12, 58);
            this.hlWebsite.Name = "hlWebsite";
            this.hlWebsite.Size = new System.Drawing.Size(132, 16);
            this.hlWebsite.TabIndex = 2;
            this.hlWebsite.TabStop = true;
            this.hlWebsite.Text = "http://www.kaisnet.de";
            this.hlWebsite.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.hlWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.klWebsite_LinkClicked);
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(261, 134);
            this.Controls.Add(this.hlWebsite);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.bnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Informationen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.LinkLabel hlWebsite;
    }
}