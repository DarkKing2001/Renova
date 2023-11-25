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
using System.Windows.Shapes;

namespace Ventana
{
    /// <summary>
    /// Lógica de interacción para BuscarExamenPractico.xaml
    /// </summary>
    public partial class BuscarExamenPractico : Window
    {
        public BuscarExamenPractico()
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
                    List<Instructor> i = new List<Instructor>();
                    i.Add(Mantenedor.BuscarEP(rut));

                    DG_ExamenP.ItemsSource = i;
                    
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

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private static readonly Regex regex = new Regex("[^0-9-]+");

        private static bool ValidarRut(string text)
        {
            return !regex.IsMatch(text);
        }

        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarRut(e.Text);
        }

        private void DG_ExamenP_Loaded(object sender, RoutedEventArgs e)
        {
            DG_ExamenP.ItemsSource = Mantenedor.MostrarEEPP();
        }

        private void BotonMostrar_Click(object sender, RoutedEventArgs e)
        {
            DG_ExamenP.ItemsSource = Mantenedor.MostrarEEPP();
        }
    }
}
