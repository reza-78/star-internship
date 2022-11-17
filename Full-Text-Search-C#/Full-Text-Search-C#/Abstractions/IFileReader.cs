namespace Full_Text_Search_C_.Abstractions;

public interface IFileReader: IDataLoader
{
    IEnumerable<string> ReadFilesInDirectory(string folderPath);
    public string[] ReadFile(string filePath);

}