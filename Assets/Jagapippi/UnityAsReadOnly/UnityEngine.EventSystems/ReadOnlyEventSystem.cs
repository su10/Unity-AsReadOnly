using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyEventSystem
    {
        bool alreadySelecting { get; }
        IReadOnlyBaseInputModule currentInputModule { get; }
        IReadOnlyGameObject currentSelectedGameObject { get; }
        IReadOnlyGameObject firstSelectedGameObject { get; }
        bool isFocused { get; }
        int pixelDragThreshold { get; }
        bool sendNavigationEvents { get; }
        bool IsPointerOverGameObject();
        bool IsPointerOverGameObject(int pointerId);
        void RaycastAll(PointerEventData eventData, List<RaycastResult> raycastResults);
        // void SetSelectedGameObject(GameObject selected, BaseEventData pointer);
        // void SetSelectedGameObject(GameObject selected);
        string ToString();
        // void UpdateModules();
    }

    public class ReadOnlyEventSystem<T> : ReadOnlyUIBehaviour<T>, IReadOnlyEventSystem where T : EventSystem
    {
        protected ReadOnlyEventSystem(T obj) : base(obj)
        {
        }

        #region Properties

        public bool alreadySelecting => _obj.alreadySelecting;
        public ReadOnlyBaseInputModule currentInputModule => _obj.currentInputModule.IsTrulyNull() ? null : _obj.currentInputModule.AsReadOnly();
        IReadOnlyBaseInputModule IReadOnlyEventSystem.currentInputModule => this.currentInputModule;
        public ReadOnlyGameObject currentSelectedGameObject => _obj.currentSelectedGameObject.IsTrulyNull() ? null : _obj.currentSelectedGameObject.AsReadOnly();
        IReadOnlyGameObject IReadOnlyEventSystem.currentSelectedGameObject => this.currentSelectedGameObject;
        public ReadOnlyGameObject firstSelectedGameObject => _obj.firstSelectedGameObject.IsTrulyNull() ? null : _obj.firstSelectedGameObject.AsReadOnly();
        IReadOnlyGameObject IReadOnlyEventSystem.firstSelectedGameObject => this.firstSelectedGameObject;
        public bool isFocused => _obj.isFocused;
        public int pixelDragThreshold => _obj.pixelDragThreshold;
        public bool sendNavigationEvents => _obj.sendNavigationEvents;

        #endregion

        #region Public Methods

        public bool IsPointerOverGameObject() => _obj.IsPointerOverGameObject();
        public bool IsPointerOverGameObject(int pointerId) => _obj.IsPointerOverGameObject(pointerId);
        public void RaycastAll(PointerEventData eventData, List<RaycastResult> raycastResults) => _obj.RaycastAll(eventData, raycastResults);
        // public void SetSelectedGameObject(GameObject selected, BaseEventData pointer) => _obj.SetSelectedGameObject(selected, pointer);
        // public void SetSelectedGameObject(GameObject selected) => _obj.SetSelectedGameObject(selected);
        public override string ToString() => _obj.ToString();
        // public void UpdateModules() => _obj.UpdateModules();

        #endregion
    }

    public sealed class ReadOnlyEventSystem : ReadOnlyEventSystem<EventSystem>
    {
        public ReadOnlyEventSystem(EventSystem obj) : base(obj)
        {
        }
    }

    public static class EventSystemExtensions
    {
        public static ReadOnlyEventSystem AsReadOnly(this EventSystem self) => new ReadOnlyEventSystem(self);
    }
}