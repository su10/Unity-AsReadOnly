using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyText
    {
        bool alignByGeometry { get; }
        TextAnchor alignment { get; }
        IReadOnlyTextGenerator cachedTextGenerator { get; }
        IReadOnlyTextGenerator cachedTextGeneratorForLayout { get; }
        float flexibleHeight { get; }
        float flexibleWidth { get; }
        IReadOnlyFont font { get; }
        int fontSize { get; }
        FontStyle fontStyle { get; }
        HorizontalWrapMode horizontalOverflow { get; }
        int layoutPriority { get; }
        float lineSpacing { get; }
        IReadOnlyTexture mainTexture { get; }
        float minHeight { get; }
        float minWidth { get; }
        float pixelsPerUnit { get; }
        float preferredHeight { get; }
        float preferredWidth { get; }
        bool resizeTextForBestFit { get; }
        int resizeTextMaxSize { get; }
        int resizeTextMinSize { get; }
        bool supportRichText { get; }
        string text { get; }
        VerticalWrapMode verticalOverflow { get; }
        // void CalculateLayoutInputHorizontal();
        // void CalculateLayoutInputVertical();
        // void FontTextureChanged();
        TextGenerationSettings GetGenerationSettings(Vector2 extents);
        // void OnRebuildRequested();
    }

    public class ReadOnlyText<T> : ReadOnlyMaskableGraphic<T>, IReadOnlyText where T : Text
    {
        protected ReadOnlyText(T obj) : base(obj)
        {
        }

        #region Properties

        public bool alignByGeometry => _obj.alignByGeometry;
        public TextAnchor alignment => _obj.alignment;
        public ReadOnlyTextGenerator cachedTextGenerator => _obj.cachedTextGenerator.AsReadOnly();
        IReadOnlyTextGenerator IReadOnlyText.cachedTextGenerator => this.cachedTextGenerator;
        public ReadOnlyTextGenerator cachedTextGeneratorForLayout => _obj.cachedTextGeneratorForLayout.AsReadOnly();
        IReadOnlyTextGenerator IReadOnlyText.cachedTextGeneratorForLayout => this.cachedTextGeneratorForLayout;
        public virtual float flexibleHeight => _obj.flexibleHeight;
        public virtual float flexibleWidth => _obj.flexibleWidth;
        public ReadOnlyFont font => _obj.font.AsReadOnly();
        IReadOnlyFont IReadOnlyText.font => this.font;
        public int fontSize => _obj.fontSize;
        public FontStyle fontStyle => _obj.fontStyle;
        public HorizontalWrapMode horizontalOverflow => _obj.horizontalOverflow;
        public virtual int layoutPriority => _obj.layoutPriority;
        public float lineSpacing => _obj.lineSpacing;
        public override ReadOnlyTexture mainTexture => _obj.mainTexture.AsReadOnly();
        IReadOnlyTexture IReadOnlyText.mainTexture => this.mainTexture;
        public virtual float minHeight => _obj.minHeight;
        public virtual float minWidth => _obj.minWidth;
        public float pixelsPerUnit => _obj.pixelsPerUnit;
        public virtual float preferredHeight => _obj.preferredHeight;
        public virtual float preferredWidth => _obj.preferredWidth;
        public bool resizeTextForBestFit => _obj.resizeTextForBestFit;
        public int resizeTextMaxSize => _obj.resizeTextMaxSize;
        public int resizeTextMinSize => _obj.resizeTextMinSize;
        public bool supportRichText => _obj.supportRichText;
        public virtual string text => _obj.text;
        public VerticalWrapMode verticalOverflow => _obj.verticalOverflow;

        #endregion

        #region Public Methods

        // public void CalculateLayoutInputHorizontal() => _obj.CalculateLayoutInputHorizontal();
        // public void CalculateLayoutInputVertical() => _obj.CalculateLayoutInputVertical();
        // public void FontTextureChanged() => _obj.FontTextureChanged();
        public TextGenerationSettings GetGenerationSettings(Vector2 extents) => _obj.GetGenerationSettings(extents);
        // public void OnRebuildRequested() => _obj.OnRebuildRequested();

        #endregion
    }

    public sealed class ReadOnlyText : ReadOnlyText<Text>
    {
        public ReadOnlyText(Text obj) : base(obj)
        {
        }
    }

    public static class TextExtensions
    {
        public static ReadOnlyText AsReadOnly(this Text self) => self.IsTrulyNull() ? null : new ReadOnlyText(self);
    }
}