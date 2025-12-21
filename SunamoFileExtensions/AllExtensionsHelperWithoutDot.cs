namespace SunamoFileExtensions;

/// < summary>
///     Only in SunExc
/// </summary>
public class AllExtensionsHelperWithoutDot
{
    public static Dictionary<string, TypeOfExtension> allExtensionsWithoutDot { get; private set; }

    public static void Initialize()
    {
        var exts = AllExtensionsMethods.GetConsts();
        Initialize(exts);
    }

    public static void Initialize(List<FieldInfo> exts)
    {
        if (allExtensionsWithoutDot == null || allExtensionsWithoutDot.Count == 0)
        {
            allExtensionsWithoutDot = new Dictionary<string, TypeOfExtension>();
            var ae = new AllExtensions();
            foreach (var item in exts)
            {
                var extWithDot = item.GetValue(ae).ToString();
                var extWithoutDot = extWithDot.Substring(1);
                var v1 = item.CustomAttributes.First();
                var toe = (TypeOfExtension)v1.ConstructorArguments.First().Value;
                allExtensionsWithoutDot.Add(extWithoutDot, toe);
            }
        }
    }
}