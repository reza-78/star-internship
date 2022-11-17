namespace Full_Text_Search_C_.Search;

public class QueryProcessor
{
    public List<string> Include { get; } = new();
    public List<string> Exclude { get; } = new();
    public List<string> AtLeastOneInclude { get; } = new();

    public void ParseExpression(string expression)
    {
        ClearLists();
        var words = expression.Split(" ");
        foreach (var word in words)
        {
            switch (word[0])
            {
                case '+':
                    AtLeastOneInclude.Add(word.Substring(1));
                    break;
                case '-':
                    Exclude.Add(word.Substring(1));
                    break;
                default:
                    Include.Add(word);
                    break;
            }
        }
    }

    private void ClearLists()
    {
        Include.Clear();
        Exclude.Clear();
        AtLeastOneInclude.Clear();
    }
}