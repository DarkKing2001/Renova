using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Instructor
    {
        private string rut;
        private int faltasG;
        private int faltasL;
        private string aprobado;

        public string Rut { get => rut; set => rut = value; }
        public int FaltasG { get => faltasG; set => faltasG = value; }
        public int FaltasL { get => faltasL; set => faltasL = value; }
        public string Aprobado { get => aprobado; set => aprobado = value; }
    }
}
