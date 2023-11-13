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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //VistaAdmin va;
        //VistaFuncionario vf;
        //VistaMedico vm;
        //VistaInstructor vi;

        public MainWindow()
        {
            InitializeComponent();

            //va = new VistaAdmin();
            //vf = new VistaFuncionario();
            //vm = new VistaMedico();
            //vi = new VistaInstructor();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BotonInicioSecion_Click(object sender, RoutedEventArgs e)
        {
            if (!TextUsuario.Text.Equals("") && !pwdText.Password.Equals(""))
            {
                if (TextUsuario.Text.Equals("Admin"))
                {
                    string usuario = TextUsuario.Text;
                    string contrasenia = pwdText.Password;

                    bool comprobar = Mantenedor.BuscarUsuario(usuario, contrasenia);

                    if (comprobar != false)
                    {
                        this.Hide();
                        VistaAdmin va = new VistaAdmin();
                        va.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error, contraseña incorrecta");
                    }
                }
                else if (TextUsuario.Text.Equals("Instructor"))
                {
                    string usuario = TextUsuario.Text;
                    string contrasenia = pwdText.Password;

                    bool comprobar = Mantenedor.BuscarUsuario(usuario, contrasenia);

                    if (comprobar != false)
                    {
                        this.Hide();

                        VistaInstructor vi = new VistaInstructor();
                        vi.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error, contraseña incorrecta");
                    }
                }
                else if (TextUsuario.Text.Equals("Funcionario"))
                {
                    string usuario = TextUsuario.Text;
                    string contrasenia = pwdText.Password;

                    bool comprobar = Mantenedor.BuscarUsuario(usuario, contrasenia);

                    if (comprobar != false)
                    {
                        this.Hide();
                        VistaFuncionario vf = new VistaFuncionario();
                        vf.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error, contraseña incorrecta");
                    }
                }
                else if (TextUsuario.Text.Equals("Doctor"))
                {
                    string usuario = TextUsuario.Text;
                    string contrasenia = pwdText.Password;

                    bool comprobar = Mantenedor.BuscarUsuario(usuario, contrasenia);

                    if (comprobar != false)
                    {
                        this.Hide();
                        VistaMedico vm = new VistaMedico();
                        vm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error, contraseña incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario No valido");
                }
                
            }
            else
            {
                MessageBox.Show("No puede haber ningun campo vacio");
            }
        }

        private void BtnMinimizar(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Limpiar()
        {
            TextUsuario.Text = "";
            pwdText.Password = "";
        }
    }
}
