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
    /// Lógica de interacción para BuscarET.xaml
    /// </summary>
    public partial class BuscarET : UserControl
    {
        public BuscarET()
        {
            InitializeComponent();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                if (Mantenedor.BuscarET(rut) != null)
                {
                    DG_buscarET.ItemsSource = Mantenedor.BuscarET(rut);
                }
                else
                {
                    MessageBox.Show("Rut no cuenta con examen");
                }
            }
            else
            {
                MessageBox.Show("Error, rut no puede estar vacio");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                if (rut.Length == 10)
                {
                    if (Mantenedor.BuscarET(rut) != null)
                    {
                        Mantenedor.EliminarET(rut);
                    }
                    else
                    {
                        MessageBox.Show("Rut no cuenta con examen");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido, ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("Error, rut no puede estar vacio");
            }
        }

        private void BotonMostrarDatos_Click(object sender, RoutedEventArgs e)
        {
            DG_buscarET.ItemsSource = Mantenedor.MostrarEETT();
        }

        private void DG_buscarET_Loaded(object sender, RoutedEventArgs e)
        {
            DG_buscarET.ItemsSource = Mantenedor.MostrarEETT();
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
