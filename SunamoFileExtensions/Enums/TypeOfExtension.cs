namespace SunamoFileExtensions.Enums;

/// <summary>
/// Represents the type of extension type.
/// </summary>
public enum TypeOfExtension
{
    /// <summary>
    /// The archive value.
    /// </summary>
    archive,
    /// <summary>
    /// The image value.
    /// </summary>
    image,
    /// <summary>
    /// The source code value.
    /// </summary>
    source_code,
    /// <summary>
    /// The document text value.
    /// </summary>
    documentText,
    /// <summary>
    /// The document binary value.
    /// </summary>
    documentBinary,
    /// <summary>
    /// The database value.
    /// </summary>
    database,
    // Verified that all extensions in AllExtension are textual.
    /// <summary>
    /// The config text value.
    /// </summary>
    configText,
    // Can't name data because is difficult to search (exists also database)
    /// <summary>
    /// The content text value.
    /// </summary>
    contentText,
    /// <summary>
    /// The content binary value.
    /// </summary>
    contentBinary,
    // Verified that all extensions in AllExtension are textual.
    /// <summary>
    /// The settings text value.
    /// </summary>
    settingsText,
    // Verified that all extensions in AllExtension are textual.
    /// <summary>
    /// The visual studio text value.
    /// </summary>
    visual_studioText,
    /// <summary>
    /// The executable value.
    /// </summary>
    executable,
    /// <summary>
    /// The binary value.
    /// </summary>
    binary,
    // For resources, it probably wouldn't matter if they were encoded in base64,
    // but to be safe, they are all classified as binary to avoid potential damage.
    /// <summary>
    /// The resource value.
    /// </summary>
    resource,
    // Verified that all extensions in AllExtension are textual.
    /// <summary>
    /// The script value.
    /// </summary>
    script,
    /// <summary>
    /// The font value.
    /// </summary>
    font,
    /// <summary>
    /// The multimedia value.
    /// </summary>
    multimedia,
    /// <summary>
    /// The temporary value.
    /// </summary>
    temporary,
    // Used when extension isn't known. For other files, display their description from Windows.
    /// <summary>
    /// The other value.
    /// </summary>
    other
}
