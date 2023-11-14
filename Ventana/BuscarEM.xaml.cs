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
    /// Lógica de interacción para BuscarEM.xaml
    /// </summary>
    public partial class BuscarEM : UserControl
    {
        public BuscarEM()
        {
            InitializeComponent();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                if (TextRut.Text.Length == 10)
                {
                    string rut = TextRut.Text;

                    if (Mantenedor.BuscarMedico(rut) != null)
                    {
                        DG_ExamenesM.ItemsSource = Mantenedor.BuscarMedico(rut);
                    }
                }
                else
                {
                    MessageBox.Show("rut no válido, ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("No puede estar el campo rut Vacio");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                if (TextRut.Text.Length == 10)
                {
                    string rut = TextRut.Text;

                    if (Mantenedor.BuscarMedico(rut) != null)
                    {
                        Mantenedor.EliminarMedico(rut);
                    }
                    else
                    {
                        MessageBox.Show("Rut no cuenta con examen medico");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido, ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("No puede estar el campo rut Vacio");
            }
        }

        private void BotonMostrar_Click(object sender, RoutedEventArgs e)
        {
            DG_ExamenesM.ItemsSource = Mantenedor.MostrarMedicos();
        }

        private void DG_ExamenesM_Loaded(object sender, RoutedEventArgs e)
        {
            DG_ExamenesM.ItemsSource = Mantenedor.MostrarMedicos();
        }

        private static readonly Regex regex = new Regex("[^0-9-k]+");

        private static bool ValidarRut(string text)
        {
            return !regex.IsMatch(text);
        }

        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarRut(e.Text);
        }
    }
}
