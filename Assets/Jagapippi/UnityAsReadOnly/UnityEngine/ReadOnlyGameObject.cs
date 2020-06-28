using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public class ReadOnlyGameObject : ReadOnlyObject<GameObject>
    {
        public ReadOnlyGameObject(GameObject obj) : base(obj)
        {
        }

        #region Properties

        public bool activeInHierarchy => _obj.activeInHierarchy;
        public bool activeSelf => _obj.activeSelf;
        public bool isStatic => _obj.isStatic;
        public int layer => _obj.layer;
        public ReadOnlyScene scene => _obj.scene.AsReadOnly();
        public string tag => _obj.tag;
        public ReadOnlyTransform transform => _obj.transform.AsReadOnly();

        #endregion

        #region Public Methods

        // AddComponent
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
        // SetActive

        #endregion
    }

    public static class GameObjectExtensions
    {
        public static ReadOnlyGameObject AsReadOnly(this GameObject self) => new ReadOnlyGameObject(self);
    }
}