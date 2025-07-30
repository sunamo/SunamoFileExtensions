namespace SunamoFileExtensions.Attributes;

public class TypeOfExtensionAttribute : Attribute
{
    public TypeOfExtensionAttribute(TypeOfExtension toe)
    {
        Type = toe;
    }

    public TypeOfExtension Type { get; set; }
}