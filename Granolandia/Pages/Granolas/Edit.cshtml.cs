using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Granolandia.Core;
using Granolandia.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Granolandia.Pages.Granolas
{
    public class EditModel : PageModel
    {
		private readonly IGranolaData granolaData;
		private readonly IHtmlHelper htmlHelper;

		public IEnumerable<SelectListItem> Tipos { get; set; }

		public Granola Granola { get; set; }

		public EditModel(IGranolaData granolaData, IHtmlHelper htmlHelper)
		{
			this.granolaData = granolaData;
			this.htmlHelper = htmlHelper;
		}

		public IActionResult OnGet(int granolaId)
        {
			Tipos = htmlHelper.GetEnumSelectList<GranolaTipo>();
			Granola = granolaData.GetById(granolaId);

			if(Granola == null)
			{
				return RedirectToPage("./ErrorPage");

			}
			return Page();
        }
    }
}