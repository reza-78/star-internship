using Full_Text_Search_C_.Search;

namespace Full_Text_Search_C_.Test.Search;

public class QueryProcessorTest
{
    [Fact]
    public void ParseExpression_SimpleValues_Parsed_Test()
    {
        string expression = "hello -world +!";
        QueryProcessor queryProcessor = new QueryProcessor();
        queryProcessor.ParseExpression(expression);
        Assert.Single(queryProcessor.Include);
        Assert.Single(queryProcessor.Exclude);
        Assert.Single(queryProcessor.AtLeastOneInclude);
        Assert.Equal("hello", queryProcessor.Include[0]);
        Assert.Equal("world", queryProcessor.Exclude[0]);
        Assert.Equal("!", queryProcessor.AtLeastOneInclude[0]);
    }
}