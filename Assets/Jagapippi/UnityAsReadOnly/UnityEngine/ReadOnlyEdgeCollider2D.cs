using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyEdgeCollider2D
    {
        int edgeCount { get; }
        float edgeRadius { get; }
        int pointCount { get; }
        Vector2[] points { get; }
        // void Reset();
    }

    public sealed class ReadOnlyEdgeCollider2D : ReadOnlyCollider2D<EdgeCollider2D>, IReadOnlyEdgeCollider2D
    {
        public ReadOnlyEdgeCollider2D(EdgeCollider2D obj) : base(obj)
        {
        }

        #region Properties

        public int edgeCount => _obj.edgeCount;
        public float edgeRadius => _obj.edgeRadius;
        public int pointCount => _obj.pointCount;
        public Vector2[] points => _obj.points;

        #endregion

        #region Public Methods

        public void Reset() => _obj.Reset();

        #endregion
    }

    public static class EdgeCollider2DExtensions
    {
        public static ReadOnlyEdgeCollider2D AsReadOnly(this EdgeCollider2D self) => self.IsTrulyNull() ? null : new ReadOnlyEdgeCollider2D(self);
    }
}