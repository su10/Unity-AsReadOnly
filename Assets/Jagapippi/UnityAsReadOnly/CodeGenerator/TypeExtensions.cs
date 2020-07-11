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

        public static string ToSimpleString(this Type type)
        {
            if (type.IsGenericType) return GenericTypeToString(type);
            if (type.IsArray) return ArrayTypeToString(type);
            return type.ToAliasName();
        }

        private static string GenericTypeToString(Type type)
        {
            if (type.IsGenericType == false) throw new ArgumentException(nameof(type));

            var builder = new StringBuilder("<");
            var genericArguments = type.GetGenericArguments();

            for (var i = 0; i < genericArguments.Length; i++)
            {
                var genericArgument = genericArguments[i];
                if (genericArgument.IsArray)
                {
                    builder.Append(ArrayTypeToString(genericArgument));
                }
                else if (genericArgument.IsGenericType)
                {
                    builder.Append(GenericTypeToString(genericArgument));
                }
                else
                {
                    builder.Append(genericArgument.ToAliasName());
                }

                if (i < genericArguments.Length - 1) builder.Append(", ");
            }

            builder.Append(">");

            var name = type.Name;
            return builder.Insert(0, name.Substring(0, name.IndexOf("`"))).ToString();
        }

        private static string ArrayTypeToString(Type type)
        {
            if (type.IsArray == false) throw new ArgumentException(nameof(type));
            var builder = new StringBuilder();

            while (type.HasElementType)
            {
                if (type.IsMultidimensionalArray()) // like a int[,]
                {
                    builder.Append($"[{new string(',', type.GetArrayRank() - 1)}]");
                }
                else
                {
                    builder.Append("[]");
                }

                type = type.GetElementType();
            }

            builder.Insert(0, ToSimpleString(type));
            return builder.ToString();
        }

        private static string ToAliasName(this Type self)
        {
            return TypeAliases.ContainsKey(self) ? TypeAliases[self] : self.Name;
        }

        private static bool IsMultidimensionalArray(this Type type)
        {
            return type.IsArray && (2 <= type.GetArrayRank());
        }
    }
}