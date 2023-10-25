using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Solicitud
    {
        private int numSoli;
        private string rut;
        private DateTime fecha;
        private string renovacion;
        private string clase;
        private byte[] carnet;
        private byte[] recidencia;
        private byte[] licencia;
        private byte[] certificado;
        private string aprobado;

        public int NumSoli { get => numSoli; set => numSoli = value; }
        public string Rut { get => rut; set => rut = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Renovacion { get => renovacion; set => renovacion = value; }
        public string Clase { get => clase; set => clase = value; }
        public byte[] Carnet { get => carnet; set => carnet = value; }
        public byte[] Recidencia { get => recidencia; set => recidencia = value; }
        public byte[] Licencia { get => licencia; set => licencia = value; }
        public byte[] Certificado { get => certificado; set => certificado = value; }
        public string Aprobado { get => aprobado; set => aprobado = value; }
    }
}
