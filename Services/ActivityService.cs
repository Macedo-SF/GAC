using GAC.Classes;
using GAC.Models;
using GAC.Services.Interfaces;
using System.Xml.Linq;

namespace GAC.Services;

public class ActivityService : IActivityService
{
	private static List<ActivityModel> _activities = new List<ActivityModel>();
	private readonly IActivityTypeService _activityTypesService;
	private static bool init = false;

	public ActivityService(IActivityTypeService activityTypesService)
    {
        _activityTypesService = activityTypesService;
        if (!init)
        {
            InitializeActivity();
            init = !init;

		}
    }
    private void InitializeActivity()
    {
        _activities.Add(new ActivityModel(category:  _activityTypesService.GetActivityTypes()[3], 
            name: "Nome 1", 
            hours: 20, 
            fileName: "dummy.pdf"));
        _activities.Add(new ActivityModel(category: _activityTypesService.GetActivityTypes()[6],
            name: "Nome 2",
            hours: 30,
            fileName: "dummy.pdf"));
        _activities.Add(new ActivityModel(category: _activityTypesService.GetActivityTypes()[0],
            name: "Nome 3",
            hours: 20,
            fileName: "dummy.pdf"));
        _activities.Add(new ActivityModel(category: _activityTypesService.GetActivityTypes()[5],
            name:"Nome 4",
            hours: 5,
            fileName: "dummy.pdf"));

        _activities.Add(new ActivityModel(category: _activityTypesService.GetActivityTypes()[5],
            name: "Nome 5",
            hours: 15,
            fileName: "dummy.pdf"));
        _activities.Add(new ActivityModel(category: _activityTypesService.GetActivityTypes()[19],
            name: "Nome 6",
            hours: 60,
            fileName: "dummy.pdf"));
		_activities.Add(new ActivityModel(category: _activityTypesService.GetActivityTypes()[6],
			name: "Invalida 1",
			hours: 20,
			fileName: ""));
		_activities.Add(new ActivityModel(category: _activityTypesService.GetActivityTypes()[1],
			name: "Invalida 2",
			hours: 10,
			fileName: ""));
		_activities.Add(new ActivityModel(category: _activityTypesService.GetActivityTypes()[8],
			name: "Invalida 3",
			hours: 5,
			fileName: ""));
	}
    public List<ActivityModel> GetActivities()
    {
        return _activities;
    }

    public void AddActivity(ActivityModel activity)
    {
        _activities.Add(activity);
    }

    public ActivityModel? GetActivityById(int id)
    {
        return _activities.FirstOrDefault(x => x.Id == id);
    }
}
