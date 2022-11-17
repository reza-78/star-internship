using Full_Text_Search_C_.Models;

namespace Full_Text_Search_C_.Search;

public class FilterProvider
{
    // we can implement this class like simple calculator example.
    // creating a provider and an Enum for types of filtering and use just Filter() method.
    // writing tests more simpler with Theory 
    
    private readonly InvertedIndex _invertedIndex;
    private readonly DataOperator _dataOperator = new ();

    public FilterProvider(InvertedIndex invertedIndex)
    {
        _invertedIndex = invertedIndex;
    }

    public HashSet<int> FindDocsInclude(List<string> includeWords)
    {
        var docsInclude = new List<HashSet<int>>();
        foreach (var term in includeWords)
        {
            docsInclude.Add(_invertedIndex.Get(term));
        }
        return _dataOperator.Intersect(docsInclude);
    }

    public HashSet<int> RemoveDocsExclude(HashSet<int> docsInclude, List<string> excludeWords)
    {
        if (docsInclude.Count == 0) return null;
        foreach (var term in excludeWords)
        {
            foreach (var doc in _invertedIndex.Get(term))
            {
                docsInclude.Remove(doc);
            }
        }
        return docsInclude;
    }

    public HashSet<int> FindDocsAtLeastOneInclude(HashSet<int> docs, List<string> includeAtLeastOneWords)
    {
        if (docs.Count == 0) return null;
        HashSet<int> docsIncludeAtLeastOne = new HashSet<int>();
        foreach (var term in includeAtLeastOneWords)
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

}