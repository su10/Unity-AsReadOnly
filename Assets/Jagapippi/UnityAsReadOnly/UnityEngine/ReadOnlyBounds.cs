using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyBounds : IEquatable<Bounds>
    {
        private readonly Bounds _bounds;

        public ReadOnlyBounds(Bounds bounds)
        {
            _bounds = bounds;
        }

        #region Properties

        public Vector3 center => _bounds.center;
        public Vector3 extents => _bounds.extents;
        public Vector3 max => _bounds.max;
        public Vector3 min => _bounds.min;
        public Vector3 size => _bounds.size;

        #endregion

        #region Public Methods

        public Vector3 ClosestPoint(Vector3 point) => _bounds.ClosestPoint(point);
        public bool Contains(Vector3 point) => _bounds.Contains(point);
        // public void Encapsulate(Vector3 point) => _bounds.Encapsulate(point);
        // public void Encapsulate(Bounds bounds) => _bounds.Encapsulate(bounds);
        public override bool Equals(object other) => _bounds.Equals(other);
        public bool Equals(Bounds other) => _bounds.Equals(other);
        // public void Expand(float amount) => _bounds.Expand(amount);
        // public void Expand(Vector3 amount) => _bounds.Expand(amount);
        public override int GetHashCode() => _bounds.GetHashCode();
        public bool IntersectRay(Ray ray) => _bounds.IntersectRay(ray);
        public bool IntersectRay(Ray ray, out float distance) => _bounds.IntersectRay(ray, out distance);
        public bool Intersects(Bounds bounds) => _bounds.Intersects(bounds);
        // public void SetMinMax(Vector3 min, Vector3 max) => _bounds.SetMinMax(min, max);
        public float SqrDistance(Vector3 point) => _bounds.SqrDistance(point);
        public override string ToString() => _bounds.ToString();
        public string ToString(string format) => _bounds.ToString(format);

        #endregion

        #region Operators

        public static bool operator ==(ReadOnlyBounds lhs, Bounds rhs) => (lhs._bounds == rhs);
        public static bool operator !=(ReadOnlyBounds lhs, Bounds rhs) => !(lhs == rhs);
        public static implicit operator ReadOnlyBounds(Bounds v) => new ReadOnlyBounds(v);
        public static implicit operator Bounds(ReadOnlyBounds v) => v._bounds;

        #endregion
    }

    public static class BoundsExtensions
    {
        public static ReadOnlyBounds AsReadOnly(this Bounds self) => new ReadOnlyBounds(self);
    }
}