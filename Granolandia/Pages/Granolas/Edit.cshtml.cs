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

		[BindProperty]
		public Granola Granola { get; set; }

		public EditModel(IGranolaData granolaData, IHtmlHelper htmlHelper)
		{
			this.granolaData = granolaData;
			this.htmlHelper = htmlHelper;
		}

		public IActionResult OnGet(int? granolaId)
        {
			Tipos = htmlHelper.GetEnumSelectList<GranolaTipo>();
			if (granolaId.HasValue)
			{
				Granola = granolaData.GetById(granolaId.Value);
			}else
			{
				Granola = new Granola();
			}
			

			if(Granola == null)
			{
				return RedirectToPage("./ErrorPage");

			}
			return Page();
        }

		public IActionResult OnPost()
		{
			//El framework mantedra un rastreo de toda la informacion mediante esta propiedad ModelState
		//	ModelState["Descripcion"].AttemptedValue();

			if(!ModelState.IsValid)
			{

				Tipos = htmlHelper.GetEnumSelectList<GranolaTipo>();
				return Page();				
			}

			if(Granola.Id > 0)
			{ 
				Granola = granolaData.UpdateGranola(Granola);
				
			}
			else
			{
				granolaData.Add(Granola);
			}
			granolaData.Commit();
			TempData["Message"] = "Datos Guardados!";
			return RedirectToPage("./Detail", new { granolaid = Granola.Id });
		}
    }
}