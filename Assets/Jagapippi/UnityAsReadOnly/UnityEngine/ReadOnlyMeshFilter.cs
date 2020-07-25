using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMeshFilter
    {
        IReadOnlyMesh mesh { get; }
        IReadOnlyMesh sharedMesh { get; }
    }

    public sealed class ReadOnlyMeshFilter : ReadOnlyComponent<MeshFilter>, IReadOnlyMeshFilter
    {
        public ReadOnlyMeshFilter(MeshFilter obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyMesh mesh => _obj.mesh.AsReadOnly();
        IReadOnlyMesh IReadOnlyMeshFilter.mesh => this.mesh;
        public ReadOnlyMesh sharedMesh => _obj.sharedMesh.AsReadOnly();
        IReadOnlyMesh IReadOnlyMeshFilter.sharedMesh => this.sharedMesh;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class MeshFilterExtensions
    {
        public static ReadOnlyMeshFilter AsReadOnly(this MeshFilter self) => self.IsTrulyNull() ? null : new ReadOnlyMeshFilter(self);
    }
}