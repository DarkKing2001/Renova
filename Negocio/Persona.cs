using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Persona
    {
        private string rut;
        private string nombre;
        private string snombre;
        private string apellido_p;
        private string apellido_m;
        private string correo;
        private int comuna;


        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Snombre { get => snombre; set => snombre = value; }
        public string Apellido_p { get => apellido_p; set => apellido_p = value; }
        public string Apellido_m { get => apellido_m; set => apellido_m = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Comuna { get => comuna; set => comuna = value; }

        /*public Persona(int rut, string nombre, string snombre, string apellido_p, string apellido_m, string correo, int comuna)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.snombre = snombre;
            this.apellido_p = apellido_p;
            this.apellido_m = apellido_m;
            this.correo = correo;
            this.comuna = comuna;
        }*/
    }
}
