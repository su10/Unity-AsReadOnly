using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyAnimatorClipInfo
    {
        private readonly AnimatorClipInfo _info;

        public ReadOnlyAnimatorClipInfo(AnimatorClipInfo info)
        {
            _info = info;
        }

        #region Properties

        public ReadOnlyAnimationClip clip => _info.clip.AsReadOnly();
        public float weight => _info.weight;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class AnimatorClipInfoExtensions
    {
        public static ReadOnlyAnimatorClipInfo AsReadOnly(this AnimatorClipInfo self) => new ReadOnlyAnimatorClipInfo(self);
    }
}