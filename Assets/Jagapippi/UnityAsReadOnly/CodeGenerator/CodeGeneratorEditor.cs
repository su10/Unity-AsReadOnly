using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace Jagapippi.UnityAsReadOnly
{
    [CustomEditor(typeof(CodeGenerator))]
    public class CodeGeneratorEditor : Editor
    {
        private static readonly Encoding Encoding = new UTF8Encoding(true);

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

            public enum Template
            {
                Simple,
                Derived,
                Inheritable,
            }

            public string typeName = "UnityEngine.Transform";
            public string outputNamespace = "Jagapippi.UnityAsReadOnly";
            public Template template;
            public bool overwrite = false;
        }

        private SerializedObject settings;
        private string _result;

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

            if (GUILayout.Button("Dry Run")) _result = this.Generate(dryRun: true);
            if (GUILayout.Button("Generate")) _result = this.Generate(dryRun: false);

            {
                const string style = "ScriptText";
                var rect = GUILayoutUtility.GetRect(new GUIContent(_result), style);
                rect.x = 0;
                rect.width = EditorGUIUtility.currentViewWidth;
                GUI.Box(rect, _result, style);
            }
        }

        private string Generate(bool dryRun = false)
        {
            var target = (Settings) settings.targetObject;
            var type = FindUnityType(target.typeName);

            if (type == null)
            {
                Debug.LogError($"Type not found: \"{target.typeName}\"");
                return string.Empty;
            }

            var shortTypeName = target.typeName.Split('.').Last();
            if ((target.overwrite == false) && (FindType($"{target.outputNamespace}.ReadOnly{shortTypeName}") != null))
            {
                Debug.LogError($"Type already exists: \"ReadOnly{shortTypeName}\"");
                return string.Empty;
            }

            var code = string.Empty;

            switch (target.template)
            {
                case Settings.Template.Simple:
                    code = CodeGenerator.GenerateSimpleClass(type, target.outputNamespace);
                    break;

                case Settings.Template.Derived:
                    code = CodeGenerator.GenerateDerivedClass(type, target.outputNamespace, type.BaseType.Name);
                    break;

                case Settings.Template.Inheritable:
                    if (type.IsSealed)
                    {
                        Debug.LogError($"Type is sealed: \"{target.typeName}\"");
                        return string.Empty;
                    }

                    code = CodeGenerator.GenerateInheritableClass(type, target.outputNamespace, type.BaseType.Name);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Settings.template));
            }

            if (dryRun) return code;

            var dirPath = CreateDirectoryIfNecessary(type);
            var path = $"{dirPath}/ReadOnly{type.Name}.cs";
            File.WriteAllText(path, code, Encoding);
            AssetDatabase.ImportAsset(path);
            EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath(path, typeof(Object)));

            return code;
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

        private static Type FindUnityType(string typeName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.GetName().Name.StartsWith("Unity") == false) continue;
                var type = assembly.GetType(typeName);
                if (type != null) return type;
            }

            return null;
        }

        private static Type FindType(string typeName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType(typeName);
                if (type != null) return type;
            }

            return null;
        }
    }
}