namespace SunamoFileExtensions;

// Use Generate for AllExtensions when adding more than 1 new extension
/// <summary>
/// Represents the all extensions type.
/// </summary>
public partial class AllExtensions
{
    /// <summary>
    /// The editorconfig constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string editorconfig = ".editorconfig";
    /// <summary>
    /// The gitignore constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string gitignore = ".gitignore";
    /// <summary>
    /// The hintrc constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string hintrc = ".hintrc";
    /// <summary>
    /// The npmrc constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string npmrc = ".npmrc";
    /// <summary>
    /// The nvmrc constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string nvmrc = ".nvmrc";
    /// <summary>
    /// The yarnrc constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string yarnrc = ".yarnrc";
    /// <summary>
    /// The properties constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string properties = ".properties";
    /// <summary>
    /// The lock constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.contentText)]
    public const string _lock = ".lock";
    /// <summary>
    /// The env constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string env = ".env";
    /// <summary>
    /// The development constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string development = ".development";
    /// <summary>
    /// The production constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string production = ".production";
    /// <summary>
    /// The json constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.contentText)]
    public const string json = ".json";
    /// <summary>
    /// The eslintrc constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string eslintrc = ".eslintrc";
    /// <summary>
    /// The prettierrc constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.configText)]
    public const string prettierrc = ".prettierrc";
    // vcf is really a text file
    /// <summary>
    /// The vcf constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.contentText)]
    public const string vcf = ".vcf";
    /// <summary>
    /// The zip constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.archive)]
    public const string zip = ".zip";
    /// <summary>
    /// The gif constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.image)]
    public const string gif = ".gif";
    /// <summary>
    /// The rar constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.archive)]
    public const string rar = ".rar";
    /// <summary>
    /// The cs constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string cs = ".cs";
    /// <summary>
    /// The vue constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string vue = ".vue";
    /// <summary>
    /// The aspx constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string aspx = ".aspx";
    /// <summary>
    /// The 7 z constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.archive)]
    public const string _7z = ".7z";
    /// <summary>
    /// The jpg constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.image)]
    public const string jpg = ".jpg";
    /// <summary>
    /// The js constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string js = ".js";
    /// <summary>
    /// The asmx constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string asmx = ".asmx";
    /// <summary>
    /// The htm constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string htm = ".htm";
    /// <summary>
    /// The html constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string html = ".html";
    /// <summary>
    /// The master constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string master = ".master";
    /// <summary>
    /// The txt constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.documentText)]
    public const string txt = ".txt";
    /// <summary>
    /// The dll constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.binary)]
    public const string dll = ".dll";
    /// <summary>
    /// The xml constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.contentText)]
    public const string xml = ".xml";
    /// <summary>
    /// The db constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.database)]
    public const string db = ".db";
    /// <summary>
    /// The whtt constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string whtt = ".whtt";
    /// <summary>
    /// The config constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string config = ".config";
    /// <summary>
    /// The gitattributes constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string gitattributes = ".gitattributes";
    /// <summary>
    /// The sln constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string sln = ".sln";
    /// <summary>
    /// The sample constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string sample = ".sample";
    /// <summary>
    /// The idx constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string idx = ".idx";
    /// <summary>
    /// The pack constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string pack = ".pack";
    /// <summary>
    /// The suo constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string suo = ".suo";
    /// <summary>
    /// The csproj constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string csproj = ".csproj";
    /// <summary>
    /// The ico constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.image)]
    public const string ico = ".ico";
    /// <summary>
    /// The xaml constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string xaml = ".xaml";
    /// <summary>
    /// The bmp constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.image)]
    public const string bmp = ".bmp";
    /// <summary>
    /// The png constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.image)]
    public const string png = ".png";
    /// <summary>
    /// The exe constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.executable)]
    public const string exe = ".exe";
    /// <summary>
    /// The pdb constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string pdb = ".pdb";
    /// <summary>
    /// The manifest constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string manifest = ".manifest";
    /// <summary>
    /// The ini constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.settingsText)]
    public const string ini = ".ini";
    /// <summary>
    /// The cache constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string cache = ".cache";
    /// <summary>
    /// The resources constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.resource)]
    public const string resources = ".resources";
    /// <summary>
    /// The lref constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string lref = ".lref";
    /// <summary>
    /// The baml constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string baml = ".baml";
    /// <summary>
    /// The resx constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.resource)]
    public const string resx = ".resx";
    // Visual Studio export, XML format
    /// <summary>
    /// The settings constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.settingsText)]
    public const string settings = ".settings";
    /// <summary>
    /// The nupkg constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string nupkg = ".nupkg";
    /// <summary>
    /// The nuspec constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string nuspec = ".nuspec";
    /// <summary>
    /// The pri constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string pri = ".pri";
    /// <summary>
    /// The ps 1 constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.script)]
    public const string ps1 = ".ps1";
    /// <summary>
    /// The rtf constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.documentText)]
    public const string rtf = ".rtf";
    /// <summary>
    /// The css constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.source_code)]
    public const string css = ".css";
    /// <summary>
    /// The recovery constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string recovery = ".recovery";
    /// <summary>
    /// The pfx constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string pfx = ".pfx";
    /// <summary>
    /// The targets constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string targets = ".targets";
    /// <summary>
    /// The user constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.visual_studioText)]
    public const string user = ".user";
    /// <summary>
    /// The def constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string def = ".def";
    /// <summary>
    /// The props constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string props = ".props";
    /// <summary>
    /// The xdt constant.
    /// </summary>
    [TypeOfExtension(TypeOfExtension.other)]
    public const string xdt = ".xdt";
}
