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
                    List<Funcionario> f = new List<Funcionario>();
                    f.Add(Mantenedor.BuscarET(rut));
                    DG_ExamenesT.ItemsSource = f;
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

        private void BotonMostrar_Click(object sender, RoutedEventArgs e)
        {
            DG_ExamenesT.ItemsSource = Mantenedor.MostrarEETT();
        }

        private void DG_ExamenesT_Loaded(object sender, RoutedEventArgs e)
        {
            DG_ExamenesT.ItemsSource = Mantenedor.MostrarEETT();
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

        private void DG_ExamenesT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*try
            {
                //string rut = this.DG_ExamenesT.SelectedCells[0].Column.ToString();
                //string aprobado = this.DG_ExamenesT.SelectedCells[4].ToString();

                //MessageBox.Show("Rut: " + rut + ", Aprobado: " + aprobado);

                if (DG_ExamenesT.SelectedIndex != -1)
                {
                    Funcionario f = this.DG_ExamenesT.SelectedItem as Funcionario;

                    if (f != null)
                    {
                        MessageBox.Show("Rut: " + f.Rut + ", Aprobado: " + f.Aprobado);
                    }
                    
                }
            }
            catch (Exception)
            {
                return;
            }*/
        }
    }
}
