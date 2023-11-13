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

        public MainVistaAdmin()
        {
            ShowBuscarPersonas = new ViewModelCommand(ExecuteShowBuscarPersonas);
            ShowPersona = new ViewModelCommand(ExecuteShowPersona);

            ShowBuscarUsuarios = new ViewModelCommand(ExecuteShowBuscarUsuarios);
            ShowUsuario = new ViewModelCommand(ExecuteShowUsuario);

            ExecuteShowBuscarPersonas(null);
        }

        private void ExecuteShowBuscarPersonas(object obj)
        {
            CurrentChildView = new ModeloBuscarP();
            Caption = "Examenes";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowPersona(object obj)
        {
            CurrentChildView = new ModeloPersona();
            Caption = "Examen";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowBuscarUsuarios(object obj)
        {
            CurrentChildView = new ModeloBuscarU();
            Caption = "Examenes";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowUsuario(object obj)
        {
            CurrentChildView = new ModeloUsuario();
            Caption = "Examen";
            Icon = IconChar.UserGroup;
        }
    }
}
