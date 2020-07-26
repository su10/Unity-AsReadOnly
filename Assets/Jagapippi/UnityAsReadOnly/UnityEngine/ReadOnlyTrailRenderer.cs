using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTrailRenderer
    {
        LineAlignment alignment { get; }
        bool autodestruct { get; }
        IReadOnlyGradient colorGradient { get; }
        bool emitting { get; }
        Color endColor { get; }
        float endWidth { get; }
        bool generateLightingData { get; }
        float minVertexDistance { get; }
        int numCapVertices { get; }
        int numCornerVertices { get; }
        int positionCount { get; }
        float shadowBias { get; }
        Color startColor { get; }
        float startWidth { get; }
        LineTextureMode textureMode { get; }
        float time { get; }
        IReadOnlyAnimationCurve widthCurve { get; }
        float widthMultiplier { get; }
        // void AddPosition(Vector3 position);
        // void AddPositions(Vector3[] positions);
        void BakeMesh(Mesh mesh, bool useTransform);
        void BakeMesh(Mesh mesh, Camera camera, bool useTransform);
        void BakeMesh(Mesh mesh, ReadOnlyCamera camera, bool useTransform);
        // void Clear();
        Vector3 GetPosition(int index);
        int GetPositions(Vector3[] positions);
        // void SetPosition(int index, Vector3 position);
        // void SetPositions(Vector3[] positions);
    }

    public sealed class ReadOnlyTrailRenderer : ReadOnlyRenderer<TrailRenderer>, IReadOnlyTrailRenderer
    {
        public ReadOnlyTrailRenderer(TrailRenderer obj) : base(obj)
        {
        }

        #region Properties

        public LineAlignment alignment => _obj.alignment;
        public bool autodestruct => _obj.autodestruct;
        public ReadOnlyGradient colorGradient => _obj.colorGradient.AsReadOnly();
        IReadOnlyGradient IReadOnlyTrailRenderer.colorGradient => this.colorGradient;
        public bool emitting => _obj.emitting;
        public Color endColor => _obj.endColor;
        public float endWidth => _obj.endWidth;
        public bool generateLightingData => _obj.generateLightingData;
        public float minVertexDistance => _obj.minVertexDistance;
        public int numCapVertices => _obj.numCapVertices;
        public int numCornerVertices => _obj.numCornerVertices;
        public int positionCount => _obj.positionCount;
        public float shadowBias => _obj.shadowBias;
        public Color startColor => _obj.startColor;
        public float startWidth => _obj.startWidth;
        public LineTextureMode textureMode => _obj.textureMode;
        public float time => _obj.time;
        public ReadOnlyAnimationCurve widthCurve => _obj.widthCurve.AsReadOnly();
        IReadOnlyAnimationCurve IReadOnlyTrailRenderer.widthCurve => this.widthCurve;
        public float widthMultiplier => _obj.widthMultiplier;

        #endregion

        #region Public Methods

        // public void AddPosition(Vector3 position) => _obj.AddPosition(position);
        // public void AddPositions(Vector3[] positions) => _obj.AddPositions(positions);
        public void BakeMesh(Mesh mesh, bool useTransform) => _obj.BakeMesh(mesh, useTransform);
        public void BakeMesh(Mesh mesh, Camera camera, bool useTransform) => _obj.BakeMesh(mesh, camera, useTransform);
        public void BakeMesh(Mesh mesh, ReadOnlyCamera camera, bool useTransform) => _obj.BakeMesh(mesh, camera._obj, useTransform);
        // public void Clear() => _obj.Clear();
        public Vector3 GetPosition(int index) => _obj.GetPosition(index);
        public int GetPositions(Vector3[] positions) => _obj.GetPositions(positions);
        // public void SetPosition(int index, Vector3 position) => _obj.SetPosition(index, position);
        // public void SetPositions(Vector3[] positions) => _obj.SetPositions(positions);

        #endregion
    }

    public static class TrailRendererExtensions
    {
        public static ReadOnlyTrailRenderer AsReadOnly(this TrailRenderer self) => self.IsTrulyNull() ? null : new ReadOnlyTrailRenderer(self);
    }
}