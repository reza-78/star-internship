using Full_Text_Search_C_.Search;

namespace Full_Text_Search_C_.Test.Search;

public class DataOperatorTest
{
    [Fact]
    public void Intersect_TwoSet_Intersected_Test()
    {
        var set1 = new HashSet<int>() {1, 2, 3};
        var set2 = new HashSet<int>() {2, 3, 4};
        var list = new List<HashSet<int>>() {set1, set2};
        var result = new DataOperator().Intersect(list);
        
        Assert.Equal(new HashSet<int>() {2, 3}, result);
    }
}