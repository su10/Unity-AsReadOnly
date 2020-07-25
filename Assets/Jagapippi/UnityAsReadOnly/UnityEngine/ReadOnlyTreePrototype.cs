using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTreePrototype
    {
        float bendFactor { get; }
        IReadOnlyGameObject prefab { get; }
        bool Equals(object obj);
        int GetHashCode();
    }

    public sealed class ReadOnlyTreePrototype : IReadOnlyTreePrototype
    {
        internal readonly TreePrototype _obj;

        public ReadOnlyTreePrototype(TreePrototype obj)
        {
            _obj = obj;
        }

        #region Properties

        public float bendFactor => _obj.bendFactor;
        public ReadOnlyGameObject prefab => _obj.prefab.AsReadOnly();
        IReadOnlyGameObject IReadOnlyTreePrototype.prefab => this.prefab;

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => _obj.Equals(obj);
        public override int GetHashCode() => _obj.GetHashCode();

        #endregion
    }

    public static class TreePrototypeExtensions
    {
        public static ReadOnlyTreePrototype AsReadOnly(this TreePrototype self) => self.IsTrulyNull() ? null : new ReadOnlyTreePrototype(self);
        internal static bool IsTrulyNull(this TreePrototype self) => ReferenceEquals(self, null);
    }
}