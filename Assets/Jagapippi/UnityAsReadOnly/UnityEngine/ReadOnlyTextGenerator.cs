using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTextGenerator
    {
        int characterCount { get; }
        int characterCountVisible { get; }
        IList<UICharInfo> characters { get; }
        int fontSizeUsedForBestFit { get; }
        int lineCount { get; }
        IList<UILineInfo> lines { get; }
        Rect rectExtents { get; }
        int vertexCount { get; }
        IList<UIVertex> verts { get; }
        void GetCharacters(List<UICharInfo> characters);
        UICharInfo[] GetCharactersArray();
        void GetLines(List<UILineInfo> lines);
        UILineInfo[] GetLinesArray();
        float GetPreferredHeight(string str, TextGenerationSettings settings);
        float GetPreferredWidth(string str, TextGenerationSettings settings);
        void GetVertices(List<UIVertex> vertices);
        UIVertex[] GetVerticesArray();
        // void Invalidate();
        // bool Populate(string str, TextGenerationSettings settings);
        // bool PopulateWithErrors(string str, TextGenerationSettings settings, GameObject context);
    }

    public sealed class ReadOnlyTextGenerator : IReadOnlyTextGenerator
    {
        internal readonly TextGenerator _obj;

        public ReadOnlyTextGenerator(TextGenerator obj)
        {
            if (obj.IsTrulyNull()) throw new ArgumentNullException(nameof(obj));

            _obj = obj;
        }

        #region Properties

        public int characterCount => _obj.characterCount;
        public int characterCountVisible => _obj.characterCountVisible;
        public IList<UICharInfo> characters => _obj.characters;
        public int fontSizeUsedForBestFit => _obj.fontSizeUsedForBestFit;
        public int lineCount => _obj.lineCount;
        public IList<UILineInfo> lines => _obj.lines;
        public Rect rectExtents => _obj.rectExtents;
        public int vertexCount => _obj.vertexCount;
        public IList<UIVertex> verts => _obj.verts;

        #endregion

        #region Public Methods

        public void GetCharacters(List<UICharInfo> characters) => _obj.GetCharacters(characters);
        public UICharInfo[] GetCharactersArray() => _obj.GetCharactersArray();
        public void GetLines(List<UILineInfo> lines) => _obj.GetLines(lines);
        public UILineInfo[] GetLinesArray() => _obj.GetLinesArray();
        public float GetPreferredHeight(string str, TextGenerationSettings settings) => _obj.GetPreferredHeight(str, settings);
        public float GetPreferredWidth(string str, TextGenerationSettings settings) => _obj.GetPreferredWidth(str, settings);
        public void GetVertices(List<UIVertex> vertices) => _obj.GetVertices(vertices);
        public UIVertex[] GetVerticesArray() => _obj.GetVerticesArray();
        // public void Invalidate() => _obj.Invalidate();
        // public bool Populate(string str, TextGenerationSettings settings) => _obj.Populate(str, settings);
        // public bool PopulateWithErrors(string str, TextGenerationSettings settings, GameObject context) => _obj.PopulateWithErrors(str, settings, context);

        #endregion
    }

    public static class TextGeneratorExtensions
    {
        public static ReadOnlyTextGenerator AsReadOnly(this TextGenerator self) => self.IsTrulyNull() ? null : new ReadOnlyTextGenerator(self);
        internal static bool IsTrulyNull(this TextGenerator self) => ReferenceEquals(self, null);
    }
}