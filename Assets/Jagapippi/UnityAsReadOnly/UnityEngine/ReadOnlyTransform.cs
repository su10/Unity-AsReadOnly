using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTransform : IEnumerable<IReadOnlyTransform>
    {
        int childCount { get; }
        Vector3 eulerAngles { get; }
        Vector3 forward { get; }
        bool hasChanged { get; }
        int hierarchyCapacity { get; }
        int hierarchyCount { get; }
        Vector3 localEulerAngles { get; }
        Vector3 localPosition { get; }
        Quaternion localRotation { get; }
        Vector3 localScale { get; }
        Matrix4x4 localToWorldMatrix { get; }
        Vector3 lossyScale { get; }
        IReadOnlyTransform parent { get; }
        Vector3 position { get; }
        Vector3 right { get; }
        IReadOnlyTransform root { get; }
        Quaternion rotation { get; }
        Vector3 up { get; }
        Matrix4x4 worldToLocalMatrix { get; }
        // void DetachChildren();
        IReadOnlyTransform Find(string n);
        IReadOnlyTransform GetChild(int index);
        new IEnumerator<IReadOnlyTransform> GetEnumerator();
        int GetSiblingIndex();
        Vector3 InverseTransformDirection(Vector3 direction);
        Vector3 InverseTransformDirection(float x, float y, float z);
        Vector3 InverseTransformPoint(Vector3 position);
        Vector3 InverseTransformPoint(float x, float y, float z);
        Vector3 InverseTransformVector(Vector3 vector);
        Vector3 InverseTransformVector(float x, float y, float z);
        bool IsChildOf(Transform parent);
        bool IsChildOf(ReadOnlyTransform parent);
        // void LookAt(Transform target, Vector3 worldUp);
        // void LookAt(Transform target);
        // void LookAt(Vector3 worldPosition, Vector3 worldUp);
        // void LookAt(Vector3 worldPosition);
        // void Rotate(Vector3 eulers, Space relativeTo);
        // void Rotate(Vector3 eulers);
        // void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo);
        // void Rotate(float xAngle, float yAngle, float zAngle);
        // void Rotate(Vector3 axis, float angle, Space relativeTo);
        // void Rotate(Vector3 axis, float angle);
        // void RotateAround(Vector3 point, Vector3 axis, float angle);
        // void SetAsFirstSibling();
        // void SetAsLastSibling();
        // void SetParent(Transform p);
        // void SetParent(Transform parent, bool worldPositionStays);
        // void SetPositionAndRotation(Vector3 position, Quaternion rotation);
        // void SetSiblingIndex(int index);
        Vector3 TransformDirection(Vector3 direction);
        Vector3 TransformDirection(float x, float y, float z);
        Vector3 TransformPoint(Vector3 position);
        Vector3 TransformPoint(float x, float y, float z);
        Vector3 TransformVector(Vector3 vector);
        Vector3 TransformVector(float x, float y, float z);
        // void Translate(Vector3 translation, Space relativeTo);
        // void Translate(Vector3 translation);
        // void Translate(float x, float y, float z, Space relativeTo);
        // void Translate(float x, float y, float z);
        // void Translate(Vector3 translation, Transform relativeTo);
        // void Translate(float x, float y, float z, Transform relativeTo);
    }

    public class ReadOnlyTransform<T> : ReadOnlyComponent<T>, IReadOnlyTransform, IEnumerable<ReadOnlyTransform> where T : Transform
    {
        protected ReadOnlyTransform(T obj) : base(obj)
        {
        }

        #region Properties

        public int childCount => _obj.childCount;
        public Vector3 eulerAngles => _obj.eulerAngles;
        public Vector3 forward => _obj.forward;
        public bool hasChanged => _obj.hasChanged;
        public int hierarchyCapacity => _obj.hierarchyCapacity;
        public int hierarchyCount => _obj.hierarchyCount;
        public Vector3 localEulerAngles => _obj.localEulerAngles;
        public Vector3 localPosition => _obj.localPosition;
        public Quaternion localRotation => _obj.localRotation;
        public Vector3 localScale => _obj.localScale;
        public Matrix4x4 localToWorldMatrix => _obj.localToWorldMatrix;
        public Vector3 lossyScale => _obj.lossyScale;
        public ReadOnlyTransform parent => _obj.parent.IsTrulyNull() ? null : _obj.parent.AsReadOnly();
        IReadOnlyTransform IReadOnlyTransform.parent => this.parent;
        public Vector3 position => _obj.position;
        public Vector3 right => _obj.right;
        public ReadOnlyTransform root => _obj.root.IsTrulyNull() ? null : _obj.root.AsReadOnly();
        IReadOnlyTransform IReadOnlyTransform.root => this.root;
        public Quaternion rotation => _obj.rotation;
        public Vector3 up => _obj.up;
        public Matrix4x4 worldToLocalMatrix => _obj.worldToLocalMatrix;

        #endregion

        #region Public Methods

        // public void DetachChildren() => _obj.DetachChildren();

        public ReadOnlyTransform Find(string n)
        {
            var transform = _obj.Find(n);
            return transform.IsTrulyNull() ? null : transform.AsReadOnly();
        }

        IReadOnlyTransform IReadOnlyTransform.Find(string n) => this.Find(n);

        public ReadOnlyTransform GetChild(int index)
        {
            var transform = _obj.GetChild(index);
            return transform.IsTrulyNull() ? null : transform.AsReadOnly();
        }

        IReadOnlyTransform IReadOnlyTransform.GetChild(int index) => this.GetChild(index);
        public IEnumerator<ReadOnlyTransform> GetEnumerator() => new Enumerator<ReadOnlyTransform<T>, ReadOnlyTransform>(this);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        IEnumerator<IReadOnlyTransform> IReadOnlyTransform.GetEnumerator() => new Enumerator<IReadOnlyTransform>(this);
        IEnumerator<IReadOnlyTransform> IEnumerable<IReadOnlyTransform>.GetEnumerator() => ((IReadOnlyTransform) this).GetEnumerator();
        public int GetSiblingIndex() => _obj.GetSiblingIndex();
        public Vector3 InverseTransformDirection(Vector3 direction) => _obj.InverseTransformDirection(direction);
        public Vector3 InverseTransformDirection(float x, float y, float z) => _obj.InverseTransformDirection(x, y, z);
        public Vector3 InverseTransformPoint(Vector3 position) => _obj.InverseTransformPoint(position);
        public Vector3 InverseTransformPoint(float x, float y, float z) => _obj.InverseTransformPoint(x, y, z);
        public Vector3 InverseTransformVector(Vector3 vector) => _obj.InverseTransformVector(vector);
        public Vector3 InverseTransformVector(float x, float y, float z) => _obj.InverseTransformVector(x, y, z);
        public bool IsChildOf(Transform parent) => _obj.IsChildOf(parent);
        public bool IsChildOf(ReadOnlyTransform parent) => _obj.IsChildOf(parent._obj);
        // public void LookAt(Transform target, Vector3 worldUp) => _obj.LookAt(target, worldUp);
        // public void LookAt(Transform target) => _obj.LookAt(target);
        // public void LookAt(Vector3 worldPosition, Vector3 worldUp) => _obj.LookAt(worldPosition, worldUp);
        // public void LookAt(Vector3 worldPosition) => _obj.LookAt(worldPosition);
        // public void Rotate(Vector3 eulers, Space relativeTo) => _obj.Rotate(eulers, relativeTo);
        // public void Rotate(Vector3 eulers) => _obj.Rotate(eulers);
        // public void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo) => _obj.Rotate(xAngle, yAngle, zAngle, relativeTo);
        // public void Rotate(float xAngle, float yAngle, float zAngle) => _obj.Rotate(xAngle, yAngle, zAngle);
        // public void Rotate(Vector3 axis, float angle, Space relativeTo) => _obj.Rotate(axis, angle, relativeTo);
        // public void Rotate(Vector3 axis, float angle) => _obj.Rotate(axis, angle);
        // public void RotateAround(Vector3 point, Vector3 axis, float angle) => _obj.RotateAround(point, axis, angle);
        // public void SetAsFirstSibling() => _obj.SetAsFirstSibling();
        // public void SetAsLastSibling() => _obj.SetAsLastSibling();
        // public void SetParent(Transform p) => _obj.SetParent(p);
        // public void SetParent(Transform parent, bool worldPositionStays) => _obj.SetParent(parent, worldPositionStays);
        // public void SetPositionAndRotation(Vector3 position, Quaternion rotation) => _obj.SetPositionAndRotation(position, rotation);
        // public void SetSiblingIndex(int index) => _obj.SetSiblingIndex(index);
        public Vector3 TransformDirection(Vector3 direction) => _obj.TransformDirection(direction);
        public Vector3 TransformDirection(float x, float y, float z) => _obj.TransformDirection(x, y, z);
        public Vector3 TransformPoint(Vector3 position) => _obj.TransformPoint(position);
        public Vector3 TransformPoint(float x, float y, float z) => _obj.TransformPoint(x, y, z);
        public Vector3 TransformVector(Vector3 vector) => _obj.TransformVector(vector);
        public Vector3 TransformVector(float x, float y, float z) => _obj.TransformVector(x, y, z);
        // public void Translate(Vector3 translation, Space relativeTo) => _obj.Translate(translation, relativeTo);
        // public void Translate(Vector3 translation) => _obj.Translate(translation);
        // public void Translate(float x, float y, float z, Space relativeTo) => _obj.Translate(x, y, z, relativeTo);
        // public void Translate(float x, float y, float z) => _obj.Translate(x, y, z);
        // public void Translate(Vector3 translation, Transform relativeTo) => _obj.Translate(translation, relativeTo);
        // public void Translate(float x, float y, float z, Transform relativeTo) => _obj.Translate(x, y, z, relativeTo);

        #endregion

        private class Enumerator<TSource> : Enumerator<TSource, TSource> where TSource : IReadOnlyTransform
        {
            internal Enumerator(TSource transform) : base(transform)
            {
            }
        }

        private class Enumerator<TSource, TResult> : IEnumerator<TResult> where TSource : IReadOnlyTransform
        {
            private int _currentIndex = -1;
            private readonly TSource _readOnlyTransform;

            internal Enumerator(TSource transform)
            {
                _readOnlyTransform = transform;
            }

            object IEnumerator.Current => this.Current;
            public bool MoveNext() => ++_currentIndex < _readOnlyTransform.childCount;
            public void Reset() => _currentIndex = -1;
            public void Dispose() => this.Reset();
            public TResult Current => (TResult) _readOnlyTransform.GetChild(_currentIndex);
        }
    }

    public sealed class ReadOnlyTransform : ReadOnlyTransform<Transform>
    {
        public ReadOnlyTransform(Transform obj) : base(obj)
        {
        }
    }

    public static class TransformExtensions
    {
        public static ReadOnlyTransform AsReadOnly(this Transform self) => new ReadOnlyTransform(self);
    }
}