namespace GAC.Models;

// Class representing a Student
public class StudentModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PPC { get; set; }
    public int RegisteredHours { get; set; }
    public List<ActivityModel> Activities { get; set; }
}
