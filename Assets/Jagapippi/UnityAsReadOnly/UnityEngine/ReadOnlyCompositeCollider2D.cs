using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCompositeCollider2D
    {
        float edgeRadius { get; }
        CompositeCollider2D.GenerationType generationType { get; }
        CompositeCollider2D.GeometryType geometryType { get; }
        int pathCount { get; }
        int pointCount { get; }
        float vertexDistance { get; }
        // void GenerateGeometry();
        int GetPath(int index, Vector2[] points);
        int GetPathPointCount(int index);
    }

    public sealed class ReadOnlyCompositeCollider2D : ReadOnlyCollider2D<CompositeCollider2D>, IReadOnlyCompositeCollider2D
    {
        public ReadOnlyCompositeCollider2D(CompositeCollider2D obj) : base(obj)
        {
        }

        #region Properties

        public float edgeRadius => _obj.edgeRadius;
        public CompositeCollider2D.GenerationType generationType => _obj.generationType;
        public CompositeCollider2D.GeometryType geometryType => _obj.geometryType;
        public int pathCount => _obj.pathCount;
        public int pointCount => _obj.pointCount;
        public float vertexDistance => _obj.vertexDistance;

        #endregion

        #region Public Methods

        // public void GenerateGeometry() => _obj.GenerateGeometry();
        public int GetPath(int index, Vector2[] points) => _obj.GetPath(index, points);
        public int GetPathPointCount(int index) => _obj.GetPathPointCount(index);

        #endregion
    }

    public static class CompositeCollider2DExtensions
    {
        public static ReadOnlyCompositeCollider2D AsReadOnly(this CompositeCollider2D self) => self.IsTrulyNull() ? null : new ReadOnlyCompositeCollider2D(self);
    }
}