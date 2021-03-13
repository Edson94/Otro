using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngelGuardian_V2._0.Models
{
    public class Estatus
    {
        public int IdEstatus { get; set; }
        public String Nombre { get; set; }
	    public DateTime Fecha { get; set; }

        public virtual Comprobante Comprobantes { get; set; }
        public virtual ComprobanteDetalle ComprobanteDetalles { get; set; }
    }
}
