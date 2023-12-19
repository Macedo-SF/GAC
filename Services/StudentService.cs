using GAC.Classes;
using GAC.Models;
using GAC.Services.Interfaces;
using System.Xml.Linq;

namespace GAC.Services
{
    public class StudentService: IStudentService
    {
        private readonly List<StudentModel> _students;
        private readonly IActivityTypeService _activityService;

        public StudentService(IActivityTypeService activityService)
        {
            _students = new List<StudentModel>();
            _activityService = activityService;
            //Initialize students, you can load this from a database or other source
            // For example:
            // _students.Add(new Student { Id = 1, Name = "John Doe", PPC = "Your PPC here", Activities = new List<Activity>() });
            //_students.Add(new Student { Id = 2, Name = "Jane Smith", PPC = "Another PPC", Activities = new List<Activity>() });
            //...
        }

        public List<StudentModel> GetStudents()
        {
            return _students;
        }

        public void AddStudentActivity(int studentId, string activityName /* Other activity details if needed */)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                var activityType = _activityService.GetActivityTypeByName(activityName);
                // Validate if activity type exists and meets criteria before adding
                if (activityType != null)
                { /* && Add your validation logic here 
                    // Create an Activity instance based on the activity type and add it to the student's activities
                    var activity = new Activity { Name = activityName /*, Other properties based on the activityType */
                }
                var activity = new ActivityModel(category: activityType, name: "", hours: 0, fileName: "");
                student.Activities.Add(activity);
            }
            // Update student's total registered hours
            // student.RegisteredHours += activity.Hours; // You might calculate this based on activityType's hours
        }
    }
}