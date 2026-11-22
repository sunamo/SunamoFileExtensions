namespace SunamoFileExtensions;

/// <summary>
/// Represents the all extensions methods type.
/// </summary>
public class AllExtensionsMethods
{
    /// <summary>
    /// Get consts.
    /// </summary>
    /// <returns>The get consts result.</returns>
    public static List<FieldInfo> GetConsts()
    {
        return typeof(AllExtensions).GetFields().Where(field => field.IsStatic && field.IsLiteral).ToList();
    }
}
