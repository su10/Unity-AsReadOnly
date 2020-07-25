using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCollider
    {
        IReadOnlyRigidbody attachedRigidbody { get; }
        Bounds bounds { get; }
        float contactOffset { get; }
        bool enabled { get; }
        bool isTrigger { get; }
        IReadOnlyPhysicMaterial material { get; }
        IReadOnlyPhysicMaterial sharedMaterial { get; }
        Vector3 ClosestPoint(Vector3 position);
        Vector3 ClosestPointOnBounds(Vector3 position);
        bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance);
    }

    public class ReadOnlyCollider<T> : ReadOnlyComponent<T>, IReadOnlyCollider where T : Collider
    {
        protected ReadOnlyCollider(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyRigidbody attachedRigidbody => _obj.attachedRigidbody.AsReadOnly();
        IReadOnlyRigidbody IReadOnlyCollider.attachedRigidbody => this.attachedRigidbody;
        public Bounds bounds => _obj.bounds;
        public float contactOffset => _obj.contactOffset;
        public bool enabled => _obj.enabled;
        public bool isTrigger => _obj.isTrigger;
        public ReadOnlyPhysicMaterial material => _obj.material.AsReadOnly();
        IReadOnlyPhysicMaterial IReadOnlyCollider.material => this.material;
        public ReadOnlyPhysicMaterial sharedMaterial => _obj.sharedMaterial.AsReadOnly();
        IReadOnlyPhysicMaterial IReadOnlyCollider.sharedMaterial => this.sharedMaterial;

        #endregion

        #region Public Methods

        public Vector3 ClosestPoint(Vector3 position) => _obj.ClosestPoint(position);
        public Vector3 ClosestPointOnBounds(Vector3 position) => _obj.ClosestPointOnBounds(position);
        public bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance) => _obj.Raycast(ray, out hitInfo, maxDistance);

        #endregion
    }

    public sealed class ReadOnlyCollider : ReadOnlyCollider<Collider>
    {
        public ReadOnlyCollider(Collider obj) : base(obj)
        {
        }
    }

    public static class ColliderExtensions
    {
        public static ReadOnlyCollider AsReadOnly(this Collider self) => self.IsTrulyNull() ? null : new ReadOnlyCollider(self);
    }
}