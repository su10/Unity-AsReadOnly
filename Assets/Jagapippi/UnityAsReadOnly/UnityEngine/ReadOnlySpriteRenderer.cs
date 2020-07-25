using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlySpriteRenderer
    {
        float adaptiveModeThreshold { get; }
        Color color { get; }
        SpriteDrawMode drawMode { get; }
        bool flipX { get; }
        bool flipY { get; }
        SpriteMaskInteraction maskInteraction { get; }
        Vector2 size { get; }
        Sprite sprite { get; }
        SpriteSortPoint spriteSortPoint { get; }
        SpriteTileMode tileMode { get; }
    }

    public sealed class ReadOnlySpriteRenderer : ReadOnlyRenderer<SpriteRenderer>, IReadOnlySpriteRenderer
    {
        public ReadOnlySpriteRenderer(SpriteRenderer obj) : base(obj)
        {
        }

        #region Properties

        public float adaptiveModeThreshold => _obj.adaptiveModeThreshold;
        public Color color => _obj.color;
        public SpriteDrawMode drawMode => _obj.drawMode;
        public bool flipX => _obj.flipX;
        public bool flipY => _obj.flipY;
        public SpriteMaskInteraction maskInteraction => _obj.maskInteraction;
        public Vector2 size => _obj.size;
        public Sprite sprite => _obj.sprite;
        public SpriteSortPoint spriteSortPoint => _obj.spriteSortPoint;
        public SpriteTileMode tileMode => _obj.tileMode;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class SpriteRendererExtensions
    {
        public static ReadOnlySpriteRenderer AsReadOnly(this SpriteRenderer self) => self.IsTrulyNull() ? null : new ReadOnlySpriteRenderer(self);
    }
}