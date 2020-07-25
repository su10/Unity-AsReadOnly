using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTerrainLayer
    {
        Vector4 diffuseRemapMax { get; }
        Vector4 diffuseRemapMin { get; }
        IReadOnlyTexture2D diffuseTexture { get; }
        Vector4 maskMapRemapMax { get; }
        Vector4 maskMapRemapMin { get; }
        IReadOnlyTexture2D maskMapTexture { get; }
        float metallic { get; }
        IReadOnlyTexture2D normalMapTexture { get; }
        float normalScale { get; }
        float smoothness { get; }
        Color specular { get; }
        Vector2 tileOffset { get; }
        Vector2 tileSize { get; }
    }

    public sealed class ReadOnlyTerrainLayer : ReadOnlyObject<TerrainLayer>, IReadOnlyTerrainLayer
    {
        public ReadOnlyTerrainLayer(TerrainLayer obj) : base(obj)
        {
        }

        #region Properties

        public Vector4 diffuseRemapMax => _obj.diffuseRemapMax;
        public Vector4 diffuseRemapMin => _obj.diffuseRemapMin;
        public ReadOnlyTexture2D diffuseTexture => _obj.diffuseTexture.AsReadOnly();
        IReadOnlyTexture2D IReadOnlyTerrainLayer.diffuseTexture => this.diffuseTexture;
        public Vector4 maskMapRemapMax => _obj.maskMapRemapMax;
        public Vector4 maskMapRemapMin => _obj.maskMapRemapMin;
        public ReadOnlyTexture2D maskMapTexture => _obj.maskMapTexture.AsReadOnly();
        IReadOnlyTexture2D IReadOnlyTerrainLayer.maskMapTexture => this.maskMapTexture;
        public float metallic => _obj.metallic;
        public ReadOnlyTexture2D normalMapTexture => _obj.normalMapTexture.AsReadOnly();
        IReadOnlyTexture2D IReadOnlyTerrainLayer.normalMapTexture => this.normalMapTexture;
        public float normalScale => _obj.normalScale;
        public float smoothness => _obj.smoothness;
        public Color specular => _obj.specular;
        public Vector2 tileOffset => _obj.tileOffset;
        public Vector2 tileSize => _obj.tileSize;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class TerrainLayerExtensions
    {
        public static ReadOnlyTerrainLayer AsReadOnly(this TerrainLayer self) => self.IsTrulyNull() ? null : new ReadOnlyTerrainLayer(self);
    }
}