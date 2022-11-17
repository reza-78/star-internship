using Full_Text_Search_C_.Abstractions;
using Full_Text_Search_C_.PreProcesses;
using Full_Text_Search_C_.Test.Abstractions;

namespace Full_Text_Search_C_.Test.PreProcesses;

public class FileReaderTest:IDataLoaderTest
{
    public void LoadDataTest()
    {
        IDataLoader dataLoader = new FileReader();
        var result = dataLoader.LoadData("testDoc.txt");
        Assert.Equal(3, result.Length);
        Assert.Equal(new []{"hello", "world", "!"}, result);
    }
}