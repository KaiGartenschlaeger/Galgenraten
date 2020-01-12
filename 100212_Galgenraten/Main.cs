using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Galgenraten
{
    public partial class frmMain : Form
    {
        OleDbConnection db_con = new OleDbConnection();
        OleDbCommand db_com = null;
        OleDbDataReader db_dr = null;

        List<char> pushed_keys = new List<char>();

        int grp_index = 0;

        //Wortgruppen
        public struct struct_groups
        {
            public int nr;
            public string name;
        }
        public List<struct_groups> groups = new List<struct_groups>();

        //Highscoreliste
        public struct struct_highscore
        {
            public string name;
            public int points;
        }
        public List<struct_highscore> highscore = new List<struct_highscore>();
                
        Random rnd = new Random();

        bool game_run = false;
        int versuche = 0;
        int points = 0;
        string curr_word = string.Empty;
        public string player_name = string.Empty;

        public struct struct_word
        {
            public char ch;
            public bool ok;
        }
        struct_word[] curr_word_arr;

        //Konstruktor
        public frmMain()
        {
            InitializeComponent();
        }

        //Fehlermeldung
        private void errorMessageBox(string message, bool end)
        {
            MessageBox.Show(null, message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            if (end == true)
                this.Close();
        }

        //Blendet die Buttons ein/aus
        private void showButtons(bool visible)
        {
            bnA.Visible = visible;
            bnB.Visible = visible;
            bnC.Visible = visible;
            bnD.Visible = visible;
            bnE.Visible = visible;
            bnF.Visible = visible;
            bnG.Visible = visible;
            bnH.Visible = visible;
            bnI.Visible = visible;
            bnJ.Visible = visible;
            bnK.Visible = visible;
            bnL.Visible = visible;
            bnM.Visible = visible;
            bnN.Visible = visible;
            bnO.Visible = visible;
            bnP.Visible = visible;
            bnQ.Visible = visible;
            bnR.Visible = visible;
            bnS.Visible = visible;
            bnT.Visible = visible;
            bnU.Visible = visible;
            bnV.Visible = visible;
            bnW.Visible = visible;
            bnX.Visible = visible;
            bnY.Visible = visible;
            bnZ.Visible = visible;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pbGalgen.Image = global::Galgenraten.Properties.Resources._10a;

            //Datenbankverbindung öffnen
            try
            {
                db_con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=words.accdb;";
                db_con.Open();

                //Wörtergruppen einlesen
                db_com = new OleDbCommand("SELECT * FROM tabGroup ORDER BY grp_name ASC", db_con);
                db_dr = db_com.ExecuteReader(CommandBehavior.CloseConnection);

                struct_groups group = new struct_groups();

                while (db_dr.Read())
                {
                    group.nr = Convert.ToInt32(db_dr["grp_nr"]);
                    group.name = db_dr["grp_name"].ToString();
                    groups.Add(group);
                }

                if (groups.Count == 0)
                {
                    errorMessageBox("Keine Wörtergruppen gefunden", true);
                }

                //Wörter
                db_com = new OleDbCommand("SELECT * FROM tabWords", db_con);
                db_dr = db_com.ExecuteReader(CommandBehavior.CloseConnection);

                if (db_dr.HasRows == false)
                    errorMessageBox("Keine Wörter in Datenbank gefunden", true);
            }
            catch (Exception exc)
            {
                errorMessageBox(exc.Message, true);
            }

            showButtons(true);
        }

        //Entfernt alle unzulässigen Zeichen aus das gesuchte Wort
        private string convertWord(string word)
        {
            word = word.Trim();
            word = word.ToUpper();
            word = word.Replace("Ä", "AE");
            word = word.Replace("Ö", "OE");
            word = word.Replace("Ü", "UE");

            string result = string.Empty;
            char[] word_arr;
            
            word_arr = word.ToCharArray();
            foreach (char ch in word_arr)
            {
                if ((ch >= 'A' && ch <= 'Z') || ch == ' ')
                    result += ch.ToString();
            }

            return result;
        }

        //Neues Spiel starten
        private void bnNewWord_Click(object sender, EventArgs e)
        {
            frmNewWord frm_new = new frmNewWord(this, grp_index);

            frm_new.Left = this.Left + (this.Width / 2) - (frm_new.Width / 2);
            frm_new.Top = this.Top + (this.Height / 2) - (frm_new.Height / 2);

            if (frm_new.ShowDialog() == DialogResult.OK)
            {
                player_name = frm_new.GetPlayerName();
                grp_index = frm_new.grp_index;

                try
                {
                    string sql_com = string.Empty;
                    int word_group = frm_new.GetSelGroup();
                    
                    //Anzahl Datensätze ermitteln
                    if(word_group == -1)
                        sql_com = "SELECT COUNT(*) FROM tabWords";
                    else
                        sql_com = "SELECT COUNT(*) FROM tabWords WHERE wrd_grp_nr=" + word_group.ToString();

                    db_com = new OleDbCommand(sql_com, db_con);

                    int word_count = (int)db_com.ExecuteScalar();

                    if (word_count <= 0)
                    {
                        MessageBox.Show("Keine Wörter gefunden");
                        return;
                    }
                    else
                    {
                        //Zufälliges Wort aus DB lesen
                        int rnd_word = rnd.Next(word_count);

                        if (word_group == -1)
                            sql_com = "SELECT * FROM tabWords";
                        else
                            sql_com = "SELECT * FROM tabWords WHERE wrd_grp_nr=" + word_group.ToString();

                        db_com = new OleDbCommand(sql_com, db_con);
                        db_dr = db_com.ExecuteReader(CommandBehavior.CloseConnection);

                        curr_word = string.Empty;
                        
                        int index = 0;
                        while (db_dr.Read())
                        {
                            if (index == rnd_word)
                                curr_word = db_dr["wrd_wort"].ToString();

                            index++;
                        }

                        curr_word = convertWord(curr_word);
                        
                        //Wort in Array ablegen
                        curr_word_arr = new struct_word[curr_word.Length];
                        for (int i = 0; i < curr_word_arr.Length; i++)
                        {
                            curr_word_arr[i].ch = Convert.ToChar(curr_word.Substring(i, 1));

                            if (curr_word_arr[i].ch == 32)
                                curr_word_arr[i].ok = true;
                            else
                                curr_word_arr[i].ok = false;
                        }

                        //Startwerte einstellen
                        versuche = 10;
                        points = 1000;

                        //Oberfläche anpassen
                        pbGalgen.Image = global::Galgenraten.Properties.Resources._10a;

                        lbLeftAttempts.Text = versuche.ToString();
                        lbPointsValue.Text = points.ToString("n0");

                        showButtons(true);

                        RefreshWord();

                        game_run = true;
                        pushed_keys.Clear();
                    }
                }
                catch (Exception exc)
                {
                    errorMessageBox(exc.Message, true);
                }
            }
        }

        //Schreibt das Wort formatiert ins Label
        private void RefreshWord()
        {
            string word = string.Empty;

            for (int i = 0; i < curr_word_arr.Length; i++)
            {
                if (curr_word_arr[i].ch == 32)
                {
                    word += "   ";
                }
                else
                {
                    if (curr_word_arr[i].ok == false)
                        word += " _ ";
                    else
                        word += " " + curr_word_arr[i].ch + " ";
                }
            }
            lbSearchWord.Text = word;
        }

        //Überprüft ob das Spiel gewonnen wurde
        private void checkWin()
        {
            if (versuche > 0)
            {
                bool win = true;

                for (int i = 0; i < curr_word_arr.Length; i++)
                {
                    if (curr_word_arr[i].ok == false)
                    {
                        win = false;
                        break;
                    }
                }

                if (win == true)
                    GameWin();
            }
            else
            {
                GameOver();
            }
        }

        //Spiel gewonnen
        private void GameWin()
        {
            game_run = false;
            AddHighscore(player_name, this.points);
            pbGalgen.Image = global::Galgenraten.Properties.Resources.GW;
            MessageBox.Show("Herzlichen Glückwunsch, sie haben " + this.points.ToString("n0") + " Punkte erreicht.");
        }

        //Spiel verloren
        private void GameOver()
        {
            game_run = false;
            MessageBox.Show("Leider Verloren ):\nGesuchtes Wort: " + curr_word);
        }

        //Punkte hinzufügen
        private void remPoints(int points)
        {
            if (this.points >= points)
                this.points -= points;
            else
                this.points = 0;

            lbPointsValue.Text = this.points.ToString("n0");
        }

        //Punkte abziehen
        private void addPoints(int points)
        {
            this.points += points;
            lbPointsValue.Text = this.points.ToString("n0");
        }

        //Aktuallisiert die PictureBox
        private void refreshAttempts()
        {
            if (versuche >= 10)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._10a;
            if (versuche == 9)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._09a;
            else if (versuche == 8)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._08a;
            else if (versuche == 7)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._07a;
            else if (versuche == 6)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._06a;
            else if (versuche == 5)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._05a;
            else if (versuche == 4)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._04a;
            else if (versuche == 3)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._03a;
            else if (versuche == 2)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._02a;
            else if (versuche == 1)
                pbGalgen.Image = global::Galgenraten.Properties.Resources._01a;
            else
                pbGalgen.Image = global::Galgenraten.Properties.Resources.go;

            lbLeftAttempts.Text = versuche.ToString();
        }

        //Einen Buchstaben überprüfen
        private void checkChar(char character)
        {
            //Kleinbuchtsaben -> Großbuchstaben
            if (character >= 'a' && character <= 'z')
                character = Convert.ToChar(character.ToString().ToUpper());
            
            if (game_run == true && character >= 'A' && character <= 'Z')
            {                
                //Bereits geratene Buchstaben speeren
                foreach (char ch in pushed_keys)
                {
                    if (character == ch)
                        return;
                }
                pushed_keys.Add(character);

                //Buchstabe suchen
                bool exist = false;

                for (int i = 0; i < curr_word_arr.Length; i++)
                {
                    if (curr_word_arr[i].ch == character && curr_word_arr[i].ok == false)
                    {
                        curr_word_arr[i].ok = true;
                        exist = true;
                    }
                }

                if (exist == true)
                {
                    //Buchstabe vorhanden
                    RefreshWord();
                    addPoints(points * 10 / 100);
                }
                else
                {
                    //Buchstabe nicht vorhanden
                    remPoints(points * 10 / 100);
                    versuche--;
                    refreshAttempts();
                }

                //Bereits gedrückte Buttons speeren
                switch (character)
                {
                    case 'A': bnA.Visible = false; break;
                    case 'B': bnB.Visible = false; break;
                    case 'C': bnC.Visible = false; break;
                    case 'D': bnD.Visible = false; break;
                    case 'E': bnE.Visible = false; break;
                    case 'F': bnF.Visible = false; break;
                    case 'G': bnG.Visible = false; break;
                    case 'H': bnH.Visible = false; break;
                    case 'I': bnI.Visible = false; break;
                    case 'J': bnJ.Visible = false; break;
                    case 'K': bnK.Visible = false; break;
                    case 'L': bnL.Visible = false; break;
                    case 'M': bnM.Visible = false; break;
                    case 'N': bnN.Visible = false; break;
                    case 'O': bnO.Visible = false; break;
                    case 'P': bnP.Visible = false; break;
                    case 'Q': bnQ.Visible = false; break;
                    case 'R': bnR.Visible = false; break;
                    case 'S': bnS.Visible = false; break;
                    case 'T': bnT.Visible = false; break;
                    case 'U': bnU.Visible = false; break;
                    case 'V': bnV.Visible = false; break;
                    case 'W': bnW.Visible = false; break;
                    case 'X': bnX.Visible = false; break;
                    case 'Y': bnY.Visible = false; break;
                    case 'Z': bnZ.Visible = false; break;
                }

                checkWin(); //Begriffe aufgelöst, Spiel gewonnen?
            }
        }

        private void bnA_Click(object sender, EventArgs e)
        {
            checkChar('A');            
        }
        private void bnB_Click(object sender, EventArgs e)
        {
            checkChar('B');
        }
        private void bnC_Click(object sender, EventArgs e)
        {
            checkChar('C');
        }
        private void bnD_Click(object sender, EventArgs e)
        {
            checkChar('D');
        }
        private void bnE_Click(object sender, EventArgs e)
        {
            checkChar('E');
        }
        private void bnF_Click(object sender, EventArgs e)
        {
            checkChar('F');
        }
        private void bnG_Click(object sender, EventArgs e)
        {
            checkChar('G');
        }
        private void bnH_Click(object sender, EventArgs e)
        {
            checkChar('H');
        }
        private void bnI_Click(object sender, EventArgs e)
        {
            checkChar('I');
        }
        private void bnJ_Click(object sender, EventArgs e)
        {
            checkChar('J');
        }
        private void bnK_Click(object sender, EventArgs e)
        {
            checkChar('K');
        }
        private void bnL_Click(object sender, EventArgs e)
        {
            checkChar('L');
        }
        private void bnM_Click(object sender, EventArgs e)
        {
            checkChar('M');
        }
        private void bnN_Click(object sender, EventArgs e)
        {
            checkChar('N');
        }
        private void bnO_Click(object sender, EventArgs e)
        {
            checkChar('O');
        }
        private void bnP_Click(object sender, EventArgs e)
        {
            checkChar('P');
        }
        private void bnQ_Click(object sender, EventArgs e)
        {
            checkChar('Q');
        }
        private void bnR_Click(object sender, EventArgs e)
        {
            checkChar('R');
        }
        private void bnS_Click(object sender, EventArgs e)
        {
            checkChar('S');
        }
        private void bnT_Click(object sender, EventArgs e)
        {
            checkChar('T');
        }
        private void bnU_Click(object sender, EventArgs e)
        {
            checkChar('U');
        }
        private void bnV_Click(object sender, EventArgs e)
        {
            checkChar('V');
        }
        private void bnW_Click(object sender, EventArgs e)
        {
            checkChar('W');
        }
        private void bnX_Click(object sender, EventArgs e)
        {
            checkChar('X');
        }
        private void bnY_Click(object sender, EventArgs e)
        {
            checkChar('Y');
        }
        private void bnZ_Click(object sender, EventArgs e)
        {
            checkChar('Z');
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (game_run == true)
            {
                if (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                    checkChar(e.KeyChar);
                else if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                    checkChar(e.KeyChar);
            }
        }

        //Aktuallisiert die Highscore-List
        public void refreshHighscoreList()
        {
            int count = 0;

            try
            {
                db_com = new OleDbCommand("SELECT * FROM tabHighscore ORDER BY hs_points DESC", db_con);
                db_dr = db_com.ExecuteReader(CommandBehavior.CloseConnection);

                struct_highscore hs = new struct_highscore();
                highscore.Clear();
                
                while (db_dr.Read())
                {
                    hs.points = Convert.ToInt32(db_dr["hs_points"]);
                    hs.name = db_dr["hs_name"].ToString();
                    highscore.Add(hs);
                    count++;

                    if (count >= 10)
                        break;
                }
                
                //Überflüssige Einträge aus der DB entfernen
                if (highscore.Count >= 10)
                {
                    db_com = new OleDbCommand("DELETE FROM tabHighscore WHERE hs_points < " + highscore[9].points.ToString(), db_con);
                    db_com.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                errorMessageBox(exc.Message, false);
            }
        }

        //Fügt einen Eintag zur Hignscore-Tabelle hinzu
        private void AddHighscore(string name, int points)
        {
            try
            {
                db_com = new OleDbCommand("INSERT INTO tabHighscore (hs_points, hs_name) VALUES (" + points.ToString() + ", '" + name + "')", db_con);
                db_com.ExecuteNonQuery();
            }
            catch(Exception)
            {
                //errorMessageBox(exc.Message, false);
            }
        }

        //Highscore-Fenster Öffnen
        private void bnHighscore_Click(object sender, EventArgs e)
        {
            refreshHighscoreList();
            
            frmHighscore frm_hs = new frmHighscore(this);

            frm_hs.Left = this.Left + this.Width / 2 - frm_hs.Width / 2;
            frm_hs.Top = this.Top + this.Height / 2 - frm_hs.Height / 2;

            frm_hs.ShowDialog();
        }

        private void bnInfo_Click(object sender, EventArgs e)
        {
            frmInfo frm_inf = new frmInfo();

            frm_inf.Location = new Point(this.Left + this.Width / 2 - frm_inf.Width / 2, this.Top + this.Height / 2 - frm_inf.Height / 2);
            frm_inf.ShowDialog();
        }
    }
}