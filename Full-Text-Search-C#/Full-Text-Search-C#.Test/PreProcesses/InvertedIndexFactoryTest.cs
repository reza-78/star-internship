using Full_Text_Search_C_.Abstractions;
using Full_Text_Search_C_.PreProcesses;
using NSubstitute;

namespace Full_Text_Search_C_.Test.PreProcesses;

public class InvertedIndexFactoryTest
{
    // [Fact]
    // public void CreateInvertedIndex_SimpleValues_Created_Test()
    // {
    //     var dataLoader = Substitute.For<FileReader>();
    //     dataLoader.ReadFilesInDirectory(Arg.Any<string>())
    //         .Returns(new List<string>() {""});
    //     dataLoader.LoadData("").Returns(new []{"hello", "world"});
    //     var invertedIndexFactory = new InvertedIndexFactory(dataLoader);
    //     var result = invertedIndexFactory.CreateInvertedIndex("");
    //     
    //     Assert.Equal(new HashSet<int>(){1}, result.Get("hello"));
    //     Assert.Equal(new HashSet<int>(){1}, result.Get("world"));
    // }
}