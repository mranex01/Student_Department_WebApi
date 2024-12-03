namespace ASPCoreWebAPICRUD.Models;

public class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; } 
    public string LastName { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public int? Standard { get; set; }

    public string? DisplayName { get; set; }
}
