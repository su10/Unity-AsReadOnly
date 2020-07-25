using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyGradient
    {
        GradientAlphaKey[] alphaKeys { get; }
        GradientColorKey[] colorKeys { get; }
        GradientMode mode { get; }
        bool Equals(object o);
        bool Equals(Gradient other);
        Color Evaluate(float time);
        int GetHashCode();
        // void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys);
    }

    public class ReadOnlyGradient<T> : IReadOnlyGradient, IEquatable<Gradient>, IEquatable<ReadOnlyGradient> where T : Gradient
    {
        private readonly T _obj;

        public ReadOnlyGradient(T obj)
        {
            if (obj.IsTrulyNull()) throw new ArgumentNullException(nameof(obj));

            _obj = obj;
        }

        #region Properties

        public GradientAlphaKey[] alphaKeys => _obj.alphaKeys;
        public GradientColorKey[] colorKeys => _obj.colorKeys;
        public GradientMode mode => _obj.mode;

        #endregion

        #region Public Methods

        public bool Equals(Gradient other) => _obj.Equals(other);
        public bool Equals(ReadOnlyGradient other) => _obj.Equals(other._obj);
        public override bool Equals(object o) => _obj.Equals(o);
        public Color Evaluate(float time) => _obj.Evaluate(time);
        public override int GetHashCode() => _obj.GetHashCode();
        // public void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys) => _obj.SetKeys(colorKeys, alphaKeys);

        #endregion
    }

    public sealed class ReadOnlyGradient : ReadOnlyGradient<Gradient>
    {
        public ReadOnlyGradient(Gradient obj) : base(obj)
        {
        }
    }

    public static class GradientExtensions
    {
        public static ReadOnlyGradient AsReadOnly(this Gradient self) => self.IsTrulyNull() ? null : new ReadOnlyGradient(self);
        internal static bool IsTrulyNull(this Gradient self) => ReferenceEquals(self, null);
    }
}