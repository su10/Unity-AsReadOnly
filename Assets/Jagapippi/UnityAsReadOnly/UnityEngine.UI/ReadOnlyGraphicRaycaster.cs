using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyGraphicRaycaster : IReadOnlyBaseRaycaster
    {
        GraphicRaycaster.BlockingObjects blockingObjects { get; }
        new IReadOnlyCamera eventCamera { get; }
        bool ignoreReversedGraphics { get; }
        new int renderOrderPriority { get; }
        new int sortOrderPriority { get; }
        new void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);
    }

    public sealed class ReadOnlyGraphicRaycaster : ReadOnlyBaseRaycaster<GraphicRaycaster>, IReadOnlyGraphicRaycaster
    {
        public ReadOnlyGraphicRaycaster(GraphicRaycaster obj) : base(obj)
        {
        }

        #region Properties

        public GraphicRaycaster.BlockingObjects blockingObjects => _obj.blockingObjects;
        public new IReadOnlyCamera eventCamera => (_obj.eventCamera == null) ? null : _obj.eventCamera.AsReadOnly();
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
        public static IReadOnlyGraphicRaycaster AsReadOnly(this GraphicRaycaster self) => new ReadOnlyGraphicRaycaster(self);
    }
}