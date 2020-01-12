namespace Galgenraten
{
    partial class frmNewWord
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
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.bnStart = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.cbWordGroup = new System.Windows.Forms.ComboBox();
            this.lbWordGroup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbName.Location = new System.Drawing.Point(9, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbName.Location = new System.Drawing.Point(12, 25);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(266, 20);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbName_KeyPress);
            // 
            // bnStart
            // 
            this.bnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.bnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.bnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.bnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bnStart.Location = new System.Drawing.Point(200, 126);
            this.bnStart.Name = "bnStart";
            this.bnStart.Size = new System.Drawing.Size(80, 28);
            this.bnStart.TabIndex = 2;
            this.bnStart.Text = "Start";
            this.bnStart.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.bnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.bnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.bnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bnCancel.Location = new System.Drawing.Point(12, 126);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(80, 28);
            this.bnCancel.TabIndex = 3;
            this.bnCancel.Text = "Abbrechen";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // cbWordGroup
            // 
            this.cbWordGroup.BackColor = System.Drawing.SystemColors.Window;
            this.cbWordGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWordGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbWordGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbWordGroup.FormattingEnabled = true;
            this.cbWordGroup.IntegralHeight = false;
            this.cbWordGroup.Location = new System.Drawing.Point(12, 74);
            this.cbWordGroup.MaxDropDownItems = 18;
            this.cbWordGroup.Name = "cbWordGroup";
            this.cbWordGroup.Size = new System.Drawing.Size(268, 21);
            this.cbWordGroup.TabIndex = 4;
            this.cbWordGroup.SelectedIndexChanged += new System.EventHandler(this.cbWordGroup_SelectedIndexChanged);
            // 
            // lbWordGroup
            // 
            this.lbWordGroup.AutoSize = true;
            this.lbWordGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbWordGroup.Location = new System.Drawing.Point(12, 58);
            this.lbWordGroup.Name = "lbWordGroup";
            this.lbWordGroup.Size = new System.Drawing.Size(63, 13);
            this.lbWordGroup.TabIndex = 5;
            this.lbWordGroup.Text = "Wortgruppe";
            // 
            // frmNewWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(292, 166);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbWordGroup);
            this.Controls.Add(this.cbWordGroup);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnStart);
            this.Controls.Add(this.lbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewWord";
            this.Opacity = 0.95;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Neues Wort";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmNewWord_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button bnStart;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.ComboBox cbWordGroup;
        private System.Windows.Forms.Label lbWordGroup;
    }
}