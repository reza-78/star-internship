namespace phase3.Model;

public class StudentAvgScore
{
    public string Name { get; }
    public string LastName { get; }
    public double AvgScore { get; }

    public StudentAvgScore(string name, string lastName, double avgScore)
    {
        Name = name;
        LastName = lastName;
        AvgScore = avgScore;
    }
}