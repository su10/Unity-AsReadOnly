using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public class ReadOnlyTransform : ReadOnlyComponent<Transform>
    {
        public ReadOnlyTransform(Transform obj) : base(obj)
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
        public ReadOnlyTransform parent => _obj.parent.AsReadOnly();
        public Vector3 position => _obj.position;
        public Vector3 right => _obj.right;
        public ReadOnlyTransform root => _obj.root.AsReadOnly();
        public Quaternion rotation => _obj.rotation;
        public Vector3 up => _obj.up;
        public Matrix4x4 worldToLocalMatrix => _obj.worldToLocalMatrix;

        #endregion

        #region Public Methods

        // DetachChildren
        public ReadOnlyTransform Find(string n) => _obj.Find(n).AsReadOnly();
        public ReadOnlyTransform GetChild(int index) => _obj.GetChild(index).AsReadOnly();
        public int GetSiblingIndex() => _obj.GetSiblingIndex();
        public Vector3 InverseTransformDirection(Vector3 direction) => _obj.InverseTransformDirection(direction);
        public Vector3 InverseTransformDirection(float x, float y, float z) => _obj.InverseTransformDirection(x, y, z);
        public Vector3 InverseTransformPoint(Vector3 position) => _obj.InverseTransformPoint(position);
        public Vector3 InverseTransformPoint(float x, float y, float z) => _obj.InverseTransformPoint(x, y, z);
        public Vector3 InverseTransformVector(Vector3 vector) => _obj.InverseTransformVector(vector);
        public Vector3 InverseTransformVector(float x, float y, float z) => _obj.InverseTransformVector(x, y, z);
        public bool IsChildOf(Transform parent) => _obj.IsChildOf(parent);
        public bool IsChildOf(ReadOnlyTransform parent) => _obj.IsChildOf(parent._obj);
        // LookAt
        // Rotate
        // RotateAround
        // SetAsFirstSibling
        // SetAsLastSibling
        // SetParent
        // SetPositionAndRotation
        // SetSiblingIndex
        public Vector3 TransformDirection(Vector3 direction) => _obj.TransformDirection(direction);
        public Vector3 TransformDirection(float x, float y, float z) => _obj.TransformDirection(x, y, z);
        public Vector3 TransformPoint(Vector3 position) => _obj.TransformPoint(position);
        public Vector3 TransformPoint(float x, float y, float z) => _obj.TransformPoint(x, y, z);
        public Vector3 TransformVector(Vector3 vector) => _obj.TransformVector(vector);
        public Vector3 TransformVector(float x, float y, float z) => _obj.TransformVector(x, y, z);
        // Translate

        #endregion
    }

    public static class TransformExtensions
    {
        public static ReadOnlyTransform AsReadOnly(this Transform self) => new ReadOnlyTransform(self);
    }
}