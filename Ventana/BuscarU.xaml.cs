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
    /// Lógica de interacción para BuscarU.xaml
    /// </summary>
    public partial class BuscarU : UserControl
    {
        public BuscarU()
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

                    //Usuario u = Mantenedor.BuscarUsuarios(rut);
                    //ObservableCollection<Usuario> dataList = new ObservableCollection<Usuario>();

                    //dataList.Add(new Usuario {Rut = u.Rut, Nombre = u.Nombre, Contra = u.Contra });

                    //BusUsuarios.ItemsSource = dataList;
                    BusUsuarios.ItemsSource = Mantenedor.BuscarUsuarios(rut);

                    //BusUsuarios.DataContext = Mantenedor.BuscarUsuarios(rut);

                }
                else
                {
                    MessageBox.Show("Rut no valido, ej: 12345678-9");
                }
            }
            else
            {
                MessageBox.Show("El campo rut no puede estar vacio");
            }
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!TextRut.Text.Equals(""))
            {
                string rut = TextRut.Text;

                if (Mantenedor.BuscarRutUsuario(rut) != false)
                {
                    Mantenedor.EliminarUsuario(rut);
                }
                else
                {
                    MessageBox.Show("Rut no Cuenta con un usuario");
                }
            }
            else
            {
                MessageBox.Show("El campo rut no puede estar vacio");
            }
        }

        private void BotonMostrarDatos_Click(object sender, RoutedEventArgs e)
        {
            BusUsuarios.ItemsSource = Mantenedor.MostrarUsuarios();
        }

        private void BusPersonas_Loaded(object sender, RoutedEventArgs e)
        {
            BusUsuarios.ItemsSource = Mantenedor.MostrarUsuarios();
        }
    }
}
