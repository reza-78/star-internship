using Full_Text_Search_C_.Search;

namespace Full_Text_Search_C_.Test.Search;

public class QueryProcessorTest
{
    [Fact]
    public void ParseExpression_SimpleValues_Parsed_Test()
    {
        string expression = "hello -world +!";
        QueryProcessor queryProcessor = new QueryProcessor();
        var parsedExpression = queryProcessor.ParseExpression(expression);
        Assert.Single(parsedExpression.Include);
        Assert.Single(parsedExpression.Exclude);
        Assert.Single(parsedExpression.AtLeastOneInclude);
        Assert.Equal("hello", parsedExpression.Include[0]);
        Assert.Equal("world", parsedExpression.Exclude[0]);
        Assert.Equal("!", parsedExpression.AtLeastOneInclude[0]);
    }
}