using System.Reflection;

namespace Attest.Fake.Conventions
{
    internal static class TypeInfoExtensions
    {
        internal static bool InterfaceEndsWith(this TypeInfo typeInfo, string ending)
        {
            return typeInfo.IsInterface && typeInfo.Name.EndsWith(ending);
        }

        internal static bool ClassEndsWith(this TypeInfo typeInfo, string ending)
        {
            return typeInfo.IsInterface == false && typeInfo.IsAbstract == false && typeInfo.Name.EndsWith(ending);
        }
    }
}