namespace Full_Text_Search_C_.Search;

public class DataOperator
{
    public HashSet<int> Intersect(List<HashSet<int>> docsList)
    {
        return docsList
            .Skip(1)
            .Aggregate(
                new HashSet<int>(docsList.First()),
                (h, e) =>
                {
                    h.IntersectWith(e);
                    return h;
                }
            );
    }
}