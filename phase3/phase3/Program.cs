// See https://aka.ms/new-console-template for more information

// Console.WriteLine(Directory.GetCurrentDirectory());

using phase3.util;

namespace phase3;

public static class Program
{
    public static void Main(string[] args)
    {
        new BestStudentsFinder().FindBestStudents(3);
    }
}