using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Galgenraten
{
    public partial class frmNewWord : Form
    {
        frmMain incForm;
        public int grp_index = 0;

        public frmNewWord(frmMain incForm, int grp_index)
        {
            InitializeComponent();

            this.incForm = incForm;

            //Standardwerte
            tbName.Text = incForm.player_name;
            
            cbWordGroup.Items.Add("Alle Gruppen");
            for (int i = 0; i < incForm.groups.Count; i++)
            {
                cbWordGroup.Items.Add(incForm.groups[i].name);
            }

            cbWordGroup.SelectedIndex = grp_index;

            if (tbName.Text.Trim() == "")
                bnStart.Enabled = false;
        }

        public string GetPlayerName()
        {
            return tbName.Text.Trim();
        }

        public int GetSelGroup()
        {
            if (cbWordGroup.SelectedIndex == 0)
                return -1;
            else
            {
                return incForm.groups[cbWordGroup.SelectedIndex - 1].nr;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
                bnStart.Enabled = false;
            else
                bnStart.Enabled = true;
        }

         private void cbWordGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            grp_index = cbWordGroup.SelectedIndex;
        }

         private void frmNewWord_KeyUp(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter && bnStart.Enabled == true)
             {
                 cbWordGroup.Focus();
                 this.DialogResult = DialogResult.OK;
                 e.SuppressKeyPress = false;
             }
         }

         private void tbName_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == '\r')
                 e.Handled = true;
         }
    }
}
