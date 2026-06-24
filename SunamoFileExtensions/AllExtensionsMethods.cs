namespace SunamoFileExtensions;

public class AllExtensionsMethods
{
    public static List<FieldInfo> GetConsts()
    {
        return typeof(AllExtensions).GetFields().Where(field => field.IsStatic && field.IsLiteral).ToList();
    }
}
