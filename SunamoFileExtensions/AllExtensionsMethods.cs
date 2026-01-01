namespace SunamoFileExtensions;

/// <summary>
/// Provides methods for working with AllExtensions constants
/// </summary>
public class AllExtensionsMethods
{
    /// <summary>
    /// Gets all constant fields from the AllExtensions class
    /// </summary>
    /// <returns>List of FieldInfo objects representing extension constants</returns>
    public static List<FieldInfo> GetConsts()
    {
        return typeof(AllExtensions).GetFields().Where(field => field.IsStatic && field.IsLiteral).ToList();
    }
}
