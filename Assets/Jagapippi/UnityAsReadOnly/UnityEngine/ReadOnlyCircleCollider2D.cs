using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCircleCollider2D
    {
        float radius { get; }
    }

    public sealed class ReadOnlyCircleCollider2D : ReadOnlyCollider2D<CircleCollider2D>, IReadOnlyCircleCollider2D
    {
        public ReadOnlyCircleCollider2D(CircleCollider2D obj) : base(obj)
        {
        }

        #region Properties

        public float radius => _obj.radius;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class CircleCollider2DExtensions
    {
        public static ReadOnlyCircleCollider2D AsReadOnly(this CircleCollider2D self) => self.IsTrulyNull() ? null : new ReadOnlyCircleCollider2D(self);
    }
}