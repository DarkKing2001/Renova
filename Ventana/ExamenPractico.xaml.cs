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
    /// Lógica de interacción para ExamenPractico.xaml
    /// </summary>
    public partial class ExamenPractico : Window
    {
        //BuscarExamenPractico ep;
        public ExamenPractico()
        {
            InitializeComponent();
            //ep = new BuscarExamenPractico();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextDV.Text.Equals("") && !TextFaltasG.Text.Equals("") && !TextFaltasL.Text.Equals(""))
            {
                if (TextRut.Text.Length == 8)
                {
                    string rut = TextRut.Text + "-" + TextDV.Text;
                    int faltasG = Convert.ToInt32(TextFaltasG.Text);
                    int faltasL = Convert.ToInt32(TextFaltasL.Text);
                    string aprobado;

                    if (Mantenedor.BuscarRut(rut) != false)
                    {
                        if (faltasG <= 1 && faltasL <= 9)
                        {
                            aprobado = "Aprobado";
                        }
                        else
                        {
                            aprobado = "Reprobado";
                        }

                        Instructor i = new Instructor();

                        i.Rut = rut;
                        i.FaltasG = faltasG;
                        i.FaltasL = faltasL;
                        i.Aprobado = aprobado;

                        Mantenedor.AgregarEP(i);
                    }
                    else
                    {
                        MessageBox.Show("Rut no encontrado en la base de datos");
                    }
                }
                else
                {
                    MessageBox.Show("Error, rut no puede tener menos de 8 digitos, sin contar el DV");
                }
            }
            else
            {
                MessageBox.Show("No puede haber ningun campo vacio");
            }
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextDV.Text.Equals("") && !TextFaltasG.Text.Equals("") && !TextFaltasL.Text.Equals(""))
            {
                if (TextRut.Text.Length == 8)
                {
                    string rut = TextRut.Text + "-" + TextDV.Text;

                    if (Mantenedor.BuscarRutEP(rut) != false)
                    {
                        int faltasG = Convert.ToInt32(TextFaltasG.Text);
                        int faltasL = Convert.ToInt32(TextFaltasL.Text);
                        string aprobado;

                        if (faltasG <= 1 && faltasL <= 9)
                        {
                            aprobado = "Aprobado";
                        }
                        else
                        {
                            aprobado = "Reprobado";
                        }

                        Instructor i = new Instructor();

                        i.Rut = rut;
                        i.FaltasG = faltasG;
                        i.FaltasL = faltasL;
                        i.Aprobado = aprobado;

                        Mantenedor.ModificarEP(i);
                    }                    
                    else
                    {
                        MessageBox.Show("Rut no encontrado");
                    }
                }
                else
                {
                    MessageBox.Show("Error, rut no puede tener menos de 8 digitos, sin contar el DV");
                }
            }
            else
            {
                MessageBox.Show("No puede haber ningun campo vacio");
            }
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarExamenPractico ep = new BuscarExamenPractico();
            ep.Show();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private static readonly Regex regex = new Regex("[^0-9]+");
        private static readonly Regex regex1 = new Regex("[^0-9-k]+");

        private static bool SoloNumeros(string text)
        {
            return !regex.IsMatch(text);
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

        private void TextFaltasG_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloNumeros(e.Text);
        }

        private void TextFaltasL_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloNumeros(e.Text);
        }
    }
}
