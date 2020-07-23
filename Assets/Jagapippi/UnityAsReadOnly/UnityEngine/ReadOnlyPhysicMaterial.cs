using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyPhysicMaterial
    {
        PhysicMaterialCombine bounceCombine { get; }
        float bounciness { get; }
        float dynamicFriction { get; }
        PhysicMaterialCombine frictionCombine { get; }
        float staticFriction { get; }
    }

    public class ReadOnlyPhysicMaterial : ReadOnlyObject<PhysicMaterial>, IReadOnlyPhysicMaterial
    {
        public ReadOnlyPhysicMaterial(PhysicMaterial obj) : base(obj)
        {
        }

        #region Properties

        public PhysicMaterialCombine bounceCombine => _obj.bounceCombine;
        public float bounciness => _obj.bounciness;
        public float dynamicFriction => _obj.dynamicFriction;
        public PhysicMaterialCombine frictionCombine => _obj.frictionCombine;
        public float staticFriction => _obj.staticFriction;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class PhysicMaterialExtensions
    {
        public static ReadOnlyPhysicMaterial AsReadOnly(this PhysicMaterial self) => new ReadOnlyPhysicMaterial(self);
    }
}