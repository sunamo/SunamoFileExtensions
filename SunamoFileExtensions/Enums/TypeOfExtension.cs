namespace SunamoFileExtensions.Enums;

public enum TypeOfExtension
{
    archive,
    image,
    source_code,
    documentText,
    documentBinary,
    database,
    // Verified that all extensions in AllExtension are textual.
    configText,
    // Can't name data because is difficult to search (exists also database)
    contentText,
    contentBinary,
    // Verified that all extensions in AllExtension are textual.
    settingsText,
    // Verified that all extensions in AllExtension are textual.
    visual_studioText,
    executable,
    binary,
    // For resources, it probably wouldn't matter if they were encoded in base64,
    // but to be safe, they are all classified as binary to avoid potential damage.
    resource,
    // Verified that all extensions in AllExtension are textual.
    script,
    font,
    multimedia,
    temporary,
    // Used when extension isn't known. For other files, display their description from Windows.
    other
}
