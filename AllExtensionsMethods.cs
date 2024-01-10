namespace SunamoFileExtensions;

public class AllExtensionsMethods
{
    public static List<FieldInfo> GetConsts()
    {
        return (typeof(AllExtensions).GetFields().Where(x => x.IsStatic && x.IsLiteral)).ToList();
    }
}
