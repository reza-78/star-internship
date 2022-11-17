using Full_Text_Search_C_.PreProcesses;

namespace Full_Text_Search_C_.Search;

public class Searcher
{
    private readonly FilterProvider _filterProvider;
    private QueryProcessor _queryProcessor;

    public Searcher()
    {
        _filterProvider = new FilterProvider(new InvertedIndexFactory(new FileReader())
            .CreateInvertedIndex("../../../../EnglishData"));
    }

    public HashSet<int>? Search(string expression)
    {
        PrepareQueryProcessor(expression);
        HashSet<int> result = _filterProvider.FindDocsInclude(_queryProcessor.Include);
        HashSet<int> resultAfterRemoveDocsExclude = _filterProvider.RemoveDocsExclude(result, _queryProcessor.Exclude);
        HashSet<int> resultAfterFindDocsAtLeastOneInclude =
            _filterProvider.FindDocsAtLeastOneInclude(resultAfterRemoveDocsExclude, _queryProcessor.AtLeastOneInclude);
        return resultAfterFindDocsAtLeastOneInclude;
    }

    private void PrepareQueryProcessor(string expression)
    {
        _queryProcessor = new QueryProcessor();
        _queryProcessor.ParseExpression(expression);
    }
}