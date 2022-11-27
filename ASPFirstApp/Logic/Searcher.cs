using ASPFirstApp.Abstraction;
using Full_Text_Search_C_.Search;

namespace ASPFirstApp.Logic;

public class SearchLogic: ISearchLogic
{
    private readonly Searcher _searcher;

    public SearchLogic(Searcher searcher)
    {
        _searcher = searcher;
    }

    public HashSet<int> SearchExpression(string[] words)
    {
        return _searcher.Search(String.Join(" ", words));
    }
}