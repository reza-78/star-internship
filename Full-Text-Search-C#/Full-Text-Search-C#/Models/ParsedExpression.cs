namespace Full_Text_Search_C_.Models;

public class ParsedExpression
{
    public ParsedExpression(List<string> include, List<string> exclude, List<string> atLeastOneInclude)
    {
        Include = include;
        Exclude = exclude;
        AtLeastOneInclude = atLeastOneInclude;
    }

    public List<string> Include { get; }
    public List<string> Exclude { get; }
    public List<string> AtLeastOneInclude { get; }
}