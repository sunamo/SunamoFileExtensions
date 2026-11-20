namespace SunamoFileExtensions._public;

/// <summary>
/// Represents the FS file extensions type.
/// </summary>
public class FSFileExtensions
{
    /// <summary>
    /// Is extension.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is extension result.</returns>
    public static bool IsExtension(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }
        if (!text.TrimStart('.').ToLower().All(c => char.IsLetter(c) && char.IsLower(c) || char.IsDigit(c)))
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Get extension.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="args">The args.</param>
    /// <returns>The get extension result.</returns>
    public static string GetExtension(string path, GetExtensionArgsFileExtensions? args = null)
    {
        args ??= new GetExtensionArgsFileExtensions();
        string result = "";
        int lastDot = path.LastIndexOf('.');
        if (lastDot == -1)
        {
            return string.Empty;
        }
        int lastSlash = path.LastIndexOf('/');
        int lastBackslash = path.LastIndexOf('\\');
        if (lastSlash > lastDot)
        {
            return string.Empty;
        }
        if (lastBackslash > lastDot)
        {
            return string.Empty;
        }
        result = path.Substring(lastDot);
        if (!IsExtension(result))
        {
            if (args.FilesWithoutExtensionReturnAsIs)
            {
                return result;
            }
            return string.Empty;
        }
        if (!args.ReturnOriginalCase)
        {
            result = result.ToLower();
        }
        return result;
    }
}
