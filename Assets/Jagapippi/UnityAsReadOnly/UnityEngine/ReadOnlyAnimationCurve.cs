using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAnimationCurve
    {
        Keyframe[] keys { get; }
        int length { get; }
        WrapMode postWrapMode { get; }
        WrapMode preWrapMode { get; }
        // int AddKey(float time, float value);
        // int AddKey(Keyframe key);
        bool Equals(object o);
        bool Equals(AnimationCurve other);
        float Evaluate(float time);
        int GetHashCode();
        // int MoveKey(int index, Keyframe key);
        // void RemoveKey(int index);
        // void SmoothTangents(int index, float weight);
    }

    public abstract class ReadOnlyAnimationCurve<T> : IReadOnlyAnimationCurve, IEquatable<AnimationCurve>, IEquatable<ReadOnlyAnimationCurve> where T : AnimationCurve
    {
        protected internal readonly T _obj;

        protected ReadOnlyAnimationCurve(T obj)
        {
            if (obj.IsTrulyNull()) throw new ArgumentNullException(nameof(obj));

            _obj = obj;
        }

        #region Properties

        public Keyframe[] keys => _obj.keys;
        public int length => _obj.length;
        public WrapMode postWrapMode => _obj.postWrapMode;
        public WrapMode preWrapMode => _obj.preWrapMode;

        #endregion

        #region Public Methods

        // public int AddKey(float time, float value) => _obj.AddKey(time, value);
        // public int AddKey(Keyframe key) => _obj.AddKey(key);
        public override bool Equals(object o) => _obj.Equals(o);
        public bool Equals(AnimationCurve other) => _obj.Equals(other);
        public bool Equals(ReadOnlyAnimationCurve other) => _obj.Equals(other._obj);
        public float Evaluate(float time) => _obj.Evaluate(time);
        public override int GetHashCode() => _obj.GetHashCode();
        // public int MoveKey(int index, Keyframe key) => _obj.MoveKey(index, key);
        // public void RemoveKey(int index) => _obj.RemoveKey(index);
        // public void SmoothTangents(int index, float weight) => _obj.SmoothTangents(index, weight);

        #endregion
    }

    public sealed class ReadOnlyAnimationCurve : ReadOnlyAnimationCurve<AnimationCurve>
    {
        public ReadOnlyAnimationCurve(AnimationCurve obj) : base(obj)
        {
        }
    }

    public static class AnimationCurveExtensions
    {
        public static ReadOnlyAnimationCurve AsReadOnly(this AnimationCurve self) => self.IsTrulyNull() ? null : new ReadOnlyAnimationCurve(self);
        internal static bool IsTrulyNull(this AnimationCurve self) => ReferenceEquals(self, null);
    }
}