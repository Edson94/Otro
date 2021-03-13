using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngelGuardian_V2._0.Models
{
	public class Comprobante
	{
		public int IdComprobante { get; set; }
		public int IdUsuario { get; set; }
		public int IdNegocio { get; set; }
		public Boolean Efectivo { get; set; }
		public int IdEstatus { get; set; }
		public int IdDireccion { get; set; }
		public int Puntuacion { get; set; }
		public float Precio {get;set;}
		public DateTime Fecha { get; set; }

		public virtual Usuario Usuario { get; set; }
		public virtual Negocio Negocio { get; set; }
		public virtual Estatus Estatus { get; set; }
		public virtual Direcccion Direcccion { get; set; }

		public virtual ICollection<ComprobanteDetalle> ComprobanteDetalles { get; set; }
	}
}
