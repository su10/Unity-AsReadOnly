using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyBehaviour
    {
        bool enabled { get; }
        bool isActiveAndEnabled { get; }
    }

    public class ReadOnlyBehaviour<T> : ReadOnlyComponent<T>, IReadOnlyBehaviour where T : Behaviour
    {
        protected ReadOnlyBehaviour(T obj) : base(obj)
        {
        }

        #region Properties

        public bool enabled => _obj.enabled;
        public bool isActiveAndEnabled => _obj.isActiveAndEnabled;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyBehaviour : ReadOnlyBehaviour<Behaviour>
    {
        public ReadOnlyBehaviour(Behaviour obj) : base(obj)
        {
        }
    }

    public static class BehaviourExtensions
    {
        public static ReadOnlyBehaviour AsReadOnly(this Behaviour self) => self.IsTrulyNull() ? null : new ReadOnlyBehaviour(self);
    }
}