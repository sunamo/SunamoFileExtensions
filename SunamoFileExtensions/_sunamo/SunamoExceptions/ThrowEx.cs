namespace SunamoFileExtensions._sunamo.SunamoExceptions;

internal partial class ThrowEx
{
    internal static bool NotImplementedCase(object notImplementedName)
    {
        return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName);
    }

    #region Other
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> exceptionLocation = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(exceptionLocation.Item1, exceptionLocation.Item2, true);
        return fullName;
    }

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

    internal static bool ThrowIsNotNull<TArgument>(Func<string, TArgument, string?> exceptionGenerator, TArgument argument)
    {
        string? exception = exceptionGenerator(FullNameOfExecutedCode(), argument);
        return ThrowIsNotNull(exception);
    }

    #endregion
    #endregion
}
