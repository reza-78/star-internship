using Full_Text_Search_C_.Abstractions;
using Full_Text_Search_C_.PreProcesses;
namespace Full_Text_Search_C_.Test.PreProcesses;

public class FileReaderTest
{
    [Fact]
    public void ReadFileTest()
    {
        IFileReader fileReader = new FileReader();
        var result = fileReader.ReadFile("testDoc.txt");
        Assert.Equal(3, result.Length);
        Assert.Equal(new []{"hello", "world", "!"}, result);
    }

    [Fact]
    public void ReadFilesInDirectoryTest()
    {
        IFileReader fileReader = new FileReader();
        var result = fileReader.ReadFilesInDirectory("dataDirectory");
        Assert.Single(result);
    }
    
    
}