using System.Reflection;
using System.Text;

namespace Jagapippi.UnityAsReadOnly
{
    public static class MethodInfoExtensions
    {
        public static string ToInterfaceString(this MethodInfo self)
        {
            return self.GetSignature(new StringBuilder()).Append(";").ToString();
        }

        private static StringBuilder GetSignature(this MethodInfo self, StringBuilder builder)
        {
            builder.Append($"{self.ReturnType.ToCSharpRepresentation()} {self.Name}");

            if (self.IsGenericMethod)
            {
                builder.Append("<");

                var genericArguments = self.GetGenericArguments();

                for (var i = 0; i < genericArguments.Length; i++)
                {
                    if (0 < i) builder.Append(", ");
                    builder.Append(genericArguments[i]);
                }

                builder.Append(">");
            }

            builder.Append("(");

            var parameters = self.GetParameters();

            for (var i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];

                if (0 < i) builder.Append(", ");

                if (param.ParameterType.IsByRef)
                {
                    builder.Append(param.IsOut ? "out " : "ref ");
                    builder.Append(param.ParameterType.GetElementType().ToCSharpRepresentation());
                }
                else
                {
                    builder.Append(param.ParameterType.ToCSharpRepresentation());
                }

                builder.Append($" {param.Name}");
            }

            builder.Append(")");

            if (self.IsGenericMethod)
            {
                var genericArguments = self.GetGenericArguments();

                for (var i = 0; i < genericArguments.Length; i++)
                {
                    var argumentType = genericArguments[i];
                    var constraints = argumentType.GetConstraints();

                    if (string.IsNullOrEmpty(constraints) == false)
                    {
                        builder.Append($" where {argumentType.Name} : {constraints}");
                    }
                }
            }

            return builder;
        }

        public static string ToDelegationString(this MethodInfo self)
        {
            return ToDelegationString(self, new StringBuilder()).ToString();
        }

        private static StringBuilder ToDelegationString(this MethodInfo self, StringBuilder builder)
        {
            builder.Append($"public {self.GetSignature(new StringBuilder())} => _obj.{self.Name}");

            if (self.IsGenericMethod)
            {
                builder.Append("<");

                var genericArguments = self.GetGenericArguments();

                for (var i = 0; i < genericArguments.Length; i++)
                {
                    if (0 < i) builder.Append(", ");
                    builder.Append(genericArguments[i]);
                }

                builder.Append(">");
            }

            builder.Append("(");

            var parameters = self.GetParameters();

            for (var i = 0; i < parameters.Length; i++)
            {
                if (0 < i) builder.Append(", ");

                var param = parameters[i];

                if (param.ParameterType.IsByRef)
                {
                    builder.Append(param.IsOut ? "out " : "ref ");
                }

                builder.Append(param.Name);
            }

            builder.Append(");");

            return builder;
        }
    }
}