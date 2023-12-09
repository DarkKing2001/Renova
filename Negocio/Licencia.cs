using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Licencia
    {
        private string rut;
        private string muni;
        private DateTime u_control;
        private DateTime control;

        public string Rut { get => rut; set => rut = value; }
        public string Muni { get => muni; set => muni = value; }
        public DateTime U_control { get => u_control; set => u_control = value; }
        public DateTime Control { get => control; set => control = value; }
    }
}
