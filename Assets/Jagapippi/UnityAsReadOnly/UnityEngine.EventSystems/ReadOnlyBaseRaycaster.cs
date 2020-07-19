using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyBaseRaycaster : IReadOnlyUIBehaviour
    {
        IReadOnlyCamera eventCamera { get; }
        int renderOrderPriority { get; }
        int sortOrderPriority { get; }
        void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);
        new string ToString();
    }

    public class ReadOnlyBaseRaycaster<T> : ReadOnlyUIBehaviour<T>, IReadOnlyBaseRaycaster where T : BaseRaycaster
    {
        protected ReadOnlyBaseRaycaster(T obj) : base(obj)
        {
        }

        #region Properties

        public IReadOnlyCamera eventCamera => (_obj.eventCamera == null) ? null : _obj.eventCamera.AsReadOnly();
        public int renderOrderPriority => _obj.renderOrderPriority;
        public int sortOrderPriority => _obj.sortOrderPriority;

        #endregion

        #region Public Methods

        public void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList) => _obj.Raycast(eventData, resultAppendList);
        public new string ToString() => _obj.ToString();

        #endregion
    }

    public sealed class ReadOnlyBaseRaycaster : ReadOnlyBaseRaycaster<BaseRaycaster>
    {
        public ReadOnlyBaseRaycaster(BaseRaycaster obj) : base(obj)
        {
        }
    }

    public static class BaseRaycasterExtensions
    {
        public static IReadOnlyBaseRaycaster AsReadOnly(this BaseRaycaster self) => new ReadOnlyBaseRaycaster(self);
    }
}