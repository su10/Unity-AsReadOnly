using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyDetailPrototype
    {
        float bendFactor { get; }
        Color dryColor { get; }
        Color healthyColor { get; }
        float maxHeight { get; }
        float maxWidth { get; }
        float minHeight { get; }
        float minWidth { get; }
        float noiseSpread { get; }
        IReadOnlyGameObject prototype { get; }
        Texture2D prototypeTexture { get; }
        DetailRenderMode renderMode { get; }
        bool usePrototypeMesh { get; }
        bool Equals(object obj);
        int GetHashCode();
    }

    public sealed class ReadOnlyDetailPrototype : IReadOnlyDetailPrototype
    {
        private readonly DetailPrototype _obj;

        public ReadOnlyDetailPrototype(DetailPrototype obj)
        {
            if (obj.IsTrulyNull()) throw new ArgumentNullException(nameof(obj));

            _obj = obj;
        }

        #region Properties

        public float bendFactor => _obj.bendFactor;
        public Color dryColor => _obj.dryColor;
        public Color healthyColor => _obj.healthyColor;
        public float maxHeight => _obj.maxHeight;
        public float maxWidth => _obj.maxWidth;
        public float minHeight => _obj.minHeight;
        public float minWidth => _obj.minWidth;
        public float noiseSpread => _obj.noiseSpread;
        public ReadOnlyGameObject prototype => _obj.prototype.AsReadOnly();
        IReadOnlyGameObject IReadOnlyDetailPrototype.prototype => this.prototype;
        public Texture2D prototypeTexture => _obj.prototypeTexture;
        public DetailRenderMode renderMode => _obj.renderMode;
        public bool usePrototypeMesh => _obj.usePrototypeMesh;

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => _obj.Equals(obj);
        public override int GetHashCode() => _obj.GetHashCode();

        #endregion
    }

    public static class DetailPrototypeExtensions
    {
        public static ReadOnlyDetailPrototype AsReadOnly(this DetailPrototype self) => new ReadOnlyDetailPrototype(self);
        internal static bool IsTrulyNull(this DetailPrototype self) => ReferenceEquals(self, null);
    }
}