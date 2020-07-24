using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTextMesh
    {
        TextAlignment alignment { get; }
        TextAnchor anchor { get; }
        float characterSize { get; }
        Color color { get; }
        IReadOnlyFont font { get; }
        int fontSize { get; }
        FontStyle fontStyle { get; }
        float lineSpacing { get; }
        float offsetZ { get; }
        bool richText { get; }
        float tabSize { get; }
        string text { get; }
    }

    public sealed class ReadOnlyTextMesh : ReadOnlyComponent<TextMesh>, IReadOnlyTextMesh
    {
        public ReadOnlyTextMesh(TextMesh obj) : base(obj)
        {
        }

        #region Properties

        public TextAlignment alignment => _obj.alignment;
        public TextAnchor anchor => _obj.anchor;
        public float characterSize => _obj.characterSize;
        public Color color => _obj.color;
        public ReadOnlyFont font => _obj.font.AsReadOnly();
        IReadOnlyFont IReadOnlyTextMesh.font => this.font;
        public int fontSize => _obj.fontSize;
        public FontStyle fontStyle => _obj.fontStyle;
        public float lineSpacing => _obj.lineSpacing;
        public float offsetZ => _obj.offsetZ;
        public bool richText => _obj.richText;
        public float tabSize => _obj.tabSize;
        public string text => _obj.text;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class TextMeshExtensions
    {
        public static ReadOnlyTextMesh AsReadOnly(this TextMesh self) => new ReadOnlyTextMesh(self);
    }
}