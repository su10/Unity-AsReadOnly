using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public class CodeGenerator : ScriptableObject
    {
        public static string GetUsingSection(Type type)
        {
            var builder = new StringBuilder();

            foreach (var @namespace in type.GetRelatedNamespaces())
            {
                builder.AppendLine($"using {@namespace};");
            }

            return builder.ToString();
        }

        public static string GetInterfaceSection(Type type, int indentSpace = 0)
        {
            var builder = new StringBuilder();

            {
                var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                var list = new List<KeyValuePair<string, string>>();

                foreach (var p in properties)
                {
                    if (p.IsDefined(typeof(ObsoleteAttribute))) continue;
                    list.Add(new KeyValuePair<string, string>(p.PropertyType.ToSimpleString(), p.Name));
                }

                foreach (var kv in list.OrderBy(kv => kv.Value))
                {
                    builder.AppendLine($"{new string(' ', indentSpace)}{kv.Key} {kv.Value} {{ get; }}");
                }
            }
            {
                var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                var list = new List<KeyValuePair<string, MethodInfo>>();

                foreach (var m in methods)
                {
                    if (m.IsDefined(typeof(ObsoleteAttribute))) continue;
                    if (m.Name.StartsWith("get_") || m.Name.StartsWith("set_")) continue;

                    list.Add(new KeyValuePair<string, MethodInfo>(m.ReturnType.ToSimpleString(), m));
                }

                foreach (var kv in list.OrderBy(kv => kv.Value.Name))
                {
                    var methodInfo = kv.Value;
                    builder.Append($"{new string(' ', indentSpace)}{methodInfo.ToInterfaceString()}");
                }
            }

            return builder.ToString();
        }

        public static string GetPropertiesSection(Type type, int indentSpace = 0)
        {
            var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            var list = new List<KeyValuePair<string, string>>();

            foreach (var p in properties)
            {
                if (p.IsDefined(typeof(ObsoleteAttribute))) continue;
                list.Add(new KeyValuePair<string, string>(p.PropertyType.ToSimpleString(), p.Name));
            }

            var builder = new StringBuilder();

            foreach (var kv in list.OrderBy(kv => kv.Value))
            {
                builder.AppendLine($"{new string(' ', indentSpace)}public {kv.Key} {kv.Value} => _obj.{kv.Value};");
            }

            return builder.ToString();
        }

        public static string GetMethodsSection(Type type, int indentSpace = 0)
        {
            var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            var list = new List<KeyValuePair<string, MethodInfo>>();

            foreach (var m in methods)
            {
                if (m.IsDefined(typeof(ObsoleteAttribute))) continue;
                if (m.Name.StartsWith("get_") || m.Name.StartsWith("set_")) continue;

                list.Add(new KeyValuePair<string, MethodInfo>(m.ReturnType.ToSimpleString(), m));
            }

            var resultBuilder = new StringBuilder();

            foreach (var kv in list.OrderBy(kv => kv.Value.Name))
            {
                var methodInfo = kv.Value;
                resultBuilder.Append($"{new string(' ', indentSpace)}{methodInfo.ToDelegationString()}");
            }

            return resultBuilder.ToString();
        }

        public static string GenerateSimpleClass(Type type, string @namespace, string baseClass)
        {
            return CodeTemplate.FormatSimpleClass(
                GetUsingSection(type),
                @namespace,
                type.Name,
                baseClass,
                GetPropertiesSection(type, 8),
                GetMethodsSection(type, 8)
            );
        }

        public static string GenerateClassWithInterface(Type type, string @namespace, string baseClass)
        {
            return CodeTemplate.FormatClassWithInterface(
                GetUsingSection(type),
                @namespace,
                type.Name,
                baseClass,
                GetInterfaceSection(type, 8),
                GetPropertiesSection(type, 8),
                GetMethodsSection(type, 8)
            );
        }

        public static string GenerateGenericClass(Type type, string @namespace, string baseClass)
        {
            return CodeTemplate.FormatGenericClass(
                GetUsingSection(type),
                @namespace,
                type.Name,
                baseClass,
                GetInterfaceSection(type, 8),
                GetPropertiesSection(type, 8),
                GetMethodsSection(type, 8)
            );
        }
    }
}