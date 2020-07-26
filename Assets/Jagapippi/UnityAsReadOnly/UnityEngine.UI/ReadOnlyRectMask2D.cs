#if !UNITY_WSA
using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRectMask2D
    {
        Rect canvasRect { get; }
        IReadOnlyRectTransform rectTransform { get; }
        // void AddClippable(IClippable clippable);
        bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera);
        bool IsRaycastLocationValid(Vector2 sp, ReadOnlyCamera eventCamera);
        // void PerformClipping();
        // void RemoveClippable(IClippable clippable);
    }

    public class ReadOnlyRectMask2D<T> : ReadOnlyUIBehaviour<T>, IReadOnlyRectMask2D where T : RectMask2D
    {
        protected ReadOnlyRectMask2D(T obj) : base(obj)
        {
        }

        #region Properties

        public Rect canvasRect => _obj.canvasRect;
        public ReadOnlyRectTransform rectTransform => _obj.rectTransform.AsReadOnly();
        IReadOnlyRectTransform IReadOnlyRectMask2D.rectTransform => this.rectTransform;

        #endregion

        #region Public Methods

        // public void AddClippable(IClippable clippable) => _obj.AddClippable(clippable);
        public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera) => _obj.IsRaycastLocationValid(sp, eventCamera);
        public virtual bool IsRaycastLocationValid(Vector2 sp, ReadOnlyCamera eventCamera) => _obj.IsRaycastLocationValid(sp, eventCamera._obj);
        // public void PerformClipping() => _obj.PerformClipping();
        // public void RemoveClippable(IClippable clippable) => _obj.RemoveClippable(clippable);

        #endregion
    }

    public sealed class ReadOnlyRectMask2D : ReadOnlyRectMask2D<RectMask2D>
    {
        public ReadOnlyRectMask2D(RectMask2D obj) : base(obj)
        {
        }
    }

    public static class RectMask2DExtensions
    {
        public static ReadOnlyRectMask2D AsReadOnly(this RectMask2D self) => self.IsTrulyNull() ? null : new ReadOnlyRectMask2D(self);
    }
}
#endif