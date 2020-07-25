using System.Linq;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTerrainData
    {
        int alphamapHeight { get; }
        int alphamapLayers { get; }
        int alphamapResolution { get; }
        int alphamapTextureCount { get; }
        IReadOnlyTexture2D[] alphamapTextures { get; }
        int alphamapWidth { get; }
        int baseMapResolution { get; }
        Bounds bounds { get; }
        int detailHeight { get; }
        int detailPatchCount { get; }
        IReadOnlyDetailPrototype[] detailPrototypes { get; }
        int detailResolution { get; }
        int detailResolutionPerPatch { get; }
        int detailWidth { get; }
        int heightmapHeight { get; }
        int heightmapResolution { get; }
        Vector3 heightmapScale { get; }
        IReadOnlyRenderTexture heightmapTexture { get; }
        int heightmapWidth { get; }
        Vector3 size { get; }
        IReadOnlyTerrainLayer[] terrainLayers { get; }
        float thickness { get; }
        int treeInstanceCount { get; }
        TreeInstance[] treeInstances { get; }
        IReadOnlyTreePrototype[] treePrototypes { get; }
        float wavingGrassAmount { get; }
        float wavingGrassSpeed { get; }
        float wavingGrassStrength { get; }
        Color wavingGrassTint { get; }
        float[,,] GetAlphamaps(int x, int y, int width, int height);
        IReadOnlyTexture2D GetAlphamapTexture(int index);
        int[,] GetDetailLayer(int xBase, int yBase, int width, int height, int layer);
        float GetHeight(int x, int y);
        float[,] GetHeights(int xBase, int yBase, int width, int height);
        float GetInterpolatedHeight(float x, float y);
        Vector3 GetInterpolatedNormal(float x, float y);
        float[] GetMaximumHeightError();
        PatchExtents[] GetPatchMinMaxHeights();
        float GetSteepness(float x, float y);
        int[] GetSupportedLayers(int xBase, int yBase, int totalWidth, int totalHeight);
        TreeInstance GetTreeInstance(int index);
        // void OverrideMaximumHeightError(float[] maxError);
        // void OverrideMinMaxPatchHeights(PatchExtents[] minMaxHeights);
        // void RefreshPrototypes();
        // void SetAlphamaps(int x, int y, float[,,] map);
        // void SetBaseMapDirty();
        // void SetDetailLayer(int xBase, int yBase, int layer, int[,] details);
        // void SetDetailResolution(int detailResolution, int resolutionPerPatch);
        // void SetHeights(int xBase, int yBase, float[,] heights);
        // void SetHeightsDelayLOD(int xBase, int yBase, float[,] heights);
        // void SetTreeInstance(int index, TreeInstance instance);
        // void UpdateDirtyRegion(int x, int y, int width, int height, bool syncHeightmapTextureImmediately);
    }

    public sealed class ReadOnlyTerrainData : ReadOnlyObject<TerrainData>, IReadOnlyTerrainData
    {
        public ReadOnlyTerrainData(TerrainData obj) : base(obj)
        {
        }

        #region Properties

        public int alphamapHeight => _obj.alphamapHeight;
        public int alphamapLayers => _obj.alphamapLayers;
        public int alphamapResolution => _obj.alphamapResolution;
        public int alphamapTextureCount => _obj.alphamapTextureCount;
        public ReadOnlyTexture2D[] alphamapTextures => _obj.alphamapTextures?.Select(t => t.AsReadOnly()).ToArray();
        IReadOnlyTexture2D[] IReadOnlyTerrainData.alphamapTextures => this.alphamapTextures;
        public int alphamapWidth => _obj.alphamapWidth;
        public int baseMapResolution => _obj.baseMapResolution;
        public Bounds bounds => _obj.bounds;
        public int detailHeight => _obj.detailHeight;
        public int detailPatchCount => _obj.detailPatchCount;
        public ReadOnlyDetailPrototype[] detailPrototypes => _obj.detailPrototypes?.Select(d => d.AsReadOnly()).ToArray();
        IReadOnlyDetailPrototype[] IReadOnlyTerrainData.detailPrototypes => this.detailPrototypes;
        public int detailResolution => _obj.detailResolution;
        public int detailResolutionPerPatch => _obj.detailResolutionPerPatch;
        public int detailWidth => _obj.detailWidth;
        public int heightmapHeight => _obj.heightmapHeight;
        public int heightmapResolution => _obj.heightmapResolution;
        public Vector3 heightmapScale => _obj.heightmapScale;
        public ReadOnlyRenderTexture heightmapTexture => _obj.heightmapTexture.AsReadOnly();
        IReadOnlyRenderTexture IReadOnlyTerrainData.heightmapTexture => this.heightmapTexture;
        public int heightmapWidth => _obj.heightmapWidth;
        public Vector3 size => _obj.size;
        public ReadOnlyTerrainLayer[] terrainLayers => _obj.terrainLayers?.Select(l => l.AsReadOnly()).ToArray();
        IReadOnlyTerrainLayer[] IReadOnlyTerrainData.terrainLayers => this.terrainLayers;
        public float thickness => _obj.thickness;
        public int treeInstanceCount => _obj.treeInstanceCount;
        public TreeInstance[] treeInstances => _obj.treeInstances;
        public ReadOnlyTreePrototype[] treePrototypes => _obj.treePrototypes?.Select(p => p.AsReadOnly()).ToArray();
        IReadOnlyTreePrototype[] IReadOnlyTerrainData.treePrototypes => this.treePrototypes;
        public float wavingGrassAmount => _obj.wavingGrassAmount;
        public float wavingGrassSpeed => _obj.wavingGrassSpeed;
        public float wavingGrassStrength => _obj.wavingGrassStrength;
        public Color wavingGrassTint => _obj.wavingGrassTint;

        #endregion

        #region Public Methods

        public float[,,] GetAlphamaps(int x, int y, int width, int height) => _obj.GetAlphamaps(x, y, width, height);
        public ReadOnlyTexture2D GetAlphamapTexture(int index) => _obj.GetAlphamapTexture(index).AsReadOnly();
        IReadOnlyTexture2D IReadOnlyTerrainData.GetAlphamapTexture(int index) => this.GetAlphamapTexture(index);
        public int[,] GetDetailLayer(int xBase, int yBase, int width, int height, int layer) => _obj.GetDetailLayer(xBase, yBase, width, height, layer);
        public float GetHeight(int x, int y) => _obj.GetHeight(x, y);
        public float[,] GetHeights(int xBase, int yBase, int width, int height) => _obj.GetHeights(xBase, yBase, width, height);
        public float GetInterpolatedHeight(float x, float y) => _obj.GetInterpolatedHeight(x, y);
        public Vector3 GetInterpolatedNormal(float x, float y) => _obj.GetInterpolatedNormal(x, y);
        public float[] GetMaximumHeightError() => _obj.GetMaximumHeightError();
        public PatchExtents[] GetPatchMinMaxHeights() => _obj.GetPatchMinMaxHeights();
        public float GetSteepness(float x, float y) => _obj.GetSteepness(x, y);
        public int[] GetSupportedLayers(int xBase, int yBase, int totalWidth, int totalHeight) => _obj.GetSupportedLayers(xBase, yBase, totalWidth, totalHeight);
        public TreeInstance GetTreeInstance(int index) => _obj.GetTreeInstance(index);
        // public void OverrideMaximumHeightError(float[] maxError) => _obj.OverrideMaximumHeightError(maxError);
        // public void OverrideMinMaxPatchHeights(PatchExtents[] minMaxHeights) => _obj.OverrideMinMaxPatchHeights(minMaxHeights);
        // public void RefreshPrototypes() => _obj.RefreshPrototypes();
        // public void SetAlphamaps(int x, int y, float[,,] map) => _obj.SetAlphamaps(x, y, map);
        // public void SetBaseMapDirty() => _obj.SetBaseMapDirty();
        // public void SetDetailLayer(int xBase, int yBase, int layer, int[,] details) => _obj.SetDetailLayer(xBase, yBase, layer, details);
        // public void SetDetailResolution(int detailResolution, int resolutionPerPatch) => _obj.SetDetailResolution(detailResolution, resolutionPerPatch);
        // public void SetHeights(int xBase, int yBase, float[,] heights) => _obj.SetHeights(xBase, yBase, heights);
        // public void SetHeightsDelayLOD(int xBase, int yBase, float[,] heights) => _obj.SetHeightsDelayLOD(xBase, yBase, heights);
        // public void SetTreeInstance(int index, TreeInstance instance) => _obj.SetTreeInstance(index, instance);
        // public void UpdateDirtyRegion(int x, int y, int width, int height, bool syncHeightmapTextureImmediately) => _obj.UpdateDirtyRegion(x, y, width, height, syncHeightmapTextureImmediately);

        #endregion
    }

    public static class TerrainDataExtensions
    {
        public static ReadOnlyTerrainData AsReadOnly(this TerrainData self) => self.IsTrulyNull() ? null : new ReadOnlyTerrainData(self);
    }
}