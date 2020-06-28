using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Jagapippi.UnityAsReadOnly
{
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
                    if (Type.GetType($"Jagapippi.UnityAsReadOnly.ReadOnly{type.Name},UnityAsReadOnly") == null)
                    {
                        var dirPath = CreateDirectoryIfNecessary(type);
                        var path = $"{dirPath}/ReadOnly{type.Name}.cs";
                        var code = CodeGenerator.Generate(type, type.BaseType.Name);

                        File.WriteAllText(path, code);
                        AssetDatabase.ImportAsset(path);
                        EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath(path, typeof(Object)));
                    }
                    else
                    {
                        Debug.LogError($"Type already exists: \"{target.type}\"");
                    }
                }
                else
                {
                    Debug.LogError($"Type not found: \"{target.type}\"");
                }
            }
        }

        private static string CreateDirectoryIfNecessary(Type type)
        {
            var path = $"Assets/Jagapippi/UnityAsReadonly/{type.Namespace}";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            return path;
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
}