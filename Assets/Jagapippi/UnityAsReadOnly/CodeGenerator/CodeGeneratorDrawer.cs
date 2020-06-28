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
            var typeString = $"{target.type},{target.assembly}";
            var type = Type.GetType(typeString);

            if (type != null)
            {
                CodeGenerator.Generate(type, target.baseClass);
            }
            else
            {
                Debug.LogError($"Type not found: {typeString}");
            }
        }
    }
}