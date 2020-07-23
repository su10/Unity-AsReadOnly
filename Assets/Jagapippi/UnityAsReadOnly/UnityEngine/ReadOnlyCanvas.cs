using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCanvas
    {
        AdditionalCanvasShaderChannels additionalShaderChannels { get; }
        int cachedSortingLayerValue { get; }
        bool isRootCanvas { get; }
        float normalizedSortingGridSize { get; }
        bool overridePixelPerfect { get; }
        bool overrideSorting { get; }
        bool pixelPerfect { get; }
        Rect pixelRect { get; }
        float planeDistance { get; }
        float referencePixelsPerUnit { get; }
        RenderMode renderMode { get; }
        int renderOrder { get; }
        IReadOnlyCanvas rootCanvas { get; }
        float scaleFactor { get; }
        int sortingLayerID { get; }
        string sortingLayerName { get; }
        int sortingOrder { get; }
        int targetDisplay { get; }
        IReadOnlyCamera worldCamera { get; }
    }

    public sealed class ReadOnlyCanvas : ReadOnlyBehaviour<Canvas>, IReadOnlyCanvas
    {
        public ReadOnlyCanvas(Canvas obj) : base(obj)
        {
        }

        #region Properties

        public AdditionalCanvasShaderChannels additionalShaderChannels => _obj.additionalShaderChannels;
        public int cachedSortingLayerValue => _obj.cachedSortingLayerValue;
        public bool isRootCanvas => _obj.isRootCanvas;
        public float normalizedSortingGridSize => _obj.normalizedSortingGridSize;
        public bool overridePixelPerfect => _obj.overridePixelPerfect;
        public bool overrideSorting => _obj.overrideSorting;
        public bool pixelPerfect => _obj.pixelPerfect;
        public Rect pixelRect => _obj.pixelRect;
        public float planeDistance => _obj.planeDistance;
        public float referencePixelsPerUnit => _obj.referencePixelsPerUnit;
        public RenderMode renderMode => _obj.renderMode;
        public int renderOrder => _obj.renderOrder;
        public ReadOnlyCanvas rootCanvas => _obj.rootCanvas.IsTrulyNull() ? null : _obj.rootCanvas.AsReadOnly();
        IReadOnlyCanvas IReadOnlyCanvas.rootCanvas => this.rootCanvas;
        public float scaleFactor => _obj.scaleFactor;
        public int sortingLayerID => _obj.sortingLayerID;
        public string sortingLayerName => _obj.sortingLayerName;
        public int sortingOrder => _obj.sortingOrder;
        public int targetDisplay => _obj.targetDisplay;
        public ReadOnlyCamera worldCamera => _obj.worldCamera.IsTrulyNull() ? null : _obj.worldCamera.AsReadOnly();
        IReadOnlyCamera IReadOnlyCanvas.worldCamera => this.worldCamera;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class CanvasExtensions
    {
        public static ReadOnlyCanvas AsReadOnly(this Canvas self) => new ReadOnlyCanvas(self);
    }
}