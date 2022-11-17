using Full_Text_Search_C_.Abstractions;
using Full_Text_Search_C_.Models;

namespace Full_Text_Search_C_.PreProcesses;

public class InvertedIndexFactory
{
    private readonly InvertedIndex _invertedIndex = new();
    private readonly IDataLoader _dataLoader;

    public InvertedIndexFactory(IDataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }

    public InvertedIndex CreateInvertedIndex(string folderPath)
    {
        ReadTermsFromFile(((FileReader)_dataLoader).ReadFilesInDirectory(folderPath));
        return _invertedIndex;
    }

    private void ReadTermsFromFile(IEnumerable<string> files)
    {
        var counter = 1;
        foreach (var file in files)
        {
            InsertTermsToInvertedIndex(_dataLoader.LoadData(file), counter++);
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