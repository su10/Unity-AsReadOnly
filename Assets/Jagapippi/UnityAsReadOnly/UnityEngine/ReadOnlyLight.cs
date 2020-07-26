using UnityEngine;
using UnityEngine.Rendering;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyLight
    {
#if UNITY_EDITOR
        Vector2 areaSize { get; }
#endif
        LightBakingOutput bakingOutput { get; }
        float bounceIntensity { get; }
        Color color { get; }
        float colorTemperature { get; }
        int commandBufferCount { get; }
        IReadOnlyTexture cookie { get; }
        float cookieSize { get; }
        int cullingMask { get; }
        Flare flare { get; }
        float intensity { get; }
        float[] layerShadowCullDistances { get; }
#if UNITY_EDITOR
        LightmapBakeType lightmapBakeType { get; }
#endif
        LightShadowCasterMode lightShadowCasterMode { get; }
        float range { get; }
        LightRenderMode renderMode { get; }
#if UNITY_EDITOR
        float shadowAngle { get; }
#endif
        float shadowBias { get; }
        int shadowCustomResolution { get; }
        float shadowNearPlane { get; }
        float shadowNormalBias { get; }
#if UNITY_EDITOR
        float shadowRadius { get; }
#endif
        LightShadowResolution shadowResolution { get; }
        LightShadows shadows { get; }
        float shadowStrength { get; }
        float spotAngle { get; }
        LightType type { get; }
        // void AddCommandBuffer(LightEvent evt, CommandBuffer buffer);
        // void AddCommandBuffer(LightEvent evt, CommandBuffer buffer, ShadowMapPass shadowPassMask);
        // void AddCommandBufferAsync(LightEvent evt, CommandBuffer buffer, ComputeQueueType queueType);
        // void AddCommandBufferAsync(LightEvent evt, CommandBuffer buffer, ShadowMapPass shadowPassMask, ComputeQueueType queueType);
        // CommandBuffer[] GetCommandBuffers(LightEvent evt);
        // void RemoveAllCommandBuffers();
        // void RemoveCommandBuffer(LightEvent evt, CommandBuffer buffer);
        // void RemoveCommandBuffers(LightEvent evt);
        // void Reset();
        // void SetLightDirty();
    }

    public sealed class ReadOnlyLight : ReadOnlyBehaviour<Light>, IReadOnlyLight
    {
        public ReadOnlyLight(Light obj) : base(obj)
        {
        }

        #region Properties

#if UNITY_EDITOR
        public Vector2 areaSize => _obj.areaSize;
#endif
        public LightBakingOutput bakingOutput => _obj.bakingOutput;
        public float bounceIntensity => _obj.bounceIntensity;
        public Color color => _obj.color;
        public float colorTemperature => _obj.colorTemperature;
        public int commandBufferCount => _obj.commandBufferCount;
        public ReadOnlyTexture cookie => _obj.cookie.AsReadOnly();
        IReadOnlyTexture IReadOnlyLight.cookie => this.cookie;
        public float cookieSize => _obj.cookieSize;
        public int cullingMask => _obj.cullingMask;
        public Flare flare => _obj.flare;
        public float intensity => _obj.intensity;
        public float[] layerShadowCullDistances => _obj.layerShadowCullDistances;
#if UNITY_EDITOR
        public LightmapBakeType lightmapBakeType => _obj.lightmapBakeType;
#endif
        public LightShadowCasterMode lightShadowCasterMode => _obj.lightShadowCasterMode;
        public float range => _obj.range;
        public LightRenderMode renderMode => _obj.renderMode;
#if UNITY_EDITOR
        public float shadowAngle => _obj.shadowAngle;
#endif
        public float shadowBias => _obj.shadowBias;
        public int shadowCustomResolution => _obj.shadowCustomResolution;
        public float shadowNearPlane => _obj.shadowNearPlane;
        public float shadowNormalBias => _obj.shadowNormalBias;
#if UNITY_EDITOR
        public float shadowRadius => _obj.shadowRadius;
#endif
        public LightShadowResolution shadowResolution => _obj.shadowResolution;
        public LightShadows shadows => _obj.shadows;
        public float shadowStrength => _obj.shadowStrength;
        public float spotAngle => _obj.spotAngle;
        public LightType type => _obj.type;

        #endregion

        #region Public Methods

        // public void AddCommandBuffer(LightEvent evt, CommandBuffer buffer) => _obj.AddCommandBuffer(evt, buffer);
        // public void AddCommandBuffer(LightEvent evt, CommandBuffer buffer, ShadowMapPass shadowPassMask) => _obj.AddCommandBuffer(evt, buffer, shadowPassMask);
        // public void AddCommandBufferAsync(LightEvent evt, CommandBuffer buffer, ComputeQueueType queueType) => _obj.AddCommandBufferAsync(evt, buffer, queueType);
        // public void AddCommandBufferAsync(LightEvent evt, CommandBuffer buffer, ShadowMapPass shadowPassMask, ComputeQueueType queueType) => _obj.AddCommandBufferAsync(evt, buffer, shadowPassMask, queueType);
        // public CommandBuffer[] GetCommandBuffers(LightEvent evt) => _obj.GetCommandBuffers(evt);
        // public void RemoveAllCommandBuffers() => _obj.RemoveAllCommandBuffers();
        // public void RemoveCommandBuffer(LightEvent evt, CommandBuffer buffer) => _obj.RemoveCommandBuffer(evt, buffer);
        // public void RemoveCommandBuffers(LightEvent evt) => _obj.RemoveCommandBuffers(evt);
        // public void Reset() => _obj.Reset();
        // public void SetLightDirty() => _obj.SetLightDirty();

        #endregion
    }

    public static class LightExtensions
    {
        public static ReadOnlyLight AsReadOnly(this Light self) => self.IsTrulyNull() ? null : new ReadOnlyLight(self);
    }
}