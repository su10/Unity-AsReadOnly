using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAnimationClip
    {
        bool empty { get; }
        // AnimationEvent[] events { get; }
        float frameRate { get; }
        bool hasGenericRootTransform { get; }
        bool hasMotionCurves { get; }
        bool hasMotionFloatCurves { get; }
        bool hasRootCurves { get; }
        bool humanMotion { get; }
        bool legacy { get; }
        float length { get; }
        Bounds localBounds { get; }
        WrapMode wrapMode { get; }
        // void AddEvent(AnimationEvent evt);
        // void ClearCurves();
        // void EnsureQuaternionContinuity();
        void SampleAnimation(GameObject go, float time);
        // void SetCurve(string relativePath, Type type, string propertyName, AnimationCurve curve);
    }

    public sealed class ReadOnlyAnimationClip : ReadOnlyMotion<AnimationClip>, IReadOnlyAnimationClip
    {
        public ReadOnlyAnimationClip(AnimationClip obj) : base(obj)
        {
        }

        #region Properties

        public bool empty => _obj.empty;
        // public AnimationEvent[] events => _obj.events;
        public float frameRate => _obj.frameRate;
        public bool hasGenericRootTransform => _obj.hasGenericRootTransform;
        public bool hasMotionCurves => _obj.hasMotionCurves;
        public bool hasMotionFloatCurves => _obj.hasMotionFloatCurves;
        public bool hasRootCurves => _obj.hasRootCurves;
        public bool humanMotion => _obj.humanMotion;
        public new bool legacy => _obj.legacy;
        public float length => _obj.length;
        public Bounds localBounds => _obj.localBounds;
        public WrapMode wrapMode => _obj.wrapMode;

        #endregion

        #region Public Methods

        // public void AddEvent(AnimationEvent evt) => _obj.AddEvent(evt);
        // public void ClearCurves() => _obj.ClearCurves();
        // public void EnsureQuaternionContinuity() => _obj.EnsureQuaternionContinuity();
        public void SampleAnimation(GameObject go, float time) => _obj.SampleAnimation(go, time);
        // public void SetCurve(string relativePath, Type type, string propertyName, AnimationCurve curve) => _obj.SetCurve(relativePath, type, propertyName, curve);

        #endregion
    }

    public static class AnimationClipExtensions
    {
        public static ReadOnlyAnimationClip AsReadOnly(this AnimationClip self) => new ReadOnlyAnimationClip(self);
    }
}