using System;
using System.Linq;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461
{
    public static class TypeExtensions
    {
        public static TypeInfo TypeInfo(this Type type)
        {
            return Net461.TypeInfo.FromClassName(type.FullName);
        }

        public static TypeInfo TypeInfoWithGenericParameters(this Type type, params Type[] genericTypeParameters)
        {
            var genericTypeParameterNames = genericTypeParameters.Select(x => x.FullName).ToArray();

            return Net461.TypeInfo.FromGenericClassName(type.FullName, genericTypeParameterNames);
        }
    }
}