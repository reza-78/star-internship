using Full_Text_Search_C_.Abstractions;

namespace Full_Text_Search_C_.PreProcesses;

public class FileReader:IDataLoader
{
    public string[] LoadData(string source)
    {
        var context = File.ReadAllText(source);
                return context.Split(" ");
    }

    public IEnumerable<string> ReadFilesInDirectory(string folderPath)
    {
        return Directory.EnumerateFiles(folderPath);
    }
}