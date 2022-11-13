using Newtonsoft.Json;

namespace phase3.util;

public class FileReader
{
    internal static List<TData>? ReadFile<TData>(string fileName)
    {
        using var r = new StreamReader(fileName);
        var json = r.ReadToEnd();
        return JsonConvert.DeserializeObject<List<TData>>(json);
    }
}