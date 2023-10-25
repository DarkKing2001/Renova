using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para BuscarExamenMedico.xaml
    /// </summary>
    public partial class BuscarExamenMedico : Window
    {
        public BuscarExamenMedico()
        {
            InitializeComponent();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                BusMedicos.DataContext = Mantenedor.BuscarMedico(rut);
            }
            else
            {
                MessageBox.Show("No puede estar el campo rut Vacio");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                BusMedicos.DataContext = Mantenedor.EliminarMedico(rut);
            }
            else
            {
                MessageBox.Show("No puede estar el campo rut Vacio");
            }
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BusMedicos_Loaded(object sender, RoutedEventArgs e)
        {
            BusMedicos.DataContext = Mantenedor.MostrarMedicos();
        }
    }
}
