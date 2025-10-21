// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoFileExtensions;

public class AllExtensionsMethods
{
    public static List<FieldInfo> GetConsts()
    {
        return typeof(AllExtensions).GetFields().Where(x => x.IsStatic && x.IsLiteral).ToList();
    }
}