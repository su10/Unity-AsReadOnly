using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyImage
    {
        float alphaHitTestMinimumThreshold { get; }
        float fillAmount { get; }
        bool fillCenter { get; }
        bool fillClockwise { get; }
        Image.FillMethod fillMethod { get; }
        int fillOrigin { get; }
        float flexibleHeight { get; }
        float flexibleWidth { get; }
        bool hasBorder { get; }
        int layoutPriority { get; }
        Texture mainTexture { get; }
        IReadOnlyMaterial material { get; }
        float minHeight { get; }
        float minWidth { get; }
        IReadOnlySprite overrideSprite { get; }
        float pixelsPerUnit { get; }
        float preferredHeight { get; }
        float preferredWidth { get; }
        bool preserveAspect { get; }
        IReadOnlySprite sprite { get; }
        Image.Type type { get; }
        bool useSpriteMesh { get; }
        // void CalculateLayoutInputHorizontal();
        // void CalculateLayoutInputVertical();
        bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera);
        // void OnAfterDeserialize();
        // void OnBeforeSerialize();
        // void SetNativeSize();
    }

    public class ReadOnlyImage<T> : ReadOnlyMaskableGraphic<T>, IReadOnlyImage where T : Image
    {
        protected ReadOnlyImage(T obj) : base(obj)
        {
        }

        #region Properties

        public float alphaHitTestMinimumThreshold => _obj.alphaHitTestMinimumThreshold;
        public float fillAmount => _obj.fillAmount;
        public bool fillCenter => _obj.fillCenter;
        public bool fillClockwise => _obj.fillClockwise;
        public Image.FillMethod fillMethod => _obj.fillMethod;
        public int fillOrigin => _obj.fillOrigin;
        public float flexibleHeight => _obj.flexibleHeight;
        public float flexibleWidth => _obj.flexibleWidth;
        public bool hasBorder => _obj.hasBorder;
        public int layoutPriority => _obj.layoutPriority;
        public override Texture mainTexture => _obj.mainTexture;
        public override ReadOnlyMaterial material => _obj.material.AsReadOnly();
        IReadOnlyMaterial IReadOnlyImage.material => this.material;
        public float minHeight => _obj.minHeight;
        public float minWidth => _obj.minWidth;
        public ReadOnlySprite overrideSprite => _obj.overrideSprite.AsReadOnly();
        IReadOnlySprite IReadOnlyImage.overrideSprite => this.overrideSprite;
        public float pixelsPerUnit => _obj.pixelsPerUnit;
        public float preferredHeight => _obj.preferredHeight;
        public float preferredWidth => _obj.preferredWidth;
        public bool preserveAspect => _obj.preserveAspect;
        public ReadOnlySprite sprite => _obj.sprite.AsReadOnly();
        IReadOnlySprite IReadOnlyImage.sprite => this.sprite;
        public Image.Type type => _obj.type;
        public bool useSpriteMesh => _obj.useSpriteMesh;

        #endregion

        #region Public Methods

        // public void CalculateLayoutInputHorizontal() => _obj.CalculateLayoutInputHorizontal();
        // public void CalculateLayoutInputVertical() => _obj.CalculateLayoutInputVertical();
        public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera) => _obj.IsRaycastLocationValid(screenPoint, eventCamera);
        // public void OnAfterDeserialize() => _obj.OnAfterDeserialize();
        // public void OnBeforeSerialize() => _obj.OnBeforeSerialize();
        // public void SetNativeSize() => _obj.SetNativeSize();

        #endregion
    }

    public sealed class ReadOnlyImage : ReadOnlyImage<Image>
    {
        public ReadOnlyImage(Image obj) : base(obj)
        {
        }
    }

    public static class ImageExtensions
    {
        public static ReadOnlyImage AsReadOnly(this Image self) => self.IsTrulyNull() ? null : new ReadOnlyImage(self);
    }
}