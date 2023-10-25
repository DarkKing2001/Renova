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
    /// Lógica de interacción para VistaAdmin.xaml
    /// </summary>
    public partial class VistaAdmin : Window
    {
        //MantenedorU mu;
        //MantenedorP mp;
        //BuscarUsuarios bu;
        //BuscarPersonas bp;
        public VistaAdmin()
        {
            InitializeComponent();
            //mu = new MantenedorU();
            //mp = new MantenedorP();
            //bu = new BuscarUsuarios();
            //bp = new BuscarPersonas();
        }

        private void BotonMU_Click(object sender, RoutedEventArgs e)
        {
            MantenedorU mu = new MantenedorU();
            mu.ShowDialog();
        }

        private void BotonMP_Click(object sender, RoutedEventArgs e)
        {
            MantenedorP mp = new MantenedorP();
            mp.ShowDialog();
        }

        private void BotonBU_Click(object sender, RoutedEventArgs e)
        {
            BuscarUsuarios bu = new BuscarUsuarios();
            bu.ShowDialog();
        }

        private void BotonBP_Click(object sender, RoutedEventArgs e)
        {
            BuscarPersonas bp = new BuscarPersonas();
            bp.ShowDialog();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
