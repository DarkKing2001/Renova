﻿using Negocio;
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
    /// Lógica de interacción para ExamenM.xaml
    /// </summary>
    public partial class ExamenM : UserControl
    {
        public ExamenM()
        {
            InitializeComponent();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                if (rut.Length == 10)
                {
                    if (Mantenedor.BuscarRut(rut) != false)
                    {
                        if (Mantenedor.BuscarRutEM(rut) != true)
                        {
                            Medico m = new Medico();

                            m.Rut = rut;

                            if (RB_examenV_A.IsChecked == true)
                            {
                                m.ExamenV = "Aprobado";
                            }
                            else
                            {
                                m.ExamenV = "Reprobado";
                            }

                            if (RB_examenA_A.IsChecked == true)
                            {
                                m.ExamenA = "Aprobado";
                            }
                            else
                            {
                                m.ExamenA = "Reprobado";
                            }

                            if (RB_examenP_A.IsChecked == true)
                            {
                                m.ExamenP = "Aprobado";
                            }
                            else
                            {
                                m.ExamenP = "Reprobado";
                            }

                            if (RB_cooA.IsChecked == true)
                            {
                                m.CoordinacionM = "Aprobado";
                            }
                            else
                            {
                                m.CoordinacionM = "Reprobado";
                            }
                            if (RB_examenG_A.IsChecked == true)
                            {
                                m.ExamenG = "Aprobado";
                            }
                            else
                            {
                                m.ExamenG = "Reprobado";
                            }

                            if (RB_examenV_A.IsChecked == true && RB_examenA_A.IsChecked == true &&
                                RB_examenP_A.IsChecked == true && RB_cooA.IsChecked == true &&
                                RB_examenG_A.IsChecked == true)
                            {
                                m.Aprobado = "Aprobado";
                            }
                            else
                            {
                                m.Aprobado = "Reprobado";
                            }

                            m.Anio = Convert.ToInt32(CB_Anio.Text);

                            Mantenedor.AgregarMedico(m);
                        }
                        else
                        {
                            MessageBox.Show("Rut cuenta con un examen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, rut no válido");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido, ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                if (rut.Length == 10)
                {
                    if (Mantenedor.BuscarRutEM(rut) != false)
                    {
                        Medico m = new Medico();

                        m.Rut = rut;

                        if (RB_examenV_A.IsChecked == true)
                        {
                            m.ExamenV = "Aprobado";
                        }
                        else
                        {
                            m.ExamenV = "Reprobado";
                        }

                        if (RB_examenA_A.IsChecked == true)
                        {
                            m.ExamenA = "Aprobado";
                        }
                        else
                        {
                            m.ExamenA = "Reprobado";
                        }

                        if (RB_examenP_A.IsChecked == true)
                        {
                            m.ExamenP = "Aprobado";
                        }
                        else
                        {
                            m.ExamenP = "Reprobado";
                        }

                        if (RB_cooA.IsChecked == true)
                        {
                            m.CoordinacionM = "Aprobado";
                        }
                        else
                        {
                            m.CoordinacionM = "Reprobado";
                        }
                        if (RB_examenG_A.IsChecked == true)
                        {
                            m.ExamenG = "Aprobado";
                        }
                        else
                        {
                            m.ExamenG = "Reprobado";
                        }

                        if (RB_examenV_A.IsChecked == true && RB_examenA_A.IsChecked == true &&
                            RB_examenP_A.IsChecked == true && RB_cooA.IsChecked == true &&
                            RB_examenG_A.IsChecked == true)
                        {
                            m.Aprobado = "Aprobado";
                        }
                        else
                        {
                            m.Aprobado = "Reprobado";
                        }

                        m.Anio = Convert.ToInt32(CB_Anio.Text);

                        Mantenedor.ModificarMedico(m);
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
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                if (rut.Length == 10)
                {
                    if (Mantenedor.BuscarMedico(rut) != null)
                    {
                        Medico m = Mantenedor.BuscarMedico(rut);

                        if(m.ExamenA == "Aprobado")
                        {
                            RB_examenA_A.IsChecked = true;
                        }
                        else
                        {
                            RB_examenA_N.IsChecked = true;
                        }
                        if (m.ExamenV == "Aprobado")
                        {
                            RB_examenV_A.IsChecked = true;
                        }
                        else
                        {
                            RB_examenV_N.IsChecked = true;
                        }
                        if (m.ExamenP == "Aprobado")
                        {
                            RB_examenP_A.IsChecked = true;
                        }
                        else
                        {
                            RB_examenP_N.IsChecked = true;
                        }
                        if (m.CoordinacionM == "Aprobado")
                        {
                            RB_cooA.IsChecked = true;
                        }
                        else
                        {
                            RB_cooN.IsChecked = true;
                        }
                        if (m.ExamenG == "Aprobado")
                        {
                            RB_examenG_A.IsChecked = true;
                        }
                        else
                        {
                            RB_examenG_N.IsChecked = true;
                        }

                        switch (m.Anio)
                        {
                            case 2:
                                CB_Anio.SelectedIndex = 0;
                                break;
                            case 3:
                                CB_Anio.SelectedIndex = 1;
                                break;
                            case 4:
                                CB_Anio.SelectedIndex = 2;
                                break;
                            case 5:
                                CB_Anio.SelectedIndex = 3;
                                break;
                            case 6:
                                CB_Anio.SelectedIndex = 4;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Persona no cuenta con examen");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no válido, ej: 12345678-9");
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

        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarRut(e.Text);
        }
    }
}
