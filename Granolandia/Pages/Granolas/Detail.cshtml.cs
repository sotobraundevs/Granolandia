using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Granolandia.Core;
using Granolandia.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Granolandia.Pages.Granolas
{
    public class DetailModel : PageModel
    {

		private readonly IGranolaData granolaData;
		[TempData]
		public string Message { get; set; }

		public Granola Granola { get; set; }
		//Se inyecta la interface 
		public DetailModel(IGranolaData granolaData)
		{
			this.granolaData = granolaData;

		}

		public IActionResult OnGet(int granolaId)
        {
			Granola = granolaData.GetById(granolaId);

			if(Granola == null)
			{
				return RedirectToPage("./ErrorPage");

			}

			return Page();
        }
    }
}