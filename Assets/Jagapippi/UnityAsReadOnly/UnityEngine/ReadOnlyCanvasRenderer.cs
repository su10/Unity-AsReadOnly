using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCanvasRenderer
    {
        int absoluteDepth { get; }
        bool cull { get; }
        bool cullTransparentMesh { get; }
        bool hasMoved { get; }
        bool hasPopInstruction { get; }
        bool hasRectClipping { get; }
        int materialCount { get; }
        int popMaterialCount { get; }
        int relativeDepth { get; }
        // void Clear();
        // void DisableRectClipping();
        // void EnableRectClipping(Rect rect);
        float GetAlpha();
        Color GetColor();
        float GetInheritedAlpha();
        IReadOnlyMaterial GetMaterial(int index);
        IReadOnlyMaterial GetMaterial();
        IReadOnlyMaterial GetPopMaterial(int index);
        // void SetAlpha(float alpha);
        // void SetAlphaTexture(Texture texture);
        // void SetColor(Color color);
        // void SetMaterial(Material material, int index);
        // void SetMaterial(Material material, Texture texture);
        // void SetMesh(Mesh mesh);
        // void SetPopMaterial(Material material, int index);
        // void SetTexture(Texture texture);
    }

    public sealed class ReadOnlyCanvasRenderer : ReadOnlyComponent<CanvasRenderer>, IReadOnlyCanvasRenderer
    {
        public ReadOnlyCanvasRenderer(CanvasRenderer obj) : base(obj)
        {
        }

        #region Properties

        public int absoluteDepth => _obj.absoluteDepth;
        public bool cull => _obj.cull;
        public bool cullTransparentMesh => _obj.cullTransparentMesh;
        public bool hasMoved => _obj.hasMoved;
        public bool hasPopInstruction => _obj.hasPopInstruction;
        public bool hasRectClipping => _obj.hasRectClipping;
        public int materialCount => _obj.materialCount;
        public int popMaterialCount => _obj.popMaterialCount;
        public int relativeDepth => _obj.relativeDepth;

        #endregion

        #region Public Methods

        // public void Clear() => _obj.Clear();
        // public void DisableRectClipping() => _obj.DisableRectClipping();
        // public void EnableRectClipping(Rect rect) => _obj.EnableRectClipping(rect);
        public float GetAlpha() => _obj.GetAlpha();
        public Color GetColor() => _obj.GetColor();
        public float GetInheritedAlpha() => _obj.GetInheritedAlpha();
        public ReadOnlyMaterial GetMaterial(int index) => _obj.GetMaterial(index).AsReadOnly();
        IReadOnlyMaterial IReadOnlyCanvasRenderer.GetMaterial(int index) => this.GetMaterial(index);
        public ReadOnlyMaterial GetMaterial() => _obj.GetMaterial().AsReadOnly();
        IReadOnlyMaterial IReadOnlyCanvasRenderer.GetMaterial() => this.GetMaterial();
        public ReadOnlyMaterial GetPopMaterial(int index) => _obj.GetPopMaterial(index).AsReadOnly();
        IReadOnlyMaterial IReadOnlyCanvasRenderer.GetPopMaterial(int index) => this.GetPopMaterial(index);
        // public void SetAlpha(float alpha) => _obj.SetAlpha(alpha);
        // public void SetAlphaTexture(Texture texture) => _obj.SetAlphaTexture(texture);
        // public void SetColor(Color color) => _obj.SetColor(color);
        // public void SetMaterial(Material material, int index) => _obj.SetMaterial(material, index);
        // public void SetMaterial(Material material, Texture texture) => _obj.SetMaterial(material, texture);
        // public void SetMesh(Mesh mesh) => _obj.SetMesh(mesh);
        // public void SetPopMaterial(Material material, int index) => _obj.SetPopMaterial(material, index);
        // public void SetTexture(Texture texture) => _obj.SetTexture(texture);

        #endregion
    }

    public static class CanvasRendererExtensions
    {
        public static ReadOnlyCanvasRenderer AsReadOnly(this CanvasRenderer self) => self.IsTrulyNull() ? null : new ReadOnlyCanvasRenderer(self);
    }
}