using System;
using System.Collections.Generic;
using System.Text;

namespace Jagapippi.UnityAsReadOnly
{
    // TODO: Use NUnit.Framework.Internal.TypeHelper if possible
    public static class TypeHelper
    {
        public static string ToString(Type type)
        {
            if (type.IsGenericType) return GenericToString(type);
            if (type.IsArray) return ArrayToString(type);
            return BuiltInTypeToString(type);
        }

        public static string GenericToString(Type type)
        {
            if (type.IsGenericType == false) throw new ArgumentException(nameof(type));

            var builder = new StringBuilder("<");
            var genericArguments = type.GetGenericArguments();

            for (var i = 0; i < genericArguments.Length; i++)
            {
                var genericArgument = genericArguments[i];
                if (genericArgument.IsArray)
                {
                    builder.Append(ArrayToString(genericArgument));
                }
                else if (genericArgument.IsGenericType)
                {
                    builder.Append(GenericToString(genericArgument));
                }
                else
                {
                    builder.Append(BuiltInTypeToString(genericArgument));
                }

                if (i < genericArguments.Length - 1) builder.Append(", ");
            }

            builder.Append(">");

            var name = type.Name;
            return builder.Insert(0, name.Substring(0, name.IndexOf("`"))).ToString();
        }

        // TODO: Consider generic type
        public static string ArrayToString(Type type)
        {
            if (type.IsArray == false) throw new ArgumentException(nameof(type));

            var builder = new StringBuilder();

            while (type.HasElementType)
            {
                builder.Append("[]");
                type = type.GetElementType();
            }

            return builder.Insert(0, BuiltInTypeToString(type)).ToString();
        }

        public static string BuiltInTypeToString(Type type)
        {
            return TypeAliases.ContainsKey(type) ? TypeAliases[type] : type.Name;
        }

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
    }
}