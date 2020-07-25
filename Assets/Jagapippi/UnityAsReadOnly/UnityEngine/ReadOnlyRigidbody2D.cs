using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRigidbody2D
    {
        float angularDrag { get; }
        float angularVelocity { get; }
        int attachedColliderCount { get; }
        RigidbodyType2D bodyType { get; }
        Vector2 centerOfMass { get; }
        CollisionDetectionMode2D collisionDetectionMode { get; }
        RigidbodyConstraints2D constraints { get; }
        float drag { get; }
        bool freezeRotation { get; }
        float gravityScale { get; }
        float inertia { get; }
        RigidbodyInterpolation2D interpolation { get; }
        bool isKinematic { get; }
        float mass { get; }
        Vector2 position { get; }
        float rotation { get; }
        IReadOnlyPhysicsMaterial2D sharedMaterial { get; }
        bool simulated { get; }
        RigidbodySleepMode2D sleepMode { get; }
        bool useAutoMass { get; }
        bool useFullKinematicContacts { get; }
        Vector2 velocity { get; }
        Vector2 worldCenterOfMass { get; }
        // void AddForce(Vector2 force);
        // void AddForce(Vector2 force, ForceMode2D mode);
        // void AddForceAtPosition(Vector2 force, Vector2 position);
        // void AddForceAtPosition(Vector2 force, Vector2 position, ForceMode2D mode);
        // void AddRelativeForce(Vector2 relativeForce);
        // void AddRelativeForce(Vector2 relativeForce, ForceMode2D mode);
        // void AddTorque(float torque);
        // void AddTorque(float torque, ForceMode2D mode);
        // int Cast(Vector2 direction, RaycastHit2D[] results);
        // int Cast(Vector2 direction, RaycastHit2D[] results, float distance);
        // int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results);
        // int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance);
        ColliderDistance2D Distance(Collider2D collider);
        ColliderDistance2D Distance(ReadOnlyCollider2D collider);
        // int GetAttachedColliders(Collider2D[] results);
        // int GetContacts(ContactPoint2D[] contacts);
        // int GetContacts(ContactFilter2D contactFilter, ContactPoint2D[] contacts);
        // int GetContacts(Collider2D[] colliders);
        // int GetContacts(ContactFilter2D contactFilter, Collider2D[] colliders);
        Vector2 GetPoint(Vector2 point);
        Vector2 GetPointVelocity(Vector2 point);
        Vector2 GetRelativePoint(Vector2 relativePoint);
        Vector2 GetRelativePointVelocity(Vector2 relativePoint);
        Vector2 GetRelativeVector(Vector2 relativeVector);
        Vector2 GetVector(Vector2 vector);
        bool IsAwake();
        bool IsSleeping();
        bool IsTouching(Collider2D collider);
        bool IsTouching(ReadOnlyCollider2D collider);
        bool IsTouching(Collider2D collider, ContactFilter2D contactFilter);
        bool IsTouching(ReadOnlyCollider2D collider, ContactFilter2D contactFilter);
        bool IsTouching(ContactFilter2D contactFilter);
        bool IsTouchingLayers();
        bool IsTouchingLayers(int layerMask);
        // void MovePosition(Vector2 position);
        // void MoveRotation(float angle);
        // int OverlapCollider(ContactFilter2D contactFilter, Collider2D[] results);
        bool OverlapPoint(Vector2 point);
        // void Sleep();
        // void WakeUp();
    }

    public sealed class ReadOnlyRigidbody2D : ReadOnlyComponent<Rigidbody2D>, IReadOnlyRigidbody2D
    {
        public ReadOnlyRigidbody2D(Rigidbody2D obj) : base(obj)
        {
        }

        #region Properties

        public float angularDrag => _obj.angularDrag;
        public float angularVelocity => _obj.angularVelocity;
        public int attachedColliderCount => _obj.attachedColliderCount;
        public RigidbodyType2D bodyType => _obj.bodyType;
        public Vector2 centerOfMass => _obj.centerOfMass;
        public CollisionDetectionMode2D collisionDetectionMode => _obj.collisionDetectionMode;
        public RigidbodyConstraints2D constraints => _obj.constraints;
        public float drag => _obj.drag;
        public bool freezeRotation => _obj.freezeRotation;
        public float gravityScale => _obj.gravityScale;
        public float inertia => _obj.inertia;
        public RigidbodyInterpolation2D interpolation => _obj.interpolation;
        public bool isKinematic => _obj.isKinematic;
        public float mass => _obj.mass;
        public Vector2 position => _obj.position;
        public float rotation => _obj.rotation;
        public ReadOnlyPhysicsMaterial2D sharedMaterial => _obj.sharedMaterial.AsReadOnly();
        IReadOnlyPhysicsMaterial2D IReadOnlyRigidbody2D.sharedMaterial => this.sharedMaterial;
        public bool simulated => _obj.simulated;
        public RigidbodySleepMode2D sleepMode => _obj.sleepMode;
        public bool useAutoMass => _obj.useAutoMass;
        public bool useFullKinematicContacts => _obj.useFullKinematicContacts;
        public Vector2 velocity => _obj.velocity;
        public Vector2 worldCenterOfMass => _obj.worldCenterOfMass;

        #endregion

        #region Public Methods

        // public void AddForce(Vector2 force) => _obj.AddForce(force);
        // public void AddForce(Vector2 force, ForceMode2D mode) => _obj.AddForce(force, mode);
        // public void AddForceAtPosition(Vector2 force, Vector2 position) => _obj.AddForceAtPosition(force, position);
        // public void AddForceAtPosition(Vector2 force, Vector2 position, ForceMode2D mode) => _obj.AddForceAtPosition(force, position, mode);
        // public void AddRelativeForce(Vector2 relativeForce) => _obj.AddRelativeForce(relativeForce);
        // public void AddRelativeForce(Vector2 relativeForce, ForceMode2D mode) => _obj.AddRelativeForce(relativeForce, mode);
        // public void AddTorque(float torque) => _obj.AddTorque(torque);
        // public void AddTorque(float torque, ForceMode2D mode) => _obj.AddTorque(torque, mode);
        // public int Cast(Vector2 direction, RaycastHit2D[] results) => _obj.Cast(direction, results);
        // public int Cast(Vector2 direction, RaycastHit2D[] results, float distance) => _obj.Cast(direction, results, distance);
        // public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results) => _obj.Cast(direction, contactFilter, results);
        // public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance) => _obj.Cast(direction, contactFilter, results, distance);
        public ColliderDistance2D Distance(Collider2D collider) => _obj.Distance(collider);
        public ColliderDistance2D Distance(ReadOnlyCollider2D collider) => _obj.Distance(collider._obj);
        // public int GetAttachedColliders(Collider2D[] results) => _obj.GetAttachedColliders(results);
        // public int GetContacts(ContactPoint2D[] contacts) => _obj.GetContacts(contacts);
        // public int GetContacts(ContactFilter2D contactFilter, ContactPoint2D[] contacts) => _obj.GetContacts(contactFilter, contacts);
        // public int GetContacts(Collider2D[] colliders) => _obj.GetContacts(colliders);
        // public int GetContacts(ContactFilter2D contactFilter, Collider2D[] colliders) => _obj.GetContacts(contactFilter, colliders);
        public Vector2 GetPoint(Vector2 point) => _obj.GetPoint(point);
        public Vector2 GetPointVelocity(Vector2 point) => _obj.GetPointVelocity(point);
        public Vector2 GetRelativePoint(Vector2 relativePoint) => _obj.GetRelativePoint(relativePoint);
        public Vector2 GetRelativePointVelocity(Vector2 relativePoint) => _obj.GetRelativePointVelocity(relativePoint);
        public Vector2 GetRelativeVector(Vector2 relativeVector) => _obj.GetRelativeVector(relativeVector);
        public Vector2 GetVector(Vector2 vector) => _obj.GetVector(vector);
        public bool IsAwake() => _obj.IsAwake();
        public bool IsSleeping() => _obj.IsSleeping();
        public bool IsTouching(Collider2D collider) => _obj.IsTouching(collider);
        public bool IsTouching(ReadOnlyCollider2D collider) => _obj.IsTouching(collider._obj);
        public bool IsTouching(Collider2D collider, ContactFilter2D contactFilter) => _obj.IsTouching(collider, contactFilter);
        public bool IsTouching(ReadOnlyCollider2D collider, ContactFilter2D contactFilter) => _obj.IsTouching(collider._obj, contactFilter);
        public bool IsTouching(ContactFilter2D contactFilter) => _obj.IsTouching(contactFilter);
        public bool IsTouchingLayers() => _obj.IsTouchingLayers();
        public bool IsTouchingLayers(int layerMask) => _obj.IsTouchingLayers(layerMask);
        // public void MovePosition(Vector2 position) => _obj.MovePosition(position);
        // public void MoveRotation(float angle) => _obj.MoveRotation(angle);
        // public int OverlapCollider(ContactFilter2D contactFilter, Collider2D[] results) => _obj.OverlapCollider(contactFilter, results);
        public bool OverlapPoint(Vector2 point) => _obj.OverlapPoint(point);
        // public void Sleep() => _obj.Sleep();
        // public void WakeUp() => _obj.WakeUp();

        #endregion
    }

    public static class Rigidbody2DExtensions
    {
        public static ReadOnlyRigidbody2D AsReadOnly(this Rigidbody2D self) => self.IsTrulyNull() ? null : new ReadOnlyRigidbody2D(self);
    }
}