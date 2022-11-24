using Full_Text_Search_C_.PreProcesses;

namespace Full_Text_Search_C_.Search;

public class Searcher
{
    private readonly FilterProvider _filterProvider;
    private readonly QueryProcessor _queryProcessor;

    public Searcher(string dataPath)
    {
        _filterProvider = new FilterProvider(new InvertedIndexFactory(new FileReader())
            .CreateInvertedIndex(dataPath));
        _queryProcessor = new QueryProcessor();
    }

    public Searcher(FilterProvider filterProvider ,QueryProcessor queryProcessor)
    {
        _filterProvider = filterProvider;
        _queryProcessor = queryProcessor;
    }

    public HashSet<int>? Search(string expression)
    {
        var parsedExpression = _queryProcessor.ParseExpression(expression);
        HashSet<int> result = _filterProvider.FindDocsInclude(parsedExpression.Include);
        HashSet<int> resultAfterRemoveDocsExclude = _filterProvider.RemoveDocsExclude(result, parsedExpression.Exclude);
        HashSet<int> resultAfterFindDocsAtLeastOneInclude =
            _filterProvider.FindDocsAtLeastOneInclude(resultAfterRemoveDocsExclude, parsedExpression.AtLeastOneInclude);
        return resultAfterFindDocsAtLeastOneInclude;
    }
}