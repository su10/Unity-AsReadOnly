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
        [Serializable]
        public class Settings : ScriptableSingleton<Settings>
        {
            public new static Settings instance
            {
                get
                {
                    // NOTE: To make this editable in inspector.
                    ScriptableSingleton<Settings>.instance.hideFlags = HideFlags.DontSave;
                    return ScriptableSingleton<Settings>.instance;
                }
            }

            public string typeName = "UnityEngine.Transform";
        }

        private SerializedObject settings;

        void OnEnable()
        {
            settings = new SerializedObject(Settings.instance);
        }

        public override void OnInspectorGUI()
        {
            {
                EditorGUI.BeginChangeCheck();
                settings.UpdateIfRequiredOrScript();
                var iterator = settings.GetIterator();
                while (iterator.NextVisible(true))
                {
                    if ("m_Script" == iterator.propertyPath) continue;
                    EditorGUILayout.PropertyField(iterator, true);
                }

                settings.ApplyModifiedProperties();
                EditorGUI.EndChangeCheck();
            }

            var target = (Settings) settings.targetObject;

            if (GUILayout.Button("Generate"))
            {
                var type = FindType(target.typeName);

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
                        Debug.LogError($"Type already exists: \"{target.typeName}\"");
                    }
                }
                else
                {
                    Debug.LogError($"Type not found: \"{target.typeName}\"");
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