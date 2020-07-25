using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCapsuleCollider2D
    {
        CapsuleDirection2D direction { get; }
        Vector2 size { get; }
    }

    public sealed class ReadOnlyCapsuleCollider2D : ReadOnlyCollider2D<CapsuleCollider2D>, IReadOnlyCapsuleCollider2D
    {
        public ReadOnlyCapsuleCollider2D(CapsuleCollider2D obj) : base(obj)
        {
        }

        #region Properties

        public CapsuleDirection2D direction => _obj.direction;
        public Vector2 size => _obj.size;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class CapsuleCollider2DExtensions
    {
        public static ReadOnlyCapsuleCollider2D AsReadOnly(this CapsuleCollider2D self) => self.IsTrulyNull() ? null : new ReadOnlyCapsuleCollider2D(self);
    }
}