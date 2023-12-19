using GAC.Models;

namespace GAC.Services.Interfaces;

public interface IStudentService
{
    List<StudentModel> GetStudents();
    void AddStudentActivity(int studentId, string activityName);
    // Other methods for updating or deleting students if needed
}
