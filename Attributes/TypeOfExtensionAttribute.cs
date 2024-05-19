namespace
#if SunamoDevCode
SunamoDevCode
#else
SunamoFileExtensions
#endif
;

public class TypeOfExtensionAttribute : Attribute
{
    public TypeOfExtension Type { get; set; }

    public TypeOfExtensionAttribute(TypeOfExtension toe)
    {
        Type = toe;
    }
}
