using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyComponent
    {
        IReadOnlyGameObject gameObject { get; }
        string tag { get; }
        IReadOnlyTransform transform { get; }
        // void BroadcastMessage(string methodName, object parameter, SendMessageOptions options);
        // void BroadcastMessage(string methodName, object parameter);
        // void BroadcastMessage(string methodName);
        // void BroadcastMessage(string methodName, SendMessageOptions options);
        bool CompareTag(string tag);
        // Component GetComponent(Type type);
        // T GetComponent<T>();
        // Component GetComponent(string type);
        // Component GetComponentInChildren(Type t, bool includeInactive);
        // Component GetComponentInChildren(Type t);
        // T GetComponentInChildren<T>(bool includeInactive);
        // T GetComponentInChildren<T>();
        // Component GetComponentInParent(Type t);
        // T GetComponentInParent<T>();
        // Component[] GetComponents(Type type);
        // void GetComponents(Type type, List<Component> results);
        // void GetComponents<T>(List<T> results);
        // T[] GetComponents<T>();
        // Component[] GetComponentsInChildren(Type t, bool includeInactive);
        // Component[] GetComponentsInChildren(Type t);
        // T[] GetComponentsInChildren<T>(bool includeInactive);
        // void GetComponentsInChildren<T>(bool includeInactive, List<T> result);
        // T[] GetComponentsInChildren<T>();
        // void GetComponentsInChildren<T>(List<T> results);
        // Component[] GetComponentsInParent(Type t, bool includeInactive);
        // Component[] GetComponentsInParent(Type t);
        // T[] GetComponentsInParent<T>(bool includeInactive);
        // void GetComponentsInParent<T>(bool includeInactive, List<T> results);
        // T[] GetComponentsInParent<T>();
        // void SendMessage(string methodName, object value);
        // void SendMessage(string methodName);
        // void SendMessage(string methodName, object value, SendMessageOptions options);
        // void SendMessage(string methodName, SendMessageOptions options);
        // void SendMessageUpwards(string methodName, object value, SendMessageOptions options);
        // void SendMessageUpwards(string methodName, object value);
        // void SendMessageUpwards(string methodName);
        // void SendMessageUpwards(string methodName, SendMessageOptions options);
    }

    public class ReadOnlyComponent<T> : ReadOnlyObject<T>, IReadOnlyComponent where T : Component
    {
        protected ReadOnlyComponent(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyGameObject gameObject => (_obj.gameObject == null) ? null : _obj.gameObject.AsReadOnly();
        IReadOnlyGameObject IReadOnlyComponent.gameObject => this.gameObject;
        public string tag => _obj.tag;
        public ReadOnlyTransform transform => (_obj.transform == null) ? null : _obj.transform.AsReadOnly();
        IReadOnlyTransform IReadOnlyComponent.transform => this.transform;

        #endregion

        #region Public Methods

        // public void BroadcastMessage(string methodName, object parameter, SendMessageOptions options) => _obj.BroadcastMessage(methodName, parameter, options);
        // public void BroadcastMessage(string methodName, object parameter) => _obj.BroadcastMessage(methodName, parameter);
        // public void BroadcastMessage(string methodName) => _obj.BroadcastMessage(methodName);
        // public void BroadcastMessage(string methodName, SendMessageOptions options) => _obj.BroadcastMessage(methodName, options);
        public bool CompareTag(string tag) => _obj.CompareTag(tag);
        // public Component GetComponent(Type type) => _obj.GetComponent(type);
        // public T GetComponent<T>() => _obj.GetComponent<T>();
        // public Component GetComponent(string type) => _obj.GetComponent(type);
        // public Component GetComponentInChildren(Type t, bool includeInactive) => _obj.GetComponentInChildren(t, includeInactive);
        // public Component GetComponentInChildren(Type t) => _obj.GetComponentInChildren(t);
        // public T GetComponentInChildren<T>(bool includeInactive) => _obj.GetComponentInChildren<T>(includeInactive);
        // public T GetComponentInChildren<T>() => _obj.GetComponentInChildren<T>();
        // public Component GetComponentInParent(Type t) => _obj.GetComponentInParent(t);
        // public T GetComponentInParent<T>() => _obj.GetComponentInParent<T>();
        // public Component[] GetComponents(Type type) => _obj.GetComponents(type);
        // public void GetComponents(Type type, List<Component> results) => _obj.GetComponents(type, results);
        // public void GetComponents<T>(List<T> results) => _obj.GetComponents<T>(results);
        // public T[] GetComponents<T>() => _obj.GetComponents<T>();
        // public Component[] GetComponentsInChildren(Type t, bool includeInactive) => _obj.GetComponentsInChildren(t, includeInactive);
        // public Component[] GetComponentsInChildren(Type t) => _obj.GetComponentsInChildren(t);
        // public T[] GetComponentsInChildren<T>(bool includeInactive) => _obj.GetComponentsInChildren<T>(includeInactive);
        // public void GetComponentsInChildren<T>(bool includeInactive, List<T> result) => _obj.GetComponentsInChildren<T>(includeInactive, result);
        // public T[] GetComponentsInChildren<T>() => _obj.GetComponentsInChildren<T>();
        // public void GetComponentsInChildren<T>(List<T> results) => _obj.GetComponentsInChildren<T>(results);
        // public Component[] GetComponentsInParent(Type t, bool includeInactive) => _obj.GetComponentsInParent(t, includeInactive);
        // public Component[] GetComponentsInParent(Type t) => _obj.GetComponentsInParent(t);
        // public T[] GetComponentsInParent<T>(bool includeInactive) => _obj.GetComponentsInParent<T>(includeInactive);
        // public void GetComponentsInParent<T>(bool includeInactive, List<T> results) => _obj.GetComponentsInParent<T>(includeInactive, results);
        // public T[] GetComponentsInParent<T>() => _obj.GetComponentsInParent<T>();
        // public void SendMessage(string methodName, object value) => _obj.SendMessage(methodName, value);
        // public void SendMessage(string methodName) => _obj.SendMessage(methodName);
        // public void SendMessage(string methodName, object value, SendMessageOptions options) => _obj.SendMessage(methodName, value, options);
        // public void SendMessage(string methodName, SendMessageOptions options) => _obj.SendMessage(methodName, options);
        // public void SendMessageUpwards(string methodName, object value, SendMessageOptions options) => _obj.SendMessageUpwards(methodName, value, options);
        // public void SendMessageUpwards(string methodName, object value) => _obj.SendMessageUpwards(methodName, value);
        // public void SendMessageUpwards(string methodName) => _obj.SendMessageUpwards(methodName);
        // public void SendMessageUpwards(string methodName, SendMessageOptions options) => _obj.SendMessageUpwards(methodName, options);

        #endregion
    }

    public sealed class ReadOnlyComponent : ReadOnlyComponent<Component>
    {
        public ReadOnlyComponent(Component obj) : base(obj)
        {
        }
    }

    public static class ComponentExtensions
    {
        public static ReadOnlyComponent AsReadOnly(this Component self) => new ReadOnlyComponent(self);
    }
}