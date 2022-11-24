using Full_Text_Search_C_.Search;

public class Program
{
    public static void Main(string[] args)
    {
        var expression = Console.ReadLine();
        foreach (var i in new Searcher("../../../../EnglishData").Search(expression))
        {
            Console.WriteLine(i);
        }
    }
}
