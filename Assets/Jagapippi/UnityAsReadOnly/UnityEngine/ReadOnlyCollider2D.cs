using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCollider2D
    {
        IReadOnlyRigidbody2D attachedRigidbody { get; }
        float bounciness { get; }
        Bounds bounds { get; }
        IReadOnlyCompositeCollider2D composite { get; }
        float density { get; }
        float friction { get; }
        bool isTrigger { get; }
        Vector2 offset { get; }
        int shapeCount { get; }
        IReadOnlyPhysicsMaterial2D sharedMaterial { get; }
        bool usedByComposite { get; }
        bool usedByEffector { get; }
        // int Cast(Vector2 direction, RaycastHit2D[] results);
        // int Cast(Vector2 direction, RaycastHit2D[] results, float distance);
        // int Cast(Vector2 direction, RaycastHit2D[] results, float distance, bool ignoreSiblingColliders);
        // int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results);
        // int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance);
        // int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance, bool ignoreSiblingColliders);
        ColliderDistance2D Distance(Collider2D collider);
        ColliderDistance2D Distance(ReadOnlyCollider2D collider);
        // int GetContacts(ContactPoint2D[] contacts);
        // int GetContacts(ContactFilter2D contactFilter, ContactPoint2D[] contacts);
        // int GetContacts(Collider2D[] colliders);
        // int GetContacts(ContactFilter2D contactFilter, Collider2D[] colliders);
        bool IsTouching(Collider2D collider);
        bool IsTouching(ReadOnlyCollider2D collider);
        bool IsTouching(Collider2D collider, ContactFilter2D contactFilter);
        bool IsTouching(ReadOnlyCollider2D collider, ContactFilter2D contactFilter);
        bool IsTouching(ContactFilter2D contactFilter);
        bool IsTouchingLayers();
        bool IsTouchingLayers(int layerMask);
        // int OverlapCollider(ContactFilter2D contactFilter, Collider2D[] results);
        bool OverlapPoint(Vector2 point);
        // int Raycast(Vector2 direction, RaycastHit2D[] results);
        // int Raycast(Vector2 direction, RaycastHit2D[] results, float distance);
        // int Raycast(Vector2 direction, RaycastHit2D[] results, float distance, int layerMask);
        // int Raycast(Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth);
        // int Raycast(Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth);
        // int Raycast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results);
        // int Raycast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance);
    }

    public abstract class ReadOnlyCollider2D<T> : ReadOnlyBehaviour<T>, IReadOnlyCollider2D where T : Collider2D
    {
        protected ReadOnlyCollider2D(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyRigidbody2D attachedRigidbody => _obj.attachedRigidbody.AsReadOnly();
        IReadOnlyRigidbody2D IReadOnlyCollider2D.attachedRigidbody => this.attachedRigidbody;
        public float bounciness => _obj.bounciness;
        public Bounds bounds => _obj.bounds;
        public ReadOnlyCompositeCollider2D composite => _obj.composite.AsReadOnly();
        IReadOnlyCompositeCollider2D IReadOnlyCollider2D.composite => this.composite;
        public float density => _obj.density;
        public float friction => _obj.friction;
        public bool isTrigger => _obj.isTrigger;
        public Vector2 offset => _obj.offset;
        public int shapeCount => _obj.shapeCount;
        public ReadOnlyPhysicsMaterial2D sharedMaterial => _obj.sharedMaterial.AsReadOnly();
        IReadOnlyPhysicsMaterial2D IReadOnlyCollider2D.sharedMaterial => this.sharedMaterial;
        public bool usedByComposite => _obj.usedByComposite;
        public bool usedByEffector => _obj.usedByEffector;

        #endregion

        #region Public Methods

        // public int Cast(Vector2 direction, RaycastHit2D[] results) => _obj.Cast(direction, results);
        // public int Cast(Vector2 direction, RaycastHit2D[] results, float distance) => _obj.Cast(direction, results, distance);
        // public int Cast(Vector2 direction, RaycastHit2D[] results, float distance, bool ignoreSiblingColliders) => _obj.Cast(direction, results, distance, ignoreSiblingColliders);
        // public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results) => _obj.Cast(direction, contactFilter, results);
        // public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance) => _obj.Cast(direction, contactFilter, results, distance);
        // public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance, bool ignoreSiblingColliders) => _obj.Cast(direction, contactFilter, results, distance, ignoreSiblingColliders);
        public ColliderDistance2D Distance(Collider2D collider) => _obj.Distance(collider);
        public ColliderDistance2D Distance(ReadOnlyCollider2D collider) => _obj.Distance(collider._obj);
        // public int GetContacts(ContactPoint2D[] contacts) => _obj.GetContacts(contacts);
        // public int GetContacts(ContactFilter2D contactFilter, ContactPoint2D[] contacts) => _obj.GetContacts(contactFilter, contacts);
        // public int GetContacts(Collider2D[] colliders) => _obj.GetContacts(colliders);
        // public int GetContacts(ContactFilter2D contactFilter, Collider2D[] colliders) => _obj.GetContacts(contactFilter, colliders);
        public bool IsTouching(Collider2D collider) => _obj.IsTouching(collider);
        public bool IsTouching(ReadOnlyCollider2D collider) => _obj.IsTouching(collider._obj);
        public bool IsTouching(Collider2D collider, ContactFilter2D contactFilter) => _obj.IsTouching(collider, contactFilter);
        public bool IsTouching(ReadOnlyCollider2D collider, ContactFilter2D contactFilter) => _obj.IsTouching(collider._obj, contactFilter);
        public bool IsTouching(ContactFilter2D contactFilter) => _obj.IsTouching(contactFilter);
        public bool IsTouchingLayers() => _obj.IsTouchingLayers();
        public bool IsTouchingLayers(int layerMask) => _obj.IsTouchingLayers(layerMask);
        // public int OverlapCollider(ContactFilter2D contactFilter, Collider2D[] results) => _obj.OverlapCollider(contactFilter, results);
        public bool OverlapPoint(Vector2 point) => _obj.OverlapPoint(point);
        // public int Raycast(Vector2 direction, RaycastHit2D[] results) => _obj.Raycast(direction, results);
        // public int Raycast(Vector2 direction, RaycastHit2D[] results, float distance) => _obj.Raycast(direction, results, distance);
        // public int Raycast(Vector2 direction, RaycastHit2D[] results, float distance, int layerMask) => _obj.Raycast(direction, results, distance, layerMask);
        // public int Raycast(Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth) => _obj.Raycast(direction, results, distance, layerMask, minDepth);
        // public int Raycast(Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth) => _obj.Raycast(direction, results, distance, layerMask, minDepth, maxDepth);
        // public int Raycast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results) => _obj.Raycast(direction, contactFilter, results);
        // public int Raycast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance) => _obj.Raycast(direction, contactFilter, results, distance);

        #endregion
    }

    public sealed class ReadOnlyCollider2D : ReadOnlyCollider2D<Collider2D>
    {
        public ReadOnlyCollider2D(Collider2D obj) : base(obj)
        {
        }
    }

    public static class Collider2DExtensions
    {
        public static ReadOnlyCollider2D AsReadOnly(this Collider2D self) => self.IsTrulyNull() ? null : new ReadOnlyCollider2D(self);
    }
}