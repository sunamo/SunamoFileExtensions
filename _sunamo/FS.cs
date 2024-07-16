
namespace SunamoFileExtensions._sunamo;
using SunamoFileExtensions.Args;

//namespace SunamoFileExtensions._sunamo.SunamoExceptions._AddedToAllCsproj;
internal class FS
{


    /// <summary>
    /// files as .bowerrc return whole
    /// </summary>
    /// <param name="so"></param>
    /// <param name="folders"></param>
    public static List<string> AllExtensionsInFolders(List<string> filesFull, GetExtensionArgsFileExtensions gea = null)
    {
        List<string> vr = new List<string>();


#if DEBUG

        //var dx = filesFull.IndexOf(".babelrc");
#endif
        var files = new List<string>(OnlyExtensionsToLower(filesFull, gea));

#if DEBUG
        //var dxs = CA.IndexesWithValue(files, Consts.se);

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

    public static List<string> OnlyExtensionsToLower(List<string> cesta, GetExtensionArgsFileExtensions a = null)
    {
        if (a == null)
        {
            a = new GetExtensionArgsFileExtensions();
        }

        a.returnOriginalCase = false;

        List<string> vr = new List<string>(cesta.Count);
        CA.InitFillWith(vr, cesta.Count);
        for (int i = 0; i < vr.Count; i++)
        {
            vr[i] = Path.GetExtension(cesta[i]).ToLower();
        }
        return vr;
    }

    internal static void CreateUpfoldersPsysicallyUnlessThere(string nad)
    {
        CreateFoldersPsysicallyUnlessThere(Path.GetDirectoryName(nad));
    }
    internal static void CreateFoldersPsysicallyUnlessThere(string nad)
    {
        ThrowEx.IsNullOrEmpty("nad", nad);
        ThrowEx.IsNotWindowsPathFormat("nad", nad);
        if (Directory.Exists(nad))
        {
            return;
        }
        List<string> slozkyKVytvoreni = new List<string>
{
nad
};
        while (true)
        {
            nad = Path.GetDirectoryName(nad);

            if (Directory.Exists(nad))
            {
                break;
            }
            string kopia = nad;
            slozkyKVytvoreni.Add(kopia);
        }
        slozkyKVytvoreni.Reverse();
        foreach (string item in slozkyKVytvoreni)
        {
            string folder = item;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}