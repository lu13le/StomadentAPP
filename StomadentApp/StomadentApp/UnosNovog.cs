using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StomadentApp
{
    public partial class UnosNovog : Form
    {
        public string Ime { get { return tbIme.Text; } }
        public string Prezime { get { return tbPrezime.Text; } }
        public string Zaposlenje { get { return tbZaposlenje.Text; } }
        public string Intervencija { get { return tbIntervencija.Text; } }
        public string Adresa { get { return tbAdresa.Text; } }
        public string Broj { get { return tbBroj.Text; } }
        public string jmbg { get { return tbJmbg.Text; } }
        public string primarni { get { return textBox1.Text; } }
        public string datum { get { return dateTimePicker1.Value.ToString(); } }
        public UnosNovog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbAdresa.Clear();
            tbBroj.Clear();
            tbIme.Clear();
            tbIntervencija.Clear();
            tbPrezime.Clear();
            tbZaposlenje.Clear();
            textBox1.Clear();
            tbJmbg.Clear();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            tbIme.Focus();
            if (tbIme.Text == ""||tbJmbg.Text=="" || tbPrezime.Text == "" || tbZaposlenje.Text == "" || tbAdresa.Text == "" || tbIntervencija.Text == "" || tbBroj.Text == ""||textBox1.Text=="")
            {
                MessageBox.Show("Morate popuniti sva polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
