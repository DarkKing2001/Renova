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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ventana
{
    /// <summary>
    /// Lógica de interacción para BuscarP.xaml
    /// </summary>
    public partial class BuscarP : UserControl
    {
        public BuscarP()
        {
            InitializeComponent();
        }

        private void BotonBuscarP_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                if (TextRut.Text.Length == 10)
                {
                    string rut = TextRut.Text;

                    BusPersonas.ItemsSource = Mantenedor.Buscar(rut);
                }
                else
                {
                    MessageBox.Show("Rut no valido, ej:12345678-9");
                    BusPersonas.ItemsSource = Mantenedor.MostrarPersonas();
                }
            }
            else
            {
                MessageBox.Show("Error, no puede estar el campo rut vacio");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                Mantenedor.Eliminar(rut);
            }
            else
            {
                MessageBox.Show("Error, no puede estar el campo rut vacio");
            }
        }

        private void BusPersonas_Loaded(object sender, RoutedEventArgs e)
        {
            BusPersonas.ItemsSource = Mantenedor.MostrarPersonas();
        }
    }
}
