using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyGameObject
    {
        bool activeInHierarchy { get; }
        bool activeSelf { get; }
        IReadOnlyGameObject gameObject { get; }
#if UNITY_EDITOR
        bool isStatic { get; }
#endif
        int layer { get; }
        ReadOnlyScene scene { get; }
        string tag { get; }
        IReadOnlyTransform transform { get; }
        // Component AddComponent(Type componentType);
        // T AddComponent<T>() where T : Component;
        // void BroadcastMessage(string methodName, SendMessageOptions options);
        // void BroadcastMessage(string methodName, object parameter, SendMessageOptions options);
        // void BroadcastMessage(string methodName, object parameter);
        // void BroadcastMessage(string methodName);
        bool CompareTag(string tag);
        // T GetComponent<T>();
        // Component GetComponent(Type type);
        // Component GetComponent(string type);
        // Component GetComponentInChildren(Type type, bool includeInactive);
        // Component GetComponentInChildren(Type type);
        // T GetComponentInChildren<T>();
        // T GetComponentInChildren<T>(bool includeInactive);
        // Component GetComponentInParent(Type type);
        // T GetComponentInParent<T>();
        // Component[] GetComponents(Type type);
        // T[] GetComponents<T>();
        // void GetComponents(Type type, List<Component> results);
        // void GetComponents<T>(List<T> results);
        // Component[] GetComponentsInChildren(Type type);
        // Component[] GetComponentsInChildren(Type type, bool includeInactive);
        // T[] GetComponentsInChildren<T>(bool includeInactive);
        // void GetComponentsInChildren<T>(bool includeInactive, List<T> results);
        // T[] GetComponentsInChildren<T>();
        // void GetComponentsInChildren<T>(List<T> results);
        // Component[] GetComponentsInParent(Type type);
        // Component[] GetComponentsInParent(Type type, bool includeInactive);
        // void GetComponentsInParent<T>(bool includeInactive, List<T> results);
        // T[] GetComponentsInParent<T>(bool includeInactive);
        // T[] GetComponentsInParent<T>();
        // void SendMessage(string methodName, SendMessageOptions options);
        // void SendMessage(string methodName, object value, SendMessageOptions options);
        // void SendMessage(string methodName, object value);
        // void SendMessage(string methodName);
        // void SendMessageUpwards(string methodName, SendMessageOptions options);
        // void SendMessageUpwards(string methodName, object value, SendMessageOptions options);
        // void SendMessageUpwards(string methodName, object value);
        // void SendMessageUpwards(string methodName);
        // void SetActive(bool value);
    }

    public sealed class ReadOnlyGameObject : ReadOnlyObject<GameObject>, IReadOnlyGameObject
    {
        public ReadOnlyGameObject(GameObject obj) : base(obj)
        {
        }

        #region Properties

        public bool activeInHierarchy => _obj.activeInHierarchy;
        public bool activeSelf => _obj.activeSelf;
        public ReadOnlyGameObject gameObject => _obj.gameObject.IsTrulyNull() ? null : _obj.gameObject.AsReadOnly();
        IReadOnlyGameObject IReadOnlyGameObject.gameObject => this.gameObject;
#if UNITY_EDITOR
        public bool isStatic => _obj.isStatic;
#endif
        public int layer => _obj.layer;
        public ReadOnlyScene scene => _obj.scene.AsReadOnly();
        public string tag => _obj.tag;
        public ReadOnlyTransform transform => _obj.transform.IsTrulyNull() ? null : _obj.transform.AsReadOnly();
        IReadOnlyTransform IReadOnlyGameObject.transform => this.transform;

        #endregion

        #region Public Methods

        // public Component AddComponent(Type componentType) => _obj.AddComponent(componentType);
        // public T AddComponent<T>() where T : Component => _obj.AddComponent<T>();
        // public void BroadcastMessage(string methodName, SendMessageOptions options) => _obj.BroadcastMessage(methodName, options);
        // public void BroadcastMessage(string methodName, object parameter, SendMessageOptions options) => _obj.BroadcastMessage(methodName, parameter, options);
        // public void BroadcastMessage(string methodName, object parameter) => _obj.BroadcastMessage(methodName, parameter);
        // public void BroadcastMessage(string methodName) => _obj.BroadcastMessage(methodName);
        public bool CompareTag(string tag) => _obj.CompareTag(tag);
        // public T GetComponent<T>() => _obj.GetComponent<T>();
        // public Component GetComponent(Type type) => _obj.GetComponent(type);
        // public Component GetComponent(string type) => _obj.GetComponent(type);
        // public Component GetComponentInChildren(Type type, bool includeInactive) => _obj.GetComponentInChildren(type, includeInactive);
        // public Component GetComponentInChildren(Type type) => _obj.GetComponentInChildren(type);
        // public T GetComponentInChildren<T>() => _obj.GetComponentInChildren<T>();
        // public T GetComponentInChildren<T>(bool includeInactive) => _obj.GetComponentInChildren<T>(includeInactive);
        // public Component GetComponentInParent(Type type) => _obj.GetComponentInParent(type);
        // public T GetComponentInParent<T>() => _obj.GetComponentInParent<T>();
        // public Component[] GetComponents(Type type) => _obj.GetComponents(type);
        // public T[] GetComponents<T>() => _obj.GetComponents<T>();
        // public void GetComponents(Type type, List<Component> results) => _obj.GetComponents(type, results);
        // public void GetComponents<T>(List<T> results) => _obj.GetComponents<T>(results);
        // public Component[] GetComponentsInChildren(Type type) => _obj.GetComponentsInChildren(type);
        // public Component[] GetComponentsInChildren(Type type, bool includeInactive) => _obj.GetComponentsInChildren(type, includeInactive);
        // public T[] GetComponentsInChildren<T>(bool includeInactive) => _obj.GetComponentsInChildren<T>(includeInactive);
        // public void GetComponentsInChildren<T>(bool includeInactive, List<T> results) => _obj.GetComponentsInChildren<T>(includeInactive, results);
        // public T[] GetComponentsInChildren<T>() => _obj.GetComponentsInChildren<T>();
        // public void GetComponentsInChildren<T>(List<T> results) => _obj.GetComponentsInChildren<T>(results);
        // public Component[] GetComponentsInParent(Type type) => _obj.GetComponentsInParent(type);
        // public Component[] GetComponentsInParent(Type type, bool includeInactive) => _obj.GetComponentsInParent(type, includeInactive);
        // public void GetComponentsInParent<T>(bool includeInactive, List<T> results) => _obj.GetComponentsInParent<T>(includeInactive, results);
        // public T[] GetComponentsInParent<T>(bool includeInactive) => _obj.GetComponentsInParent<T>(includeInactive);
        // public T[] GetComponentsInParent<T>() => _obj.GetComponentsInParent<T>();
        // public void SendMessage(string methodName, SendMessageOptions options) => _obj.SendMessage(methodName, options);
        // public void SendMessage(string methodName, object value, SendMessageOptions options) => _obj.SendMessage(methodName, value, options);
        // public void SendMessage(string methodName, object value) => _obj.SendMessage(methodName, value);
        // public void SendMessage(string methodName) => _obj.SendMessage(methodName);
        // public void SendMessageUpwards(string methodName, SendMessageOptions options) => _obj.SendMessageUpwards(methodName, options);
        // public void SendMessageUpwards(string methodName, object value, SendMessageOptions options) => _obj.SendMessageUpwards(methodName, value, options);
        // public void SendMessageUpwards(string methodName, object value) => _obj.SendMessageUpwards(methodName, value);
        // public void SendMessageUpwards(string methodName) => _obj.SendMessageUpwards(methodName);
        // public void SetActive(bool value) => _obj.SetActive(value);

        #endregion
    }

    public static class GameObjectExtensions
    {
        public static ReadOnlyGameObject AsReadOnly(this GameObject self) => new ReadOnlyGameObject(self);
    }
}