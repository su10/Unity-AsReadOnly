using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyGraphicRaycaster
    {
        GraphicRaycaster.BlockingObjects blockingObjects { get; }
        IReadOnlyCamera eventCamera { get; }
        bool ignoreReversedGraphics { get; }
        int renderOrderPriority { get; }
        int sortOrderPriority { get; }
        void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);
    }

    public sealed class ReadOnlyGraphicRaycaster : ReadOnlyBaseRaycaster<GraphicRaycaster>, IReadOnlyGraphicRaycaster
    {
        public ReadOnlyGraphicRaycaster(GraphicRaycaster obj) : base(obj)
        {
        }

        #region Properties

        public GraphicRaycaster.BlockingObjects blockingObjects => _obj.blockingObjects;
        public new ReadOnlyCamera eventCamera => (_obj.eventCamera == null) ? null : _obj.eventCamera.AsReadOnly();
        IReadOnlyCamera IReadOnlyGraphicRaycaster.eventCamera => this.eventCamera;
        public bool ignoreReversedGraphics => _obj.ignoreReversedGraphics;
        public new int renderOrderPriority => _obj.renderOrderPriority;
        public new int sortOrderPriority => _obj.sortOrderPriority;

        #endregion

        #region Public Methods

        public new void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList) => _obj.Raycast(eventData, resultAppendList);

        #endregion
    }

    public static class GraphicRaycasterExtensions
    {
        public static ReadOnlyGraphicRaycaster AsReadOnly(this GraphicRaycaster self) => new ReadOnlyGraphicRaycaster(self);
    }
}