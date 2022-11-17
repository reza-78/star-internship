using Full_Text_Search_C_.Models;
using Full_Text_Search_C_.PreProcesses;

namespace Full_Text_Search_C_.Search;

public class Searcher
{
    private readonly QueryProcessor _queryProcessor;
    private readonly InvertedIndex _invertedIndex;

    public Searcher()
    {
        _invertedIndex = new InvertedIndexFactory(new FileReader())
            .CreateInvertedIndex("../../../../EnglishData");
        _queryProcessor = new QueryProcessor();
    }

    public HashSet<int>? Search(string expression)
    {
        _queryProcessor.ParseExpression(expression);
        HashSet<int>? result = FindDocsInclude();
        RemoveDocsExclude(result);
        return FindDocsAtLeastOneInclude(result);
    }

    private HashSet<int>? FindDocsInclude()
    {
        var docsInclude = new List<HashSet<int>>();
        if (_queryProcessor.Include.Count != 0)
        {
            foreach (var term in _queryProcessor.Include)
            {
                docsInclude.Add(_invertedIndex.Get(term));
            }

            return Intersect(docsInclude);
        }

        return null;
    }

    private void RemoveDocsExclude(HashSet<int>? docsInclude)
    {
        if (docsInclude == null) return;
        foreach (var term in _queryProcessor.Exclude)
        {
            foreach (var doc in _invertedIndex.Get(term))
            {
                docsInclude.Remove(doc);
            }
        }
    }

    private HashSet<int>? FindDocsAtLeastOneInclude(HashSet<int>? docs)
    {
        if (docs == null) return null;
        HashSet<int> docsIncludeAtLeastOne = new HashSet<int>();
        foreach (var term in _queryProcessor.AtLeastOneInclude)
        {
            foreach (var doc in _invertedIndex.Get(term))
            {
                docsIncludeAtLeastOne.Add(doc);
            }
        }
        return removeNotIncludeAtLeastOne(docs, docsIncludeAtLeastOne);
        
    }

    private HashSet<int> removeNotIncludeAtLeastOne(HashSet<int> docs, HashSet<int> atLeast)
    {
        HashSet<int> result = new HashSet<int>();
        foreach (var doc in docs)
        {
            if (atLeast.Contains(doc))
            {
                result.Add(doc);
            }
        }

        return result;
    }

    private HashSet<int> Intersect(List<HashSet<int>> docsList)
    {
        return docsList
            .Skip(1)
            .Aggregate(
                new HashSet<int>(docsList.First()),
                (h, e) =>
                {
                    h.Intersect(e);
                    return h;
                }
            );
    }
}