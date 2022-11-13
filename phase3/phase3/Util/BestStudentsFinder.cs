using phase3.Model;

namespace phase3.util;

public class BestStudentsFinder
{
    public void FindBestStudents(int range)
    {
        List<Student>? students = FileReader.ReadFile<Student>("students.json");
        List<StudentScore>? scores = FileReader.ReadFile<StudentScore>("scores.json");
        List<StudentAvgScore> result = CalculateScoreAvg(students, scores, range);
        PrintBestStudents(result);
    }

    private List<StudentAvgScore> CalculateScoreAvg(List<Student>? students, List<StudentScore>? scores, int range)
    {
        return (from student in students
                join score in scores on student.StudentNumber equals score.StudentNumber into g
                select new StudentAvgScore(student.FirstName, student.LastName,
                    g.Average(x => x.Score)))
            .OrderByDescending(s => s.AvgScore).Take(range).ToList();
    }

    private void PrintBestStudents(List<StudentAvgScore> result)
    {
        result.ForEach(s => Console.WriteLine($"{s.Name} {s.LastName}, avg: {s.AvgScore}"));
    } 
}