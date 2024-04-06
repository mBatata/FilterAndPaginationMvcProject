using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilterAndPaginationMvcProject.Services;

public sealed class DataService : IDataService
{
	private const int PageSize = 20;
	
	public HomepageModel GetModel(int pageNumber = 1, string? firstAndLastNameFilter = null, SortBy sortBy = SortBy.FirstNameAsc, string? extraInformationFilter = null)
	{
		var data = GenerateTestData();

		if (!string.IsNullOrWhiteSpace(firstAndLastNameFilter))
		{
			data = Array.FindAll(data, x => x.FullName.Contains(firstAndLastNameFilter, StringComparison.OrdinalIgnoreCase));
		}
		
		if (!string.IsNullOrWhiteSpace(extraInformationFilter))
		{
			data = Array.FindAll(data, x => x.ExtraInformation.Contains(extraInformationFilter, StringComparison.OrdinalIgnoreCase));
		}
		
		switch(sortBy)
		{
			case SortBy.FirstNameAsc:
				Array.Sort(data, (x, y) => x.FirstName.CompareTo(y.FirstName));
				break;
				
			case SortBy.FirstNameDesc:
				Array.Sort(data, (x, y) => y.FirstName.CompareTo(x.FirstName));
				break;
				
			case SortBy.LastNameAsc:
				Array.Sort(data, (x, y) => x.LastName.CompareTo(y.LastName));
				break;
				
			case SortBy.LastNameDesc:
				Array.Sort(data, (x, y) => y.LastName.CompareTo(x.LastName));
				break;
		}

		return new HomepageModel()
		{
			FirstAndLastNameFilter = firstAndLastNameFilter,
			ExtraInformationFilter = extraInformationFilter,
			SortBy = sortBy,
			SortByOptions = GetSortByOptions(),
			PaginatedResult = new PaginationModel<DataModel>(pageNumber, PageSize, data)
		};
	}
	
	private static DataModel[] GenerateTestData()
	{
		const int numberOfItems = 120;
		var data = new DataModel[numberOfItems];

		for (var i = 0; i < numberOfItems; i++)
		{
			data[i] = new DataModel()
			{
				Number = i,
				FirstName = $"FirstName {i}",
				LastName = $"LastName {i}",
				ExtraInformation = $"ExtraInformation {i}"
			};
		}

		return data;
	}

	private static IEnumerable<SelectListItem> GetSortByOptions() => new List<SelectListItem>()
	{
		new("First name ascending", SortBy.FirstNameAsc.ToString()),
		new("First name descending", SortBy.FirstNameDesc.ToString()),
		new("Last name ascending", SortBy.LastNameAsc.ToString()),
		new("Last name descending", SortBy.LastNameDesc.ToString())
	};
}