using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlySphereCollider
    {
        Vector3 center { get; }
        float radius { get; }
    }

    public class ReadOnlySphereCollider<T> : ReadOnlyCollider<T>, IReadOnlySphereCollider where T : SphereCollider
    {
        protected ReadOnlySphereCollider(T obj) : base(obj)
        {
        }

        #region Properties

        public Vector3 center => _obj.center;
        public float radius => _obj.radius;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlySphereCollider : ReadOnlySphereCollider<SphereCollider>
    {
        public ReadOnlySphereCollider(SphereCollider obj) : base(obj)
        {
        }
    }

    public static class SphereColliderExtensions
    {
        public static ReadOnlySphereCollider AsReadOnly(this SphereCollider self) => self.IsTrulyNull() ? null : new ReadOnlySphereCollider(self);
    }
}