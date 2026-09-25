namespace SunamoFileExtensions;

public class AllExtensionsHelper
{
    // Dictionary of extensions grouped by type (with dot)
    public static Dictionary<TypeOfExtension, List<string>>? ExtensionsByType { get; set; }

    // Dictionary of extensions grouped by type (without dot)
    public static Dictionary<TypeOfExtension, List<string>>? ExtensionsByTypeWithoutDot { get; set; }

    // Returns true if binary, false if text. Throws if TypeOfExtension.other is passed.
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

    public static void Initialize(bool isCallingAllExtensionsHelperWithoutDotInitialize)
    {
        if (isCallingAllExtensionsHelperWithoutDotInitialize) AllExtensionsHelperWithoutDot.Initialize();
        Initialize();
    }

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

    // Returns TypeOfExtension.other if not found
    public static TypeOfExtension FindTypeWithoutDot(string extension)
    {
        if (extension != "" && AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot != null)
            if (AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot.ContainsKey(extension))
                return AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot[extension];
        return TypeOfExtension.other;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NormalizeExtension2(string item) => item.ToLower().TrimStart('.');

    public static bool IsFileHasKnownExtension(string filePath)
    {
        Initialize(true);

        var ext = Path.GetExtension(filePath);
        ext = NormalizeExtension2(ext);

        return AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot?.ContainsKey(ext) ?? false;
    }

    // Extension can be with or without dot
    public static bool IsContained(string extension)
    {
        extension = extension.TrimStart('.');
        return AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot?.ContainsKey(extension) ?? false;
    }

    // Returns TypeOfExtension.other if not found
    public static TypeOfExtension FindTypeWithDot(string extension)
    {
        if (extension != "" && AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot != null)
        {
            extension = extension.Substring(1);
            if (AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot.ContainsKey(extension))
                return AllExtensionsHelperWithoutDot.AllExtensionsWithoutDot[extension];
        }
        return TypeOfExtension.other;
    }
}
