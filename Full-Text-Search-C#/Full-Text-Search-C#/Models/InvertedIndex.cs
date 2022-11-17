namespace Full_Text_Search_C_.Models;

public class InvertedIndex
{
    private readonly Dictionary<string, HashSet<int>> _invertedIndex;

    public InvertedIndex()
    {
        _invertedIndex = new Dictionary<string, HashSet<int>>();
    }

    public InvertedIndex(Dictionary<string, HashSet<int>> invertedIndex)
    {
        _invertedIndex = invertedIndex;
    }

    public void Add(string term, int docId)
    {
        if (_invertedIndex.TryGetValue(term, out var termList))
        {
            termList.Add(docId);
        }
        else
        {
            _invertedIndex.Add(term, new HashSet<int>(new []{docId}));
        }
    }

    public HashSet<int> Get(string term)
    {
        return _invertedIndex[term];
    }

}