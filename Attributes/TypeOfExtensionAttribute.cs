namespace
#if SunamoDevCode
SunamoDevCode
#elif SunamoHttp
SunamoHttp
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