
namespace SunamoFileExtensions._public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FSFileExtensions
{
    public static bool IsExtension(string result)
    {
        if (string.IsNullOrWhiteSpace(result))
        {
            return false;
        }
        if (!result.TrimStart('.').ToLower().All(c => char.IsLetter(c) && char.IsLower(c) || char.IsDigit(c)))
        {
            return false;
        }
        return true;
    }

    public static string GetExtension(string v, GetExtensionArgsFileExtensions a = null)
    {
        if (a == null)
        {
            a = new GetExtensionArgsFileExtensions();
        }

        string result = "";
        int lastDot = v.LastIndexOf(AllChars.dot);
        if (lastDot == -1)
        {
            return string.Empty;
        }
        int lastSlash = v.LastIndexOf(AllChars.slash);
        int lastBs = v.LastIndexOf(AllChars.bs);
        if (lastSlash > lastDot)
        {
            return string.Empty;
        }
        if (lastBs > lastDot)
        {
            return string.Empty;
        }
        result = v.Substring(lastDot);

        if (!IsExtension(result))
        {
            if (a.filesWoExtReturnAsIs)
            {
                return result;
            }
            return string.Empty;
        }

        if (!a.returnOriginalCase)
        {
            result = result.ToLower();
        }



        return result;
    }
}