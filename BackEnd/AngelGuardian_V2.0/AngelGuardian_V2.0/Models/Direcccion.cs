using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngelGuardian_V2._0.Models
{
    public class Direcccion
    {
		public int IdDireccion { get; set; }
		public String Lugar { get; set; }
		public String Calle { get; set; }
		public String Referencia { get; set; }
		public int NumeroExterior { get; set; }
		public float Latitud { get; set; }
		public float Longitud { get; set; }

		public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
