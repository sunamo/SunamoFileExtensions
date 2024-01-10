namespace SunamoFileExtensions;

/// < summary >
/// Only in SunExc
/// </ summary >
public class AllExtensionsHelperWithoutDot
{
    static Dictionary<string, TypeOfExtension> _allExtensionsWithoutDot = null;

    public static Dictionary<string, TypeOfExtension> allExtensionsWithoutDot { get { return _allExtensionsWithoutDot; } }

    public static void Initialize()
    {
        var exts = AllExtensionsMethods.GetConsts();
        Initialize(exts);
    }

    public static void Initialize(List<FieldInfo> exts)
    {
        if (allExtensionsWithoutDot == null || allExtensionsWithoutDot.Count == 0)
        {
            _allExtensionsWithoutDot = new Dictionary<string, TypeOfExtension>();

            AllExtensions ae = new AllExtensions();
            foreach (var item in exts)
            {
                string extWithDot = item.GetValue(ae).ToString();
                string extWithoutDot = extWithDot.Substring(1);
                var v1 = item.CustomAttributes.First();
                TypeOfExtension toe = (TypeOfExtension)v1.ConstructorArguments.First().Value;
                allExtensionsWithoutDot.Add(extWithoutDot, toe);
            }
        }
    }
}
