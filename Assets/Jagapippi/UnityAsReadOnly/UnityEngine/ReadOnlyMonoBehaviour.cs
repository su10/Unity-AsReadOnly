using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMonoBehaviour : IReadOnlyBehaviour
    {
#if UNITY_EDITOR
        bool runInEditMode { get; }
#endif
        bool useGUILayout { get; }
    }

    public class ReadOnlyMonoBehaviour<T> : ReadOnlyBehaviour<T>, IReadOnlyMonoBehaviour where T : MonoBehaviour
    {
        protected ReadOnlyMonoBehaviour(T obj) : base(obj)
        {
        }

        #region Properties

#if UNITY_EDITOR
        public bool runInEditMode => _obj.runInEditMode;
#endif
        public bool useGUILayout => _obj.useGUILayout;

        #endregion

        #region Public Methods

        // CancelInvoke
        // Invoke
        // InvokeRepeating
        // IsInvoking
        // StartCoroutine
        // StopAllCoroutines
        // StopCoroutine

        #endregion
    }

    public class ReadOnlyMonoBehaviour : ReadOnlyMonoBehaviour<MonoBehaviour>
    {
        public ReadOnlyMonoBehaviour(MonoBehaviour obj) : base(obj)
        {
        }
    }

    public static class MonoBehaviourExtensions
    {
        public static ReadOnlyMonoBehaviour AsReadOnly(this MonoBehaviour self) => new ReadOnlyMonoBehaviour(self);
    }
}