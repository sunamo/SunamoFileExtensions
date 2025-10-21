// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoFileExtensions._sunamo;

//namespace SunamoFileExtensions._sunamo.SunamoExceptions._AddedToAllCsproj;
internal class FS
{
    /// <summary>
    /// files as .bowerrc return whole
    /// </summary>
    /// <param name="so"></param>
    /// <param name="folders"></param>
    internal static List<string> AllExtensionsInFolders(List<string> filesFull, GetExtensionArgsFileExtensions gea = null)
    {
        List<string> vr = new List<string>();
#if DEBUG
        //var dx = filesFull.IndexOf(".babelrc");
#endif
        var files = new List<string>(OnlyExtensionsToLower(filesFull, gea));
#if DEBUG
        //var dxs = CA.IndexesWithValue(files, "");
        //List<string> c = CA.GetIndexes(filesFull, dxs);
        //ClipboardHelper.SetLines(c);
        //var dx2 = files.IndexOf(".babelrc");
#endif
        foreach (var item in files)
        {
            if (!vr.Contains(item))
            {
                vr.Add(item);
            }
        }
        return vr;
    }
    internal static List<string> OnlyExtensionsToLower(List<string> cesta, GetExtensionArgsFileExtensions a = null)
    {
        if (a == null)
        {
            a = new GetExtensionArgsFileExtensions();
        }
        a.returnOriginalCase = false;
        List<string> vr = new List<string>(cesta.Count);
        //CA.InitFillWith(vr, cesta.Count);
        for (int i = 0; i < vr.Count; i++)
        {
            vr[i] = Path.GetExtension(cesta[i]).ToLower();
        }
        return vr;
    }
}