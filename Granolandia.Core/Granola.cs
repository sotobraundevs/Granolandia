using System;
using System.ComponentModel.DataAnnotations;

namespace Granolandia.Core
{
	public class Granola
	{
		public int Id { get; set; }
		[Required, StringLength(80)]
		public string Nombre { get; set; }
		[Required, StringLength(280)]
		public string Descripcion { get; set; }
		public GranolaTipo Tipo { get; set; }
	}
}
