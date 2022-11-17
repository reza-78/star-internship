using Full_Text_Search_C_.Models;

namespace Full_Text_Search_C_.Test.Models;

public class InvertedIndexTest
{
    // MethodName_Condition_Expected_Test()
    [Fact]
    public void Get_SimpleValue_Got_Test()
    {
        var invertedIndex = new InvertedIndex(new Dictionary<string, HashSet<int>>()
        {
            {"hello", new HashSet<int>(){1, 2, 3}},
        });
        var result = invertedIndex.Get("hello");
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void Add_ValueNotExists_Added_Test()
    {
        var dictionary = new Dictionary<string, HashSet<int>>();
        var invertedIndex = new InvertedIndex(dictionary);
        
        invertedIndex.Add("hello", 1);

        var result = dictionary["hello"];
        Assert.Single(result);
        Assert.Contains(1, result);
    }
    
    [Fact]
    public void Add_ValueExists_Added_Test()
    {
        var dictionary = new Dictionary<string, HashSet<int>>()
            {
                {"hello", new HashSet<int>(){1, 2}},
            };
        var invertedIndex = new InvertedIndex(dictionary);
        
        invertedIndex.Add("hello", 4);

        var result = dictionary["hello"];
        Assert.Equal(3, result.Count);
        Assert.Contains(4, result);
    }
}