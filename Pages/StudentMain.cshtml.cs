using GAC.Classes;
using GAC.Models;
using GAC.Services;
using GAC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GAC.Pages // Replace with your namespace
{
    public class StudentModel : PageModel
    {
        private readonly IActivityTypeService _activityTypeService;
        private readonly IActivityService _activityService;

        public StudentModel(IActivityTypeService activityTypeService, IActivityService activityService)
        {
            _activityTypeService = activityTypeService;
            _activityService = activityService;
        }
        //trying this one
		public Dictionary<string, (int maxHours, int validHours)> ActivityTypesWithHours
		{
			get
			{
				var activityTypes = _activityTypeService.GetActivityTypes()
					.ToDictionary(x => x.Name, x => (maxHours: x.MaxHoursTotal, validHours: 0));

				foreach (var activity in _activityService.GetActivities())
				{
					if (!string.IsNullOrEmpty(activity.Certificate))
					{
						var type = activity.Category.Name;
						if (activityTypes.ContainsKey(type))
						{
							var (maxHours, validHours) = activityTypes[type];
							activityTypes[type] = (maxHours, validHours + activity.Hours);
						}
					}
				}

				return activityTypes;
			}
		}
		public int CompletedHours
		{
			get
			{
				return ActivityTypesWithHours.Sum(type => type.Value.validHours);
			}
		}

		public List<string> ActivityTypes
        {
            get
            {
                List<string> activityTypeNames = _activityTypeService.GetActivityTypeNames(); // Replace with your method to get activity names
                return activityTypeNames;
            }
        }
        public List<ActivityModel> Activities
        {
            get
            {
                List<ActivityModel> activityNames = _activityService.GetActivities(); // Replace with your method to get activity names
                return activityNames;
            }
        }

        //public StudentModel()
        //{
        //    _activityTypeService = new ActivityTypeService();
        //    _activityService = new ActivityService();
        //}

        public IActionResult OnGetCertificate(string fileName)
        {
            var filePath = Path.Combine(Classes.GlobalSettings.DirectoryPath, fileName);

            if (System.IO.File.Exists(filePath))
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(fileStream, "application/pdf"); // Adjust the file type accordingly
            }
            else
            {
                return NotFound(); // Return a 404 Not Found if the file doesn't exist
            }
        }

        public void OnGet()
        {
            // Populate dropdown with activity names
            //ActivityOptions = _activityTypeService.GetActivities()
            //    .Select(a => new SelectListItem { Value = a.Name, Text = a.Name })
            //    .ToList();
        }

        public IActionResult OnPost()
        {
            int studentId = GetStudentId();

            //_studentService.AddStudentActivity(studentId, SelectedActivity);

            return RedirectToPage("/StudentProfile", new { studentId });
        }

        private int GetStudentId()
        {
            // Logic to retrieve the student ID
            // ...
            return 1;
        }
    }
}
//aqui falta implementar o gerar pacotes
//não é aqui, mas a barra de navegação falta o link para a parte do "coordenador" qual não está implementada
//em coordenador teria de implementar alunos para ter o controle e poder importar pacotes
//julgo que aqui falta implementar deletar atividades, mas poderia ser na visualização também
//se pá tem uma forma melhor de distinguir atividades válidas de inválidas, falta isso também:
//ao passar do limite de horas máximas de um tipo, deve escolher a combinação que melhor aproxime ...
//do limite sem ultrapassa-lo, marcando as outras como inválidas, acho que uma flag bool seria melhor ...
//que fazer isso no front end

//em vez de usar arquivos locais, utilize a API do google para colocar tudo no drive ***