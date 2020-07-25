using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRenderTexture
    {
        int antiAliasing { get; }
        bool autoGenerateMips { get; }
        bool bindTextureMS { get; }
        RenderBuffer colorBuffer { get; }
        int depth { get; }
        RenderBuffer depthBuffer { get; }
        RenderTextureDescriptor descriptor { get; }
        TextureDimension dimension { get; }
        bool enableRandomWrite { get; }
        RenderTextureFormat format { get; }
        int height { get; }
        bool isPowerOfTwo { get; }
        RenderTextureMemoryless memorylessMode { get; }
        bool sRGB { get; }
        bool useDynamicScale { get; }
        bool useMipMap { get; }
        int volumeDepth { get; }
        VRTextureUsage vrUsage { get; }
        int width { get; }
        void ConvertToEquirect(RenderTexture equirect, Camera.MonoOrStereoscopicEye eye);
        // bool Create();
        // void DiscardContents(bool discardColor, bool discardDepth);
        // void DiscardContents();
        // void GenerateMips();
        IntPtr GetNativeDepthBufferPtr();
        bool IsCreated();
        // void MarkRestoreExpected();
        // void Release();
        // void ResolveAntiAliasedSurface();
        // void ResolveAntiAliasedSurface(RenderTexture target);
        // void SetGlobalShaderProperty(string propertyName);
    }

    public class ReadOnlyRenderTexture<T> : ReadOnlyTexture<T>, IReadOnlyRenderTexture where T : RenderTexture
    {
        protected ReadOnlyRenderTexture(T obj) : base(obj)
        {
        }

        #region Properties

        public int antiAliasing => _obj.antiAliasing;
        public bool autoGenerateMips => _obj.autoGenerateMips;
        public bool bindTextureMS => _obj.bindTextureMS;
        public RenderBuffer colorBuffer => _obj.colorBuffer;
        public int depth => _obj.depth;
        public RenderBuffer depthBuffer => _obj.depthBuffer;
        public RenderTextureDescriptor descriptor => _obj.descriptor;
        public override TextureDimension dimension => _obj.dimension;
        public bool enableRandomWrite => _obj.enableRandomWrite;
        public RenderTextureFormat format => _obj.format;
        public override int height => _obj.height;
        public bool isPowerOfTwo => _obj.isPowerOfTwo;
        public RenderTextureMemoryless memorylessMode => _obj.memorylessMode;
        public bool sRGB => _obj.sRGB;
        public bool useDynamicScale => _obj.useDynamicScale;
        public bool useMipMap => _obj.useMipMap;
        public int volumeDepth => _obj.volumeDepth;
        public VRTextureUsage vrUsage => _obj.vrUsage;
        public override int width => _obj.width;

        #endregion

        #region Public Methods

        public void ConvertToEquirect(RenderTexture equirect, Camera.MonoOrStereoscopicEye eye) => _obj.ConvertToEquirect(equirect, eye);
        // public bool Create() => _obj.Create();
        // public void DiscardContents(bool discardColor, bool discardDepth) => _obj.DiscardContents(discardColor, discardDepth);
        // public void DiscardContents() => _obj.DiscardContents();
        // public void GenerateMips() => _obj.GenerateMips();
        public IntPtr GetNativeDepthBufferPtr() => _obj.GetNativeDepthBufferPtr();
        public bool IsCreated() => _obj.IsCreated();
        // public void MarkRestoreExpected() => _obj.MarkRestoreExpected();
        // public void Release() => _obj.Release();
        // public void ResolveAntiAliasedSurface() => _obj.ResolveAntiAliasedSurface();
        // public void ResolveAntiAliasedSurface(RenderTexture target) => _obj.ResolveAntiAliasedSurface(target);
        // public void SetGlobalShaderProperty(string propertyName) => _obj.SetGlobalShaderProperty(propertyName);

        #endregion
    }

    public sealed class ReadOnlyRenderTexture : ReadOnlyRenderTexture<RenderTexture>
    {
        public ReadOnlyRenderTexture(RenderTexture obj) : base(obj)
        {
        }
    }

    public static class RenderTextureExtensions
    {
        public static ReadOnlyRenderTexture AsReadOnly(this RenderTexture self) => self.IsTrulyNull() ? null : new ReadOnlyRenderTexture(self);
    }
}