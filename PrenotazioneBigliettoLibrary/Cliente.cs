using System;
using System.Collections.Generic;

namespace PrenotazioneBigliettoLibrary
{
    public class Cliente
    {
        public string nome { get; set; }
        public string cognome { get; set; }
        private string cellulare;
        private string sesso;

        public List<Prenotazione> Prenotazioni = new List<Prenotazione>();

        public Cliente(string nome, string cognome)
        {
            this.nome = nome;
            this.cognome = cognome;
        }

        public string GetSesso()
        {
            return sesso;
        }

        public void SetSesso(bool s)
        {
            if (s == true)
            {
                sesso = "M";
            }
            else sesso = "F";
        }

        public string GetCellulare()
        {
            return cellulare;
        }

        public void SetCellulare(string cellulare)
        {
            if (cellulare.Length == 10)
            {
                try
                {
                    Int64.Parse(cellulare);
                    this.cellulare = cellulare;
                }
                catch (Exception)
                {
                    throw new Exception("Il cellulare deve essere di 10 cifre e deve contenere soltanto numeri");
                }
            }
            else throw new Exception("Il cellulare deve essere di 10 cifre e deve contenere soltanto numeri");
        }


        public string Stampa()
        {
            return $"{sesso},{nome} {cognome}";
        }

        public void AddPrenotazione(Prenotazione prenotazione)
        {
            Prenotazioni.Add(prenotazione);
        }

        public void RimuoviPrenotazione(Prenotazione prenotazione)
        {
            Prenotazioni.Remove(prenotazione);
        }

        public int ContaPrenotazioni()
        {
            int c = 0;
            for(int i = 0; i < Prenotazioni.Count; i++)
            {
                c++;
            }
            return c;
        }

        public double CalcolaCosto()
        {
            double c = 0;
            for(int i = 0; i < Prenotazioni.Count; i++)
            {
                c = c + Prenotazioni[i].CostoPrenotazione();
            }
            return c;
        }

        public int ContaPrenotazioniEvento(string ora)
        {
            int c = 0;

            for(int i=0; i < Prenotazioni.Count; i++)
            {
                if (Prenotazioni[i].Ora == ora)
                {
                    c++;
                }
            }
            return c++;
        }
    }
}
