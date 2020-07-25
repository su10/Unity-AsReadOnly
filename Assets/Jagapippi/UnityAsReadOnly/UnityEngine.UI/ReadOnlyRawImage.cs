using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRawImage
    {
        Texture mainTexture { get; }
        Texture texture { get; }
        Rect uvRect { get; }
        // void SetNativeSize();
    }

    public class ReadOnlyRawImage<T> : ReadOnlyMaskableGraphic<T>, IReadOnlyRawImage where T : RawImage
    {
        protected ReadOnlyRawImage(T obj) : base(obj)
        {
        }

        #region Properties

        public override Texture mainTexture => _obj.mainTexture;
        public Texture texture => _obj.texture;
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