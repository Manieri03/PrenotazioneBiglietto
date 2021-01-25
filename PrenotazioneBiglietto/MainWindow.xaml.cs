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
    }
}
