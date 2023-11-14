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
    /// Lógica de interacción para BuscarEP.xaml
    /// </summary>
    public partial class BuscarEP : UserControl
    {
        public BuscarEP()
        {
            InitializeComponent();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                if (Mantenedor.BuscarRut(rut) != false)
                {

                    DG_ExamenP.ItemsSource = Mantenedor.BuscarEP(rut);

                }
                else
                {
                    MessageBox.Show("Rut no valido");
                }
            }
            else
            {
                MessageBox.Show("No puede estar el campo rut vacio");
                DG_ExamenP.ItemsSource = Mantenedor.MostrarEEPP();
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                if (TextRut.Text.Length == 10)
                {
                    string rut = TextRut.Text;

                    if (Mantenedor.BuscarRutEP(rut) != false)
                    {
                        Mantenedor.EliminarEP(rut);
                    }
                    else
                    {
                        MessageBox.Show("Rut no valido");
                    }
                }
                else
                {
                    MessageBox.Show("Error, rut no válido, ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("No puede estar el campo rut vacio");
            }
        }

        private static readonly Regex regex = new Regex("[^0-9-k]+");

        private static bool ValidarRut(string text)
        {
            return !regex.IsMatch(text);
        }


        private void BotonMostrar_Click(object sender, RoutedEventArgs e)
        {
            DG_ExamenP.ItemsSource = Mantenedor.MostrarEEPP();
        }

        private void DG_ExamenP_Loaded_1(object sender, RoutedEventArgs e)
        {
            DG_ExamenP.ItemsSource = Mantenedor.MostrarEEPP();
        }

        private void TextRut_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarRut(e.Text);
        }
    }
}
