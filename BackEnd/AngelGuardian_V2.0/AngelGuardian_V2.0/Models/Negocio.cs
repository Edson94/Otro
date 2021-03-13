using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngelGuardian_V2._0.Models
{
    public class Negocio
    {
        public int IdNegocio { get; set; }
        public int IdImagen { get; set; }
        public String Nombre { get; set; }
        public String RazonSocial { get; set; }
        public int PuntuacionFinal { get; set; }
        public DateTime Fecha { get; set; }
        public virtual Imagen Imagen { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
