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
    /// Lógica de interacción para MLicencia.xaml
    /// </summary>
    public partial class MLicencia : UserControl
    {
        public MLicencia()
        {
            InitializeComponent();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                if (TextRut.Text.Length == 10)
                {
                    string rut = TextRut.Text;

                    if (Mantenedor.Buscar(rut) != null)
                    {
                        Medico m = Mantenedor.BuscarMedico(rut);
                        Instructor i = Mantenedor.BuscarEP(rut);
                        Funcionario f = Mantenedor.BuscarET(rut);

                        if (m != null && i != null && f != null)
                        {
                            if (m.Aprobado == "Aprobado" && i.Aprobado == "Aprobado" && f.Aprobado == "Aprobado")
                            {
                                if (Mantenedor.BuscaLicencia(rut) == null)
                                {
                                    Licencia l = new Licencia();

                                    int anio = m.Anio;
                                    DateTime fe = DateTime.Now;
                                    int a = fe.Year;


                                    DateTime fecha = new DateTime(a + anio, fe.Month, fe.Day);

                                    l.Rut = rut;
                                    l.Muni = "Paine";
                                    l.U_control = DateTime.Now;
                                    l.Control = fecha;

                                    Mantenedor.AgregarLicencia(l);
                                }
                                else
                                {
                                    MessageBox.Show("Persona ya cuenta con una licenia");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Persona tiene que aprobar todos los examenes");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Persona tiene que realizar todos los examenes");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El rut no es existe");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {

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
