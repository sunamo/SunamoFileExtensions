namespace SunamoFileExtensions.Args;

/// <summary>
/// Arguments for getting file extensions
/// </summary>
public class GetExtensionArgsFileExtensions
{
    /// <summary>
    /// If true, returns the extension in its original case; otherwise, converts to lowercase
    /// </summary>
    public bool ReturnOriginalCase { get; set; } = false;

    /// <summary>
    /// If true, files without extensions are returned as-is; otherwise, processed differently
    /// </summary>
    public bool FilesWithoutExtensionReturnAsIs { get; set; } = false;
}