using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Funcionario
    {
        private string rut;
        private int preguntasC;
        private int preguntasI;
        private string clase;
        private string aprobado;

        public string Rut { get => rut; set => rut = value; }
        public int PreguntasC { get => preguntasC; set => preguntasC = value; }
        public int PreguntasI { get => preguntasI; set => preguntasI = value; }
        public string Clase { get => clase; set => clase = value; }
        public string Aprobado { get => aprobado; set => aprobado = value; }        
    }
}
