using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngelGuardian_V2._0.Models
{
	public class Usuario
	{
		public int IdUsuario { get; set; }
		public String NickName { get; set; }
		public String Nombre { get; set; }
		public String ApellidoPaterno { get; set; }
		public String ApellidoMaterno { get; set; }
		public int Celular { get; set; }
		public String Email {get;set;}
		public Boolean Consumidor { get; set; }
		public DateTime Fecha { get; set; }

		public virtual  ICollection<Comprobante> Comprobantes { get; set; }
	}
}
