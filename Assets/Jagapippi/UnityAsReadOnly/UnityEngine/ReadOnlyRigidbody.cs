using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRigidbody
    {
        float angularDrag { get; }
        Vector3 angularVelocity { get; }
        Vector3 centerOfMass { get; }
        CollisionDetectionMode collisionDetectionMode { get; }
        RigidbodyConstraints constraints { get; }
        bool detectCollisions { get; }
        float drag { get; }
        bool freezeRotation { get; }
        Vector3 inertiaTensor { get; }
        Quaternion inertiaTensorRotation { get; }
        RigidbodyInterpolation interpolation { get; }
        bool isKinematic { get; }
        float mass { get; }
        float maxAngularVelocity { get; }
        float maxDepenetrationVelocity { get; }
        Vector3 position { get; }
        Quaternion rotation { get; }
        float sleepThreshold { get; }
        int solverIterations { get; }
        int solverVelocityIterations { get; }
        bool useGravity { get; }
        Vector3 velocity { get; }
        Vector3 worldCenterOfMass { get; }
        // void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier, ForceMode mode);
        // void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier);
        // void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius);
        // void AddForce(Vector3 force, ForceMode mode);
        // void AddForce(Vector3 force);
        // void AddForce(float x, float y, float z, ForceMode mode);
        // void AddForce(float x, float y, float z);
        // void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode mode);
        // void AddForceAtPosition(Vector3 force, Vector3 position);
        // void AddRelativeForce(Vector3 force, ForceMode mode);
        // void AddRelativeForce(Vector3 force);
        // void AddRelativeForce(float x, float y, float z, ForceMode mode);
        // void AddRelativeForce(float x, float y, float z);
        // void AddRelativeTorque(Vector3 torque, ForceMode mode);
        // void AddRelativeTorque(Vector3 torque);
        // void AddRelativeTorque(float x, float y, float z, ForceMode mode);
        // void AddRelativeTorque(float x, float y, float z);
        // void AddTorque(Vector3 torque, ForceMode mode);
        // void AddTorque(Vector3 torque);
        // void AddTorque(float x, float y, float z, ForceMode mode);
        // void AddTorque(float x, float y, float z);
        Vector3 ClosestPointOnBounds(Vector3 position);
        Vector3 GetPointVelocity(Vector3 worldPoint);
        Vector3 GetRelativePointVelocity(Vector3 relativePoint);
        bool IsSleeping();
        // void MovePosition(Vector3 position);
        // void MoveRotation(Quaternion rot);
        // void ResetCenterOfMass();
        // void ResetInertiaTensor();
        // void SetDensity(float density);
        // void Sleep();
        bool SweepTest(Vector3 direction, out RaycastHit hitInfo, float maxDistance, QueryTriggerInteraction queryTriggerInteraction);
        bool SweepTest(Vector3 direction, out RaycastHit hitInfo, float maxDistance);
        bool SweepTest(Vector3 direction, out RaycastHit hitInfo);
        RaycastHit[] SweepTestAll(Vector3 direction, float maxDistance, QueryTriggerInteraction queryTriggerInteraction);
        RaycastHit[] SweepTestAll(Vector3 direction, float maxDistance);
        RaycastHit[] SweepTestAll(Vector3 direction);
        // void WakeUp();
    }

    public abstract class ReadOnlyRigidbody<T> : ReadOnlyComponent<T>, IReadOnlyRigidbody where T : Rigidbody
    {
        protected ReadOnlyRigidbody(T obj) : base(obj)
        {
        }

        #region Properties

        public float angularDrag => _obj.angularDrag;
        public Vector3 angularVelocity => _obj.angularVelocity;
        public Vector3 centerOfMass => _obj.centerOfMass;
        public CollisionDetectionMode collisionDetectionMode => _obj.collisionDetectionMode;
        public RigidbodyConstraints constraints => _obj.constraints;
        public bool detectCollisions => _obj.detectCollisions;
        public float drag => _obj.drag;
        public bool freezeRotation => _obj.freezeRotation;
        public Vector3 inertiaTensor => _obj.inertiaTensor;
        public Quaternion inertiaTensorRotation => _obj.inertiaTensorRotation;
        public RigidbodyInterpolation interpolation => _obj.interpolation;
        public bool isKinematic => _obj.isKinematic;
        public float mass => _obj.mass;
        public float maxAngularVelocity => _obj.maxAngularVelocity;
        public float maxDepenetrationVelocity => _obj.maxDepenetrationVelocity;
        public Vector3 position => _obj.position;
        public Quaternion rotation => _obj.rotation;
        public float sleepThreshold => _obj.sleepThreshold;
        public int solverIterations => _obj.solverIterations;
        public int solverVelocityIterations => _obj.solverVelocityIterations;
        public bool useGravity => _obj.useGravity;
        public Vector3 velocity => _obj.velocity;
        public Vector3 worldCenterOfMass => _obj.worldCenterOfMass;

        #endregion

        #region Public Methods

        // public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier, ForceMode mode) => _obj.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier, mode);
        // public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier) => _obj.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier);
        // public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius) => _obj.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        // public void AddForce(Vector3 force, ForceMode mode) => _obj.AddForce(force, mode);
        // public void AddForce(Vector3 force) => _obj.AddForce(force);
        // public void AddForce(float x, float y, float z, ForceMode mode) => _obj.AddForce(x, y, z, mode);
        // public void AddForce(float x, float y, float z) => _obj.AddForce(x, y, z);
        // public void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode mode) => _obj.AddForceAtPosition(force, position, mode);
        // public void AddForceAtPosition(Vector3 force, Vector3 position) => _obj.AddForceAtPosition(force, position);
        // public void AddRelativeForce(Vector3 force, ForceMode mode) => _obj.AddRelativeForce(force, mode);
        // public void AddRelativeForce(Vector3 force) => _obj.AddRelativeForce(force);
        // public void AddRelativeForce(float x, float y, float z, ForceMode mode) => _obj.AddRelativeForce(x, y, z, mode);
        // public void AddRelativeForce(float x, float y, float z) => _obj.AddRelativeForce(x, y, z);
        // public void AddRelativeTorque(Vector3 torque, ForceMode mode) => _obj.AddRelativeTorque(torque, mode);
        // public void AddRelativeTorque(Vector3 torque) => _obj.AddRelativeTorque(torque);
        // public void AddRelativeTorque(float x, float y, float z, ForceMode mode) => _obj.AddRelativeTorque(x, y, z, mode);
        // public void AddRelativeTorque(float x, float y, float z) => _obj.AddRelativeTorque(x, y, z);
        // public void AddTorque(Vector3 torque, ForceMode mode) => _obj.AddTorque(torque, mode);
        // public void AddTorque(Vector3 torque) => _obj.AddTorque(torque);
        // public void AddTorque(float x, float y, float z, ForceMode mode) => _obj.AddTorque(x, y, z, mode);
        // public void AddTorque(float x, float y, float z) => _obj.AddTorque(x, y, z);
        public Vector3 ClosestPointOnBounds(Vector3 position) => _obj.ClosestPointOnBounds(position);
        public Vector3 GetPointVelocity(Vector3 worldPoint) => _obj.GetPointVelocity(worldPoint);
        public Vector3 GetRelativePointVelocity(Vector3 relativePoint) => _obj.GetRelativePointVelocity(relativePoint);
        public bool IsSleeping() => _obj.IsSleeping();
        // public void MovePosition(Vector3 position) => _obj.MovePosition(position);
        // public void MoveRotation(Quaternion rot) => _obj.MoveRotation(rot);
        // public void ResetCenterOfMass() => _obj.ResetCenterOfMass();
        // public void ResetInertiaTensor() => _obj.ResetInertiaTensor();
        // public void SetDensity(float density) => _obj.SetDensity(density);
        // public void Sleep() => _obj.Sleep();
        public bool SweepTest(Vector3 direction, out RaycastHit hitInfo, float maxDistance, QueryTriggerInteraction queryTriggerInteraction) => _obj.SweepTest(direction, out hitInfo, maxDistance, queryTriggerInteraction);
        public bool SweepTest(Vector3 direction, out RaycastHit hitInfo, float maxDistance) => _obj.SweepTest(direction, out hitInfo, maxDistance);
        public bool SweepTest(Vector3 direction, out RaycastHit hitInfo) => _obj.SweepTest(direction, out hitInfo);
        public RaycastHit[] SweepTestAll(Vector3 direction, float maxDistance, QueryTriggerInteraction queryTriggerInteraction) => _obj.SweepTestAll(direction, maxDistance, queryTriggerInteraction);
        public RaycastHit[] SweepTestAll(Vector3 direction, float maxDistance) => _obj.SweepTestAll(direction, maxDistance);
        public RaycastHit[] SweepTestAll(Vector3 direction) => _obj.SweepTestAll(direction);
        // public void WakeUp() => _obj.WakeUp();

        #endregion
    }

    public sealed class ReadOnlyRigidbody : ReadOnlyRigidbody<Rigidbody>
    {
        public ReadOnlyRigidbody(Rigidbody obj) : base(obj)
        {
        }
    }

    public static class RigidbodyExtensions
    {
        public static ReadOnlyRigidbody AsReadOnly(this Rigidbody self) => self.IsTrulyNull() ? null : new ReadOnlyRigidbody(self);
    }
}