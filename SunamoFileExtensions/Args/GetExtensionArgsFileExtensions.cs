namespace SunamoFileExtensions.Args;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// Arguments for getting file extensions
/// </summary>
public class GetExtensionArgsFileExtensions
{
    /// <summary>
    /// If true, returns the extension in its original case; otherwise, converts to lowercase
    /// </summary>
    public bool returnOriginalCase = false;

    /// <summary>
    /// If true, files without extensions are returned as-is; otherwise, processed differently
    /// </summary>
    public bool filesWoExtReturnAsIs = false;
}