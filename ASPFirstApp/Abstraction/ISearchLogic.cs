namespace ASPFirstApp.Abstraction;

public interface ISearchLogic
{
    public HashSet<int> SearchExpression(string[] words);
}