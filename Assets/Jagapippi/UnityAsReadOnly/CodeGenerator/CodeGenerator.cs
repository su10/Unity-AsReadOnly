﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public class CodeGenerator : ScriptableObject
    {
        public string type = "UnityEngine.Transform";

        public static string GetUsingSection(Type type)
        {
            var builder = new StringBuilder();
            builder.AppendLine("using System.Collections;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using UnityEngine;");
            if (type.Namespace != "UnityEngine") builder.AppendLine($"using {type.Namespace};");

            return builder.ToString();
        }

        public static string GetPropertiesSection(Type type)
        {
            var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            var list = new List<KeyValuePair<string, string>>();

            foreach (var p in properties)
            {
                if (p.IsDefined(typeof(ObsoleteAttribute))) continue;
                list.Add(new KeyValuePair<string, string>(TypeHelper.ToString(p.PropertyType), p.Name));
            }

            var builder = new StringBuilder();

            foreach (var kv in list.OrderBy(kv => kv.Value))
            {
                builder.AppendLine($"public {kv.Key} {kv.Value} => _obj.{kv.Value};");
            }

            return builder.ToString();
        }

        public static string GetMethodsSection(Type type)
        {
            var properties = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            var list = new List<KeyValuePair<string, MethodInfo>>();

            foreach (var m in properties)
            {
                if (m.IsDefined(typeof(ObsoleteAttribute))) continue;
                if (m.Name.StartsWith("get_") || m.Name.StartsWith("set_")) continue;

                list.Add(new KeyValuePair<string, MethodInfo>(TypeHelper.ToString(m.ReturnType), m));
            }

            var parameters = new StringBuilder();
            var invokes = new StringBuilder();
            var resultBuilder = new StringBuilder();

            foreach (var kv in list.OrderBy(kv => kv.Value.Name))
            {
                var methodInfo = kv.Value;

                parameters.Clear();
                invokes.Clear();

                parameters.Append("(");
                invokes.Append($"{methodInfo.Name}(");

                var parameterInfoArray = methodInfo.GetParameters();
                for (var i = 0; i < parameterInfoArray.Length; i++)
                {
                    var p = parameterInfoArray[i];
                    parameters.Append($"{TypeHelper.ToString(p.ParameterType)} {p.Name}");
                    invokes.Append($"{p.Name}");

                    if (i < parameterInfoArray.Length - 1)
                    {
                        parameters.Append(", ");
                        invokes.Append(", ");
                    }
                }

                parameters.Append(")");
                invokes.Append(");");

                resultBuilder.AppendLine($"public {kv.Key} {methodInfo.Name}{parameters} => _obj.{invokes}");
            }

            return resultBuilder.ToString();
        }

        public static string Generate(Type type, string baseClass)
        {
            return CodeTemplate.FormatSimpleClass(
                GetUsingSection(type),
                type.Name,
                baseClass,
                GetPropertiesSection(type),
                GetMethodsSection(type)
            );
        }
    }
}