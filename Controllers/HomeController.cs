using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FilterAndPaginationMvcProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IDataService _dataService;

	public HomeController(ILogger<HomeController> logger, IDataService dataService)
	{
		_logger = logger;
		_dataService = dataService;
	}

	public IActionResult Index(
		[FromQuery(Name = QueryStringConstants.PageNumber)] int pageNumber = 1,
		[FromQuery(Name = QueryStringConstants.FirstAndLastName)] string? firstAndLastNameFilter = null,
		[FromQuery(Name = QueryStringConstants.SortBy)] SortBy sortByFilter = SortBy.FirstNameAsc,
		[FromQuery(Name = QueryStringConstants.ExtraInformation)] string? extraInformationFilter = null)
	{
		var model = _dataService.GetModel(pageNumber, firstAndLastNameFilter, sortByFilter, extraInformationFilter);
		return View(model);
	}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
