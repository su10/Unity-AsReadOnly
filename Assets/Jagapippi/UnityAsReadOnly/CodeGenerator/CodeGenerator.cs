﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class CodeGenerator : ScriptableObject
{
    private static readonly string Template = @"
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{{
    public class ReadOnly{0} : {1}
    {{
        public ReadOnly{0}({0} obj) : base(obj)
        {{
        }}

        #region Properties

{2}
        #endregion

        #region Public Methods

{3}
        #endregion
    }}

    public static class {0}Extensions
    {{
        public static ReadOnly{0} AsReadOnly(this {0} self) => new ReadOnly{0}(self);
    }}
}}
";

    private static readonly Dictionary<Type, string> TypeAlias = new Dictionary<Type, string>
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
        {typeof(void), "void"}
    };

    private static string Nicify(Type type) => TypeAlias.ContainsKey(type) ? TypeAlias[type] : type.Name;

    public string type = "UnityEngine.Transform";
    public string assembly = "UnityEngine";
    public string baseClass = "ReadOnlyComponent<Transform>";

    public static string GetPropertiesSection(Type type)
    {
        var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
        var list = new List<KeyValuePair<string, string>>();

        foreach (var p in properties)
        {
            if (p.IsDefined(typeof(ObsoleteAttribute))) continue;
            list.Add(new KeyValuePair<string, string>(Nicify(p.PropertyType), p.Name));
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

            list.Add(new KeyValuePair<string, MethodInfo>(Nicify(m.ReturnType), m));
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
                parameters.Append($"{Nicify(p.ParameterType)} {p.Name}");
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

    public static void Generate(Type type, string baseClass)
    {
        Debug.Log(string.Format(Template, type.Name, baseClass, GetPropertiesSection(type), GetMethodsSection(type)));
    }
}