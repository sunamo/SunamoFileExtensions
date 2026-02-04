namespace SunamoFileExtensions._sunamo.SunamoExceptions;

/// <summary>
/// Internal exception throwing utilities
/// </summary>
internal partial class ThrowEx
{
    /// <summary>
    /// Throws a "not implemented case" exception
    /// </summary>
    /// <param name="notImplementedName">The name or type that is not implemented</param>
    /// <returns>True if an exception was thrown</returns>
    internal static bool NotImplementedCase(object notImplementedName)
    {
        return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName);
    }

    #region Other
    /// <summary>
    /// Gets the full name of the executing code (type.method)
    /// </summary>
    /// <returns>The full name in format "Namespace.Type.Method"</returns>
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> exceptionLocation = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(exceptionLocation.Item1, exceptionLocation.Item2, true);
        return fullName;
    }

    /// <summary>
    /// Gets the full name of executing code from type and method name
    /// </summary>
    /// <param name="type">The type (can be Type, MethodBase, string, or any object)</param>
    /// <param name="methodName">The method name</param>
    /// <param name="isFromThrowEx">If true, adjusts the stack depth</param>
    /// <returns>The full name in format "Namespace.Type.Method"</returns>
    static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (isFromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type actualType)
        {
            typeFullName = actualType.FullName ?? "Type cannot be get via type is Type type2";
        }
        else if (type is MethodBase method)
        {
            typeFullName = method.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase method";
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type actualTypeFromObject = type.GetType();
            typeFullName = actualTypeFromObject.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throws an exception if the exception message is not null
    /// </summary>
    /// <param name="exception">The exception message</param>
    /// <param name="isReallyThrowing">If true, throws the exception; if false, only breaks debugger</param>
    /// <returns>True if an exception would be thrown, false otherwise</returns>
    internal static bool ThrowIsNotNull(string? exception, bool isReallyThrowing = true)
    {
        if (exception != null)
        {
            Debugger.Break();
            if (isReallyThrowing)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }

    #region For avoid FullNameOfExecutedCode

    /// <summary>
    /// Throws an exception if the exception generator function returns a non-null message
    /// </summary>
    /// <typeparam name="TArgument">The type of the argument to pass to the exception generator</typeparam>
    /// <param name="exceptionGenerator">Function that generates the exception message</param>
    /// <param name="argument">Argument to pass to the exception generator</param>
    /// <returns>True if an exception was thrown</returns>
    internal static bool ThrowIsNotNull<TArgument>(Func<string, TArgument, string?> exceptionGenerator, TArgument argument)
    {
        string? exception = exceptionGenerator(FullNameOfExecutedCode(), argument);
        return ThrowIsNotNull(exception);
    }

    #endregion
    #endregion
}