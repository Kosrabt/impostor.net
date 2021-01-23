using System;
using System.Linq;
using System.Reflection;

namespace Impostor.Core.Helpers
{
    public static class TypeHelper
    {
        public static MethodInfo GetMatchingMethod(Type type, MethodInfo targetMethod)
        {
            var targetArguments = targetMethod.GetParameters();

            return type.GetMethods()
                .FirstOrDefault(x =>
                x.Name == targetMethod.Name &&
                x.ReturnType.IsEquivalentTo(targetMethod.ReturnType) &&
                IsMatchingParameters(targetArguments, x.GetParameters()));
        }

        private static bool IsMatchingParameters(ParameterInfo[] targetArguments, ParameterInfo[] testArguments)
        {
            if (targetArguments.Length != testArguments.Length)
                return false;

            for (int pIndex = 0; pIndex < targetArguments.Length; pIndex++)
            {
                if (!targetArguments[pIndex].ParameterType.IsEquivalentTo(testArguments[pIndex].ParameterType))
                    return false;
            }
            return true;
        }
    }
}
