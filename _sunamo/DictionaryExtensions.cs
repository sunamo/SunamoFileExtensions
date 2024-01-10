namespace SunamoFileExtensions._sunamo;

internal class DictionaryExtensions
{
    /// <summary>
    /// Is stupid use this method, is enough import System.Linq
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    /// <param name="dict"></param>
    internal static List<Key> GetKeys<Key, Value>(Dictionary<Key, Value> dict)
    {
        //return dict.Keys.ToList();
        return dict.Select(d => d.Key).ToList();
    }
}
