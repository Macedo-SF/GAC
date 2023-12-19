using GAC.Classes;

namespace GAC.Models;

// Class representing an Activity
public class ActivityModel
{
    private static int lastId = 0;
    public int Id { get; private set; }
    public ActivityTypeModel Category { get; set; }
    public string Name { get; set; }
    public int Hours { get; set; }
    public string? Certificate { get; set; } // PDF file stored as byte array

    public ActivityModel()
    {
        Id = lastId;
		lastId++;
	}
    // Constructor that accepts a file path and converts it to a byte array
    public ActivityModel(ActivityTypeModel category, string name, int hours, string fileName)
    {
        Id = lastId;
        Category = category;
        Name = name;
        Hours = hours;

        // Ensure that the global directory path is not empty
        string directoryPath = GlobalSettings.DirectoryPath ?? string.Empty;
        directoryPath = Path.GetFullPath(Path.Combine(directoryPath, @"..\wwwroot\Documentos"));

        // Combine the directory path and the file name to get the full file path
        string filePath = Path.Combine(directoryPath, fileName);

        if (File.Exists(filePath))
        {
            Certificate = fileName;

        }
        //falhando aqui, arquivo não existe? tá entrando no wwwroot?
        else
        {
            Certificate = null;
        }

        lastId++;
    }
    int getId()
    {
        return Id;
    }
    ActivityTypeModel getActivityType()
    {
        return Category;
    }
    string getName()
    {
        return Name;
    }
    int getHours()
    {
        return Hours;
    }
    string getCertificate()
    {
        return Certificate;
    }
    //useless gets...
}
