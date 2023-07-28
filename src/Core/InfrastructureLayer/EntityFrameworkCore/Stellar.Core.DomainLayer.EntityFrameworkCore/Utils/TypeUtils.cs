using Throw;

namespace Stellar.Core.DomainLayer.EntityFrameworkCore.Utils;

public static class TypeUtils
{
    public static bool InheritsFromGeneric(this Type type, Type baseGenericType, out Type? baseType)
    {
        type.ThrowIfNull();
        baseGenericType.ThrowIfNull();

        var t = type;

        while (t != null)
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == baseGenericType)
            {
                baseType = t;
                return true;
            }

            t = t.BaseType;
        }

        baseType = null;
        return false;
    }
}