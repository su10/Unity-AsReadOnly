using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public sealed class ReadOnlyQuaternion : IEquatable<Quaternion>
    {
        internal readonly Quaternion _quaternion;

        public ReadOnlyQuaternion(float x, float y, float z, float w)
        {
            _quaternion = new Quaternion(x, y, z, w);
        }

        public ReadOnlyQuaternion(Quaternion quaternion)
        {
            _quaternion = quaternion;
        }

        #region Properties

        public float x => _quaternion.x;
        public float y => _quaternion.y;
        public float z => _quaternion.z;
        public float w => _quaternion.w;
        public float this[int index] => _quaternion[index];
        public Vector3 eulerAngles => _quaternion.eulerAngles;
        public Quaternion normalized => _quaternion.normalized;

        #endregion

        #region Public Methods

        public override bool Equals(object other) => _quaternion.Equals(other);
        public bool Equals(Quaternion other) => _quaternion.Equals(other);
        public override int GetHashCode() => _quaternion.GetHashCode();
        // public void Normalize() => _quaternion.Normalize();
        // public void Set(float newX, float newY, float newZ, float newW) => _quaternion.Set(newX, newY, newZ, newW);
        // public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection) => _quaternion.SetFromToRotation(fromDirection, toDirection);
        // public void SetLookRotation(Vector3 view) => _quaternion.SetLookRotation(view);
        // public void SetLookRotation(Vector3 view, Vector3 up) => _quaternion.SetLookRotation(view, up);
        // public void ToAngleAxis(out float angle, out Vector3 axis) => _quaternion.ToAngleAxis(out angle, out axis);
        public override string ToString() => _quaternion.ToString();
        public string ToString(string format) => _quaternion.ToString(format);

        #endregion

        #region Operators

        public static ReadOnlyQuaternion operator *(ReadOnlyQuaternion lhs, ReadOnlyQuaternion rhs) => (lhs._quaternion * rhs._quaternion).AsReadOnly();
        public static ReadOnlyQuaternion operator *(ReadOnlyQuaternion lhs, Quaternion rhs) => (lhs._quaternion * rhs).AsReadOnly();
        public static ReadOnlyQuaternion operator *(Quaternion lhs, ReadOnlyQuaternion rhs) => (lhs * rhs._quaternion).AsReadOnly();
        public static ReadOnlyVector3 operator *(ReadOnlyQuaternion rotation, ReadOnlyVector3 point) => (rotation._quaternion * point._vector3).AsReadOnly();
        public static ReadOnlyVector3 operator *(ReadOnlyQuaternion rotation, Vector3 point) => (rotation._quaternion * point).AsReadOnly();
        public static bool operator ==(ReadOnlyQuaternion lhs, ReadOnlyQuaternion rhs) => (lhs._quaternion == rhs._quaternion);
        public static bool operator !=(ReadOnlyQuaternion lhs, ReadOnlyQuaternion rhs) => !(lhs == rhs);
        public static bool operator ==(ReadOnlyQuaternion lhs, Quaternion rhs) => (lhs._quaternion == rhs);
        public static bool operator !=(ReadOnlyQuaternion lhs, Quaternion rhs) => !(lhs == rhs);
        public static bool operator ==(Quaternion lhs, ReadOnlyQuaternion rhs) => (lhs == rhs._quaternion);
        public static bool operator !=(Quaternion lhs, ReadOnlyQuaternion rhs) => !(lhs == rhs);
        public static implicit operator ReadOnlyQuaternion(Quaternion v) => new ReadOnlyQuaternion(v);
        public static implicit operator Quaternion(ReadOnlyQuaternion v) => v._quaternion;

        #endregion
    }

    public static class QuaternionExtensions
    {
        public static ReadOnlyQuaternion AsReadOnly(this Quaternion self) => new ReadOnlyQuaternion(self);
    }
}