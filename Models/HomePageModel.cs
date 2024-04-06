using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilterAndPaginationMvcProject.Models;

public class HomepageModel
{
	public string? FirstAndLastNameFilter { get; set; }

	public string? ExtraInformationFilter { get; set; }
	
	public SortBy SortBy { get; set; }

	public IEnumerable<SelectListItem> SortByOptions { get; set; } = Enumerable.Empty<SelectListItem>();

	public PaginationModel<DataModel> PaginatedResult { get; set; } = new();
}

public enum SortBy
{
	FirstNameAsc = 0,
	FirstNameDesc = 1,
	LastNameAsc = 2,
	LastNameDesc = 3
}