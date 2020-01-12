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
    public partial class frmHighscore : Form
    {
        frmMain incForm;

        public frmHighscore(frmMain incForm)
        {
            InitializeComponent();

            this.incForm = incForm;

            //Highscore Liste aktuallisieren
            lvHighscore.Items.Clear();
            
            for (int i = 0; i < incForm.highscore.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = (lvHighscore.Items.Count + 1).ToString();
                lvi.SubItems.Add(incForm.highscore[i].name);
                lvi.SubItems.Add(incForm.highscore[i].points.ToString("n0"));

                lvHighscore.Items.Add(lvi);
            }            
        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}