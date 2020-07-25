using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTerrainCollider
    {
        IReadOnlyTerrainData terrainData { get; }
    }

    public class ReadOnlyTerrainCollider<T> : ReadOnlyCollider<T>, IReadOnlyTerrainCollider where T : TerrainCollider
    {
        protected ReadOnlyTerrainCollider(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyTerrainData terrainData => _obj.terrainData.AsReadOnly();
        IReadOnlyTerrainData IReadOnlyTerrainCollider.terrainData => this.terrainData;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyTerrainCollider : ReadOnlyTerrainCollider<TerrainCollider>
    {
        public ReadOnlyTerrainCollider(TerrainCollider obj) : base(obj)
        {
        }
    }

    public static class TerrainColliderExtensions
    {
        public static ReadOnlyTerrainCollider AsReadOnly(this TerrainCollider self) => self.IsTrulyNull() ? null : new ReadOnlyTerrainCollider(self);
    }
}