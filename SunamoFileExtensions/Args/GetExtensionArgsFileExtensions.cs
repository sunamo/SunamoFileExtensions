namespace SunamoFileExtensions.Args;

/// <summary>
/// Represents the get extension args file extensions type.
/// </summary>
public class GetExtensionArgsFileExtensions
{
    /// <summary>
    /// Gets or sets the return original case.
    /// </summary>
    public bool ReturnOriginalCase { get; set; } = false;
    /// <summary>
    /// Gets or sets the files without extension return as is.
    /// </summary>
    public bool FilesWithoutExtensionReturnAsIs { get; set; } = false;
}
