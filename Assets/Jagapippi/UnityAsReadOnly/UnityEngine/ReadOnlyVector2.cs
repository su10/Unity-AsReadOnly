using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyVector2 : IEquatable<Vector2>
    {
        internal readonly Vector2 _vector2;

        public ReadOnlyVector2(float x, float y)
        {
            _vector2 = new Vector2(x, y);
        }

        public ReadOnlyVector2(Vector2 vector2)
        {
            _vector2 = vector2;
        }

        #region Properties

        public float x => _vector2.x;
        public float y => _vector2.y;
        public float this[int index] => _vector2[index];
        public ReadOnlyVector2 normalized => _vector2.normalized.AsReadOnly();
        public float magnitude => _vector2.magnitude;
        public float sqrMagnitude => _vector2.sqrMagnitude;

        #endregion

        #region Public Methods

        public override string ToString() => _vector2.ToString();
        public string ToString(string format) => _vector2.ToString(format);
        public override int GetHashCode() => _vector2.GetHashCode();
        public override bool Equals(object other) => _vector2.Equals(other);
        public bool Equals(Vector2 other) => _vector2.Equals(other);
        public float SqrMagnitude() => _vector2.SqrMagnitude();

        #endregion

        #region Operators

        public static ReadOnlyVector2 operator +(ReadOnlyVector2 a, Vector2 b) => (a._vector2 + b).AsReadOnly();
        public static ReadOnlyVector2 operator -(ReadOnlyVector2 a, Vector2 b) => (a._vector2 - b).AsReadOnly();
        public static ReadOnlyVector2 operator *(ReadOnlyVector2 a, Vector2 b) => (a._vector2 * b).AsReadOnly();
        public static ReadOnlyVector2 operator /(ReadOnlyVector2 a, Vector2 b) => (a._vector2 / b).AsReadOnly();
        public static ReadOnlyVector2 operator -(ReadOnlyVector2 a) => (-a._vector2).AsReadOnly();
        public static ReadOnlyVector2 operator *(ReadOnlyVector2 a, float d) => (a._vector2 * d).AsReadOnly();
        public static ReadOnlyVector2 operator *(float d, ReadOnlyVector2 a) => (d * a._vector2).AsReadOnly();
        public static ReadOnlyVector2 operator /(ReadOnlyVector2 a, float d) => (a._vector2 / d).AsReadOnly();
        public static bool operator ==(ReadOnlyVector2 lhs, Vector2 rhs) => (lhs._vector2 == rhs);
        public static bool operator !=(ReadOnlyVector2 lhs, Vector2 rhs) => !(lhs == rhs);

        #endregion

        public static implicit operator ReadOnlyVector2(Vector2 v) => new ReadOnlyVector2(v);
        public static implicit operator Vector2(ReadOnlyVector2 v) => v._vector2;
    }

    public static class Vector2Extensions
    {
        public static ReadOnlyVector2 AsReadOnly(this Vector2 self) => new ReadOnlyVector2(self);
    }
}