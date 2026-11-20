namespace SunamoFileExtensions.Attributes;

/// <summary>
/// Represents the type of extension attribute type.
/// </summary>
public class TypeOfExtensionAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the type of extension attribute class.
    /// </summary>
    /// <param name="typeOfExtension">The type of extension.</param>
    public TypeOfExtensionAttribute(TypeOfExtension typeOfExtension)
    {
        Type = typeOfExtension;
    }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public TypeOfExtension Type { get; set; }
}
