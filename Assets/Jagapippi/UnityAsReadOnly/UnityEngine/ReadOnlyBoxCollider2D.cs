using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyBoxCollider2D
    {
        bool autoTiling { get; }
        float edgeRadius { get; }
        Vector2 size { get; }
    }

    public sealed class ReadOnlyBoxCollider2D : ReadOnlyCollider2D<BoxCollider2D>, IReadOnlyBoxCollider2D
    {
        public ReadOnlyBoxCollider2D(BoxCollider2D obj) : base(obj)
        {
        }

        #region Properties

        public bool autoTiling => _obj.autoTiling;
        public float edgeRadius => _obj.edgeRadius;
        public Vector2 size => _obj.size;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class BoxCollider2DExtensions
    {
        public static ReadOnlyBoxCollider2D AsReadOnly(this BoxCollider2D self) => self.IsTrulyNull() ? null : new ReadOnlyBoxCollider2D(self);
    }
}