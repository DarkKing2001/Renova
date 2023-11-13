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

        public ICommand ShowExamenesTeoricos { get; }
        public ICommand ShowExamenT { get; }

        public ICommand ShowExamenesMedicos { get; }
        public ICommand ShowExamenM { get; }

        public MainViewModel()
        {
            ShowExamenesPracticos = new ViewModelCommand(ExecuteShowExamenesPracticos);
            ShowExamenP = new ViewModelCommand(ExecuteShowExamenP);

            ShowExamenesMedicos = new ViewModelCommand(ExecuteShowExamenesMedicos);
            ShowExamenM = new ViewModelCommand(ExecuteShowExamenM);

            ShowExamenesTeoricos = new ViewModelCommand(ExecuteShowExamenesTeoricos);
            ShowExamenT = new ViewModelCommand(ExecuteShowExamenT);

            ExecuteShowExamenesPracticos(null);
            ExecuteShowExamenesMedicos(null);

        }

        private void ExecuteShowExamenesPracticos(object obj)
        {
            CurrentChildView = new ModeloBuscarEP();
            Caption = "Examenes";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowExamenP(object obj)
        {
            CurrentChildView = new ModeloExamenP();
            Caption = "Examen";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowExamenesTeoricos(object obj)
        {
            CurrentChildView = new ModleoBuscarET();
            Caption = "Examenes";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowExamenT(object obj)
        {
            CurrentChildView = new ModeloExamenT();
            Caption = "Examen";
            Icon = IconChar.UserGroup;
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
