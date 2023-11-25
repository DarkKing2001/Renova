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
    /// Lógica de interacción para BuscarExamenTeorico.xaml
    /// </summary>
    public partial class BuscarExamenTeorico : Window
    {
        public BuscarExamenTeorico()
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
                    List<Funcionario> f = new List<Funcionario>();
                    f.Add(Mantenedor.BuscarET(rut));

                    DG_buscarET.ItemsSource = f;
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

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
