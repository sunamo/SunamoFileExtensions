namespace SunamoFileExtensions.Attributes;

public class TypeOfExtensionAttribute : Attribute
{
    public TypeOfExtensionAttribute(TypeOfExtension typeOfExtension)
    {
        Type = typeOfExtension;
    }

    public TypeOfExtension Type { get; set; }
}
