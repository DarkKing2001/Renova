using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ventana.VistaModelo
{
    public class MainViewModel : ViewModelBase
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

        public ICommand ShowExamenesPracticos { get; }
        public ICommand ShowExamenP { get; }

        public MainViewModel()
        {
            ShowExamenesPracticos = new ViewModelCommand(ExecuteShowExamenesPracticos);
            ShowExamenP = new ViewModelCommand(ExecuteShowExamenP);

            ExecuteShowExamenesPracticos(null);
        }

        private void ExecuteShowExamenesPracticos(object obj)
        {
            CurrentChildView = new ModeloBuscarEP();
            Caption = "Examenes";
            Icon = IconChar.List;
        }

        private void ExecuteShowExamenP(object obj)
        {
            CurrentChildView = new ModeloExamenP();
            Caption = "Examen";
            Icon = IconChar.Clipboard;
        }


    }
}
