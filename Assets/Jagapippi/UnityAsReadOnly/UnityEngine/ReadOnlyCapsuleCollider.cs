using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCapsuleCollider
    {
        Vector3 center { get; }
        int direction { get; }
        float height { get; }
        float radius { get; }
    }

    public class ReadOnlyCapsuleCollider<T> : ReadOnlyCollider<T>, IReadOnlyCapsuleCollider where T : CapsuleCollider
    {
        protected ReadOnlyCapsuleCollider(T obj) : base(obj)
        {
        }

        #region Properties

        public Vector3 center => _obj.center;
        public int direction => _obj.direction;
        public float height => _obj.height;
        public float radius => _obj.radius;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyCapsuleCollider : ReadOnlyCapsuleCollider<CapsuleCollider>
    {
        public ReadOnlyCapsuleCollider(CapsuleCollider obj) : base(obj)
        {
        }
    }

    public static class CapsuleColliderExtensions
    {
        public static ReadOnlyCapsuleCollider AsReadOnly(this CapsuleCollider self) => self.IsTrulyNull() ? null : new ReadOnlyCapsuleCollider(self);
    }
}