using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMaskableGraphic
    {
        bool maskable { get; }
        // MaskableGraphic.CullStateChangedEvent onCullStateChanged { get; }
        // void Cull(Rect clipRect, bool validRect);
        IReadOnlyMaterial GetModifiedMaterial(Material baseMaterial);
        // void RecalculateClipping();
        // void RecalculateMasking();
        // void SetClipRect(Rect clipRect, bool validRect);
    }

    public class ReadOnlyMaskableGraphic<T> : ReadOnlyGraphic<T>, IReadOnlyMaskableGraphic where T : MaskableGraphic
    {
        protected ReadOnlyMaskableGraphic(T obj) : base(obj)
        {
        }

        #region Properties

        public bool maskable => _obj.maskable;
        // public MaskableGraphic.CullStateChangedEvent onCullStateChanged => _obj.onCullStateChanged;

        #endregion

        #region Public Methods

        // public void Cull(Rect clipRect, bool validRect) => _obj.Cull(clipRect, validRect);
        public ReadOnlyMaterial GetModifiedMaterial(Material baseMaterial) => _obj.GetModifiedMaterial(baseMaterial).AsReadOnly();
        IReadOnlyMaterial IReadOnlyMaskableGraphic.GetModifiedMaterial(Material baseMaterial) => this.GetModifiedMaterial(baseMaterial);
        // public void RecalculateClipping() => _obj.RecalculateClipping();
        // public void RecalculateMasking() => _obj.RecalculateMasking();
        // public void SetClipRect(Rect clipRect, bool validRect) => _obj.SetClipRect(clipRect, validRect);

        #endregion
    }

    public sealed class ReadOnlyMaskableGraphic : ReadOnlyMaskableGraphic<MaskableGraphic>
    {
        public ReadOnlyMaskableGraphic(MaskableGraphic obj) : base(obj)
        {
        }
    }

    public static class MaskableGraphicExtensions
    {
        public static ReadOnlyMaskableGraphic AsReadOnly(this MaskableGraphic self) => self.IsTrulyNull() ? null : new ReadOnlyMaskableGraphic(self);
    }
}