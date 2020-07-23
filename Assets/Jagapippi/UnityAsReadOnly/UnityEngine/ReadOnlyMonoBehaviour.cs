using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMonoBehaviour
    {
#if UNITY_EDITOR
        bool runInEditMode { get; }
#endif
        bool useGUILayout { get; }
        // void CancelInvoke();
        // void CancelInvoke(string methodName);
        // void Invoke(string methodName, float time);
        // void InvokeRepeating(string methodName, float time, float repeatRate);
        bool IsInvoking();
        bool IsInvoking(string methodName);
        // Coroutine StartCoroutine(string methodName);
        // Coroutine StartCoroutine(string methodName, object value);
        // Coroutine StartCoroutine(IEnumerator routine);
        // void StopAllCoroutines();
        // void StopCoroutine(IEnumerator routine);
        // void StopCoroutine(Coroutine routine);
        // void StopCoroutine(string methodName);
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

        // public void CancelInvoke() => _obj.CancelInvoke();
        // public void CancelInvoke(string methodName) => _obj.CancelInvoke(methodName);
        // public void Invoke(string methodName, float time) => _obj.Invoke(methodName, time);
        // public void InvokeRepeating(string methodName, float time, float repeatRate) => _obj.InvokeRepeating(methodName, time, repeatRate);
        public bool IsInvoking() => _obj.IsInvoking();
        public bool IsInvoking(string methodName) => _obj.IsInvoking(methodName);
        // public Coroutine StartCoroutine(string methodName) => _obj.StartCoroutine(methodName);
        // public Coroutine StartCoroutine(string methodName, object value) => _obj.StartCoroutine(methodName, value);
        // public Coroutine StartCoroutine(IEnumerator routine) => _obj.StartCoroutine(routine);
        // public void StopAllCoroutines() => _obj.StopAllCoroutines();
        // public void StopCoroutine(IEnumerator routine) => _obj.StopCoroutine(routine);
        // public void StopCoroutine(Coroutine routine) => _obj.StopCoroutine(routine);
        // public void StopCoroutine(string methodName) => _obj.StopCoroutine(methodName);

        #endregion
    }

    public sealed class ReadOnlyMonoBehaviour : ReadOnlyMonoBehaviour<MonoBehaviour>
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