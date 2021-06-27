using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAct.Entidades
{
    public class Persona
    {
        //Los datos a insertarse sólo afectan la tabla Persona, por lo tanto, se especifica el tipo de cada atributo
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }

    }
}
