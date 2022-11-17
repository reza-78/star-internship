using Full_Text_Search_C_.Models;

namespace Full_Text_Search_C_.Search;

public class QueryProcessor
{
    public ParsedExpression ParseExpression(string expression)
    {
        List<string> include = new();
        List<string> exclude = new();
        List<string> atLeastOneInclude = new();
        var words = expression.Split(" ");
        foreach (var word in words)
        {
            switch (word[0])
            {
                case '+':
                    atLeastOneInclude.Add(word.Substring(1));
                    break;
                case '-':
                    exclude.Add(word.Substring(1));
                    break;
                default:
                    include.Add(word);
                    break;
            }
        }
        return new ParsedExpression(include, exclude, atLeastOneInclude);
    }
}