
using Granolandia.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Granolandia.data
{
	public interface IGranolaData
	{
		IEnumerable<Granola> GetAllGranola();
		IEnumerable<Granola> GetGranolaByName(string nombre);
		Granola GetById(int id);



	}

	public class InMemoryGranolaData : IGranolaData
	{
		readonly List<Granola> granolas;

		public InMemoryGranolaData()
		{
			granolas = new List<Granola>() {

			new Granola { Id = 1, Nombre = "Clasica", Descripcion = "Trigo , cereal , chia , avena", Tipo = GranolaTipo.Clasica } ,
		new Granola { Id = 2, Nombre = "Deportistas", Descripcion = "Proteina de soja , cereal , chia , avena", Tipo = GranolaTipo.Deportistas },
		new Granola { Id = 3, Nombre = "Sin Gluten", Descripcion = "Harina de arroz  chia, , avena", Tipo = GranolaTipo.SinGluten }

			};
	}

		
		public IEnumerable<Granola> GetAllGranola()
			{
				return from g in granolas
					   orderby g.Nombre
					   select g;
			}

		public Granola GetById(int id)
		{
			return granolas.SingleOrDefault(r => r.Id == id);
		}

		public IEnumerable<Granola> GetGranolaByName(string nombre = null)
		{
			return from g in granolas
				   where string.IsNullOrEmpty(nombre) || g.Nombre.StartsWith(nombre)
				   orderby g.Nombre
				   select g;
		}

		
	}
	}
