using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Jagapippi.UnityAsReadOnly
{
    public static class TypeExtensions
    {
        private static readonly Dictionary<Type, string> TypeAliases = new Dictionary<Type, string>
        {
            {typeof(bool), "bool"},
            {typeof(byte), "byte"},
            {typeof(char), "char"},
            {typeof(decimal), "decimal"},
            {typeof(double), "double"},
            {typeof(float), "float"},
            {typeof(int), "int"},
            {typeof(long), "long"},
            {typeof(object), "object"},
            {typeof(sbyte), "sbyte"},
            {typeof(short), "short"},
            {typeof(string), "string"},
            {typeof(uint), "uint"},
            {typeof(ulong), "ulong"},
            {typeof(ushort), "ushort"},
            {typeof(void), "void"},
            {typeof(bool?), "bool?"},
            {typeof(byte?), "byte?"},
            {typeof(char?), "char?"},
            {typeof(decimal?), "decimal?"},
            {typeof(double?), "double?"},
            {typeof(float?), "float?"},
            {typeof(int?), "int?"},
            {typeof(long?), "long?"},
            {typeof(sbyte?), "sbyte?"},
            {typeof(short?), "short?"},
            {typeof(uint?), "uint?"},
            {typeof(ulong?), "ulong?"},
            {typeof(ushort?), "ushort?"},
        };

        public static IEnumerable<string> GetRelatedNamespaces(this Type self)
        {
            var set = new HashSet<string> {self.Namespace};
            var methods = self.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            foreach (var method in methods)
            {
                if (method.IsDefined(typeof(ObsoleteAttribute))) continue;

                foreach (var t in UnpackTypes(method.ReturnType))
                {
                    if (TypeAliases.ContainsKey(t)) continue;

                    set.Add(t.Namespace);
                }

                foreach (var p in method.GetParameters())
                {
                    foreach (var t in UnpackTypes(p.ParameterType))
                    {
                        if (TypeAliases.ContainsKey(t)) continue;

                        set.Add(t.Namespace);
                    }
                }
            }

            return set.OrderBy(@namespace => @namespace);
        }

        private static HashSet<Type> UnpackTypes(this Type type, HashSet<Type> set = null)
        {
            if (set == null) set = new HashSet<Type>();

            set.Add(type.IsArray ? type.GetElementType() : type);

            if (type.IsGenericType == false) return set;

            foreach (var argumentType in type.GetGenericArguments())
            {
                UnpackTypes(argumentType, set);
            }

            return set;
        }

        public static string ToCSharpRepresentation(this Type self)
        {
            return ToCSharpRepresentation(self, null);
        }

        // SEE: https://stackoverflow.com/a/47317027
        private static string ToCSharpRepresentation(Type type, Stack<Type> genericArgs, StringBuilder arrayBrackets = null)
        {
            if (TypeAliases.ContainsKey(type)) return TypeAliases[type];
            if (type.IsGenericParameter) return type.ToString();

            var code = new StringBuilder();
            var declaringType = type.DeclaringType;
            var arrayBracketsWasNull = (arrayBrackets == null);

            if (genericArgs == null) genericArgs = new Stack<Type>(type.GetGenericArguments());
            var currentTypeGenericArgsCount = genericArgs.Count;
            if (declaringType != null) currentTypeGenericArgsCount -= declaringType.GetGenericArguments().Length;

            var currentTypeGenericArgs = new Type[currentTypeGenericArgsCount];
            for (var i = currentTypeGenericArgsCount - 1; 0 <= i; i--)
            {
                currentTypeGenericArgs[i] = genericArgs.Pop();
            }

            if (declaringType != null) code.Append(ToCSharpRepresentation(declaringType, genericArgs)).Append('.');

            if (type.IsArray)
            {
                if (arrayBrackets == null) arrayBrackets = new StringBuilder();

                arrayBrackets.Append('[');
                arrayBrackets.Append(',', type.GetArrayRank() - 1);
                arrayBrackets.Append(']');

                var elementType = type.GetElementType();
                code.Insert(0, ToCSharpRepresentation(elementType, null, arrayBrackets));
            }
            else
            {
                code.Append(new string(type.Name.TakeWhile(c => char.IsLetterOrDigit(c) || c == '_').ToArray()));

                if (0 < currentTypeGenericArgsCount)
                {
                    code.Append('<');

                    for (var i = 0; i < currentTypeGenericArgsCount; i++)
                    {
                        code.Append(ToCSharpRepresentation(currentTypeGenericArgs[i], null));

                        if (i < currentTypeGenericArgsCount - 1)
                        {
                            code.Append(", ");
                        }
                    }

                    code.Append('>');
                }
            }

            if (arrayBracketsWasNull && arrayBrackets != null)
            {
                code.Append(arrayBrackets);
            }

            return code.ToString();
        }

        public static string GetConstraints(this Type self)
        {
            var builder = new StringBuilder();
            var isValueType = false;

            foreach (var constraint in self.GetGenericParameterConstraints())
            {
                if (0 < builder.Length) builder.Append(", ");
                if (constraint == typeof(ValueType))
                {
                    isValueType = true;
                }
                else
                {
                    builder.Append(constraint.Name);
                }
            }

            var constraints = self.GenericParameterAttributes & GenericParameterAttributes.SpecialConstraintMask;

            if ((constraints & GenericParameterAttributes.ReferenceTypeConstraint) != 0)
            {
                if (0 < builder.Length) builder.Append(", ");
                builder.Append("class");
            }

            if ((constraints & GenericParameterAttributes.NotNullableValueTypeConstraint) != 0)
            {
                if (0 < builder.Length) builder.Append(", ");
                builder.Append("struct");
            }

            if ((constraints & GenericParameterAttributes.DefaultConstructorConstraint) != 0 && (isValueType == false))
            {
                if (0 < builder.Length) builder.Append(", ");
                builder.Append("new()");
            }

            return builder.ToString();
        }
    }
}