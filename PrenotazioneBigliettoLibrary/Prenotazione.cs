using System;
using System.Collections.Generic;
using System.Text;

namespace PrenotazioneBigliettoLibrary
{
    public class Prenotazione
    {
        private const double PREZZO = 20.99;
        public string Ora { get; set; }
        public DateTime Data { get; set; }
        
        public Cliente Cliente { get; set; }

        public Prenotazione(Cliente cliente, string Ora, DateTime Data)
        {
            Cliente = cliente;
            this.Ora = Ora;
            this.Data = Data;
            cliente.AddPrenotazione(this);
            
        }

        public string Stampa()
        {
            return $"{Cliente.Stampa()}, {Data.ToShortDateString()}, {Ora}, {CostoPrenotazione()}";
        }

        public double CostoPrenotazione()
        {
            double prezzo = 0;
            if (Cliente.GetSesso() == "M" && this.Ora == "18.00" || Cliente.GetSesso() == "F"){
                prezzo = PREZZO - (PREZZO / 100 * 10);
            } else
                prezzo = PREZZO;
            return prezzo;

        }
    }
}
