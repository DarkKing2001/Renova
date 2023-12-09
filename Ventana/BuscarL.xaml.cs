using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Ventana
{
    /// <summary>
    /// Lógica de interacción para BuscarL.xaml
    /// </summary>
    public partial class BuscarL : UserControl
    {
        public BuscarL()
        {
            InitializeComponent();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            string rut = TextRut.Text;

            if (!rut.Equals(""))
            {
                if (rut.Length == 10)
                {
                    if (Mantenedor.BuscaLicencia(rut) != null)
                    {
                        List<Licencia> licencias = new List<Licencia>();
                        Licencia l = Mantenedor.BuscaLicencia(rut);

                        licencias.Add(l);

                        DG_Licencias.ItemsSource = licencias;
                    }
                    else
                    {
                        MessageBox.Show("Persona no cuenta con licencia");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            string rut = TextRut.Text;

            if (!rut.Equals(""))
            {
                if (rut.Length == 10)
                {
                    if (Mantenedor.BuscaLicencia(rut) != null)
                    {
                        Mantenedor.EliminarLicencia(rut);
                    }
                    else
                    {
                        MessageBox.Show("Persona no cuenta con licencia");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonMostrar_Click(object sender, RoutedEventArgs e)
        {
            DG_Licencias.ItemsSource = Mantenedor.MostrarLicenias();
        }

        private void DG_Licencias_Loaded(object sender, RoutedEventArgs e)
        {
            DG_Licencias.ItemsSource = Mantenedor.MostrarLicenias();
        }

        private static readonly Regex regex1 = new Regex("[^0-9-k]+");

        private static bool ValidarRut(string text)
        {
            return !regex1.IsMatch(text);
        }

        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarRut(e.Text);
        }
    }
}
