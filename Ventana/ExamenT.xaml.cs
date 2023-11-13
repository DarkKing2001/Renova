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
    /// Lógica de interacción para ExamenT.xaml
    /// </summary>
    public partial class ExamenT : UserControl
    {
        public ExamenT()
        {
            InitializeComponent();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextPreguntasC.Text.Equals("") && !TextPreguntasI.Text.Equals(""))
            {
                //agregar
                //String rut = TextRut.Text;
                string rut = TextRut.Text;

                if (rut.Length == 10)
                {
                    if (Mantenedor.BuscarRut(rut))
                    {
                        if (Mantenedor.BuscarET(rut) == null)
                        {
                            string aprobado;
                            int preguntasC = Convert.ToInt32(TextPreguntasC.Text);
                            int preguntasI = Convert.ToInt32(TextPreguntasI.Text);

                            string a = ComboBoxClase.Text;

                            if (a == "A1" || a == "A2" || a == "A3" || a == "A4" || a == "A5")
                            {
                                if (preguntasC + preguntasI == 20)
                                {
                                    if (preguntasC >= 18 && preguntasI <= 2)
                                    {
                                        aprobado = "Aprobado";
                                        MessageBox.Show("Examen Aprobado");
                                    }
                                    else
                                    {
                                        aprobado = "Reprobado";
                                        MessageBox.Show("Examen Reprobado");
                                    }

                                    Funcionario f = new Funcionario();

                                    f.Rut = TextRut.Text;
                                    f.PreguntasC = Convert.ToInt32(TextPreguntasC.Text);
                                    f.PreguntasI = Convert.ToInt32(TextPreguntasI.Text);
                                    f.Aprobado = aprobado;

                                    Mantenedor.AgregarET(f);
                                }
                                else
                                {
                                    MessageBox.Show("Error, la cantidad de preguntas no pueden ser mayor o menor que 20");
                                }
                            }
                            else if (a == "B" || a == "C")
                            {
                                if (preguntasC + preguntasI == 35)
                                {
                                    if (preguntasC >= 31 && preguntasI <= 4)
                                    {
                                        aprobado = "Aprobado";
                                        MessageBox.Show("Examen Aprobado");
                                    }
                                    else
                                    {
                                        aprobado = "Reprobado";
                                        MessageBox.Show("Examen Reprobado");
                                    }

                                    Funcionario f = new Funcionario();

                                    f.Rut = TextRut.Text;
                                    f.PreguntasC = Convert.ToInt32(TextPreguntasC.Text);
                                    f.PreguntasI = Convert.ToInt32(TextPreguntasI.Text);
                                    f.Aprobado = aprobado;

                                    Mantenedor.AgregarET(f);
                                }
                                else
                                {
                                    MessageBox.Show("Error, la cantidad de pregustas no pueden ser mayor o menor a 35");
                                }
                            }
                            else if (a == "D")
                            {
                                if (preguntasC + preguntasI == 12)
                                {
                                    if (preguntasC >= 9 && preguntasI <= 3)
                                    {
                                        aprobado = "Aprobado";
                                        MessageBox.Show("Examen Aprobado");
                                    }
                                    else
                                    {
                                        aprobado = "Reprobado";
                                        MessageBox.Show("Examen Reprobado");
                                    }

                                    Funcionario f = new Funcionario();

                                    f.Rut = TextRut.Text;
                                    f.PreguntasC = Convert.ToInt32(TextPreguntasC.Text);
                                    f.PreguntasI = Convert.ToInt32(TextPreguntasI.Text);
                                    f.Aprobado = aprobado;

                                    Mantenedor.AgregarET(f);
                                }
                                else
                                {
                                    MessageBox.Show("Error, la cantidad de preguntas no puede ser mayor o menor a 12");
                                }
                            }
                            /*else if (a == "E")
                            {
                                if (preguntasC >= 9 && preguntasI <= 3)
                                {
                                    aprobado = true;
                                    MessageBox.Show("Examen Aprobado");
                                }
                                else
                                {
                                    aprobado = false;
                                    MessageBox.Show("Examen Reprobado");
                                }
                            }*/
                        }
                        else
                        {
                            MessageBox.Show("Rut ya cuenta con un examen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rut no valido");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido, ej: 12345678-9");
                }

            }
            else
            {
                MessageBox.Show("Error, no puede haber ningún campo vacio");
            }
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextPreguntasC.Text.Equals("") && !TextPreguntasI.Text.Equals(""))
            {
                //agregar
                //String rut = TextRut.Text;
                string rut = TextRut.Text;

                if (rut.Length == 10)
                {
                    if (Mantenedor.BuscarET(rut) != null)
                    {
                        string aprobado;
                        int preguntasC = Convert.ToInt32(TextPreguntasC.Text);
                        int preguntasI = Convert.ToInt32(TextPreguntasI.Text);

                        string a = ComboBoxClase.Text;

                        if (a == "A1" || a == "A2" || a == "A3" || a == "A4" || a == "A5")
                        {
                            if (preguntasC + preguntasI == 20)
                            {
                                if (preguntasC >= 18 && preguntasI <= 2)
                                {
                                    aprobado = "Aprobado";
                                    MessageBox.Show("Examen Aprobado");
                                }
                                else
                                {
                                    aprobado = "Reprobado";
                                    MessageBox.Show("Examen Reprobado");
                                }

                                Funcionario f = new Funcionario();

                                f.Rut = TextRut.Text;
                                f.PreguntasC = Convert.ToInt32(TextPreguntasC.Text);
                                f.PreguntasI = Convert.ToInt32(TextPreguntasI.Text);
                                f.Aprobado = aprobado;

                                Mantenedor.ModificarET(f);
                            }
                            else
                            {
                                MessageBox.Show("Error, la cantidad de preguntas no pueden ser mayor o menor que 20");
                            }
                        }
                        else if (a == "B" || a == "C")
                        {
                            if (preguntasC + preguntasI == 35)
                            {
                                if (preguntasC >= 31 && preguntasI <= 4)
                                {
                                    aprobado = "Aprobado";
                                    MessageBox.Show("Examen Aprobado");
                                }
                                else
                                {
                                    aprobado = "Reprobado";
                                    MessageBox.Show("Examen Reprobado");
                                }

                                Funcionario f = new Funcionario();

                                f.Rut = TextRut.Text;
                                f.PreguntasC = Convert.ToInt32(TextPreguntasC.Text);
                                f.PreguntasI = Convert.ToInt32(TextPreguntasI.Text);
                                f.Aprobado = aprobado;

                                Mantenedor.ModificarET(f);
                            }
                            else
                            {
                                MessageBox.Show("Error, la cantidad de pregustas no pueden ser mayor o menor a 35");
                            }
                        }
                        else if (a == "D")
                        {
                            if (preguntasC + preguntasI == 12)
                            {
                                if (preguntasC >= 9 && preguntasI <= 3)
                                {
                                    aprobado = "Aprobado";
                                    MessageBox.Show("Examen Aprobado");
                                }
                                else
                                {
                                    aprobado = "Reprobado";
                                    MessageBox.Show("Examen Reprobado");
                                }

                                Funcionario f = new Funcionario();

                                f.Rut = TextRut.Text;
                                f.PreguntasC = Convert.ToInt32(TextPreguntasC.Text);
                                f.PreguntasI = Convert.ToInt32(TextPreguntasI.Text);
                                f.Aprobado = aprobado;

                                Mantenedor.ModificarET(f);
                            }
                            else
                            {
                                MessageBox.Show("Error, la cantidad de preguntas no puede ser mayor o menor a 12");
                            }
                        }
                        /*else if (a == "E")
                        {
                            if (preguntasC >= 9 && preguntasI <= 3)
                            {
                                aprobado = true;
                                MessageBox.Show("Examen Aprobado");
                            }
                            else
                            {
                                aprobado = false;
                                MessageBox.Show("Examen Reprobado");
                            }
                        }*/
                    }
                    else
                    {
                        MessageBox.Show("Rut no cuenta con un examen");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido, ej: 12345678-9");
                }

            }
            else
            {
                MessageBox.Show("Error, no puede haber ningún campo vacio");
            }
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private static readonly Regex regex = new Regex("[^0-9]+");
        private static readonly Regex regex1 = new Regex("[^0-9-k]+");

        private static bool SoloNumeros(string text)
        {
            return !regex.IsMatch(text);
        }

        private static bool ValidarRut(string text)
        {
            return !regex1.IsMatch(text);
        }

        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarRut(e.Text);
        }

        private void TextPreguntasC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloNumeros(e.Text);
        }

        private void TextPreguntasI_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloNumeros(e.Text);
        }
    }
}
