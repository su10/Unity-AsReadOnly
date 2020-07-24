using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyLineRenderer
    {
        LineAlignment alignment { get; }
        IReadOnlyGradient colorGradient { get; }
        Color endColor { get; }
        float endWidth { get; }
        bool generateLightingData { get; }
        bool loop { get; }
        int numCapVertices { get; }
        int numCornerVertices { get; }
        int positionCount { get; }
        float shadowBias { get; }
        Color startColor { get; }
        float startWidth { get; }
        LineTextureMode textureMode { get; }
        bool useWorldSpace { get; }
        IReadOnlyAnimationCurve widthCurve { get; }
        float widthMultiplier { get; }
        void BakeMesh(Mesh mesh, bool useTransform);
        void BakeMesh(Mesh mesh, Camera camera, bool useTransform);
        Vector3 GetPosition(int index);
        int GetPositions(Vector3[] positions);
        // void SetPosition(int index, Vector3 position);
        // void SetPositions(Vector3[] positions);
        // void Simplify(float tolerance);
    }

    public sealed class ReadOnlyLineRenderer : ReadOnlyRenderer<LineRenderer>, IReadOnlyLineRenderer
    {
        public ReadOnlyLineRenderer(LineRenderer obj) : base(obj)
        {
        }

        #region Properties

        public LineAlignment alignment => _obj.alignment;
        public ReadOnlyGradient colorGradient => _obj.colorGradient.AsReadOnly();
        IReadOnlyGradient IReadOnlyLineRenderer.colorGradient => this.colorGradient;
        public Color endColor => _obj.endColor;
        public float endWidth => _obj.endWidth;
        public bool generateLightingData => _obj.generateLightingData;
        public bool loop => _obj.loop;
        public int numCapVertices => _obj.numCapVertices;
        public int numCornerVertices => _obj.numCornerVertices;
        public int positionCount => _obj.positionCount;
        public float shadowBias => _obj.shadowBias;
        public Color startColor => _obj.startColor;
        public float startWidth => _obj.startWidth;
        public LineTextureMode textureMode => _obj.textureMode;
        public bool useWorldSpace => _obj.useWorldSpace;
        public ReadOnlyAnimationCurve widthCurve => _obj.widthCurve.AsReadOnly();
        IReadOnlyAnimationCurve IReadOnlyLineRenderer.widthCurve => this.widthCurve;
        public float widthMultiplier => _obj.widthMultiplier;

        #endregion

        #region Public Methods

        public void BakeMesh(Mesh mesh, bool useTransform) => _obj.BakeMesh(mesh, useTransform);
        public void BakeMesh(Mesh mesh, Camera camera, bool useTransform) => _obj.BakeMesh(mesh, camera, useTransform);
        public Vector3 GetPosition(int index) => _obj.GetPosition(index);
        public int GetPositions(Vector3[] positions) => _obj.GetPositions(positions);
        // public void SetPosition(int index, Vector3 position) => _obj.SetPosition(index, position);
        // public void SetPositions(Vector3[] positions) => _obj.SetPositions(positions);
        // public void Simplify(float tolerance) => _obj.Simplify(tolerance);

        #endregion
    }

    public static class LineRendererExtensions
    {
        public static ReadOnlyLineRenderer AsReadOnly(this LineRenderer self) => new ReadOnlyLineRenderer(self);
    }
}