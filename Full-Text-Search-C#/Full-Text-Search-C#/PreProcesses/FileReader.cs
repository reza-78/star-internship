using Full_Text_Search_C_.Abstractions;

namespace Full_Text_Search_C_.PreProcesses;

public class FileReader:IFileReader
{
    public IEnumerable<string> ReadFilesInDirectory(string folderPath)
    {
        return Directory.EnumerateFiles(folderPath);
    }

    public string[] ReadFile(string filePath)
    {
        var context = File.ReadAllText(filePath);
        return context.Split(" ");
    }
}