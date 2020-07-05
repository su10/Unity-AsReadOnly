﻿using System;
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
            return type.ToAliasName();
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
                    builder.Append(genericArgument.ToAliasName());
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

            return builder.Insert(0, type.ToAliasName()).ToString();
        }
    }
}