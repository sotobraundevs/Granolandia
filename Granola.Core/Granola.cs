using System;
using System.Collections.Generic;
using System.Text;

namespace Granola.Core
{
	public class Granola
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public GranolaTipo Tipo { get; set; }
	}
}
