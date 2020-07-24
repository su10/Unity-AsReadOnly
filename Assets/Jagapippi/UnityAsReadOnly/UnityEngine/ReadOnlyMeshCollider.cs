using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMeshCollider
    {
        bool convex { get; }
        MeshColliderCookingOptions cookingOptions { get; }
        IReadOnlyMesh sharedMesh { get; }
    }

    public class ReadOnlyMeshCollider<T> : ReadOnlyCollider<T>, IReadOnlyMeshCollider where T : MeshCollider
    {
        protected ReadOnlyMeshCollider(T obj) : base(obj)
        {
        }

        #region Properties

        public bool convex => _obj.convex;
        public MeshColliderCookingOptions cookingOptions => _obj.cookingOptions;
        public ReadOnlyMesh sharedMesh => _obj.sharedMesh.AsReadOnly();
        IReadOnlyMesh IReadOnlyMeshCollider.sharedMesh => this.sharedMesh;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyMeshCollider : ReadOnlyMeshCollider<MeshCollider>
    {
        public ReadOnlyMeshCollider(MeshCollider obj) : base(obj)
        {
        }
    }

    public static class MeshColliderExtensions
    {
        public static ReadOnlyMeshCollider AsReadOnly(this MeshCollider self) => new ReadOnlyMeshCollider(self);
    }
}