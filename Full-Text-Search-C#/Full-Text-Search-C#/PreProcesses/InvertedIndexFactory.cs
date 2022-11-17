using Full_Text_Search_C_.Abstractions;
using Full_Text_Search_C_.Models;

namespace Full_Text_Search_C_.PreProcesses;

public class InvertedIndexFactory
{
    private readonly InvertedIndex _invertedIndex = new();
    private readonly IFileReader _dataLoader;

    public InvertedIndexFactory(IFileReader dataLoader)
    {
        _dataLoader = dataLoader;
    }

    public InvertedIndex CreateInvertedIndex(string folderPath)
    {
        ReadTermsFromFile(_dataLoader.ReadFilesInDirectory(folderPath));
        return _invertedIndex;
    }

    private void ReadTermsFromFile(IEnumerable<string> files)
    {
        var counter = 1;
        foreach (var file in files)
        {
            InsertTermsToInvertedIndex(_dataLoader.ReadFile(file), counter++);
        }
    }

    private void InsertTermsToInvertedIndex(string[] terms, int docId)
    {
        foreach (var term in terms)
        {
            _invertedIndex.Add(term, docId);
        }
    }
}