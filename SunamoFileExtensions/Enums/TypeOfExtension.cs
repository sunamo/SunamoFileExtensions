// variables names: ok
namespace SunamoFileExtensions.Enums;

/// <summary>
/// Represents the type/category of a file extension
/// </summary>
public enum TypeOfExtension
{
    /// <summary>
    /// Archive files (zip, rar, 7z, etc.)
    /// </summary>
    archive,

    /// <summary>
    /// Image files (png, jpg, gif, etc.)
    /// </summary>
    image,

    /// <summary>
    /// Source code files (cs, js, html, etc.)
    /// </summary>
    source_code,

    /// <summary>
    /// Text document files (txt, md, rtf, etc.)
    /// </summary>
    documentText,

    /// <summary>
    /// Binary document files (pdf, etc.)
    /// </summary>
    documentBinary,

    /// <summary>
    /// Database files (db, etc.)
    /// </summary>
    database,

    /// <summary>
    /// Configuration text files. Verified that all extensions in AllExtension are textual.
    /// </summary>
    configText,

    /// <summary>
    /// Content text files (XML, JSON, mdf, ldf, sdf, etc.)
    /// Can't name data because is difficult to search (exists also database)
    /// </summary>
    contentText,

    /// <summary>
    /// Binary content files
    /// </summary>
    contentBinary,

    /// <summary>
    /// Settings text files (ini, etc.). Verified that all extensions in AllExtension are textual.
    /// </summary>
    settingsText,

    /// <summary>
    /// Visual Studio text files. Verified that all extensions in AllExtension are textual.
    /// </summary>
    visual_studioText,

    /// <summary>
    /// Executable files (exe, msi, etc.)
    /// </summary>
    executable,

    /// <summary>
    /// Binary files (dll, etc.)
    /// </summary>
    binary,

    /// <summary>
    /// Resource files. For resources, it probably wouldn't matter if they were encoded in base64,
    /// but to be safe, they are all classified as binary to avoid potential damage.
    /// </summary>
    resource,

    /// <summary>
    /// Script files (sql, cmd, ps1, etc.). Verified that all extensions in AllExtension are textual.
    /// </summary>
    script,

    /// <summary>
    /// Font files (ttf, woff, otf, etc.)
    /// </summary>
    font,

    /// <summary>
    /// Multimedia files (audio, video, etc.)
    /// </summary>
    multimedia,

    /// <summary>
    /// Temporary files
    /// </summary>
    temporary,

    /// <summary>
    /// Used when extension isn't known. For other files, display their description from Windows.
    /// </summary>
    other
}
