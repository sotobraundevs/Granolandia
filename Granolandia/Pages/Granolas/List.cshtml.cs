using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Granolandia.Core;
using Granolandia.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Granolandia.Pages.Granolas
{
    public class ListModel : PageModel
	{
		private readonly IGranolaData granolaData;
		private readonly IConfiguration config;
		public string message { get; set; }
		public IEnumerable<Granola> Granolas { get; set; }
		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }

		public ListModel(IConfiguration config, IGranolaData granolaData)
		{
			this.config = config;
			this.granolaData = granolaData;
		}

		public void OnGet()
		{
			 
			message = config["Message"];
			//Granolas = granolaData.GetAllGranola();
			Granolas = granolaData.GetGranolaByName(SearchTerm);
		}
	}
}