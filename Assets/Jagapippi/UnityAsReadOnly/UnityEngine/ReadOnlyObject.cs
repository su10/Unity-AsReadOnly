using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyObject
    {
        HideFlags hideFlags { get; }
        string name { get; }
        int GetInstanceID();
        string ToString();
    }

    public class ReadOnlyObject<T> : IReadOnlyObject where T : Object
    {
        protected readonly T _obj;

        protected ReadOnlyObject(T obj)
        {
            if (ReferenceEquals(obj, null)) throw new ArgumentNullException(nameof(obj));

            _obj = obj;
        }

        #region Properties

        public HideFlags hideFlags => _obj.hideFlags;
        public string name => _obj.name;

        #endregion

        #region Public Methods

        public int GetInstanceID() => _obj.GetInstanceID();
        public override string ToString() => _obj.ToString();

        #endregion

        #region Operators

        public static implicit operator bool(ReadOnlyObject<T> self) => (ReferenceEquals(self, null) == false) && self._obj;

        public static bool operator ==(ReadOnlyObject<T> lhs, ReadOnlyObject<T> rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return true;
            if (lhs && rhs) return (lhs._obj == rhs._obj);
            if (lhs) return (lhs._obj == rhs);
            if (rhs) return (lhs == rhs._obj);
            return true;
        }

        public static bool operator !=(ReadOnlyObject<T> x, ReadOnlyObject<T> y) => !(x == y);

        public override bool Equals(object other)
        {
            if (other == null) return _obj.Equals(other);
            if (other is ReadOnlyObject<T> readOnlyOther) return (this == readOnlyOther);
            if (other is Object obj) return (this == obj);

            return false;
        }

        public override int GetHashCode() => _obj.GetHashCode();

        #endregion
    }

    public class ReadOnlyObject : ReadOnlyObject<Object>
    {
        public ReadOnlyObject(Object obj) : base(obj)
        {
        }
    }

    public static class ObjectExtensions
    {
        public static ReadOnlyObject AsReadOnly(this Object self) => new ReadOnlyObject(self);
    }
}