namespace SunamoFileExtensions;

/// <summary>
/// Helper class for working with file extensions without dot
/// Only used in SunExc
/// </summary>
public class AllExtensionsHelperWithoutDot
{
    /// <summary>
    /// Dictionary mapping extensions (without dot) to their types
    /// </summary>
    public static Dictionary<string, TypeOfExtension>? allExtensionsWithoutDot { get; private set; }

    /// <summary>
    /// Initializes the extension dictionary by reading all extension constants
    /// </summary>
    public static void Initialize()
    {
        var extensionFields = AllExtensionsMethods.GetConsts();
        Initialize(extensionFields);
    }

    /// <summary>
    /// Initializes the extension dictionary from the specified field list
    /// </summary>
    /// <param name="extensionFields">List of field info objects representing extension constants</param>
    public static void Initialize(List<FieldInfo> extensionFields)
    {
        if (allExtensionsWithoutDot == null || allExtensionsWithoutDot.Count == 0)
        {
            allExtensionsWithoutDot = new Dictionary<string, TypeOfExtension>();
            var allExtensions = new AllExtensions();
            foreach (var item in extensionFields)
            {
                var extWithDot = item.GetValue(allExtensions)!.ToString()!;
                var extWithoutDot = extWithDot.Substring(1);
                var attribute = item.CustomAttributes.First();
                var typeOfExtension = (TypeOfExtension)attribute.ConstructorArguments.First().Value!;
                allExtensionsWithoutDot.Add(extWithoutDot, typeOfExtension);
            }
        }
    }
}
