using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyVector3 : IEquatable<Vector3>
    {
        private readonly Vector3 _vector3;

        public ReadOnlyVector3(float x, float y, float z)
        {
            _vector3 = new Vector3(x, y, z);
        }

        public ReadOnlyVector3(float x, float y)
        {
            _vector3 = new Vector3(x, y);
        }

        public ReadOnlyVector3(Vector3 vector3)
        {
            _vector3 = vector3;
        }

        public ReadOnlyVector3(Vector2 vector2)
        {
            _vector3 = vector2;
        }

        public ReadOnlyVector3(ReadOnlyVector2 vector2)
        {
            _vector3 = new Vector3(vector2.x, vector2.y);
        }

        #region Properties

        public float x => _vector3.x;
        public float y => _vector3.y;
        public float z => _vector3.z;
        public float this[int index] => _vector3[index];
        public ReadOnlyVector3 normalized => _vector3.normalized.AsReadOnly();
        public float magnitude => _vector3.magnitude;
        public float sqrMagnitude => _vector3.sqrMagnitude;

        #endregion

        #region Public Methods

        public override int GetHashCode() => _vector3.GetHashCode();
        public override bool Equals(object other) => _vector3.Equals(other);
        public bool Equals(Vector3 other) => _vector3.Equals(other);
        public override string ToString() => _vector3.ToString();
        public string ToString(string format) => _vector3.ToString(format);

        #endregion

        #region Operators

        public static ReadOnlyVector3 operator +(ReadOnlyVector3 a, Vector3 b) => (a._vector3 + b).AsReadOnly();
        public static ReadOnlyVector3 operator -(ReadOnlyVector3 a, Vector3 b) => (a._vector3 - b).AsReadOnly();
        public static ReadOnlyVector3 operator -(ReadOnlyVector3 a) => (-a._vector3).AsReadOnly();
        public static ReadOnlyVector3 operator *(ReadOnlyVector3 a, float d) => (a._vector3 * d).AsReadOnly();
        public static ReadOnlyVector3 operator *(float d, ReadOnlyVector3 a) => (d * a._vector3).AsReadOnly();
        public static ReadOnlyVector3 operator /(ReadOnlyVector3 a, float d) => (a._vector3 / d).AsReadOnly();
        public static bool operator ==(ReadOnlyVector3 lhs, Vector3 rhs) => (lhs._vector3 == rhs);
        public static bool operator !=(ReadOnlyVector3 lhs, Vector3 rhs) => !(lhs == rhs);

        #endregion

        public static implicit operator ReadOnlyVector3(Vector3 v) => new ReadOnlyVector3(v);
        public static implicit operator Vector3(ReadOnlyVector3 v) => v._vector3;
        public static implicit operator ReadOnlyVector3(Vector2 v) => new ReadOnlyVector3(v);
        public static implicit operator Vector2(ReadOnlyVector3 v) => v._vector3;
        public static implicit operator ReadOnlyVector3(ReadOnlyVector2 v) => new ReadOnlyVector3(v);
        public static implicit operator ReadOnlyVector2(ReadOnlyVector3 v) => new ReadOnlyVector2(v);
    }

    public static class Vector3Extensions
    {
        public static ReadOnlyVector3 AsReadOnly(this Vector3 self) => new ReadOnlyVector3(self);
    }
}