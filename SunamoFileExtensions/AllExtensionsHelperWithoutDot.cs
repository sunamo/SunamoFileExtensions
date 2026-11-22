namespace SunamoFileExtensions;

// Only used in SunExc
/// <summary>
/// Represents the all extensions helper without dot type.
/// </summary>
public class AllExtensionsHelperWithoutDot
{
    /// <summary>
    /// Gets or sets the all extensions without dot.
    /// </summary>
    public static Dictionary<string, TypeOfExtension>? AllExtensionsWithoutDot { get; private set; }

    /// <summary>
    /// Initialize.
    /// </summary>
    /// <returns>The initialize result.</returns>
    public static void Initialize()
    {
        var extensionFields = AllExtensionsMethods.GetConsts();
        Initialize(extensionFields);
    }

    /// <summary>
    /// Initializes a new instance of the initialize class.
    /// </summary>
    /// <param name="extensionFields">The extension fields.</param>
    public static void Initialize(List<FieldInfo> extensionFields)
    {
        if (AllExtensionsWithoutDot == null || AllExtensionsWithoutDot.Count == 0)
        {
            AllExtensionsWithoutDot = new Dictionary<string, TypeOfExtension>();
            var allExtensions = new AllExtensions();
            foreach (var item in extensionFields)
            {
                var extWithDot = item.GetValue(allExtensions)!.ToString()!;
                var extWithoutDot = extWithDot.Substring(1);
                var attribute = item.CustomAttributes.First();
                var typeOfExtension = (TypeOfExtension)attribute.ConstructorArguments.First().Value!;
                AllExtensionsWithoutDot.Add(extWithoutDot, typeOfExtension);
            }
        }
    }
}
