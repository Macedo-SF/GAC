using GAC.Classes;
using GAC.Models;

namespace GAC.Services.Interfaces;

public interface IActivityTypeService
{
    List<ActivityTypeModel> GetActivityTypes();
    ActivityTypeModel? GetActivityTypeByName(string activityTypeName);
    List<string> GetActivityTypeNames();
}
