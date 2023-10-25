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
    /// Lógica de interacción para VistaInstructor.xaml
    /// </summary>
    public partial class VistaInstructor : Window
    {
        //ExamenPractico ep;
        //BuscarExamenPractico bep;
        public VistaInstructor()
        {
            InitializeComponent();
            //ep = new ExamenPractico();
            //bep = new BuscarExamenPractico();
        }

        private void BotonET_Click(object sender, RoutedEventArgs e)
        {
            ExamenPractico ep = new ExamenPractico();
            ep.ShowDialog();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarExamenPractico bep = new BuscarExamenPractico();
            bep.ShowDialog();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
