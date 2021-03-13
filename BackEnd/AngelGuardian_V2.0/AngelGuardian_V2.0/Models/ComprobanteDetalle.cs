using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngelGuardian_V2._0.Models
{
    public class ComprobanteDetalle
    {
        public int IdComprobanteDetalle { get; set; }
        public int IdComprobante { get; set; }
        public int IdServicio { get; set; }
        public int IdEstatus { get; set; }
        public int Puntuacion { get; set; }
        public float Precio { get; set; }
        public float? Cambio { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Comprobante Comprobante { get; set; }
        public virtual Servicio Servicio { get; set; }
        public virtual Estatus Estatus { get; set; }
    }
}
