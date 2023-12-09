using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ventana.VistaModelo
{
    public class MainVistaAdmin : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowBuscarPersonas { get; }
        public ICommand ShowPersona { get; }
        public ICommand ShowBuscarUsuarios { get; }
        public ICommand ShowUsuario { get; }
        public ICommand ShowLicencias { get; }
        public ICommand ShowLicencia { get; }

        public MainVistaAdmin()
        {
            ShowBuscarPersonas = new ViewModelCommand(ExecuteShowBuscarPersonas);
            ShowPersona = new ViewModelCommand(ExecuteShowPersona);

            ShowBuscarUsuarios = new ViewModelCommand(ExecuteShowBuscarUsuarios);
            ShowUsuario = new ViewModelCommand(ExecuteShowUsuario);

            ShowLicencias = new ViewModelCommand(ExecuteShowLicencias);
            ShowLicencia = new ViewModelCommand(ExecuteShowLicencia);

            ExecuteShowBuscarPersonas(null);
        }

        private void ExecuteShowBuscarPersonas(object obj)
        {
            CurrentChildView = new ModeloBuscarP();
            Caption = "Personas";
            Icon = IconChar.List;
        }

        private void ExecuteShowPersona(object obj)
        {
            CurrentChildView = new ModeloPersona();
            Caption = "Persona";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowBuscarUsuarios(object obj)
        {
            CurrentChildView = new ModeloBuscarU();
            Caption = "Usuarios";
            Icon = IconChar.List;
        }

        private void ExecuteShowUsuario(object obj)
        {
            CurrentChildView = new ModeloUsuario();
            Caption = "Usuario";
            Icon = IconChar.User;
        }

        private void ExecuteShowLicencias(object obj)
        {
            CurrentChildView = new ModeloBuscarL();
            Caption = "Licencias";
            Icon = IconChar.IdCard;
        }

        private void ExecuteShowLicencia(object obj)
        {
            CurrentChildView = new ModeloLicencia();
            Caption = "Licencia";
            Icon = IconChar.IdCard;
        }
    }
}
