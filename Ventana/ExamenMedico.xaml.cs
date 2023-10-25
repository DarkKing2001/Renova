using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;
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
    /// Lógica de interacción para ExamenMedico.xaml
    /// </summary>
    public partial class ExamenMedico : Window
    {
        //BuscarExamenMedico em;
        public ExamenMedico()
        {
            InitializeComponent();
            //em = new BuscarExamenMedico();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                if(Mantenedor.BuscarRut(TextRut.Text) != false)
                {
                    Medico m = new Medico();

                    m.Rut = TextRut.Text;

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

                    Mantenedor.AgregarMedico(m);
                }
                else
                {
                    MessageBox.Show("Error, rut no válido");
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
                if (Mantenedor.BuscarRutEM(TextRut.Text) != false)
                {
                    Medico m = new Medico();

                    m.Rut = TextRut.Text;

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

                    Mantenedor.ModificarMedico(m);
                }
                else
                {
                    MessageBox.Show("Error, rut no válido");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarExamenMedico em = new BuscarExamenMedico();
            em.ShowDialog();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
