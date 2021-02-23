using PrenotazioneBigliettoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrenotazioneBiglietto
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cliente> clienti = new List<Cliente>();
        private List<Prenotazione> prenotazioni = new List<Prenotazione>();
        private string[] ora = new string[] { "18.00", "20.30", "21.00" };
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnAggiungiCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = null;
                string cognome = null;

                if (txtNome.Text != null)
                {
                    nome = txtNome.Text;

                }
                else MessageBox.Show("Inserire un nome", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);

                if (txtCognome.Text != "")
                {
                    cognome = txtCognome.Text;

                }
                else MessageBox.Show("Inserire un cognome", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);

                Cliente cliente = new Cliente(nome, cognome);

                if (btnF.IsChecked == false && btnM.IsChecked == false)
                    MessageBox.Show("Selezionare il sesso", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    if (btnM.IsChecked == true)
                    {
                        cliente.SetSesso(true);  
                    }
                    else
                    {
                        cliente.SetSesso(false);
                    }
                }
            
                cliente.SetCellulare(txtCellulare.Text);


                cmbSelezionaCliente1.Items.Add(cliente.Stampa());
                cmbSelezionaCliente2.Items.Add(cliente.Stampa());

                txtNome.Clear();
                txtCognome.Clear();
                txtCellulare.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbOrario_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in ora)
            {
                cmbOrario.Items.Add(s);
            }
        }


        private void Btnaggiungi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(cmbSelezionaCliente1.SelectedIndex!=-1 && Calendario.SelectedDate!=null && cmbOrario.SelectedIndex != -1)
                {
                    DateTime data = Convert.ToDateTime(Calendario.Text);
                    string ora = cmbOrario.Text;
                    Cliente cliente = clienti[cmbSelezionaCliente1.SelectedIndex];
                    Prenotazione prenotazione = new Prenotazione(cliente, ora, data);
                    string prezzo = Convert.ToString(prenotazione);

                    prenotazioni.Add(prenotazione);
                    list1.Items.Add(prenotazione.Stampa());
                }

                //reset delle combobox
                cmbSelezionaCliente1.SelectedIndex = -1;
                Calendario.SelectedDate = null;
                cmbOrario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnCancella_Click(object sender, RoutedEventArgs e)
        {
            int selezione = list1.SelectedIndex;
            if (selezione >= 0)
            {
                string nome = prenotazioni[selezione].Cliente.ToString();
                for(int c=0; c<clienti.Count; c++)
                {
                    if (nome == clienti[c].ToString())
                    {
                        clienti[c].RimuoviPrenotazione(prenotazioni[selezione]);
                    }

                }
            }
            else
            {
                MessageBox.Show("Attenzione", "Non è stato selezionato alcun elemento dalla lista", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            prenotazioni.RemoveAt(selezione);
            list1.Items.Remove(list1.SelectedItem);
        }

    }
}
