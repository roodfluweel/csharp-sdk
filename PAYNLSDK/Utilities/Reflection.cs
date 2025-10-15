using System;

namespace PayNLSdk.Utilities;

internal class Reflection
{
    public static bool IsNullable(Type t)
    {
        if (t == null)
        {
            throw new ArgumentNullException("t");
        }

        return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
    }
}
