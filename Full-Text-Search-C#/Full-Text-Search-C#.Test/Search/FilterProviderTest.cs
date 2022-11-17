using Full_Text_Search_C_.Models;
using Full_Text_Search_C_.Search;

namespace Full_Text_Search_C_.Test.Search;

public class FilterProviderTest
{
    [Fact]
    public void FindDocsInclude_SimpleValues_FoundDocs_Test()
    {
        var invertedIndex = new InvertedIndex(new Dictionary<string, HashSet<int>>()
        {
            {"hello", new HashSet<int>() {1, 2, 3}},
            {"world", new HashSet<int>() {1, 3}},
            {"!", new HashSet<int>() {4}}
        });
        FilterProvider filterProvider = new FilterProvider(invertedIndex);
        var result = filterProvider.FindDocsInclude(new List<string>() {"hello", "world"});
        var expected = new HashSet<int>() {1, 3};
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void RemoveDocsExclude_SimpleValues_RemoveDocs_Test()
    {
        var invertedIndex = new InvertedIndex(new Dictionary<string, HashSet<int>>()
        {
            {"world", new HashSet<int>() {1, 3}},
        });
        var excludeWords = new List<string>() {"world"};
        var docs = new HashSet<int>() {1, 2, 3};
        FilterProvider filterProvider = new FilterProvider(invertedIndex);
        var result = filterProvider.RemoveDocsExclude(docs, excludeWords);

        var expected = new HashSet<int>() {2};
        Assert.Equal(expected, result);

    }
    
    [Fact]
    public void RemoveDocsExclude_EmptySet_RemoveDocs_Test()
    {
        var invertedIndex = new InvertedIndex(new Dictionary<string, HashSet<int>>()
        {
            {"world", new HashSet<int>() {1, 3}},
        });
        var excludeWords = new List<string>() {"world"};
        var docs = new HashSet<int>();
        FilterProvider filterProvider = new FilterProvider(invertedIndex);
        var result = filterProvider.RemoveDocsExclude(docs, excludeWords);
        Assert.Null(result);
    }
    
    [Fact]
    public void FindDocsAtLeastOneInclude_SimpleValues_FoundDocs_Test()
    {
        var invertedIndex = new InvertedIndex(new Dictionary<string, HashSet<int>>()
        {
            {"hello", new HashSet<int>() {1, 2, 3}},
            {"world", new HashSet<int>() {1, 3}},
            {"!", new HashSet<int>() {3}}
        });
        var atLeastIncludeWords = new List<string>() {"world", "!"};
        var docs = new HashSet<int>() {1, 2, 3};
        FilterProvider filterProvider = new FilterProvider(invertedIndex);
        var result = filterProvider.FindDocsAtLeastOneInclude(docs, atLeastIncludeWords);

        var expected = new HashSet<int>() {1, 3};
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void FindDocsAtLeastOneInclude_EmptySet_FoundDocs_Test()
    {
        var invertedIndex = new InvertedIndex(new Dictionary<string, HashSet<int>>()
        {
            {"world", new HashSet<int>() {1, 3}},
        });
        var atLeastIncludeWords = new List<string>() {"world"};
        var docs = new HashSet<int>();
        FilterProvider filterProvider = new FilterProvider(invertedIndex);
        var result = filterProvider.FindDocsAtLeastOneInclude(docs, atLeastIncludeWords);
        
        Assert.Null(result);
    }
}