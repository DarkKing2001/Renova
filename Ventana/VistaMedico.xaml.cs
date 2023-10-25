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
    /// Lógica de interacción para VistaMedico.xaml
    /// </summary>
    public partial class VistaMedico : Window
    {
        //ExamenMedico em;
        //BuscarExamenMedico bem;
        public VistaMedico()
        {
            InitializeComponent();
            //em = new ExamenMedico();
            //bem = new BuscarExamenMedico();
        }

        private void BotonEM_Click(object sender, RoutedEventArgs e)
        {
            ExamenMedico em = new ExamenMedico();
            em.ShowDialog();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarExamenMedico bem = new BuscarExamenMedico();
            bem.ShowDialog();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
