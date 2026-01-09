namespace SunamoFileExtensions._public;

/// <summary>
/// Provides file extension-related utility methods
/// </summary>
public class FSFileExtensions
{
    /// <summary>
    /// Determines whether the specified string is a valid file extension
    /// </summary>
    /// <param name="result">The string to check</param>
    /// <returns>True if the string is a valid extension, false otherwise</returns>
    public static bool IsExtension(string result)
    {
        if (string.IsNullOrWhiteSpace(result))
        {
            return false;
        }
        if (!result.TrimStart('.').ToLower().All(c => char.IsLetter(c) && char.IsLower(c) || char.IsDigit(c)))
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Gets the extension from the specified file path
    /// </summary>
    /// <param name="path">The file path to extract extension from</param>
    /// <param name="args">Optional arguments for extension extraction</param>
    /// <returns>The file extension, or empty string if not found</returns>
    public static string GetExtension(string path, GetExtensionArgsFileExtensions? args = null)
    {
        if (args == null)
        {
            args = new GetExtensionArgsFileExtensions();
        }
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