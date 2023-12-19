using GAC.Models;
using GAC.Services;
using GAC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GAC.Pages
{
    public class ViewActivityModel : PageModel
    {
        private readonly IActivityTypeService _activityTypeService;
        private readonly IActivityService _activityService;

        public ViewActivityModel(IActivityTypeService activityTypeService, IActivityService activityService)
        {
            _activityTypeService = activityTypeService;
            _activityService = activityService;
        }
        public ActivityModel Activity { get; private set; }
		public void OnGet()
		{
			string id = Request.Query["id"].ToString();
			if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int activityId))
			{
				Activity = _activityService.GetActivityById(activityId);
			}
			// Handle scenario where activity is not found or ID is invalid
			if (Activity == null)
			{
				// Perform appropriate action or redirect to handle this scenario
				// For example, redirect to an error page or perform another action
				// Response.Redirect("/Error"); or return NotFound();
			}
		}
	}
}
//aqui a edição da atividade está errada
//na minha visão deveria ser possivel apenas adicionar um certificado