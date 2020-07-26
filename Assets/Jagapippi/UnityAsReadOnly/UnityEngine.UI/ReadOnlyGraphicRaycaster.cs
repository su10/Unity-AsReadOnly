#if !UNITY_WSA
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

    public abstract class ReadOnlyGraphicRaycaster<T> : ReadOnlyBaseRaycaster<T>, IReadOnlyGraphicRaycaster where T : GraphicRaycaster
    {
        protected ReadOnlyGraphicRaycaster(T obj) : base(obj)
        {
        }

        #region Properties

        public GraphicRaycaster.BlockingObjects blockingObjects => _obj.blockingObjects;
        public override ReadOnlyCamera eventCamera => _obj.eventCamera.AsReadOnly();
        IReadOnlyCamera IReadOnlyGraphicRaycaster.eventCamera => this.eventCamera;
        public bool ignoreReversedGraphics => _obj.ignoreReversedGraphics;
        public override int renderOrderPriority => _obj.renderOrderPriority;
        public override int sortOrderPriority => _obj.sortOrderPriority;

        #endregion

        #region Public Methods

        public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList) => _obj.Raycast(eventData, resultAppendList);

        #endregion
    }

    public sealed class ReadOnlyGraphicRaycaster : ReadOnlyGraphicRaycaster<GraphicRaycaster>
    {
        public ReadOnlyGraphicRaycaster(GraphicRaycaster obj) : base(obj)
        {
        }
    }

    public static class GraphicRaycasterExtensions
    {
        public static ReadOnlyGraphicRaycaster AsReadOnly(this GraphicRaycaster self) => self.IsTrulyNull() ? null : new ReadOnlyGraphicRaycaster(self);
    }
}
#endif