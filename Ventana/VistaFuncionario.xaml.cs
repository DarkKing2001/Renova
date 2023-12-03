using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        /*private void BotonET_Click(object sender, RoutedEventArgs e)
        {
            ExamenPractico ep = new ExamenPractico();
            ep.ShowDialog();
        }*/



        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();

            this.Hide();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
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
