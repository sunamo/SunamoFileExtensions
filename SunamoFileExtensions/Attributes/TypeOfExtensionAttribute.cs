// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoFileExtensions.Attributes;

public class TypeOfExtensionAttribute : Attribute
{
    public TypeOfExtensionAttribute(TypeOfExtension toe)
    {
        Type = toe;
    }

    public TypeOfExtension Type { get; set; }
}