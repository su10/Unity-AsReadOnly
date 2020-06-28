using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CodeGenerator))]
public class CodeGeneratorDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var target = (CodeGenerator) this.target;

        if (GUILayout.Button("Generate"))
        {
            var type = FindType(target.type);

            if (type != null)
            {
                CodeGenerator.Generate(type, target.baseClass);
            }
            else
            {
                Debug.LogError($"Type not found: \"{target.type}\"");
            }
        }
    }

    private static Type FindType(string typeName)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (assembly.GetName().Name.StartsWith("Unity") == false) continue;
            var type = assembly.GetType(typeName);
            if (type != null) return type;
        }

        return null;
    }
}