using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyBaseRaycaster
    {
        IReadOnlyCamera eventCamera { get; }
        int renderOrderPriority { get; }
        int sortOrderPriority { get; }
        void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);
        string ToString();
    }

    public class ReadOnlyBaseRaycaster<T> : ReadOnlyUIBehaviour<T>, IReadOnlyBaseRaycaster where T : BaseRaycaster
    {
        protected ReadOnlyBaseRaycaster(T obj) : base(obj)
        {
        }

        #region Properties

        public virtual ReadOnlyCamera eventCamera => _obj.eventCamera.IsTrulyNull() ? null : _obj.eventCamera.AsReadOnly();
        IReadOnlyCamera IReadOnlyBaseRaycaster.eventCamera => this.eventCamera;
        public virtual int renderOrderPriority => _obj.renderOrderPriority;
        public virtual int sortOrderPriority => _obj.sortOrderPriority;

        #endregion

        #region Public Methods

        public virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList) => _obj.Raycast(eventData, resultAppendList);
        public override string ToString() => _obj.ToString();

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
        public static ReadOnlyBaseRaycaster AsReadOnly(this BaseRaycaster self) => new ReadOnlyBaseRaycaster(self);
    }
}