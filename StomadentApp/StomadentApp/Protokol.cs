using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StomadentApp
{
    public partial class Protokol : Form
    {
        private Stack<Pacijent> pacijenti;
        private Pacijent p;
        SqlConnection konekcija = new SqlConnection(Konekcija.cnn);
        public Protokol()
        {
            InitializeComponent();
            pacijenti = new Stack<Pacijent>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stomadentDataSet.Pacijenti' table. You can move, or remove it, as needed.
            this.pacijentiTableAdapter.Fill(this.stomadentDataSet.Pacijenti);
            // TODO: This line of code loads data into the 'stomadentDataSet.Pacijenti' table. You can move, or remove it, as needed.
            this.pacijentiTableAdapter.Fill(this.stomadentDataSet.Pacijenti);
            // TODO: This line of code loads data into the 'stomadentDataSet.Pacijenti' table. You can move, or remove it, as needed.
            this.pacijentiTableAdapter.Fill(this.stomadentDataSet.Pacijenti);
            // TODO: This line of code loads data into the 'stomadentDataSet.Pacijenti' table. You can move, or remove it, as needed.
            this.pacijentiTableAdapter.Fill(this.stomadentDataSet.Pacijenti);
            // TODO: This line of code loads data into the 'stomadentDataSet.Pacijent' table. You can move, or remove it, as needed.
            this.pacijentiTableAdapter.Fill(this.stomadentDataSet.Pacijenti);

        }

        private void Protokol_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Želite li da zatvorite aplikaciju?", "Zatvorite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnUbaci_Click(object sender, EventArgs e)
        {
            UnosNovog frm = new UnosNovog();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                p = new Pacijent(frm.Ime, frm.Prezime, frm.Zaposlenje, frm.Intervencija, frm.Adresa, frm.Broj,frm.jmbg,frm.datum,frm.primarni);
                pacijenti.Push(p);
                try
                {
                    this.pacijentiTableAdapter.Insert(frm.Ime,frm.Prezime,frm.Zaposlenje,frm.Adresa,frm.Intervencija,frm.Broj,frm.jmbg,frm.datum,frm.primarni);
                    MessageBox.Show("Uspešno ste uneli podatke o pacijentu u protokol.", "Uspešan unos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.pacijentiTableAdapter.Fill(this.stomadentDataSet.Pacijenti);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska!", ex.Message);
                }
            }
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selektovaniRed = dataGridView1.SelectedRows[0].Index;
                string ime = dataGridView1[0, selektovaniRed].Value.ToString();
                string prezime = dataGridView1[1, selektovaniRed].Value.ToString();
                string zaposlenje = dataGridView1[2, selektovaniRed].Value.ToString();
                string intervencija = dataGridView1[3, selektovaniRed].Value.ToString();
                string adresa = dataGridView1[4, selektovaniRed].Value.ToString();
                string broj = dataGridView1[5, selektovaniRed].Value.ToString();
                string jmbg = dataGridView1[6, selektovaniRed].Value.ToString();
                string datum = dataGridView1[7, selektovaniRed].Value.ToString();
                string primarni = dataGridView1[8, selektovaniRed].Value.ToString();
                if (MessageBox.Show("Želite li da zatvorite aplikaciju?", "Zatvorite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                }
                else
                {
                   
                }
                try
                {
                    this.pacijentiTableAdapter.Delete(ime, prezime,zaposlenje, intervencija, adresa, broj, jmbg, datum,primarni);
                    
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    this.pacijentiTableAdapter.Update(stomadentDataSet);
                    MessageBox.Show("Uspešno ste obrisali podatke o pacijentu iz protokola.", "Uspešno brisanje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception )
                {
                    MessageBox.Show("Uspešno ste obrisali podatke o pacijentu iz protokola.", "Uspešno brisanje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tbPretraga_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            konekcija.Open();
            using (SqlCommand komanda = new SqlCommand("Select * from Pacijenti where Jmbg=@Jmbg", konekcija))
            {
                komanda.Parameters.Add(new SqlParameter("JMBG", tbPretraga.Text));
                SqlDataReader reader = komanda.ExecuteReader();
                while (reader.Read())
                {
                    //listBox1.Items.Add("Ime i prezime\t  "+"Zaposlenje\t  "+"Adresa\t  "+"Intervencija\t  " +"Broj\t  "+"Datum\t  " );
                  
                    listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString()+ "\t  " + reader[2].ToString() + "\t  " + reader[3].ToString() + "\t  " + reader[4].ToString() + "\t  " + reader[5].ToString() + "\t  " + reader[7].ToString());
                    listBox1.Items.Add("\n\r");
                }
                konekcija.Close();
            }
        }

    }
}
