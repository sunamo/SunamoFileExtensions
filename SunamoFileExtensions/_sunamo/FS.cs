namespace SunamoFileExtensions._sunamo;

internal class FS
{
    // Gets all unique file extensions from a list of file paths
    // Files like .bowerrc return whole name as extension
    internal static List<string> AllExtensionsInFolders(List<string> paths, GetExtensionArgsFileExtensions? args = null)
    {
        List<string> result = new List<string>();
        var files = new List<string>(OnlyExtensionsToLower(paths, args));
        foreach (var item in files)
        {
            if (!result.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    internal static List<string> OnlyExtensionsToLower(List<string> paths, GetExtensionArgsFileExtensions? args = null)
    {
        args ??= new GetExtensionArgsFileExtensions();
        args.ReturnOriginalCase = false;
        List<string> result = new List<string>();
        for (int i = 0; i < paths.Count; i++)
        {
            result.Add(Path.GetExtension(paths[i]).ToLower());
        }
        return result;
    }
}
