using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ventana.VistaModelo
{
    public class MainVistaF : ViewModelBase
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


        public ICommand ShowExamenesTeoricos { get; }
        public ICommand ShowExamenT { get; }
        public ICommand ShowSolicitudes { get; }
        public ICommand ShowSolicitud { get; }

        public MainVistaF()
        {

            ShowExamenesTeoricos = new ViewModelCommand(ExecuteShowExamenesTeoricos);
            ShowExamenT = new ViewModelCommand(ExecuteShowExamenT);

            ShowSolicitudes = new ViewModelCommand(ExecuteShowSolicitudes);
            ShowSolicitud = new ViewModelCommand(ExecuteShowSoli);

            ExecuteShowExamenesTeoricos(null);

        }

        private void ExecuteShowExamenesTeoricos(object obj)
        {
            CurrentChildView = new ModeloBuscarET();
            Caption = "Examenes";
            Icon = IconChar.ClipboardList;
        }

        private void ExecuteShowExamenT(object obj)
        {
            CurrentChildView = new ModeloExamenT();
            Caption = "Examen";
            Icon = IconChar.Clipboard;
        }

        private void ExecuteShowSolicitudes(object obj)
        {
            CurrentChildView = new ModeloBuscarS();
            Caption = "Solicitudes";
            Icon = IconChar.Scroll;
        }

        private void ExecuteShowSoli(object obj)
        {
            CurrentChildView = new ModeloSolicitud();
            Caption = "Solicitud";
            Icon = IconChar.CalendarDays;
        }
    }
}
