using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngelGuardian_V2._0.Models
{
    public class Imagen
    {
        public int IdImagen { get; set; }
        public String Nombre { get; set; }
        public String Ruta { get; set; }
        public float Size { get; set; }
        public DateTime Fecha { get; set; }


        public virtual Negocio Negocio { get; set; }
    }
}
