using Full_Text_Search_C_.Abstractions;
using Full_Text_Search_C_.PreProcesses;
namespace Full_Text_Search_C_.Test.PreProcesses;

public class FileReaderTest
{
    public void LoadDataTest()
    {
        IDataLoader dataLoader = new FileReader();
        var result = ((FileReader)dataLoader).ReadFile("testDoc.txt");
        Assert.Equal(3, result.Length);
        Assert.Equal(new []{"hello", "world", "!"}, result);
    }
}