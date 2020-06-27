using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyComponent : IReadOnlyObject
    {
        ReadOnlyGameObject gameObject { get; }
        string tag { get; }
        ReadOnlyTransform transform { get; }
        bool CompareTag(string tag);
    }

    public class ReadOnlyComponent<T> : ReadOnlyObject<T>, IReadOnlyComponent where T : Component
    {
        protected ReadOnlyComponent(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyGameObject gameObject => _obj.gameObject.AsReadOnly();
        public string tag => _obj.tag;
        public ReadOnlyTransform transform => _obj.transform.AsReadOnly();

        #endregion

        #region Methods

        // BroadcastMessage
        public bool CompareTag(string tag) => _obj.CompareTag(tag);
        // GetComponent
        // GetComponentInChildren
        // GetComponentInParent
        // GetComponents
        // GetComponentsInChildren
        // GetComponentsInParent
        // SendMessage
        // SendMessageUpwards

        #endregion
    }

    public class ReadOnlyComponent : ReadOnlyComponent<Component>
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