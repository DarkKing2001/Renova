using Microsoft.Win32;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para Solicitudes.xaml
    /// </summary>
    public partial class Solicitudes : Window
    {
        public Solicitudes()
        {
            InitializeComponent();
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextDV.Text.Equals(""))
            {
                string rut = TextRut.Text + "-" + TextDV.Text;

                if (Mantenedor.BuscarRut(rut) != false)
                {
                    DateTime? calenSelec = CalendarioFecha.SelectedDate;
                    //string hora = CB_Hora.SelectedItem.ToString();                    

                    if (calenSelec != null)
                    {
                        //DateTime h = new DateTime(2023, 10, 10, 00, 00, 00);

                        DateTime f = Convert.ToDateTime(CalendarioFecha.SelectedDate);


                        if (f > DateTime.Now)
                        {
                           if (f.DayOfWeek != DayOfWeek.Sunday)
                           {
                                //if (!TextLicencia.Text.Equals("") && RB_PrimeraL.IsChecked == true && CB_Clase.SelectedIndex <=4)
                                //{
                                if (!TextCarnet.Text.Equals("") && !TextCertificado.Text.Equals("") && !TextRecidencia.Text.Equals(""))
                                {
                                    int dia = f.Day;
                                    int mes = f.Month;
                                    int anio = f.Year;
                                    int hora = 0;

                                    if (CB_Hora.SelectedIndex == 0)
                                    {
                                        hora = 09;
                                    }
                                    else if (CB_Hora.SelectedIndex == 1)
                                    {
                                        hora = 10;
                                    }
                                    else if (CB_Hora.SelectedIndex == 2)
                                    {
                                        hora = 11;
                                    }
                                    else if (CB_Hora.SelectedIndex == 3)
                                    {
                                        hora = 12;
                                    }
                                    else if (CB_Hora.SelectedIndex == 4)
                                    {
                                        hora = 14;
                                    }
                                    else if (CB_Hora.SelectedIndex == 5)
                                    {
                                        hora = 15;
                                    }
                                    else if (CB_Hora.SelectedIndex == 6)
                                    {
                                        hora = 16;
                                    }

                                    DateTime fecha = new DateTime(anio, mes, dia, hora, 00, 00);

                                    if (Mantenedor.BuscarHoras(fecha) <= 3)
                                    {
                                        Solicitud s = new Solicitud();

                                        s.Rut = TextRut.Text + "-" + TextDV.Text;
                                        s.Fecha = fecha; //Convert.ToDateTime(CalendarioFecha.SelectedDate);
                                                         //s.Carnet = TextCarnet.Text;
                                                         //s.Recidencia = TextRecidencia.Text;
                                                         //s.Licencia = TextLicencia.Text;
                                                         //s.Certificado = TextLicencia.Text;


                                        //var aux = (BitmapImage)this.myCarnet.Source;
                                        //s.Carnet = aux.UriSource.AbsoluteUri;

                                        byte[] carnet = Mantenedor.ImageByte(myCarnet);
                                        s.Carnet = carnet;

                                        //var ar = (BitmapImage)this.myRecidencia.Source;
                                        //s.Recidencia = ar.UriSource.AbsoluteUri;

                                        byte[] recidencia = Mantenedor.ImageByte(myRecidencia);
                                        s.Recidencia = recidencia;

                                        //var al = (BitmapImage)this.myLicencia.Source;
                                        //s.Licencia = al.UriSource.AbsoluteUri;

                                        if(!TextLicencia.Text.Equals(""))
                                        {
                                            byte[] licencia = Mantenedor.ImageByte(myLicencia);
                                            s.Licencia = licencia;
                                        }
                                        else
                                        {
                                            s.Licencia = null;
                                        }

                                        //var ac = (BitmapImage)this.myCertificado.Source;
                                        //s.Certificado = ac.UriSource.AbsoluteUri;

                                        byte[] certificado = Mantenedor.ImageByte(myCertificado);
                                        s.Certificado = certificado;

                                        if (RB_PrimeraL.IsChecked == true)
                                        {
                                            s.Renovacion = "Primera Licencia";
                                        }
                                        else
                                        {
                                            s.Renovacion = "Renovacion";
                                        }

                                        s.Clase = CB_Clase.Text;

                                        s.Aprobado = "Aprobado";

                                        //MessageBox.Show("fecha igual: " + fecha.ToString("yyyy/MM/dd HH:mm"));
                                        Mantenedor.AgregarSolicitud(s);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No quedan cupos para la fecha o Hora indicada");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Tiene que subir el carnet, recidencia, certificado y/o licencia");
                                }
                                /*}
                                else if (!TextLicencia.Text.Equals("") && RB_Renovacion.IsChecked == true)
                                {
                                    int dia = f.Day;
                                    int mes = f.Month;
                                    int anio = f.Year;
                                    int hora = 0;

                                    if (CB_Hora.SelectedIndex == 0)
                                    {
                                        hora = 09;
                                    }
                                    else if (CB_Hora.SelectedIndex == 1)
                                    {
                                        hora = 10;
                                    }
                                    else if (CB_Hora.SelectedIndex == 2)
                                    {
                                        hora = 11;
                                    }
                                    else if (CB_Hora.SelectedIndex == 3)
                                    {
                                        hora = 12;
                                    }
                                    else if (CB_Hora.SelectedIndex == 4)
                                    {
                                        hora = 14;
                                    }
                                    else if (CB_Hora.SelectedIndex == 5)
                                    {
                                        hora = 15;
                                    }
                                    else if (CB_Hora.SelectedIndex == 6)
                                    {
                                        hora = 16;
                                    }

                                    DateTime fecha = new DateTime(anio, mes, dia, hora, 00, 00);

                                    if (Mantenedor.BuscarHoras(fecha) <=3)
                                    {
                                        Solicitud s = new Solicitud();


                                        s.Rut = TextRut.Text + "-" + TextDV.Text;
                                        s.Fecha = fecha; //Convert.ToDateTime(CalendarioFecha.SelectedDate);
                                                         //s.Carnet = TextCarnet.Text;
                                                         //s.Recidencia = TextRecidencia.Text;
                                                         //s.Licencia = TextLicencia.Text;
                                                         //s.Certificado = TextLicencia.Text;


                                        //var aux = (BitmapImage)this.myCarnet.Source;
                                        //s.Carnet = aux.UriSource.AbsoluteUri;

                                        byte[] carnet = Mantenedor.ImageByte(myCarnet);
                                        s.Carnet = carnet;

                                        //var ar = (BitmapImage)this.myRecidencia.Source;
                                        //s.Recidencia = ar.UriSource.AbsoluteUri;

                                        byte[] recidencia = Mantenedor.ImageByte(myRecidencia);
                                        s.Recidencia = recidencia;

                                        //var al = (BitmapImage)this.myLicencia.Source;
                                        //s.Licencia = al.UriSource.AbsoluteUri;

                                        byte[] licencia = Mantenedor.ImageByte(myCarnet);
                                        s.Licencia = licencia;

                                        //var ac = (BitmapImage)this.myCertificado.Source;
                                        //s.Certificado = ac.UriSource.AbsoluteUri;

                                        byte[] certificado = Mantenedor.ImageByte(myCarnet);
                                        s.Certificado = certificado;

                                        if (RB_PrimeraL.IsChecked == true)
                                        {
                                            s.Renovacion = "Primera Licencia";
                                        }
                                        else
                                        {
                                            s.Renovacion = "Renovacion";
                                        }

                                        s.Clase = CB_Clase.Text;

                                        if (RB_Aprobado.IsChecked == true)
                                        {
                                            s.Aprobado = "Aprobado";
                                        }
                                        else
                                        {
                                            s.Aprobado = "Rechazado";
                                        }

                                        //MessageBox.Show("fecha igual: " + fecha.ToString("yyyy/MM/dd HH:mm"));
                                        Mantenedor.AgregarSolicitud(s);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No quedan cupos en la fecha y/o hora seleccionada");
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show("Tiene que subir una fotocopia de la licencia actual");
                                }*/
                           }
                           else
                           {
                                MessageBox.Show("No se puede escoger los dias Domingos");
                           }
                        }
                        else
                        {
                            MessageBox.Show("La fecha escogida no puede ser menor que la actual");
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Debe escoger una fecha");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no valido");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals("") && !TextDV.Text.Equals(""))
            {
                string rut = TextRut.Text + "-" + TextDV.Text;

                if (Mantenedor.BuscarRut(rut) != false)
                {
                    DateTime? calenSelec = CalendarioFecha.SelectedDate;
                    //string hora = CB_Hora.SelectedItem.ToString();                    

                    if (calenSelec != null)
                    {
                        //DateTime h = new DateTime(2023, 10, 10, 00, 00, 00);

                        DateTime f = Convert.ToDateTime(CalendarioFecha.SelectedDate);


                        if (f > DateTime.Now)
                        {
                            if (f.DayOfWeek != DayOfWeek.Sunday)
                            {
                                if (!TextLicencia.Text.Equals("") && RB_PrimeraL.IsChecked == true && CB_Clase.SelectedIndex <= 4)
                                {
                                    int dia = f.Day;
                                    int mes = f.Month;
                                    int anio = f.Year;
                                    int hora = 0;

                                    if (CB_Hora.SelectedIndex == 0)
                                    {
                                        hora = 09;
                                    }
                                    else if (CB_Hora.SelectedIndex == 1)
                                    {
                                        hora = 10;
                                    }
                                    else if (CB_Hora.SelectedIndex == 2)
                                    {
                                        hora = 11;
                                    }
                                    else if (CB_Hora.SelectedIndex == 3)
                                    {
                                        hora = 12;
                                    }
                                    else if (CB_Hora.SelectedIndex == 4)
                                    {
                                        hora = 14;
                                    }
                                    else if (CB_Hora.SelectedIndex == 5)
                                    {
                                        hora = 15;
                                    }
                                    else if (CB_Hora.SelectedIndex == 6)
                                    {
                                        hora = 16;
                                    }

                                    DateTime fecha = new DateTime(anio, mes, dia, hora, 00, 00);

                                    if (Mantenedor.BuscarHoras(fecha) <= 3)
                                    {
                                        Solicitud s = new Solicitud();

                                        s.Rut = TextRut.Text + "-" + TextDV.Text;
                                        s.Fecha = fecha; //Convert.ToDateTime(CalendarioFecha.SelectedDate);
                                                         //s.Carnet = TextCarnet.Text;
                                                         //s.Recidencia = TextRecidencia.Text;
                                                         //s.Licencia = TextLicencia.Text;
                                                         //s.Certificado = TextLicencia.Text;


                                        //var aux = (BitmapImage)this.myCarnet.Source;
                                        //s.Carnet = aux.UriSource.AbsoluteUri;

                                        byte[] carnet = Mantenedor.ImageByte(myCarnet);
                                        s.Carnet = carnet;

                                        //var ar = (BitmapImage)this.myRecidencia.Source;
                                        //s.Recidencia = ar.UriSource.AbsoluteUri;

                                        byte[] recidencia = Mantenedor.ImageByte(myRecidencia);
                                        s.Recidencia = recidencia;

                                        //var al = (BitmapImage)this.myLicencia.Source;
                                        //s.Licencia = al.UriSource.AbsoluteUri;

                                        byte[] licencia = Mantenedor.ImageByte(myCarnet);
                                        s.Licencia = licencia;

                                        //var ac = (BitmapImage)this.myCertificado.Source;
                                        //s.Certificado = ac.UriSource.AbsoluteUri;

                                        byte[] certificado = Mantenedor.ImageByte(myCarnet);
                                        s.Certificado = certificado;

                                        if (RB_PrimeraL.IsChecked == true)
                                        {
                                            s.Renovacion = "Primera Licencia";
                                        }
                                        else
                                        {
                                            s.Renovacion = "Renovacion";
                                        }

                                        s.Clase = CB_Clase.Text;

                                        s.Aprobado = "Aprobado";

                                        //MessageBox.Show("fecha igual: " + fecha.ToString("yyyy/MM/dd HH:mm"));
                                        Mantenedor.ModificarSolicitud(s);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No quedan cupos para la fecha o Hora indicada");
                                    }

                                }
                                else if (!TextLicencia.Text.Equals("") && RB_Renovacion.IsChecked == true)
                                {
                                    int dia = f.Day;
                                    int mes = f.Month;
                                    int anio = f.Year;
                                    int hora = 0;

                                    if (CB_Hora.SelectedIndex == 0)
                                    {
                                        hora = 09;
                                    }
                                    else if (CB_Hora.SelectedIndex == 1)
                                    {
                                        hora = 10;
                                    }
                                    else if (CB_Hora.SelectedIndex == 2)
                                    {
                                        hora = 11;
                                    }
                                    else if (CB_Hora.SelectedIndex == 3)
                                    {
                                        hora = 12;
                                    }
                                    else if (CB_Hora.SelectedIndex == 4)
                                    {
                                        hora = 14;
                                    }
                                    else if (CB_Hora.SelectedIndex == 5)
                                    {
                                        hora = 15;
                                    }
                                    else if (CB_Hora.SelectedIndex == 6)
                                    {
                                        hora = 16;
                                    }

                                    DateTime fecha = new DateTime(anio, mes, dia, hora, 00, 00);

                                    if (Mantenedor.BuscarHoras(fecha) <= 3)
                                    {
                                        Solicitud s = new Solicitud();


                                        s.Rut = TextRut.Text + "-" + TextDV.Text;
                                        s.Fecha = fecha; //Convert.ToDateTime(CalendarioFecha.SelectedDate);
                                                         //s.Carnet = TextCarnet.Text;
                                                         //s.Recidencia = TextRecidencia.Text;
                                                         //s.Licencia = TextLicencia.Text;
                                                         //s.Certificado = TextLicencia.Text;


                                        //var aux = (BitmapImage)this.myCarnet.Source;
                                        //s.Carnet = aux.UriSource.AbsoluteUri;

                                        byte[] carnet = Mantenedor.ImageByte(myCarnet);
                                        s.Carnet = carnet;

                                        //var ar = (BitmapImage)this.myRecidencia.Source;
                                        //s.Recidencia = ar.UriSource.AbsoluteUri;

                                        byte[] recidencia = Mantenedor.ImageByte(myRecidencia);
                                        s.Recidencia = recidencia;

                                        //var al = (BitmapImage)this.myLicencia.Source;
                                        //s.Licencia = al.UriSource.AbsoluteUri;

                                        byte[] licencia = Mantenedor.ImageByte(myCarnet);
                                        s.Licencia = licencia;

                                        //var ac = (BitmapImage)this.myCertificado.Source;
                                        //s.Certificado = ac.UriSource.AbsoluteUri;

                                        byte[] certificado = Mantenedor.ImageByte(myCarnet);
                                        s.Certificado = certificado;

                                        if (RB_PrimeraL.IsChecked == true)
                                        {
                                            s.Renovacion = "Primera Licencia";
                                        }
                                        else
                                        {
                                            s.Renovacion = "Renovacion";
                                        }

                                        s.Clase = CB_Clase.Text;

                                        if (RB_Aprobado.IsChecked == true)
                                        {
                                            s.Aprobado = "Aprobado";
                                        }
                                        else
                                        {
                                            s.Aprobado = "Rechazado";
                                        }

                                        //MessageBox.Show("fecha igual: " + fecha.ToString("yyyy/MM/dd HH:mm"));
                                        Mantenedor.ModificarSolicitud(s);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No quedan cupos en la fecha y/o hora seleccionada");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Tiene que subir una fotocopia de la licencia actual");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se puede escoger los dias Domingos");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La fecha escogida no puede ser menor que la actual");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Debe escoger una fecha");
                    }
                }
                else
                {
                    MessageBox.Show("Rut no valido");
                }
            }
            else
            {
                MessageBox.Show("No puede haber campos vacios");
            }
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarSolicitud bs = new BuscarSolicitud();
            bs.ShowDialog();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BotonCarnet_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Documentos |*.pdf; *.jpg";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofdSeleccionar.Title = "Seleccionar Documento";

            bool? resultado = ofdSeleccionar.ShowDialog();

            if (resultado == true)
            {
                //string ruta = ofdSeleccionar.FileName;
                //TextCarnet.Text = ruta;

                Uri url = new Uri(ofdSeleccionar.FileName);
                myCarnet.Source = new BitmapImage(url);

                var aux = (BitmapImage)this.myCarnet.Source;
                TextCarnet.Text = aux.UriSource.AbsoluteUri;
            }
        }

        private void BotonRecidencia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Documentos |*.pdf; *.jpg";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofdSeleccionar.Title = "Seleccionar Documento";            

            bool? resultado = ofdSeleccionar.ShowDialog();

            if (resultado == true)
            {
                //string ruta = ofdSeleccionar.FileName;
                //TextRecidencia.Text = ruta;

                Uri url = new Uri(ofdSeleccionar.FileName);
                myRecidencia.Source = new BitmapImage(url);

                var aux = (BitmapImage)this.myRecidencia.Source;
                TextRecidencia.Text = aux.UriSource.AbsoluteUri;
            }

            
        }

        private void BotonLicencia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Documentos |*.pdf; *.jpg";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofdSeleccionar.Title = "Seleccionar Documento";

            bool? resultado = ofdSeleccionar.ShowDialog();

            if (resultado == true)
            {
                //string ruta = ofdSeleccionar.FileName;
                //TextLicencia.Text = ruta;

                Uri url = new Uri(ofdSeleccionar.FileName);
                myLicencia.Source = new BitmapImage(url);

                var aux = (BitmapImage)this.myLicencia.Source;
                TextLicencia.Text = aux.UriSource.AbsoluteUri;
            }
        }

        private void CalendarioFecha_Loaded(object sender, RoutedEventArgs e)
        {
            /*DateTime currentDate = DateTime.Today;

            // Definir el rango para bloquear cada domingo a partir de la fecha actual
            while (currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                currentDate = currentDate.AddDays(1);
            }

            while (currentDate.Year == DateTime.Today.Year && currentDate.Year <= DateTime.Today.Year) // Cambiar la condición según sea necesario
            {
                CalendarioFecha.BlackoutDates.Add(new CalendarDateRange(currentDate));
                currentDate = currentDate.AddDays(7);
            }*/

            

            // Crear un nuevo objeto de tipo CalendarDateRange para bloquear los días sábados y domingos
            //CalendarDateRange sabado = new CalendarDateRange(DateTime.MinValue, DayOfWeek.Saturday, DateTime.MaxValue, DayOfWeek.Sunday);
            //CalendarDateRange domingo = new CalendarDateRange(startDate, endDate);

            // Añadir el rango al control de calendario
            //CalendarioFecha.BlackoutDates.Add(sabado);
            //CalendarioFecha.BlackoutDates.Add(domingo);

            //CalendarioFecha.BlackoutDates.Add(new CalendarDateRange(new DateTime(2023, 10, 12)));
        }

        private void BotonCertificado_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Documentos |*.pdf; *.jpg";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofdSeleccionar.Title = "Seleccionar Documento";

            bool? resultado = ofdSeleccionar.ShowDialog();

            if (resultado == true)
            {
                //string ruta = ofdSeleccionar.FileName;
                //TextCertificado.Text = ruta;

                Uri url = new Uri(ofdSeleccionar.FileName);
                myCertificado.Source = new BitmapImage(url);

                var aux = (BitmapImage)this.myCertificado.Source;
                TextCertificado.Text = aux.UriSource.AbsoluteUri;
            }
        }

        private void Limpiar()
        {
            TextRut.Text = "";
            TextDV.Text = "";
            TextCarnet.Text = "";
            TextRecidencia.Text = "";
            TextCertificado.Text = "";
            TextLicencia.Text = "";

            CB_Hora.SelectedIndex = 0;
            CB_Clase.SelectedIndex = 0;

            RB_PrimeraL.IsChecked = true;
        }
    }
}
