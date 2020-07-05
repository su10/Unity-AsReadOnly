using System;
using System.Collections.Generic;

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

        public static string ToAliasName(this Type self)
        {
            return TypeAliases.ContainsKey(self) ? TypeAliases[self] : self.Name;
        }
    }
}