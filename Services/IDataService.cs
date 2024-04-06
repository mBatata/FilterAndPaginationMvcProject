namespace FilterAndPaginationMvcProject.Services;

public interface IDataService
{
	HomepageModel GetModel(int pageNumber = 1, string? firstAndLastNameFilter = null, SortBy sortBy = SortBy.FirstNameAsc, string? extraInformationFilter = null);
}