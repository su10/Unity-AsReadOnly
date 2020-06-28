using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public class ReadOnlyCanvas : ReadOnlyBehaviour<Canvas>
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
        public ReadOnlyCanvas rootCanvas => _obj.rootCanvas.AsReadOnly();
        public float scaleFactor => _obj.scaleFactor;
        public int sortingLayerID => _obj.sortingLayerID;
        public string sortingLayerName => _obj.sortingLayerName;
        public int sortingOrder => _obj.sortingOrder;
        public int targetDisplay => _obj.targetDisplay;
        public ReadOnlyCamera worldCamera => _obj.worldCamera.AsReadOnly();

        #endregion

        #region Public Methods

        #endregion
    }

    public static class CanvasExtensions
    {
        public static ReadOnlyCanvas AsReadOnly(this Canvas self) => new ReadOnlyCanvas(self);
    }
}