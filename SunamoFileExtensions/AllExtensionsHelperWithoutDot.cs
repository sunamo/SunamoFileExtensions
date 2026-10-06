namespace SunamoFileExtensions;

// Only used in SunExc
public class AllExtensionsHelperWithoutDot
{
    public static Dictionary<string, TypeOfExtension>? AllExtensionsWithoutDot { get; private set; }

    public static void Initialize()
    {
        var extensionFields = AllExtensionsMethods.GetConsts();
        Initialize(extensionFields);
    }

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
