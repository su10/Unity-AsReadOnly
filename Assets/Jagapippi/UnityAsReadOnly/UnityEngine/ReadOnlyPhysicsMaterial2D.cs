using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyPhysicsMaterial2D
    {
        float bounciness { get; }
        float friction { get; }
    }

    public sealed class ReadOnlyPhysicsMaterial2D : ReadOnlyObject<PhysicsMaterial2D>, IReadOnlyPhysicsMaterial2D
    {
        public ReadOnlyPhysicsMaterial2D(PhysicsMaterial2D obj) : base(obj)
        {
        }

        #region Properties

        public float bounciness => _obj.bounciness;
        public float friction => _obj.friction;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class PhysicsMaterial2DExtensions
    {
        public static ReadOnlyPhysicsMaterial2D AsReadOnly(this PhysicsMaterial2D self) => self.IsTrulyNull() ? null : new ReadOnlyPhysicsMaterial2D(self);
    }
}