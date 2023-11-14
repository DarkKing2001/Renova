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
    /// Lógica de interacción para BuscarP.xaml
    /// </summary>
    public partial class BuscarP : UserControl
    {
        public BuscarP()
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

                    DG_Personas.ItemsSource = Mantenedor.Buscar(rut);
                }
                else
                {
                    MessageBox.Show("Rut no valido, ej:12345678-9");
                }
            }
            else
            {
                MessageBox.Show("Error, no puede estar el campo rut vacio");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                Mantenedor.Eliminar(rut);
            }
            else
            {
                MessageBox.Show("Error, no puede estar el campo rut vacio");
            }
        }

        private void DG_Personas_Loaded(object sender, RoutedEventArgs e)
        {
            DG_Personas.ItemsSource = Mantenedor.MostrarPersonas();
        }

        private void BotonMostrar_Click(object sender, RoutedEventArgs e)
        {
            DG_Personas.ItemsSource = Mantenedor.MostrarPersonas();
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
