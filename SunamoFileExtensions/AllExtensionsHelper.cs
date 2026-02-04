namespace SunamoFileExtensions;

/// <summary>
/// Helper class for working with file extensions and their types
/// </summary>
public class AllExtensionsHelper
{
    /// <summary>
    /// Dictionary of extensions grouped by type (with dot)
    /// </summary>
    public static Dictionary<TypeOfExtension, List<string>>? ExtensionsByType { get; set; }

    /// <summary>
    /// Dictionary of extensions grouped by type (without dot)
    /// </summary>
    public static Dictionary<TypeOfExtension, List<string>>? ExtensionsByTypeWithoutDot { get; set; }

    /// <summary>
    /// Determines whether the specified extension type is binary or text
    /// Returns true if binary, false if text
    /// Throws exception if TypeOfExtension.other is passed
    /// </summary>
    /// <param name="typeOfExtension">The type of extension to check</param>
    /// <returns>True if binary, false if text</returns>
    /// <exception cref="Exception">Thrown when TypeOfExtension.other is passed</exception>
    public static bool IsBinaryOrText(TypeOfExtension typeOfExtension)
    {
        if (typeOfExtension == TypeOfExtension.other)
        {
            throw new Exception("Was passed TypeOfExtension.other");
        }

        switch (typeOfExtension)
        {
            case TypeOfExtension.source_code:
            case TypeOfExtension.documentText:
            case TypeOfExtension.configText:
            case TypeOfExtension.contentText:
            case TypeOfExtension.settingsText:
            case TypeOfExtension.visual_studioText:
            case TypeOfExtension.script:
                return false;
            case TypeOfExtension.archive:
            case TypeOfExtension.image:
            case TypeOfExtension.documentBinary:
            case TypeOfExtension.database:
            case TypeOfExtension.resource:
            case TypeOfExtension.font:
            case TypeOfExtension.multimedia:
            case TypeOfExtension.temporary:
            case TypeOfExtension.executable:
            case TypeOfExtension.binary:
            case TypeOfExtension.contentBinary:
                return true;
            default:
                ThrowEx.NotImplementedCase(typeOfExtension);
                break;
        }

        return true;
    }

    /// <summary>
    /// Gets all extensions in the specified files grouped by category
    /// </summary>
    /// <param name="files">List of file paths</param>
    /// <param name="args">Optional arguments for extension extraction</param>
    /// <returns>Dictionary of extensions grouped by type</returns>
    public static Dictionary<TypeOfExtension, List<string>> AllExtensionsInFolderByCategory(List<string> files,
        GetExtensionArgsFileExtensions? args = null)
    {
        Initialize(true);

        var extensions = FS.AllExtensionsInFolders(files, args);

        var dict = new Dictionary<TypeOfExtension, List<string>>();

        foreach (var item in extensions)
        {
            var type = FindTypeWithDot(item);
            DictionaryHelper.AddOrCreate(dict, type, item);
        }

        return dict;
    }

    /// <summary>
    /// Initializes the extension dictionaries
    /// </summary>
    /// <param name="isCallingAllExtensionsHelperWithoutDotInitialize">If true, also initializes AllExtensionsHelperWithoutDot</param>
    public static void Initialize(bool isCallingAllExtensionsHelperWithoutDotInitialize)
    {
        if (isCallingAllExtensionsHelperWithoutDotInitialize) AllExtensionsHelperWithoutDot.Initialize();
        Initialize();
    }

    /// <summary>
    /// Initializes the extension dictionaries by reading all extension constants
    /// </summary>
    public static void Initialize()
    {
        if (ExtensionsByType == null)
        {
            ExtensionsByType = new Dictionary<TypeOfExtension, List<string>>();
            ExtensionsByTypeWithoutDot = new Dictionary<TypeOfExtension, List<string>>();
            var allExtensions = new AllExtensions();
            var extensionFields = AllExtensionsMethods.GetConsts();
            foreach (var item in extensionFields)
            {
                var extWithDot = item.GetValue(allExtensions)!.ToString()!;
                var extWithoutDot = extWithDot.Substring(1);
                var attribute = item.CustomAttributes.First();
                var typeOfExtension = (TypeOfExtension)attribute.ConstructorArguments.First().Value!;

                if (!ExtensionsByType.ContainsKey(typeOfExtension))
                {
                    var extensions = new List<string>();
                    extensions.Add(extWithDot);
                    ExtensionsByType.Add(typeOfExtension, extensions);
                    var extensionsWithoutDot = new List<string>();
                    extensionsWithoutDot.Add(extWithoutDot);
                    ExtensionsByTypeWithoutDot.Add(typeOfExtension, extensionsWithoutDot);
                }
                else
                {
                    ExtensionsByType[typeOfExtension].Add(extWithDot);
                    ExtensionsByTypeWithoutDot[typeOfExtension].Add(extWithoutDot);
                }
            }
        }
    }

    /// <summary>
    /// Finds the type of extension for the specified extension without dot
    /// Returns TypeOfExtension.other if not found
    /// </summary>
    /// <param name="extension">The extension without dot</param>
    /// <returns>The type of the extension</returns>
    public static TypeOfExtension FindTypeWithoutDot(string extension)
    {
        if (extension != "" && AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot != null)
            if (AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot.ContainsKey(extension))
                return AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot[extension];
        return TypeOfExtension.other;
    }

    /// <summary>
    /// Normalizes the extension by converting to lowercase and trimming the dot
    /// </summary>
    /// <param name="item">The extension to normalize</param>
    /// <returns>The normalized extension</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NormalizeExtension2(string item)
    {
        return item.ToLower().TrimStart('.');
    }

    /// <summary>
    /// Checks if the specified file has a known extension
    /// </summary>
    /// <param name="filePath">The file path to check</param>
    /// <returns>True if the file has a known extension, false otherwise</returns>
    public static bool IsFileHasKnownExtension(string filePath)
    {
        Initialize(true);

        var ext = Path.GetExtension(filePath);
        ext = NormalizeExtension2(ext);

        return AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot?.ContainsKey(ext) ?? false;
    }

    /// <summary>
    /// Checks if the specified extension is contained in the known extensions
    /// Extension can be with or without dot
    /// </summary>
    /// <param name="extension">The extension to check</param>
    /// <returns>True if the extension is known, false otherwise</returns>
    public static bool IsContained(string extension)
    {
        extension = extension.TrimStart('.');
        return AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot?.ContainsKey(extension) ?? false;
    }

    /// <summary>
    /// Finds the type of extension for the specified extension with dot
    /// Returns TypeOfExtension.other if not found
    /// </summary>
    /// <param name="extension">The extension with dot</param>
    /// <returns>The type of the extension</returns>
    public static TypeOfExtension FindTypeWithDot(string extension)
    {
        if (extension != "" && AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot != null)
        {
            extension = extension.Substring(1);
#if DEBUG
            if (extension.EndsWith("js"))
            {
            }
#endif
            if (AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot.ContainsKey(extension))
                return AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot[extension];
        }
#if DEBUG
        else
        {
            Debugger.Break();
        }
#endif
        return TypeOfExtension.other;
    }
}