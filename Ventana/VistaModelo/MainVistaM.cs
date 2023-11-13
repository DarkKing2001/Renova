using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ventana.VistaModelo
{
    public class MainVistaM : ViewModelBase
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

        public ICommand ShowExamenesMedicos { get; }
        public ICommand ShowExamenM { get; }

        public MainVistaM()
        { 
            ShowExamenesMedicos = new ViewModelCommand(ExecuteShowExamenesMedicos);
            ShowExamenM = new ViewModelCommand(ExecuteShowExamenM);

            ExecuteShowExamenesMedicos(null);
        }

        private void ExecuteShowExamenesMedicos(object obj)
        {
            CurrentChildView = new ModeloBuscarEM();
            Caption = "Examenes";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowExamenM(object obj)
        {
            CurrentChildView = new ModeloExamenM();
            Caption = "Examen";
            Icon = IconChar.UserGroup;
        }
    }
}
