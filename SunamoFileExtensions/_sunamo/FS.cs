namespace SunamoFileExtensions._sunamo;

/// <summary>
/// File system utility methods for working with file extensions
/// </summary>
internal class FS
{
    /// <summary>
    /// Gets all unique file extensions from a list of file paths
    /// Files like .bowerrc return whole name as extension
    /// </summary>
    /// <param name="paths">List of full file paths</param>
    /// <param name="args">Optional arguments for extension extraction</param>
    /// <returns>List of unique file extensions</returns>
    internal static List<string> AllExtensionsInFolders(List<string> paths, GetExtensionArgsFileExtensions? args = null)
    {
        List<string> result = new List<string>();
#if DEBUG
        //var dx = filesFull.IndexOf(".babelrc");
#endif
        var files = new List<string>(OnlyExtensionsToLower(paths, args));
#if DEBUG
        //var dxs = CA.IndexesWithValue(files, "");
        //List<string> c = CA.GetIndexes(filesFull, dxs);
        //ClipboardHelper.SetLines(c);
        //var dx2 = files.IndexOf(".babelrc");
#endif
        foreach (var item in files)
        {
            if (!result.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    /// <summary>
    /// Extracts extensions from file paths and converts them to lowercase
    /// </summary>
    /// <param name="paths">List of file paths</param>
    /// <param name="args">Optional arguments for extension extraction</param>
    /// <returns>List of lowercase file extensions</returns>
    internal static List<string> OnlyExtensionsToLower(List<string> paths, GetExtensionArgsFileExtensions? args = null)
    {
        if (args == null)
        {
            args = new GetExtensionArgsFileExtensions();
        }
        args.ReturnOriginalCase = false;
        List<string> result = new List<string>();
        for (int i = 0; i < paths.Count; i++)
        {
            result.Add(Path.GetExtension(paths[i]).ToLower());
        }
        return result;
    }
}