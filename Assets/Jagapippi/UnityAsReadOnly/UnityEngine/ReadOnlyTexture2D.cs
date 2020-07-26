using Unity.Collections;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTexture2D
    {
#if UNITY_EDITOR
        bool alphaIsTransparency { get; }
#endif
        int desiredMipmapLevel { get; }
        TextureFormat format { get; }
        bool isReadable { get; }
        int loadedMipmapLevel { get; }
        int loadingMipmapLevel { get; }
        int mipmapCount { get; }
        int requestedMipmapLevel { get; }
        bool streamingMipmaps { get; }
        int streamingMipmapsPriority { get; }
        // void Apply(bool updateMipmaps, bool makeNoLongerReadable);
        // void Apply(bool updateMipmaps);
        // void Apply();
        // void ClearRequestedMipmapLevel();
        // void Compress(bool highQuality);
        Color GetPixel(int x, int y);
        Color GetPixelBilinear(float x, float y);
        Color[] GetPixels(int x, int y, int blockWidth, int blockHeight, int miplevel);
        Color[] GetPixels(int x, int y, int blockWidth, int blockHeight);
        Color[] GetPixels(int miplevel);
        Color[] GetPixels();
        Color32[] GetPixels32(int miplevel);
        Color32[] GetPixels32();
        byte[] GetRawTextureData();
        NativeArray<T> GetRawTextureData<T>() where T : struct;
        bool IsRequestedMipmapLevelLoaded();
        // void LoadRawTextureData(IntPtr data, int size);
        // void LoadRawTextureData(byte[] data);
        // void LoadRawTextureData<T>(NativeArray<T> data) where T : struct;
        // Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable);
        // Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize);
        // Rect[] PackTextures(Texture2D[] textures, int padding);
        // void ReadPixels(Rect source, int destX, int destY, bool recalculateMipMaps);
        // void ReadPixels(Rect source, int destX, int destY);
        // bool Resize(int width, int height);
        // bool Resize(int width, int height, TextureFormat format, bool hasMipMap);
        // void SetPixel(int x, int y, Color color);
        // void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, int miplevel);
        // void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors);
        // void SetPixels(Color[] colors, int miplevel);
        // void SetPixels(Color[] colors);
        // void SetPixels32(Color32[] colors, int miplevel);
        // void SetPixels32(Color32[] colors);
        // void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, int miplevel);
        // void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors);
        // void UpdateExternalTexture(IntPtr nativeTex);
    }

    public sealed class ReadOnlyTexture2D : ReadOnlyTexture<Texture2D>, IReadOnlyTexture2D
    {
        public ReadOnlyTexture2D(Texture2D obj) : base(obj)
        {
        }

        #region Properties

#if UNITY_EDITOR
        public bool alphaIsTransparency => _obj.alphaIsTransparency;
#endif
        public int desiredMipmapLevel => _obj.desiredMipmapLevel;
        public TextureFormat format => _obj.format;
        public override bool isReadable => _obj.isReadable;
        public int loadedMipmapLevel => _obj.loadedMipmapLevel;
        public int loadingMipmapLevel => _obj.loadingMipmapLevel;
        public int mipmapCount => _obj.mipmapCount;
        public int requestedMipmapLevel => _obj.requestedMipmapLevel;
        public bool streamingMipmaps => _obj.streamingMipmaps;
        public int streamingMipmapsPriority => _obj.streamingMipmapsPriority;

        #endregion

        #region Public Methods

        // public void Apply(bool updateMipmaps, bool makeNoLongerReadable) => _obj.Apply(updateMipmaps, makeNoLongerReadable);
        // public void Apply(bool updateMipmaps) => _obj.Apply(updateMipmaps);
        // public void Apply() => _obj.Apply();
        // public void ClearRequestedMipmapLevel() => _obj.ClearRequestedMipmapLevel();
        // public void Compress(bool highQuality) => _obj.Compress(highQuality);
        public Color GetPixel(int x, int y) => _obj.GetPixel(x, y);
        public Color GetPixelBilinear(float x, float y) => _obj.GetPixelBilinear(x, y);
        public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight, int miplevel) => _obj.GetPixels(x, y, blockWidth, blockHeight, miplevel);
        public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight) => _obj.GetPixels(x, y, blockWidth, blockHeight);
        public Color[] GetPixels(int miplevel) => _obj.GetPixels(miplevel);
        public Color[] GetPixels() => _obj.GetPixels();
        public Color32[] GetPixels32(int miplevel) => _obj.GetPixels32(miplevel);
        public Color32[] GetPixels32() => _obj.GetPixels32();
        public byte[] GetRawTextureData() => _obj.GetRawTextureData();
        public NativeArray<T> GetRawTextureData<T>() where T : struct => _obj.GetRawTextureData<T>();
        public bool IsRequestedMipmapLevelLoaded() => _obj.IsRequestedMipmapLevelLoaded();
        // public void LoadRawTextureData(IntPtr data, int size) => _obj.LoadRawTextureData(data, size);
        // public void LoadRawTextureData(byte[] data) => _obj.LoadRawTextureData(data);
        // public void LoadRawTextureData<T>(NativeArray<T> data) where T : struct => _obj.LoadRawTextureData<T>(data);
        // public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable) => _obj.PackTextures(textures, padding, maximumAtlasSize, makeNoLongerReadable);
        // public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize) => _obj.PackTextures(textures, padding, maximumAtlasSize);
        // public Rect[] PackTextures(Texture2D[] textures, int padding) => _obj.PackTextures(textures, padding);
        // public void ReadPixels(Rect source, int destX, int destY, bool recalculateMipMaps) => _obj.ReadPixels(source, destX, destY, recalculateMipMaps);
        // public void ReadPixels(Rect source, int destX, int destY) => _obj.ReadPixels(source, destX, destY);
        // public bool Resize(int width, int height) => _obj.Resize(width, height);
        // public bool Resize(int width, int height, TextureFormat format, bool hasMipMap) => _obj.Resize(width, height, format, hasMipMap);
        // public void SetPixel(int x, int y, Color color) => _obj.SetPixel(x, y, color);
        // public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, int miplevel) => _obj.SetPixels(x, y, blockWidth, blockHeight, colors, miplevel);
        // public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors) => _obj.SetPixels(x, y, blockWidth, blockHeight, colors);
        // public void SetPixels(Color[] colors, int miplevel) => _obj.SetPixels(colors, miplevel);
        // public void SetPixels(Color[] colors) => _obj.SetPixels(colors);
        // public void SetPixels32(Color32[] colors, int miplevel) => _obj.SetPixels32(colors, miplevel);
        // public void SetPixels32(Color32[] colors) => _obj.SetPixels32(colors);
        // public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, int miplevel) => _obj.SetPixels32(x, y, blockWidth, blockHeight, colors, miplevel);
        // public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors) => _obj.SetPixels32(x, y, blockWidth, blockHeight, colors);
        // public void UpdateExternalTexture(IntPtr nativeTex) => _obj.UpdateExternalTexture(nativeTex);

        #endregion
    }

    public static class Texture2DExtensions
    {
        public static ReadOnlyTexture2D AsReadOnly(this Texture2D self) => self.IsTrulyNull() ? null : new ReadOnlyTexture2D(self);
    }
}