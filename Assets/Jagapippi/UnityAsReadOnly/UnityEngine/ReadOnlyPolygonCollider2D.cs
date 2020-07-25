using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyPolygonCollider2D
    {
        bool autoTiling { get; }
        int pathCount { get; }
        Vector2[] points { get; }
        // void CreatePrimitive(int sides);
        // void CreatePrimitive(int sides, Vector2 scale);
        // void CreatePrimitive(int sides, Vector2 scale, Vector2 offset);
        Vector2[] GetPath(int index);
        int GetTotalPointCount();
        // void SetPath(int index, Vector2[] points);
    }

    public sealed class ReadOnlyPolygonCollider2D : ReadOnlyCollider2D<PolygonCollider2D>, IReadOnlyPolygonCollider2D
    {
        public ReadOnlyPolygonCollider2D(PolygonCollider2D obj) : base(obj)
        {
        }

        #region Properties

        public bool autoTiling => _obj.autoTiling;
        public int pathCount => _obj.pathCount;
        public Vector2[] points => _obj.points;

        #endregion

        #region Public Methods

        // public void CreatePrimitive(int sides) => _obj.CreatePrimitive(sides);
        // public void CreatePrimitive(int sides, Vector2 scale) => _obj.CreatePrimitive(sides, scale);
        // public void CreatePrimitive(int sides, Vector2 scale, Vector2 offset) => _obj.CreatePrimitive(sides, scale, offset);
        public Vector2[] GetPath(int index) => _obj.GetPath(index);
        public int GetTotalPointCount() => _obj.GetTotalPointCount();
        // public void SetPath(int index, Vector2[] points) => _obj.SetPath(index, points);

        #endregion
    }

    public static class PolygonCollider2DExtensions
    {
        public static ReadOnlyPolygonCollider2D AsReadOnly(this PolygonCollider2D self) => self.IsTrulyNull() ? null : new ReadOnlyPolygonCollider2D(self);
    }
}