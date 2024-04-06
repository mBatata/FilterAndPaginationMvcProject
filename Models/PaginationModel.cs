namespace FilterAndPaginationMvcProject.Models;

public class PaginationModel<T>
{
	public int CurrentPage { get; set; }
	
	public int PageSize { get; set; }
	
	public int TotalResults { get; set; }
	
	public T[] PaginatedValues { get; set; }

	public int TotalPages => PageSize == 0 ? 1 : (int)Math.Ceiling(TotalResults / (double)PageSize);
	
	public PaginationModel() 
		: this(1, 1, Array.Empty<T>()) {}
	
	public PaginationModel(int currentPage, int pageSize, T[] values)
	{
		CurrentPage = currentPage;
		PageSize = pageSize;
		TotalResults = values.Length;
		PaginatedValues = PaginateArray(values);
	}
	
	private T[] PaginateArray(T[] originalArray)
	{
		if (originalArray.Length > 0)
		{
			var startPosition = (CurrentPage - 1) * PageSize;
			var endPosition = startPosition + PageSize > TotalResults ? TotalResults : startPosition + PageSize;
			
			if (startPosition > TotalResults)
			{
				throw new IndexOutOfRangeException($"{nameof(PaginationModel<T>)} - {startPosition} > {TotalResults}");
			}

			return originalArray[startPosition..endPosition];
		}

		return Array.Empty<T>();
	}
}