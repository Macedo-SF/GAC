using GAC.Classes;
using GAC.Models;
using GAC.Services.Interfaces;

namespace GAC.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
		private readonly List<ActivityTypeModel> _activityTypes;

		public ActivityTypeService()
		{
			_activityTypes = new List<ActivityTypeModel>();
			// Initialize activities, you can load this from a database or other source
			InitializeActivityType();
		}
		private void InitializeActivityType()
        {
            _activityTypes.Add(new ActivityTypeModel { Name = "Promoção da Cidadania", MaxHoursPerInstance = 0, MaxHoursTotal = 30 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Participação em Colegiados", MaxHoursPerInstance = 0, MaxHoursTotal = 30 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Projetos de Consultoria", MaxHoursPerInstance = 0, MaxHoursTotal = 30 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Estágio Extracurricular", MaxHoursPerInstance = 0, MaxHoursTotal = 80 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Organizador de Eventos", MaxHoursPerInstance = 0, MaxHoursTotal = 30 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Visitas Técnicas", MaxHoursPerInstance = 0, MaxHoursTotal = 30 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Participação em Eventos", MaxHoursPerInstance = 0, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Maratonas de Programação", MaxHoursPerInstance = 5, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Defesas de Mestrado", MaxHoursPerInstance = 2, MaxHoursTotal = 12 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Defesas de Doutorado", MaxHoursPerInstance = 4, MaxHoursTotal = 12 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Artigo Publicado em Anais", MaxHoursPerInstance = 20, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Artigo Publicado em Revista", MaxHoursPerInstance = 30, MaxHoursTotal = 90 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Trabalho Publicado em Eventos", MaxHoursPerInstance = 15, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Premiação em Trabalhos Acadêmicos", MaxHoursPerInstance = 10, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Palestrante", MaxHoursPerInstance = 0, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Instrutor em cursos", MaxHoursPerInstance = 0, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Projetos de Pesquisa", MaxHoursPerInstance = 40, MaxHoursTotal = 80 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Monitoria", MaxHoursPerInstance = 30, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Empresa Júnior", MaxHoursPerInstance = 0, MaxHoursTotal = 60 });
            _activityTypes.Add(new ActivityTypeModel { Name = "Optativas Excedentes", MaxHoursPerInstance = 0, MaxHoursTotal = 60 });
        }

        public List<ActivityTypeModel> GetActivityTypes()
        {
            return _activityTypes;
        }
        public List<string> GetActivityTypeNames()
        {
            return _activityTypes.Select(activityType => activityType.Name).ToList();
        }

        public ActivityTypeModel? GetActivityTypeByName(string activityTypeName)
        {
            return _activityTypes.FirstOrDefault(x => x.Name == activityTypeName);
        }
    }
}
