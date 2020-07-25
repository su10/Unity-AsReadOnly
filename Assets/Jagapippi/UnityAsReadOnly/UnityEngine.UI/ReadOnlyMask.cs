using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMask
    {
        IReadOnlyGraphic graphic { get; }
        IReadOnlyRectTransform rectTransform { get; }
        bool showMaskGraphic { get; }
        IReadOnlyMaterial GetModifiedMaterial(Material baseMaterial);
        bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera);
        bool MaskEnabled();
    }

    public class ReadOnlyMask<T> : ReadOnlyUIBehaviour<T>, IReadOnlyMask where T : Mask
    {
        protected ReadOnlyMask(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyGraphic graphic => _obj.graphic.AsReadOnly();
        IReadOnlyGraphic IReadOnlyMask.graphic => this.graphic;
        public ReadOnlyRectTransform rectTransform => _obj.rectTransform.AsReadOnly();
        IReadOnlyRectTransform IReadOnlyMask.rectTransform => this.rectTransform;
        public bool showMaskGraphic => _obj.showMaskGraphic;

        #endregion

        #region Public Methods

        public virtual ReadOnlyMaterial GetModifiedMaterial(Material baseMaterial) => _obj.GetModifiedMaterial(baseMaterial).AsReadOnly();
        IReadOnlyMaterial IReadOnlyMask.GetModifiedMaterial(Material baseMaterial) => this.GetModifiedMaterial(baseMaterial);
        public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera) => _obj.IsRaycastLocationValid(sp, eventCamera);
        public virtual bool MaskEnabled() => _obj.MaskEnabled();

        #endregion
    }

    public sealed class ReadOnlyMask : ReadOnlyMask<Mask>
    {
        public ReadOnlyMask(Mask obj) : base(obj)
        {
        }
    }

    public static class MaskExtensions
    {
        public static ReadOnlyMask AsReadOnly(this Mask self) => self.IsTrulyNull() ? null : new ReadOnlyMask(self);
    }
}