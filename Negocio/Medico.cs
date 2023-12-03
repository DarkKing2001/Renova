using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Medico
    {
        private string rut;
        private int anio;
        private string examenV;
        private string examenA;
        private string examenP;
        private string coordinacionM;
        private string examenG;
        private string aprobado;

        public string Rut { get => rut; set => rut = value; }
        public int Anio { get => anio; set => anio = value; }
        public string ExamenV { get => examenV; set => examenV = value; }
        public string ExamenA { get => examenA; set => examenA = value; }
        public string ExamenP { get => examenP; set => examenP = value; }
        public string CoordinacionM { get => coordinacionM; set => coordinacionM = value; }
        public string ExamenG { get => examenG; set => examenG = value; }
        public string Aprobado { get => aprobado; set => aprobado = value; }
    }
}
