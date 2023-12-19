using GAC.Classes;
using GAC.Models;

namespace GAC.Services.Interfaces;

public interface IActivityService
{
    List<ActivityModel> GetActivities();
    void AddActivity(ActivityModel activity);
    ActivityModel? GetActivityById(int id);
}
