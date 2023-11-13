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


        public MainVistaF()
        {

            ShowExamenesTeoricos = new ViewModelCommand(ExecuteShowExamenesTeoricos);
            ShowExamenT = new ViewModelCommand(ExecuteShowExamenT);

            ExecuteShowExamenesTeoricos(null);

        }

        private void ExecuteShowExamenesTeoricos(object obj)
        {
            CurrentChildView = new ModeloBuscarET();
            Caption = "Examenes";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowExamenT(object obj)
        {
            CurrentChildView = new ModeloExamenT();
            Caption = "Examen";
            Icon = IconChar.UserGroup;
        }
    }
}
