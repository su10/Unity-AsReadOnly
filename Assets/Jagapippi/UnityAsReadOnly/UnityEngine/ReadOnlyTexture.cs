using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTexture
    {
        int anisoLevel { get; }
        TextureDimension dimension { get; }
        FilterMode filterMode { get; }
        int height { get; }
#if UNITY_EDITOR
        Hash128 imageContentsHash { get; }
#endif
        bool isReadable { get; }
        float mipMapBias { get; }
        Vector2 texelSize { get; }
        uint updateCount { get; }
        int width { get; }
        TextureWrapMode wrapMode { get; }
        TextureWrapMode wrapModeU { get; }
        TextureWrapMode wrapModeV { get; }
        TextureWrapMode wrapModeW { get; }
        IntPtr GetNativeTexturePtr();
        // void IncrementUpdateCount();
    }

    public abstract class ReadOnlyTexture<T> : ReadOnlyObject<T>, IReadOnlyTexture where T : Texture
    {
        protected ReadOnlyTexture(T obj) : base(obj)
        {
        }

        #region Properties

        public int anisoLevel => _obj.anisoLevel;
        public virtual TextureDimension dimension => _obj.dimension;
        public FilterMode filterMode => _obj.filterMode;
        public virtual int height => _obj.height;
#if UNITY_EDITOR
        public Hash128 imageContentsHash => _obj.imageContentsHash;
#endif
        public virtual bool isReadable => _obj.isReadable;
        public float mipMapBias => _obj.mipMapBias;
        public Vector2 texelSize => _obj.texelSize;
        public uint updateCount => _obj.updateCount;
        public virtual int width => _obj.width;
        public TextureWrapMode wrapMode => _obj.wrapMode;
        public TextureWrapMode wrapModeU => _obj.wrapModeU;
        public TextureWrapMode wrapModeV => _obj.wrapModeV;
        public TextureWrapMode wrapModeW => _obj.wrapModeW;

        #endregion

        #region Public Methods

        public IntPtr GetNativeTexturePtr() => _obj.GetNativeTexturePtr();
        // public void IncrementUpdateCount() => _obj.IncrementUpdateCount();

        #endregion
    }

    public sealed class ReadOnlyTexture : ReadOnlyTexture<Texture>
    {
        public ReadOnlyTexture(Texture obj) : base(obj)
        {
        }
    }

    public static class TextureExtensions
    {
        public static ReadOnlyTexture AsReadOnly(this Texture self) => self.IsTrulyNull() ? null : new ReadOnlyTexture(self);
    }
}