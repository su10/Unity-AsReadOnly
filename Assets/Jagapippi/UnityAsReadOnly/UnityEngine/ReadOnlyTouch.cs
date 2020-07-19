using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyTouch
    {
        private readonly Touch _touch;

        public ReadOnlyTouch(Touch touch)
        {
            _touch = touch;
        }

        #region Properties

        public float altitudeAngle => _touch.altitudeAngle;
        public float azimuthAngle => _touch.azimuthAngle;
        public Vector2 deltaPosition => _touch.deltaPosition;
        public float deltaTime => _touch.deltaTime;
        public int fingerId => _touch.fingerId;
        public float maximumPossiblePressure => _touch.maximumPossiblePressure;
        public TouchPhase phase => _touch.phase;
        public Vector2 position => _touch.position;
        public float pressure => _touch.pressure;
        public float radius => _touch.radius;
        public float radiusVariance => _touch.radiusVariance;
        public Vector2 rawPosition => _touch.rawPosition;
        public int tapCount => _touch.tapCount;
        public TouchType type => _touch.type;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class TouchExtensions
    {
        public static ReadOnlyTouch AsReadOnly(this Touch self) => new ReadOnlyTouch(self);
    }
}