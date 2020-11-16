using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomadentApp
{
    public class Pacijent
    {
        private string ime;
        private string prezime;
        private string zaposlenje;
        private string intervencija;
        private string adresa;
        private string brojTelefona;
        private string jmbg;
        private string primarni;
        private string datum;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Zaposlenje { get => zaposlenje; set => zaposlenje = value; }
        public string Intervencija { get => intervencija; set => intervencija = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string BrojTelefona { get => brojTelefona; set => brojTelefona = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string Primarni { get => primarni; set => primarni = value; }
        public string Datum { get => datum; set => datum = value; }

        public Pacijent()
        {

        }

        public Pacijent(string ime, string prezime, string zaposlenje, string intervencija, string adresa, string brojTelefona, string jmbg, string primarni, string datum)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.zaposlenje = zaposlenje;
            this.intervencija = intervencija;
            this.adresa = adresa;
            this.brojTelefona = brojTelefona;
            this.jmbg = jmbg;
            this.primarni = primarni;
            this.datum = datum;
        }

        public override string ToString()
        {
            return "Ime: " + ime + "\tPrezime: " + prezime + "\tZaposlenje: " + zaposlenje + "\tIntervencija: " + intervencija + "\tAdresa: " + adresa + "\tBroj telfona: " + brojTelefona+"\tJMBG: "+jmbg+"\tPrimarni"+primarni+"Datum: "+datum;
        }
    }
}
