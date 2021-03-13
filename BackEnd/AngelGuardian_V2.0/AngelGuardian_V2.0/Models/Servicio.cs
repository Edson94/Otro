using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngelGuardian_V2._0.Models
{
	public class Servicio
	{
		public int IdServicio { get; set; }
		public int IdNegocio { get; set; }
		public int Puntuacion { get; set; }
		public String Nombre { get; set; }
		public String Descripcion { get; set; }
		public float Duracion { get; set; }
		public float Precio { get; set; }
		public DateTime Fecha { get; set; }
		public virtual Negocio Negocio { get; set; }


		public virtual ComprobanteDetalle ComprobanteDetalles { get; set; }
	}
}
