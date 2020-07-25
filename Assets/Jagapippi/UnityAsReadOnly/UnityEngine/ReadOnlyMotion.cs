using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMotion
    {
        float apparentSpeed { get; }
        float averageAngularSpeed { get; }
        float averageDuration { get; }
        Vector3 averageSpeed { get; }
        bool isHumanMotion { get; }
        bool isLooping { get; }
        bool legacy { get; }
    }

    public class ReadOnlyMotion<T> : ReadOnlyObject<T>, IReadOnlyMotion where T : Motion
    {
        protected ReadOnlyMotion(T obj) : base(obj)
        {
        }

        #region Properties

        public float apparentSpeed => _obj.apparentSpeed;
        public float averageAngularSpeed => _obj.averageAngularSpeed;
        public float averageDuration => _obj.averageDuration;
        public Vector3 averageSpeed => _obj.averageSpeed;
        public bool isHumanMotion => _obj.isHumanMotion;
        public bool isLooping => _obj.isLooping;
        public bool legacy => _obj.legacy;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyMotion : ReadOnlyMotion<Motion>
    {
        public ReadOnlyMotion(Motion obj) : base(obj)
        {
        }
    }

    public static class MotionExtensions
    {
        public static ReadOnlyMotion AsReadOnly(this Motion self) => self.IsTrulyNull() ? null : new ReadOnlyMotion(self);
    }
}