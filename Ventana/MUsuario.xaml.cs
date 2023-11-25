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
    /// Lógica de interacción para MUsuario.xaml
    /// </summary>
    public partial class MUsuario : UserControl
    {
        public MUsuario()
        {
            InitializeComponent();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextUsuario.Text.Equals("") && !TextContra.Text.Equals(""))
            {
                if (TextRut.Text.Length == 20)
                {
                    string rut = TextRut.Text;

                    if (Mantenedor.Buscar(rut) != null)
                    {

                        if (Mantenedor.BuscarRut(rut) != false)
                        {

                            if (Mantenedor.BuscarRutUsuario(rut) != true)
                            {
                                if (Mantenedor.BuscarNombreUsuario(TextUsuario.Text) != true)
                                {
                                    Usuario u = new Usuario();

                                    u.Rut = rut;
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
            if (!TextRut.Text.Equals("") && !TextUsuario.Text.Equals("") && !TextContra.Text.Equals(""))
            {
                if (TextRut.Text.Length == 8)
                {
                    string rut = TextRut.Text;

                    if (Mantenedor.Buscar(rut) != null)
                    {
                        if (Mantenedor.BuscarRut(rut) != false)
                        {
                            if (Mantenedor.BuscarRutUsuario(rut) != false)
                            {
                                Usuario u = new Usuario();

                                u.Rut = rut;
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

        }

        private static readonly Regex regex = new Regex("[^0-9-k]S+");
        private static readonly Regex regex2 = new Regex("[^a-zA-Z]+$");

        private static bool ValidarRut(string text)
        {
            return !regex.IsMatch(text);
        }

        private static bool SoloLetras(string text)
        {
            return !regex2.IsMatch(text);
        }

        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarRut(e.Text);
        }

        private void TextUsuario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloLetras(e.Text);
        }
    }
}
