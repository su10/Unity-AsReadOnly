#if !UNITY_WSA
using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyGraphic
    {
        IReadOnlyCanvas canvas { get; }
        IReadOnlyCanvasRenderer canvasRenderer { get; }
        Color color { get; }
        IReadOnlyMaterial defaultMaterial { get; }
        int depth { get; }
        IReadOnlyTexture mainTexture { get; }
        IReadOnlyMaterial material { get; }
        IReadOnlyMaterial materialForRendering { get; }
        bool raycastTarget { get; }
        IReadOnlyRectTransform rectTransform { get; }
        // void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale);
        // void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha);
        // void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha, bool useRGB);
        Rect GetPixelAdjustedRect();
        // void GraphicUpdateComplete();
        // void LayoutComplete();
        // void OnCullingChanged();
        // void OnRebuildRequested();
        Vector2 PixelAdjustPoint(Vector2 point);
        bool Raycast(Vector2 sp, Camera eventCamera);
        bool Raycast(Vector2 sp, ReadOnlyCamera eventCamera);
        // void Rebuild(CanvasUpdate update);
        // void RegisterDirtyLayoutCallback(UnityAction action);
        // void RegisterDirtyMaterialCallback(UnityAction action);
        // void RegisterDirtyVerticesCallback(UnityAction action);
        // void SetAllDirty();
        // void SetLayoutDirty();
        // void SetMaterialDirty();
        // void SetNativeSize();
        // void SetVerticesDirty();
        // void UnregisterDirtyLayoutCallback(UnityAction action);
        // void UnregisterDirtyMaterialCallback(UnityAction action);
        // void UnregisterDirtyVerticesCallback(UnityAction action);
    }

    public abstract class ReadOnlyGraphic<T> : ReadOnlyUIBehaviour<T>, IReadOnlyGraphic where T : Graphic
    {
        protected ReadOnlyGraphic(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyCanvas canvas => _obj.canvas.AsReadOnly();
        IReadOnlyCanvas IReadOnlyGraphic.canvas => this.canvas;
        public ReadOnlyCanvasRenderer canvasRenderer => _obj.canvasRenderer.AsReadOnly();
        IReadOnlyCanvasRenderer IReadOnlyGraphic.canvasRenderer => this.canvasRenderer;
        public virtual Color color => _obj.color;
        public virtual ReadOnlyMaterial defaultMaterial => _obj.defaultMaterial.AsReadOnly();
        IReadOnlyMaterial IReadOnlyGraphic.defaultMaterial => this.defaultMaterial;
        public int depth => _obj.depth;
        public virtual ReadOnlyTexture mainTexture => _obj.mainTexture.AsReadOnly();
        IReadOnlyTexture IReadOnlyGraphic.mainTexture => this.mainTexture;
        public virtual ReadOnlyMaterial material => _obj.material.AsReadOnly();
        IReadOnlyMaterial IReadOnlyGraphic.material => this.material;
        public virtual ReadOnlyMaterial materialForRendering => _obj.materialForRendering.AsReadOnly();
        IReadOnlyMaterial IReadOnlyGraphic.materialForRendering => this.materialForRendering;
        public virtual bool raycastTarget => _obj.raycastTarget;
        public ReadOnlyRectTransform rectTransform => _obj.rectTransform.AsReadOnly();
        IReadOnlyRectTransform IReadOnlyGraphic.rectTransform => this.rectTransform;

        #endregion

        #region Public Methods

        // public void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale) => _obj.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
        // public void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha) => _obj.CrossFadeColor(targetColor, duration, ignoreTimeScale, useAlpha);
        // public void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha, bool useRGB) => _obj.CrossFadeColor(targetColor, duration, ignoreTimeScale, useAlpha, useRGB);
        public Rect GetPixelAdjustedRect() => _obj.GetPixelAdjustedRect();
        // public void GraphicUpdateComplete() => _obj.GraphicUpdateComplete();
        // public void LayoutComplete() => _obj.LayoutComplete();
        // public void OnCullingChanged() => _obj.OnCullingChanged();
        // public void OnRebuildRequested() => _obj.OnRebuildRequested();
        public Vector2 PixelAdjustPoint(Vector2 point) => _obj.PixelAdjustPoint(point);
        public virtual bool Raycast(Vector2 sp, Camera eventCamera) => _obj.Raycast(sp, eventCamera);
        public virtual bool Raycast(Vector2 sp, ReadOnlyCamera eventCamera) => _obj.Raycast(sp, eventCamera._obj);
        // public void Rebuild(CanvasUpdate update) => _obj.Rebuild(update);
        // public void RegisterDirtyLayoutCallback(UnityAction action) => _obj.RegisterDirtyLayoutCallback(action);
        // public void RegisterDirtyMaterialCallback(UnityAction action) => _obj.RegisterDirtyMaterialCallback(action);
        // public void RegisterDirtyVerticesCallback(UnityAction action) => _obj.RegisterDirtyVerticesCallback(action);
        // public void SetAllDirty() => _obj.SetAllDirty();
        // public void SetLayoutDirty() => _obj.SetLayoutDirty();
        // public void SetMaterialDirty() => _obj.SetMaterialDirty();
        // public void SetNativeSize() => _obj.SetNativeSize();
        // public void SetVerticesDirty() => _obj.SetVerticesDirty();
        // public void UnregisterDirtyLayoutCallback(UnityAction action) => _obj.UnregisterDirtyLayoutCallback(action);
        // public void UnregisterDirtyMaterialCallback(UnityAction action) => _obj.UnregisterDirtyMaterialCallback(action);
        // public void UnregisterDirtyVerticesCallback(UnityAction action) => _obj.UnregisterDirtyVerticesCallback(action);

        #endregion
    }

    public sealed class ReadOnlyGraphic : ReadOnlyGraphic<Graphic>
    {
        public ReadOnlyGraphic(Graphic obj) : base(obj)
        {
        }
    }

    public static class GraphicExtensions
    {
        public static ReadOnlyGraphic AsReadOnly(this Graphic self) => self.IsTrulyNull() ? null : new ReadOnlyGraphic(self);
    }
}
#endif