using System.Linq;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRuntimeAnimatorController
    {
        IReadOnlyAnimationClip[] animationClips { get; }
    }

    public class ReadOnlyRuntimeAnimatorController<T> : ReadOnlyObject<T>, IReadOnlyRuntimeAnimatorController where T : RuntimeAnimatorController
    {
        protected ReadOnlyRuntimeAnimatorController(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyAnimationClip[] animationClips => _obj.animationClips?.Select(a => a.AsReadOnly()).ToArray();
        IReadOnlyAnimationClip[] IReadOnlyRuntimeAnimatorController.animationClips => this.animationClips;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyRuntimeAnimatorController : ReadOnlyRuntimeAnimatorController<RuntimeAnimatorController>
    {
        public ReadOnlyRuntimeAnimatorController(RuntimeAnimatorController obj) : base(obj)
        {
        }
    }

    public static class RuntimeAnimatorControllerExtensions
    {
        public static ReadOnlyRuntimeAnimatorController AsReadOnly(this RuntimeAnimatorController self) => self.IsTrulyNull() ? null : new ReadOnlyRuntimeAnimatorController(self);
    }
}