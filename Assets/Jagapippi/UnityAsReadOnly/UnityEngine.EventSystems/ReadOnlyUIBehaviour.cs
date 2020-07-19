using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyUIBehaviour : IReadOnlyMonoBehaviour
    {
        bool IsActive();
        bool IsDestroyed();
    }

    public class ReadOnlyUIBehaviour<T> : ReadOnlyMonoBehaviour<T>, IReadOnlyUIBehaviour where T : UIBehaviour
    {
        protected ReadOnlyUIBehaviour(T obj) : base(obj)
        {
        }

        #region Properties

        #endregion

        #region Public Methods

        public virtual bool IsActive() => _obj.IsActive();
        public bool IsDestroyed() => _obj.IsDestroyed();

        #endregion
    }

    public sealed class ReadOnlyUIBehaviour : ReadOnlyUIBehaviour<UIBehaviour>
    {
        public ReadOnlyUIBehaviour(UIBehaviour obj) : base(obj)
        {
        }
    }

    public static class UIBehaviourExtensions
    {
        public static IReadOnlyUIBehaviour AsReadOnly(this UIBehaviour self) => new ReadOnlyUIBehaviour(self);
    }
}