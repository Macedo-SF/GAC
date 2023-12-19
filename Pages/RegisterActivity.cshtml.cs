// RegisterActivityModel.cshtml.cs

using GAC.Models;
using GAC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GAC.Pages
{
	public class RegisterActivityModel : PageModel
	{
		private readonly IActivityTypeService _activityTypeService;
		private readonly IActivityService _activityService;

		public RegisterActivityModel(IActivityTypeService activityTypeService, IActivityService activityService)
		{
			_activityTypeService = activityTypeService;
			_activityService = activityService;
		}
		public List<string> ActivityTypes
		{
			get
			{
				List<string> activityTypeNames = _activityTypeService.GetActivityTypes()
					.Select(x => x.Name)
					.ToList();
				return activityTypeNames;
			}
		}

		[BindProperty]
		public ActivityModel Activity { get; set; }

		public void OnGet()
		{
			//Activity = new ActivityModel(category, name, hours, fileName);

		}

		public IActionResult OnPost()
		{
			var name = Request.Form["Activity.Name"];
			var hours = Request.Form["Activity.Hours"];
			var category = Request.Form["Activity.Category"];
			var certificateFile = Request.Form.Files["CertificateFile"];
			//aqui falta pegar arquivo e copiar para dentro do diretório, outra opção é trabalhar com caminho completo/absoluto
			//entretanto, essa segundo pode dar erro de permissão

			var activity = new ActivityModel(name: name,
				hours: int.Parse(hours),
				category: _activityTypeService.GetActivityTypeByName(category),
				fileName: certificateFile.FileName);

			_activityService.AddActivity(activity);

			// Redirect to a success page or perform other actions
			return RedirectToPage("/StudentMain"); // Replace with your success page

		}
	}
}
//aqui tem dois problemas
//o arquivo não está sendo salvo no diretório
//o segundo é que o limite de horas máximas por registro não está sendo checado