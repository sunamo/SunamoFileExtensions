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
    ///     prošel jsem zda v AllExtension jsou všechny textové
    /// </summary>
    configText,

    /// <summary>
    ///     XML, JSON, mdf, ldf, sdf, atd.
    ///     Can't name data because is difficult search (exists also database)
    /// </summary>
    contentText,

    /// <summary>
    /// Binary content files
    /// </summary>
    contentBinary,

    /// <summary>
    ///     prošel jsem zda v AllExtension jsou všechny textové
    ///     ini, atd.
    /// </summary>
    settingsText,

    /// <summary>
    ///     prošel jsem zda v AllExtension jsou všechny textové
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
    ///     u resourců by to asi tak nevadilo kdyby byly zakódovany třeba ve b64 ale pro jistotu je všechny řadím do binárních
    ///     ať je nepoškodím
    /// </summary>
    resource,

    /// <summary>
    ///     prošel jsem zda v AllExtension jsou všechny textové
    ///     sql, cmd, ps1,
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
    ///     Is used when extension isn't know
    ///     U ostatních souborů vypsat jejich popis z windows
    /// </summary>
    other
}