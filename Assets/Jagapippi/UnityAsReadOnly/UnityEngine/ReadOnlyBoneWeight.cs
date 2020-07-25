using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyBoneWeight : IEquatable<BoneWeight>, IEquatable<ReadOnlyBoneWeight>
    {
        private readonly BoneWeight _boneWeight;

        public ReadOnlyBoneWeight(BoneWeight boneWeight)
        {
            _boneWeight = boneWeight;
        }

        #region Properties

        public float weight0 => _boneWeight.weight0;
        public float weight1 => _boneWeight.weight1;
        public float weight2 => _boneWeight.weight2;
        public float weight3 => _boneWeight.weight3;
        public int boneIndex0 => _boneWeight.boneIndex0;
        public int boneIndex1 => _boneWeight.boneIndex1;
        public int boneIndex2 => _boneWeight.boneIndex2;
        public int boneIndex3 => _boneWeight.boneIndex3;

        #endregion

        #region Public Methods

        #endregion

        #region Operators

        public static bool operator ==(ReadOnlyBoneWeight lhs, ReadOnlyBoneWeight rhs) => (lhs._boneWeight == rhs._boneWeight);
        public static bool operator !=(ReadOnlyBoneWeight lhs, ReadOnlyBoneWeight rhs) => !(lhs == rhs);
        public static bool operator ==(ReadOnlyBoneWeight lhs, BoneWeight rhs) => (lhs._boneWeight == rhs);
        public static bool operator !=(ReadOnlyBoneWeight lhs, BoneWeight rhs) => !(lhs == rhs);
        public static bool operator ==(BoneWeight lhs, ReadOnlyBoneWeight rhs) => (lhs == rhs._boneWeight);
        public static bool operator !=(BoneWeight lhs, ReadOnlyBoneWeight rhs) => !(lhs == rhs);

        public bool Equals(BoneWeight other) => _boneWeight.Equals(other);
        public bool Equals(ReadOnlyBoneWeight other) => _boneWeight.Equals(other._boneWeight);

        public override bool Equals(object other)
        {
            if (other is BoneWeight boneWeight) return _boneWeight.Equals(boneWeight);
            if (other is ReadOnlyBoneWeight readOnlyBoneWeight) return _boneWeight.Equals(readOnlyBoneWeight._boneWeight);
            return false;
        }

        public override int GetHashCode() => _boneWeight.GetHashCode();

        #endregion
    }

    public static class BoneWeightExtensions
    {
        public static ReadOnlyBoneWeight AsReadOnly(this BoneWeight self) => new ReadOnlyBoneWeight(self);
    }
}