namespace FilterAndPaginationMvcProject.Models;

public class DataModel
{
	public int Number { get; set; } = 1;
	
	public string FirstName { get; set; } = string.Empty;
	
	public string LastName { get; set; } = string.Empty;

	public string ExtraInformation { get; set; } = string.Empty;

	public string FullName => $"{FirstName} {LastName}";
}