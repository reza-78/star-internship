using ASPFirstApp.Abstraction;
using ASPFirstApp.Logic;
using Microsoft.AspNetCore.Mvc;

namespace ASPFirstApp.Controllers;

[Route("/search")]
public class SearchController : ControllerBase
{
    private readonly ISearchLogic _searchLogic;

    public SearchController(ISearchLogic searchLogic)
    {
        _searchLogic = searchLogic;
    }

    [HttpGet]
    public ActionResult<HashSet<int>> Search(string[] words)
    {

        return _searchLogic.SearchExpression(words);
    }
}