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
    /// Lógica de interacción para MantenedorU.xaml
    /// </summary>
    public partial class MantenedorU : Window
    {
        //BuscarUsuarios bu;
        public MantenedorU()
        {
            InitializeComponent();
            //bu = new BuscarUsuarios();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextUsuario.Text.Equals("") && !TextContra.Text.Equals("") && !TextDV.Text.Equals(""))
            {
                if (TextRut.Text.Length == 8)
                {
                    string rut = TextRut.Text;
                    char dv = Convert.ToChar(TextDV.Text);

                    if (Mantenedor.ValidarRut(rut, dv) != false)
                    {
                        string r = rut + "-" + dv;

                        if (Mantenedor.BuscarRut(r) != false)
                        {

                            if (Mantenedor.BuscarRutUsuario(r) != true)
                            {
                                if (Mantenedor.BuscarNombreUsuario(TextUsuario.Text) != true)
                                {
                                    Usuario u = new Usuario();

                                    u.Rut = r;
                                    u.Nombre = TextUsuario.Text;
                                    u.Contra = TextContra.Text;

                                    Mantenedor.AgregarUsuario(u);
                                }
                                else
                                {
                                    MessageBox.Show("Error, ya existe un usario con ese nombre");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error, rut ya cuenta con una cuenta");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Rut no existente");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El rut no es valido");
                    }
                }
                else
                {
                    MessageBox.Show("Error, son 8 digitos minimos sin el DV");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextUsuario.Text.Equals("") && !TextContra.Text.Equals("") && !TextDV.Text.Equals(""))
            {
                if (TextRut.Text.Length == 8)
                {
                    string rut = TextRut.Text;
                    char dv = Convert.ToChar(TextDV.Text);

                    if (Mantenedor.ValidarRut(rut, dv) != false)
                    {
                        string r = rut + "-" + dv;

                        if (Mantenedor.BuscarRut(r) != false)
                        {
                            if (Mantenedor.BuscarRutUsuario(r) != false)
                            {
                                Usuario u = new Usuario();

                                u.Rut = r;
                                u.Nombre = TextUsuario.Text;
                                u.Contra = TextContra.Text;

                                Mantenedor.ModificarUsuario(u);
                            }
                            else
                            {
                                MessageBox.Show("Error, usuario no existe");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Rut no existente");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El rut no es valido");
                    }
                }
                else
                {
                    MessageBox.Show("Error, son 8 digitos minimos sin el DV");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarUsuarios bu = new BuscarUsuarios();
            bu.ShowDialog();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private static readonly Regex regex = new Regex("[^0-9]S+");
        private static readonly Regex regex1 = new Regex("[^0-9-k]+");
        private static readonly Regex regex2 = new Regex("[^a-zA-Z]+$");

        private static bool SoloNumeros(string text)
        {
            return !regex.IsMatch(text);
        }

        private static bool SoloLetras(string text)
        {
            return !regex2.IsMatch(text);
        }

        private static bool ValidarDV(string text)
        {
            return !regex1.IsMatch(text);
        }
        
        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloNumeros(e.Text);                
        }

        private void TextDV_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarDV(e.Text);
        }

        private void TextUsuario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloLetras(e.Text);
        }
    }
}
