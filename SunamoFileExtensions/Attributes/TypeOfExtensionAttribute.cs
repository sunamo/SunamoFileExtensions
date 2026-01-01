namespace SunamoFileExtensions.Attributes;

/// <summary>
/// Attribute to specify the type of a file extension
/// </summary>
public class TypeOfExtensionAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the TypeOfExtensionAttribute class
    /// </summary>
    /// <param name="typeOfExtension">The type of the extension</param>
    public TypeOfExtensionAttribute(TypeOfExtension typeOfExtension)
    {
        Type = typeOfExtension;
    }

    /// <summary>
    /// Gets or sets the type of the extension
    /// </summary>
    public TypeOfExtension Type { get; set; }
}
