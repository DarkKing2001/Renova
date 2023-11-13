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
    /// Lógica de interacción para MPersonas.xaml
    /// </summary>
    public partial class MPersonas : UserControl
    {
        public MPersonas()
        {
            InitializeComponent();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextDV.Text.Equals("") && !TextPN.Text.Equals("") && !TextSN.Text.Equals("") &&
                !TextAP.Text.Equals("") && !TextAM.Text.Equals("") && !TextCorreo.Text.Equals(""))
            {
                if (TextRut.Text.Length == 8)
                {
                    if (TextPN.Text.Length >= 2 && TextSN.Text.Length >= 2 &&
                       TextAP.Text.Length >= 2 && TextAM.Text.Length >= 2)
                    {
                        if (ValidarEmail(TextCorreo.Text) == true)
                        {
                            string rut = TextRut.Text;
                            char dv = Convert.ToChar(TextDV.Text);

                            if (Mantenedor.ValidarRut(rut, dv) != false)
                            {
                                string r = rut + "-" + dv;

                                if (Mantenedor.BuscarRut(r) != true)
                                {
                                    Persona p = new Persona();

                                    p.Rut = r;
                                    p.Nombre = TextPN.Text;
                                    p.Snombre = TextSN.Text;
                                    p.Apellido_p = TextAP.Text;
                                    p.Apellido_m = TextAM.Text;
                                    p.Correo = TextCorreo.Text;
                                    p.Comuna = 1;

                                    Mantenedor.Agregar(p);

                                }
                                else
                                {
                                    MessageBox.Show("Rut existente");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El rut no es valido");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Correo no Valido");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, nombre o apellido muy corto");
                    }
                }
                else
                {
                    MessageBox.Show("Error, rut no válido, ej(12345678-9)");
                }

            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextDV.Text.Equals("") && !TextPN.Text.Equals("") && !TextSN.Text.Equals("") &&
                !TextAP.Text.Equals("") && !TextAM.Text.Equals("") && !TextCorreo.Text.Equals(""))
            {
                if (TextRut.Text.Length == 8)
                {
                    if (TextPN.Text.Length >= 2 && TextSN.Text.Length >= 2 &&
                       TextAP.Text.Length >= 2 && TextAM.Text.Length >= 2)
                    {
                        if (ValidarEmail(TextCorreo.Text) == true)
                        {
                            string rut = TextRut.Text;
                            char dv = Convert.ToChar(TextDV.Text);

                            if (Mantenedor.ValidarRut(rut, dv) != false)
                            {
                                string r = rut + "-" + dv;

                                if (Mantenedor.BuscarRut(r) != false)
                                {
                                    Persona p = new Persona();

                                    p.Rut = r;
                                    p.Nombre = TextPN.Text;
                                    p.Snombre = TextSN.Text;
                                    p.Apellido_p = TextAP.Text;
                                    p.Apellido_m = TextAM.Text;
                                    p.Correo = TextCorreo.Text;
                                    p.Comuna = 1;

                                    Mantenedor.Modificar(p);

                                }
                                else
                                {
                                    MessageBox.Show("Rut no existente en los registros");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El rut no es valido");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Correo no Valido");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, nombre o apellido muy corto");
                    }
                }
                else
                {
                    MessageBox.Show("Error, rut no válido, ej(12345678-9)");
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

        private static readonly Regex regex = new Regex("[^0-9]+");
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

        public static bool ValidarEmail(string email)
        {
            string formato;
            formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, formato))
            {
                if (Regex.Replace(email, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloNumeros(e.Text);
        }
        private void TextDV_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarDV(e.Text);
        }

        private void TextPN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloLetras(e.Text);
        }

        private void TextSN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloLetras(e.Text);
        }

        private void TextAP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloLetras(e.Text);
        }

        private void TextAM_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloLetras(e.Text);
        }
    }
}
