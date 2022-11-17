using Full_Text_Search_C_.Models;
using Full_Text_Search_C_.Search;
using NSubstitute;

namespace Full_Text_Search_C_.Test.Search;

public class SearchTest
{
    [Fact]
    public void Search_Test()
    {
        // var filterProvider = Substitute.For<FilterProvider>(Substitute.For<InvertedIndex>(Substitute.For<Dictionary<string, HashSet<int>>>()));
        // var includeDocs = new HashSet<int>() {1, 2, 3};
        // var excludeDocs = new HashSet<int>() {1, 2};
        // var atLeastOneIncludeDocs = new HashSet<int>() {1};
        // filterProvider.FindDocsInclude(Arg.Any<List<string>>()).Returns(includeDocs);
        // filterProvider.RemoveDocsExclude(includeDocs, Arg.Any<List<string>>()).Returns(excludeDocs);
        // filterProvider.FindDocsAtLeastOneInclude(excludeDocs, Arg.Any<List<string>>())
        //     .Returns(atLeastOneIncludeDocs);
        // var queryProcessor = Substitute.For<QueryProcessor>();
        // queryProcessor.ParseExpression(Arg.Any<string>()).Returns(new ParsedExpression(new List<string>(),
        //     new List<string>(), new List<string>()));
        // Searcher searcher = new Searcher(filterProvider, queryProcessor);
        // var result = searcher.Search("hello");
    }
}