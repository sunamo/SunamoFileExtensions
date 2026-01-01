namespace SunamoFileExtensions._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.

/// <summary>
/// Internal exception handling utilities
/// </summary>
internal sealed partial class Exceptions
{
    #region Other
    /// <summary>
    /// Checks if the before string is null or whitespace and returns it with a colon suffix if not empty
    /// </summary>
    /// <param name="before">The string to check</param>
    /// <returns>Empty string if null/whitespace, otherwise the string with ": " suffix</returns>
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    /// <summary>
    /// Gets the place where an exception occurred in the code
    /// </summary>
    /// <param name="isFillAlsoFirstTwo">If true, fills type and method name from stack trace</param>
    /// <returns>Tuple containing type name, method name, and full stack trace</returns>
    internal static Tuple<string, string, string> PlaceOfException(bool isFillAlsoFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var value = stackTrace.ToString();
        var lines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var index = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; index < lines.Count; index++)
        {
            var item = lines[index];
            if (isFillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    isFillAlsoFirstTwo = false;
                }
            if (item.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }

    /// <summary>
    /// Extracts type and method name from a stack trace line
    /// </summary>
    /// <param name="lines">The stack trace line</param>
    /// <param name="type">Output parameter for the type name</param>
    /// <param name="methodName">Output parameter for the method name</param>
    internal static void TypeAndMethodName(string lines, out string type, out string methodName)
    {
        var methodSignature = lines.Split("at ")[1].Trim();
        var text = methodSignature.Split("(")[0];
        var parts = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        type = string.Join(".", parts);
    }

    /// <summary>
    /// Gets the name of the calling method
    /// </summary>
    /// <param name="value">The number of frames to skip in the stack trace</param>
    /// <returns>The name of the calling method</returns>
    internal static string CallingMethod(int value = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(value)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }
    #endregion

    #region IsNullOrWhitespace
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();
    #endregion

    /// <summary>
    /// Creates a "not implemented case" error message
    /// </summary>
    /// <param name="before">Text to prepend to the message</param>
    /// <param name="notImplementedName">The name or type that is not implemented</param>
    /// <returns>The error message</returns>
    internal static string? NotImplementedCase(string before, object notImplementedName)
    {
        var forClause = string.Empty;
        if (notImplementedName != null)
        {
            forClause = " for ";
            if (notImplementedName.GetType() == typeof(Type))
                forClause += ((Type)notImplementedName).FullName;
            else
                forClause += notImplementedName.ToString();
        }
        return CheckBefore(before) + "Not implemented case" + forClause + " . internal program error. Please contact developer" +
        ".";
    }
}
