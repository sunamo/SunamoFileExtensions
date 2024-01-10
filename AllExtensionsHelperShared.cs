namespace SunamoFileExtensions;



public partial class AllExtensionsHelper
{
    /// <summary>
    /// With dot
    /// </summary>
    public static Dictionary<TypeOfExtension, List<string>> extensionsByType = null;
    /// <summary>
    /// With dot
    /// </summary>
    //public static Dictionary<string, TypeOfExtension> allExtensions = new Dictionary<string, TypeOfExtension>();
    public static Dictionary<TypeOfExtension, List<string>> extensionsByTypeWithoutDot = null;

    /// <summary>
    /// Return true if is binary
    /// If will pass other, throw ex
    /// </summary>
    /// <returns></returns>
    public static bool IsBinaryOrText(TypeOfExtension e)
    {
        if (e == TypeOfExtension.other)
        {
            ThrowEx.Custom("Was passed TypeOfExtension.other");
            return true;
        }

        switch (e)
        {
            case TypeOfExtension.source_code:
            case TypeOfExtension.documentText:
            case TypeOfExtension.configText:
            case TypeOfExtension.contentText:
            case TypeOfExtension.settingsText:
            case TypeOfExtension.visual_studioText:
            case TypeOfExtension.script:
                return false;
            case TypeOfExtension.archive:
            case TypeOfExtension.image:
            case TypeOfExtension.documentBinary:
            case TypeOfExtension.database:
            case TypeOfExtension.resource:
            case TypeOfExtension.font:
            case TypeOfExtension.multimedia:
            case TypeOfExtension.temporary:
            case TypeOfExtension.executable:
            case TypeOfExtension.binary:
            case TypeOfExtension.contentBinary:
                return true;
            default:
                ThrowEx.NotImplementedCase(e);
                break;
        }

        return true;
    }

    // Proč to volám zde? Má se to volat v aplikacích kde to potřebuji
    //static AllExtensionsHelper()
    //{
    //    // Must call Initialize here, not in Loaded of Window. when I run auto code in debug, it wont be initialized as is needed.
    //    Initialize();
    //}

    /// <summary>
    /// Never = false, I often forgot = true => long time to find where is error
    /// </summary>
    /// <param name="a"></param>
    public static void Initialize(bool callAlsoAllExtensionsHelperWithoutDotInitialize)
    {
        if (callAlsoAllExtensionsHelperWithoutDotInitialize)
        {
            AllExtensionsHelperWithoutDot.Initialize();
        }
        // Must call Initialize here, not in Loaded of Window. when I run auto code in debug, it wont be initialized as is needed.
        Initialize();
    }



    public static void Initialize()
    {
        //bool loadAllExtensionsWithoutDot = allExtensionsWithoutDot != null;

        if (extensionsByType == null)
        {
            extensionsByType = new Dictionary<TypeOfExtension, List<string>>();
            extensionsByTypeWithoutDot = new Dictionary<TypeOfExtension, List<string>>();
            //allExtensionsWithoutDot = new Dictionary<string, TypeOfExtension>();

            AllExtensions ae = new AllExtensions();
            var exts = AllExtensionsMethods.GetConsts();
            foreach (var item in exts)
            {
                string extWithDot = item.GetValue(ae).ToString();
                string extWithoutDot = extWithDot.Substring(1);
                var v1 = item.CustomAttributes.First();
                TypeOfExtension toe = (TypeOfExtension)v1.ConstructorArguments.First().Value;

                //if (loadAllExtensionsWithoutDot)
                //{
                //    allExtensionsWithoutDot.Add(extWithoutDot, (TypeOfExtension)toe);
                //}


                if (!extensionsByType.ContainsKey(toe))
                {
                    List<string> extensions = new List<string>();
                    extensions.Add(extWithDot);
                    extensionsByType.Add(toe, extensions);
                    List<string> extensionsWithoutDot = new List<string>();
                    extensionsWithoutDot.Add(extWithoutDot);
                    extensionsByTypeWithoutDot.Add(toe, extensionsWithoutDot);

                }
                else
                {
                    extensionsByType[toe].Add(extWithDot);
                    extensionsByTypeWithoutDot[toe].Add(extWithoutDot);
                }
            }
        }
    }

    /// <summary>
    /// When can't be found, return other
    /// Default was WithDot
    /// </summary>
    /// <param name = "p"></param>
    public static TypeOfExtension FindTypeWithoutDot(string p)
    {
        if (p != "")
        {
            if (AllExtensionsHelperWithoutDot.allExtensionsWithoutDot.ContainsKey(p))
            {
                return (TypeOfExtension)AllExtensionsHelperWithoutDot.allExtensionsWithoutDot[p];
            }
        }

        return TypeOfExtension.other;
    }

    /// <summary>
    /// A1 can be with or without dot
    /// </summary>
    /// <param name="ext"></param>
    public static bool IsContained(string p)
    {
        p = p.TrimStart('.');
        return AllExtensionsHelperWithoutDot.allExtensionsWithoutDot.ContainsKey(p);
    }

    /// <summary>
    /// When can't be found, return other
    /// Was default
    /// </summary>
    /// <param name = "p"></param>
    public static TypeOfExtension FindTypeWithDot(string p)
    {
        if (p != "")
        {
            p = p.Substring(1);

#if DEBUG
            if (p.EndsWith("js"))
            {

            }
#endif


            if (AllExtensionsHelperWithoutDot.allExtensionsWithoutDot.ContainsKey(p))
            {
                return (TypeOfExtension)AllExtensionsHelperWithoutDot.allExtensionsWithoutDot[p];
            }
        }
#if DEBUG
        else
        {
            Debugger.Break();
        }
#endif


        return TypeOfExtension.other;
    }
}
