using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyWheelCollider
    {
        float brakeTorque { get; }
        Vector3 center { get; }
        float forceAppPointDistance { get; }
        WheelFrictionCurve forwardFriction { get; }
        bool isGrounded { get; }
        float mass { get; }
        float motorTorque { get; }
        float radius { get; }
        float rpm { get; }
        WheelFrictionCurve sidewaysFriction { get; }
        float sprungMass { get; }
        float steerAngle { get; }
        float suspensionDistance { get; }
        JointSpring suspensionSpring { get; }
        float wheelDampingRate { get; }
        // void ConfigureVehicleSubsteps(float speedThreshold, int stepsBelowThreshold, int stepsAboveThreshold);
        bool GetGroundHit(out WheelHit hit);
        void GetWorldPose(out Vector3 pos, out Quaternion quat);
    }

    public abstract class ReadOnlyWheelCollider<T> : ReadOnlyCollider<T>, IReadOnlyWheelCollider where T : WheelCollider
    {
        protected ReadOnlyWheelCollider(T obj) : base(obj)
        {
        }

        #region Properties

        public float brakeTorque => _obj.brakeTorque;
        public Vector3 center => _obj.center;
        public float forceAppPointDistance => _obj.forceAppPointDistance;
        public WheelFrictionCurve forwardFriction => _obj.forwardFriction;
        public bool isGrounded => _obj.isGrounded;
        public float mass => _obj.mass;
        public float motorTorque => _obj.motorTorque;
        public float radius => _obj.radius;
        public float rpm => _obj.rpm;
        public WheelFrictionCurve sidewaysFriction => _obj.sidewaysFriction;
        public float sprungMass => _obj.sprungMass;
        public float steerAngle => _obj.steerAngle;
        public float suspensionDistance => _obj.suspensionDistance;
        public JointSpring suspensionSpring => _obj.suspensionSpring;
        public float wheelDampingRate => _obj.wheelDampingRate;

        #endregion

        #region Public Methods

        // public void ConfigureVehicleSubsteps(float speedThreshold, int stepsBelowThreshold, int stepsAboveThreshold) => _obj.ConfigureVehicleSubsteps(speedThreshold, stepsBelowThreshold, stepsAboveThreshold);
        public bool GetGroundHit(out WheelHit hit) => _obj.GetGroundHit(out hit);
        public void GetWorldPose(out Vector3 pos, out Quaternion quat) => _obj.GetWorldPose(out pos, out quat);

        #endregion
    }

    public sealed class ReadOnlyWheelCollider : ReadOnlyWheelCollider<WheelCollider>
    {
        public ReadOnlyWheelCollider(WheelCollider obj) : base(obj)
        {
        }
    }

    public static class WheelColliderExtensions
    {
        public static ReadOnlyWheelCollider AsReadOnly(this WheelCollider self) => self.IsTrulyNull() ? null : new ReadOnlyWheelCollider(self);
    }
}