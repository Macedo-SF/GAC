namespace GAC.Models;

// Class representing a Package
public class PackageModel
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public string MatriculationNumber { get; set; }
    public byte[] PackageFile { get; set; } // ZIP file stored as byte array
}
