using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyVector4 : IEquatable<Vector4>
    {
        private readonly Vector4 _vector4;

        public ReadOnlyVector4(float x, float y, float z, float w)
        {
            _vector4 = new Vector4(x, y, z, w);
        }

        public ReadOnlyVector4(float x, float y, float z)
        {
            _vector4 = new Vector4(x, y, z);
        }

        public ReadOnlyVector4(float x, float y)
        {
            _vector4 = new Vector4(x, y);
        }

        public ReadOnlyVector4(Vector4 vector4)
        {
            _vector4 = vector4;
        }

        public ReadOnlyVector4(Vector3 vector3)
        {
            _vector4 = vector3;
        }

        public ReadOnlyVector4(Vector2 vector2)
        {
            _vector4 = vector2;
        }

        public ReadOnlyVector4(ReadOnlyVector3 vector3)
        {
            _vector4 = new Vector4(vector3.x, vector3.y, vector3.z);
        }

        public ReadOnlyVector4(ReadOnlyVector2 vector2)
        {
            _vector4 = new Vector4(vector2.x, vector2.y);
        }

        #region Properties

        public float x => _vector4.x;
        public float y => _vector4.y;
        public float z => _vector4.z;
        public float w => _vector4.w;
        public float this[int index] => _vector4[index];
        public ReadOnlyVector4 normalized => _vector4.normalized.AsReadOnly();
        public float magnitude => _vector4.magnitude;
        public float sqrMagnitude => _vector4.sqrMagnitude;

        #endregion

        #region Public Methods

        public override int GetHashCode() => _vector4.GetHashCode();
        public override bool Equals(object other) => _vector4.Equals(other);
        public bool Equals(Vector4 other) => _vector4.Equals(other);
        public override string ToString() => _vector4.ToString();
        public string ToString(string format) => _vector4.ToString(format);

        #endregion

        #region Operators

        public static ReadOnlyVector4 operator +(ReadOnlyVector4 a, Vector4 b) => (a._vector4 + b).AsReadOnly();
        public static ReadOnlyVector4 operator -(ReadOnlyVector4 a, Vector4 b) => (a._vector4 - b).AsReadOnly();
        public static ReadOnlyVector4 operator -(ReadOnlyVector4 a) => (-a._vector4).AsReadOnly();
        public static ReadOnlyVector4 operator *(ReadOnlyVector4 a, float d) => (a._vector4 * d).AsReadOnly();
        public static ReadOnlyVector4 operator *(float d, ReadOnlyVector4 a) => (d * a._vector4).AsReadOnly();
        public static ReadOnlyVector4 operator /(ReadOnlyVector4 a, float d) => (a._vector4 / d).AsReadOnly();
        public static bool operator ==(ReadOnlyVector4 lhs, Vector4 rhs) => (lhs._vector4 == rhs);
        public static bool operator !=(ReadOnlyVector4 lhs, Vector4 rhs) => !(lhs == rhs);

        #endregion

        public static implicit operator ReadOnlyVector4(Vector4 v) => new ReadOnlyVector4(v);
        public static implicit operator Vector4(ReadOnlyVector4 v) => v._vector4;
        public static implicit operator ReadOnlyVector4(Vector3 v) => new ReadOnlyVector4(v);
        public static implicit operator Vector3(ReadOnlyVector4 v) => v._vector4;
        public static implicit operator ReadOnlyVector4(Vector2 v) => new ReadOnlyVector4(v);
        public static implicit operator Vector2(ReadOnlyVector4 v) => v._vector4;
        public static implicit operator ReadOnlyVector4(ReadOnlyVector3 v) => new ReadOnlyVector4(v);
        public static implicit operator ReadOnlyVector3(ReadOnlyVector4 v) => new ReadOnlyVector3((Vector3) v);
        public static implicit operator ReadOnlyVector4(ReadOnlyVector2 v) => new ReadOnlyVector4(v);
        public static implicit operator ReadOnlyVector2(ReadOnlyVector4 v) => new ReadOnlyVector2(v);
    }

    public static class Vector4Extensions
    {
        public static ReadOnlyVector4 AsReadOnly(this Vector4 self) => new ReadOnlyVector4(self);
    }
}