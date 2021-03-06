﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRenderer
    {
        bool allowOcclusionWhenDynamic { get; }
        Bounds bounds { get; }
        bool enabled { get; }
        bool isPartOfStaticBatch { get; }
        bool isVisible { get; }
        int lightmapIndex { get; }
        Vector4 lightmapScaleOffset { get; }
        IReadOnlyGameObject lightProbeProxyVolumeOverride { get; }
        LightProbeUsage lightProbeUsage { get; }
        Matrix4x4 localToWorldMatrix { get; }
        IReadOnlyMaterial material { get; }
        IReadOnlyMaterial[] materials { get; }
        MotionVectorGenerationMode motionVectorGenerationMode { get; }
        IReadOnlyTransform probeAnchor { get; }
        int realtimeLightmapIndex { get; }
        Vector4 realtimeLightmapScaleOffset { get; }
        bool receiveShadows { get; }
        ReflectionProbeUsage reflectionProbeUsage { get; }
        int rendererPriority { get; }
        uint renderingLayerMask { get; }
        ShadowCastingMode shadowCastingMode { get; }
        IReadOnlyMaterial sharedMaterial { get; }
        IReadOnlyMaterial[] sharedMaterials { get; }
        int sortingLayerID { get; }
        string sortingLayerName { get; }
        int sortingOrder { get; }
        Matrix4x4 worldToLocalMatrix { get; }
        void GetClosestReflectionProbes(List<ReflectionProbeBlendInfo> result);
        // void GetMaterials(List<Material> m);
        void GetPropertyBlock(MaterialPropertyBlock properties);
        void GetPropertyBlock(MaterialPropertyBlock properties, int materialIndex);
        // void GetSharedMaterials(List<Material> m);
        bool HasPropertyBlock();
        // void SetPropertyBlock(MaterialPropertyBlock properties);
        // void SetPropertyBlock(MaterialPropertyBlock properties, int materialIndex);
    }

    public abstract class ReadOnlyRenderer<T> : ReadOnlyComponent<T>, IReadOnlyRenderer where T : Renderer
    {
        protected ReadOnlyRenderer(T obj) : base(obj)
        {
        }

        #region Properties

        public bool allowOcclusionWhenDynamic => _obj.allowOcclusionWhenDynamic;
        public Bounds bounds => _obj.bounds;
        public bool enabled => _obj.enabled;
        public bool isPartOfStaticBatch => _obj.isPartOfStaticBatch;
        public bool isVisible => _obj.isVisible;
        public int lightmapIndex => _obj.lightmapIndex;
        public Vector4 lightmapScaleOffset => _obj.lightmapScaleOffset;
        public ReadOnlyGameObject lightProbeProxyVolumeOverride => _obj.lightProbeProxyVolumeOverride.AsReadOnly();
        IReadOnlyGameObject IReadOnlyRenderer.lightProbeProxyVolumeOverride => this.lightProbeProxyVolumeOverride;
        public LightProbeUsage lightProbeUsage => _obj.lightProbeUsage;
        public Matrix4x4 localToWorldMatrix => _obj.localToWorldMatrix;
        public ReadOnlyMaterial material => _obj.material.AsReadOnly();
        IReadOnlyMaterial IReadOnlyRenderer.material => this.material;
        public ReadOnlyMaterial[] materials => _obj.materials?.Select(m => m.AsReadOnly()).ToArray();
        IReadOnlyMaterial[] IReadOnlyRenderer.materials => this.materials;
        public MotionVectorGenerationMode motionVectorGenerationMode => _obj.motionVectorGenerationMode;
        public ReadOnlyTransform probeAnchor => _obj.probeAnchor.AsReadOnly();
        IReadOnlyTransform IReadOnlyRenderer.probeAnchor => this.probeAnchor;
        public int realtimeLightmapIndex => _obj.realtimeLightmapIndex;
        public Vector4 realtimeLightmapScaleOffset => _obj.realtimeLightmapScaleOffset;
        public bool receiveShadows => _obj.receiveShadows;
        public ReflectionProbeUsage reflectionProbeUsage => _obj.reflectionProbeUsage;
        public int rendererPriority => _obj.rendererPriority;
        public uint renderingLayerMask => _obj.renderingLayerMask;
        public ShadowCastingMode shadowCastingMode => _obj.shadowCastingMode;
        public ReadOnlyMaterial sharedMaterial => _obj.sharedMaterial.AsReadOnly();
        IReadOnlyMaterial IReadOnlyRenderer.sharedMaterial => this.sharedMaterial;
        public ReadOnlyMaterial[] sharedMaterials => _obj.sharedMaterials?.Select(m => m.AsReadOnly()).ToArray();
        IReadOnlyMaterial[] IReadOnlyRenderer.sharedMaterials => this.sharedMaterials;
        public int sortingLayerID => _obj.sortingLayerID;
        public string sortingLayerName => _obj.sortingLayerName;
        public int sortingOrder => _obj.sortingOrder;
        public Matrix4x4 worldToLocalMatrix => _obj.worldToLocalMatrix;

        #endregion

        #region Public Methods

        public void GetClosestReflectionProbes(List<ReflectionProbeBlendInfo> result) => _obj.GetClosestReflectionProbes(result);
        // public void GetMaterials(List<Material> m) => _obj.GetMaterials(m);
        public void GetPropertyBlock(MaterialPropertyBlock properties) => _obj.GetPropertyBlock(properties);
        public void GetPropertyBlock(MaterialPropertyBlock properties, int materialIndex) => _obj.GetPropertyBlock(properties, materialIndex);
        // public void GetSharedMaterials(List<Material> m) => _obj.GetSharedMaterials(m);
        public bool HasPropertyBlock() => _obj.HasPropertyBlock();
        // public void SetPropertyBlock(MaterialPropertyBlock properties) => _obj.SetPropertyBlock(properties);
        // public void SetPropertyBlock(MaterialPropertyBlock properties, int materialIndex) => _obj.SetPropertyBlock(properties, materialIndex);

        #endregion
    }

    public sealed class ReadOnlyRenderer : ReadOnlyRenderer<Renderer>
    {
        public ReadOnlyRenderer(Renderer obj) : base(obj)
        {
        }
    }

    public static class RendererExtensions
    {
        public static ReadOnlyRenderer AsReadOnly(this Renderer self) => self.IsTrulyNull() ? null : new ReadOnlyRenderer(self);
    }
}