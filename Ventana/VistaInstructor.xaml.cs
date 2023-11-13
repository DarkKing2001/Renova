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
using System.Runtime.InteropServices;
using System.Windows.Interop;

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

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        /*private void BotonET_Click(object sender, RoutedEventArgs e)
        {
            ExamenPractico ep = new ExamenPractico();
            ep.ShowDialog();
        }*/

        private void BotonExamenT(object obj)
        {
            ExamenPractico ep = new ExamenPractico();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarExamenPractico bep = new BuscarExamenPractico();
            bep.ShowDialog();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
