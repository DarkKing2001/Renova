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
    /// Lógica de interacción para VistaFuncionario.xaml
    /// </summary>
    public partial class VistaFuncionario : Window
    {
        //ExamenTeorico et;
        //BuscarExamenTeorico bet;
        public VistaFuncionario()
        {
            InitializeComponent();

            //et = new ExamenTeorico();
            //bet = new BuscarExamenTeorico();
        }

        private void BotonET_Click(object sender, RoutedEventArgs e)
        {
            ExamenTeorico et = new ExamenTeorico();
            et.ShowDialog();
        }

        private void BotonBuscarExamen_Click(object sender, RoutedEventArgs e)
        {
            BuscarExamenTeorico bet = new BuscarExamenTeorico();
            bet.ShowDialog();
        }

        private void BotonAgregarH_Click(object sender, RoutedEventArgs e)
        {
            Solicitudes s = new Solicitudes();
            s.ShowDialog();
        }

        private void BotonBuscarH_Click(object sender, RoutedEventArgs e)
        {
            BuscarSolicitud bs = new BuscarSolicitud();
            bs.ShowDialog();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
