using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCubemap
    {
        TextureFormat format { get; }
        bool isReadable { get; }
        int mipmapCount { get; }
        // void Apply(bool updateMipmaps, bool makeNoLongerReadable);
        // void Apply(bool updateMipmaps);
        // void Apply();
        Color GetPixel(CubemapFace face, int x, int y);
        Color[] GetPixels(CubemapFace face, int miplevel);
        Color[] GetPixels(CubemapFace face);
        // void SetPixel(CubemapFace face, int x, int y, Color color);
        // void SetPixels(Color[] colors, CubemapFace face, int miplevel);
        // void SetPixels(Color[] colors, CubemapFace face);
        // void SmoothEdges(int smoothRegionWidthInPixels);
        // void SmoothEdges();
    }

    public sealed class ReadOnlyCubemap : ReadOnlyTexture<Cubemap>, IReadOnlyCubemap
    {
        public ReadOnlyCubemap(Cubemap obj) : base(obj)
        {
        }

        #region Properties

        public TextureFormat format => _obj.format;
        public override bool isReadable => _obj.isReadable;
        public int mipmapCount => _obj.mipmapCount;

        #endregion

        #region Public Methods

        // public void Apply(bool updateMipmaps, bool makeNoLongerReadable) => _obj.Apply(updateMipmaps, makeNoLongerReadable);
        // public void Apply(bool updateMipmaps) => _obj.Apply(updateMipmaps);
        // public void Apply() => _obj.Apply();
        public Color GetPixel(CubemapFace face, int x, int y) => _obj.GetPixel(face, x, y);
        public Color[] GetPixels(CubemapFace face, int miplevel) => _obj.GetPixels(face, miplevel);
        public Color[] GetPixels(CubemapFace face) => _obj.GetPixels(face);
        // public void SetPixel(CubemapFace face, int x, int y, Color color) => _obj.SetPixel(face, x, y, color);
        // public void SetPixels(Color[] colors, CubemapFace face, int miplevel) => _obj.SetPixels(colors, face, miplevel);
        // public void SetPixels(Color[] colors, CubemapFace face) => _obj.SetPixels(colors, face);
        // public void SmoothEdges(int smoothRegionWidthInPixels) => _obj.SmoothEdges(smoothRegionWidthInPixels);
        // public void SmoothEdges() => _obj.SmoothEdges();

        #endregion
    }

    public static class CubemapExtensions
    {
        public static ReadOnlyCubemap AsReadOnly(this Cubemap self) => self.IsTrulyNull() ? null : new ReadOnlyCubemap(self);
    }
}