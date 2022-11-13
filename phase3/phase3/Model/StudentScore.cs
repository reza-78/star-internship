namespace phase3.Model;

public class StudentScore
{
    public int StudentNumber { get; }
    private string Lesson;
    public double Score { get; }

    public StudentScore(int studentNumber, string lesson, double score)
    {
        StudentNumber = studentNumber;
        Lesson = lesson;
        Score = score;
    }
    
}