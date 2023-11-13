using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para BuscarS.xaml
    /// </summary>
    public partial class BuscarS : UserControl
    {
        public BuscarS()
        {
            InitializeComponent();
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                if (Mantenedor.BuscarSoliRut(rut) != false)
                {
                    DG_Solicitudes.ItemsSource = Mantenedor.BuscarSolicitud(rut);
                }
                else
                {
                    MessageBox.Show("Rut no cuenta con solicitudes");
                }

            }
            else
            {
                MessageBox.Show("Error, no puede estar rut vacio");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextSoli.Text.Equals(""))
            {
                int soli = int.Parse(TextSoli.Text);

                if (Mantenedor.EliminarSolicitud(soli) != false)
                {
                    MessageBox.Show("Solicitud Eliminada");
                }
                else
                {
                    MessageBox.Show("Numero de solicitud no existe");
                }

            }
            else
            {
                MessageBox.Show("Error, no puede estar N° Solicitud vacio");
            }
        }

        private void BotonMostrar_Click(object sender, RoutedEventArgs e)
        {
            DG_Solicitudes.ItemsSource = Mantenedor.MostrarSolicitudes();
        }

        private void BotonCarnet_Click(object sender, RoutedEventArgs e)
        {
            if (!TextSoli.Text.Equals(""))
            {
                int soli = int.Parse(TextSoli.Text);
                MemoryStream ms = Mantenedor.BuscarCarnet(soli);

                if (ms != null)
                {
                    BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    bm.StreamSource = ms;
                    bm.CacheOption = BitmapCacheOption.OnLoad;
                    bm.EndInit();

                    MostrarImagen.Source = bm;

                    //byte[] s = null;
                    //MostrarImagen = Mantenedor.ByteImage(s);
                }
                else
                {
                    MessageBox.Show("Solicitud no Existe");
                }
            }
            else
            {
                MessageBox.Show("No puede estar el campo Solicitud vacio");
            }
        }

        private void BotonRecidencia_Click(object sender, RoutedEventArgs e)
        {
            if (!TextSoli.Text.Equals(""))
            {
                int soli = int.Parse(TextSoli.Text);
                MemoryStream ms = Mantenedor.BuscarRecidencia(soli);

                if (ms != null)
                {
                    BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    bm.StreamSource = ms;
                    bm.CacheOption = BitmapCacheOption.OnLoad;
                    bm.EndInit();

                    MostrarImagen.Source = bm;

                    //byte[] s = null;
                    //MostrarImagen = Mantenedor.ByteImage(s);
                }
                else
                {
                    MessageBox.Show("Solicitud no Existe");
                }
            }
            else
            {
                MessageBox.Show("No puede estar el campo Solicitud vacio");
            }
        }

        private void BotonLicencia_Click(object sender, RoutedEventArgs e)
        {
            if (!TextSoli.Text.Equals(""))
            {
                int soli = int.Parse(TextSoli.Text);
                MemoryStream ms = Mantenedor.BuscarLicencia(soli);

                if (ms != null)
                {
                    BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    bm.StreamSource = ms;
                    bm.CacheOption = BitmapCacheOption.OnLoad;
                    bm.EndInit();

                    MostrarImagen.Source = bm;

                    //byte[] s = null;
                    //MostrarImagen = Mantenedor.ByteImage(s);
                }
                else
                {
                    MessageBox.Show("Solicitud no Existe");
                }
            }
            else
            {
                MessageBox.Show("No puede estar el campo Solicitud vacio");
            }
        }

        private void BotonCertificado_Click(object sender, RoutedEventArgs e)
        {
            if (!TextSoli.Text.Equals(""))
            {
                int soli = int.Parse(TextSoli.Text);
                MemoryStream ms = Mantenedor.BuscarCertificado(soli);

                if (ms != null)
                {
                    BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    bm.StreamSource = ms;
                    bm.CacheOption = BitmapCacheOption.OnLoad;
                    bm.EndInit();

                    MostrarImagen.Source = bm;

                    //byte[] s = null;
                    //MostrarImagen = Mantenedor.ByteImage(s);
                }
                else
                {
                    MessageBox.Show("Solicitud no Existe");
                }
            }
            else
            {
                MessageBox.Show("No puede estar el campo Solicitud vacio");
            }
        }

        private static readonly Regex regex = new Regex("[^0-9]+");
        private static readonly Regex regex1 = new Regex("[^0-9-k]+");

        private static bool SoloNumeros(string text)
        {
            return !regex.IsMatch(text);
        }

        private static bool ValidarDV(string text)
        {
            return !regex1.IsMatch(text);
        }

        private void TextRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidarDV(e.Text);
        }

        private void TextSoli_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SoloNumeros(e.Text);
        }

        private void DG_Solicitudes_Loaded(object sender, RoutedEventArgs e)
        {
            DG_Solicitudes.ItemsSource = Mantenedor.MostrarSolicitudes();
        }
    }
}
