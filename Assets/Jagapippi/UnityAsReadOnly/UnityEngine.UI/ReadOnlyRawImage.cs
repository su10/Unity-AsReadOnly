using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRawImage
    {
        IReadOnlyTexture mainTexture { get; }
        IReadOnlyTexture texture { get; }
        Rect uvRect { get; }
        // void SetNativeSize();
    }

    public class ReadOnlyRawImage<T> : ReadOnlyMaskableGraphic<T>, IReadOnlyRawImage where T : RawImage
    {
        protected ReadOnlyRawImage(T obj) : base(obj)
        {
        }

        #region Properties

        public override ReadOnlyTexture mainTexture => _obj.mainTexture.AsReadOnly();
        IReadOnlyTexture IReadOnlyRawImage.mainTexture => this.mainTexture;
        public ReadOnlyTexture texture => _obj.texture.AsReadOnly();
        IReadOnlyTexture IReadOnlyRawImage.texture => this.texture;
        public Rect uvRect => _obj.uvRect;

        #endregion

        #region Public Methods

        // public void SetNativeSize() => _obj.SetNativeSize();

        #endregion
    }

    public sealed class ReadOnlyRawImage : ReadOnlyRawImage<RawImage>
    {
        public ReadOnlyRawImage(RawImage obj) : base(obj)
        {
        }
    }

    public static class RawImageExtensions
    {
        public static ReadOnlyRawImage AsReadOnly(this RawImage self) => self.IsTrulyNull() ? null : new ReadOnlyRawImage(self);
    }
}