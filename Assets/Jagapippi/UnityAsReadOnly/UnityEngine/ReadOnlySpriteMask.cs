using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlySpriteMask
    {
        float alphaCutoff { get; }
        int backSortingLayerID { get; }
        int backSortingOrder { get; }
        int frontSortingLayerID { get; }
        int frontSortingOrder { get; }
        bool isCustomRangeActive { get; }
        IReadOnlySprite sprite { get; }
        SpriteSortPoint spriteSortPoint { get; }
    }

    public sealed class ReadOnlySpriteMask : ReadOnlyRenderer<SpriteMask>, IReadOnlySpriteMask
    {
        public ReadOnlySpriteMask(SpriteMask obj) : base(obj)
        {
        }

        #region Properties

        public float alphaCutoff => _obj.alphaCutoff;
        public int backSortingLayerID => _obj.backSortingLayerID;
        public int backSortingOrder => _obj.backSortingOrder;
        public int frontSortingLayerID => _obj.frontSortingLayerID;
        public int frontSortingOrder => _obj.frontSortingOrder;
        public bool isCustomRangeActive => _obj.isCustomRangeActive;
        public ReadOnlySprite sprite => _obj.sprite.AsReadOnly();
        IReadOnlySprite IReadOnlySpriteMask.sprite => this.sprite;
        public SpriteSortPoint spriteSortPoint => _obj.spriteSortPoint;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class SpriteMaskExtensions
    {
        public static ReadOnlySpriteMask AsReadOnly(this SpriteMask self) => self.IsTrulyNull() ? null : new ReadOnlySpriteMask(self);
    }
}