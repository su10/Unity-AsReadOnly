﻿using System.Reflection;
using System.Text;

namespace Jagapippi.UnityAsReadOnly
{
    public static class MethodInfoExtensions
    {
        public static string ToDelegationString(this MethodInfo self)
        {
            return ToDelegationString(self, new StringBuilder()).ToString();
        }

        public static StringBuilder ToDelegationString(this MethodInfo self, StringBuilder builder)
        {
            var parameters = new StringBuilder();
            var arguments = new StringBuilder();

            var parameterInfoArray = self.GetParameters();

            for (var i = 0; i < parameterInfoArray.Length; i++)
            {
                var p = parameterInfoArray[i];
                parameters.Append($"{p.ParameterType.ToSimpleString()} {p.Name}");
                arguments.Append($"{p.Name}");

                if (parameterInfoArray.Length - 1 <= i) continue;

                parameters.Append(", ");
                arguments.Append(", ");
            }

            builder.AppendLine($"public {self.ReturnType.ToSimpleString()} {self.Name}({parameters}) => _obj.{self.Name}({arguments});");

            return builder;
        }
    }
}