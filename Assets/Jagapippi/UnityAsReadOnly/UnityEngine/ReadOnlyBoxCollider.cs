using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyBoxCollider
    {
        Vector3 center { get; }
        Vector3 size { get; }
    }

    public class ReadOnlyBoxCollider<T> : ReadOnlyCollider<T>, IReadOnlyBoxCollider where T : BoxCollider
    {
        protected ReadOnlyBoxCollider(T obj) : base(obj)
        {
        }

        #region Properties

        public Vector3 center => _obj.center;
        public Vector3 size => _obj.size;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyBoxCollider : ReadOnlyBoxCollider<BoxCollider>
    {
        public ReadOnlyBoxCollider(BoxCollider obj) : base(obj)
        {
        }
    }

    public static class BoxColliderExtensions
    {
        public static ReadOnlyBoxCollider AsReadOnly(this BoxCollider self) => new ReadOnlyBoxCollider(self);
    }
}