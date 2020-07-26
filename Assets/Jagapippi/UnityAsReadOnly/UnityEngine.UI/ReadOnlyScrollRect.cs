#if !UNITY_WSA
using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyScrollRect
    {
        IReadOnlyRectTransform content { get; }
        float decelerationRate { get; }
        float elasticity { get; }
        float flexibleHeight { get; }
        float flexibleWidth { get; }
        bool horizontal { get; }
        float horizontalNormalizedPosition { get; }
        IReadOnlyScrollbar horizontalScrollbar { get; }
        float horizontalScrollbarSpacing { get; }
        ScrollRect.ScrollbarVisibility horizontalScrollbarVisibility { get; }
        bool inertia { get; }
        int layoutPriority { get; }
        float minHeight { get; }
        float minWidth { get; }
        ScrollRect.MovementType movementType { get; }
        Vector2 normalizedPosition { get; }
        // ScrollRect.ScrollRectEvent onValueChanged { get; }
        float preferredHeight { get; }
        float preferredWidth { get; }
        float scrollSensitivity { get; }
        Vector2 velocity { get; }
        bool vertical { get; }
        float verticalNormalizedPosition { get; }
        IReadOnlyScrollbar verticalScrollbar { get; }
        float verticalScrollbarSpacing { get; }
        ScrollRect.ScrollbarVisibility verticalScrollbarVisibility { get; }
        IReadOnlyRectTransform viewport { get; }
        // void CalculateLayoutInputHorizontal();
        // void CalculateLayoutInputVertical();
        // void GraphicUpdateComplete();
        bool IsActive();
        // void LayoutComplete();
        // void OnBeginDrag(PointerEventData eventData);
        // void OnDrag(PointerEventData eventData);
        // void OnEndDrag(PointerEventData eventData);
        // void OnInitializePotentialDrag(PointerEventData eventData);
        // void OnScroll(PointerEventData data);
        // void Rebuild(CanvasUpdate executing);
        // void SetLayoutHorizontal();
        // void SetLayoutVertical();
        // void StopMovement();
    }

    public class ReadOnlyScrollRect<T> : ReadOnlyUIBehaviour<T>, IReadOnlyScrollRect where T : ScrollRect
    {
        protected ReadOnlyScrollRect(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyRectTransform content => _obj.content.AsReadOnly();
        IReadOnlyRectTransform IReadOnlyScrollRect.content => this.content;
        public float decelerationRate => _obj.decelerationRate;
        public float elasticity => _obj.elasticity;
        public virtual float flexibleHeight => _obj.flexibleHeight;
        public virtual float flexibleWidth => _obj.flexibleWidth;
        public bool horizontal => _obj.horizontal;
        public float horizontalNormalizedPosition => _obj.horizontalNormalizedPosition;
        public ReadOnlyScrollbar horizontalScrollbar => _obj.horizontalScrollbar.AsReadOnly();
        IReadOnlyScrollbar IReadOnlyScrollRect.horizontalScrollbar => this.horizontalScrollbar;
        public float horizontalScrollbarSpacing => _obj.horizontalScrollbarSpacing;
        public ScrollRect.ScrollbarVisibility horizontalScrollbarVisibility => _obj.horizontalScrollbarVisibility;
        public bool inertia => _obj.inertia;
        public virtual int layoutPriority => _obj.layoutPriority;
        public virtual float minHeight => _obj.minHeight;
        public virtual float minWidth => _obj.minWidth;
        public ScrollRect.MovementType movementType => _obj.movementType;
        public Vector2 normalizedPosition => _obj.normalizedPosition;
        public ScrollRect.ScrollRectEvent onValueChanged => _obj.onValueChanged;
        public virtual float preferredHeight => _obj.preferredHeight;
        public virtual float preferredWidth => _obj.preferredWidth;
        public float scrollSensitivity => _obj.scrollSensitivity;
        public Vector2 velocity => _obj.velocity;
        public bool vertical => _obj.vertical;
        public float verticalNormalizedPosition => _obj.verticalNormalizedPosition;
        public ReadOnlyScrollbar verticalScrollbar => _obj.verticalScrollbar.AsReadOnly();
        IReadOnlyScrollbar IReadOnlyScrollRect.verticalScrollbar => this.verticalScrollbar;
        public float verticalScrollbarSpacing => _obj.verticalScrollbarSpacing;
        public ScrollRect.ScrollbarVisibility verticalScrollbarVisibility => _obj.verticalScrollbarVisibility;
        public ReadOnlyRectTransform viewport => _obj.viewport.AsReadOnly();
        IReadOnlyRectTransform IReadOnlyScrollRect.viewport => this.viewport;

        #endregion

        #region Public Methods

        // public void CalculateLayoutInputHorizontal() => _obj.CalculateLayoutInputHorizontal();
        // public void CalculateLayoutInputVertical() => _obj.CalculateLayoutInputVertical();
        // public void GraphicUpdateComplete() => _obj.GraphicUpdateComplete();
        public override bool IsActive() => _obj.IsActive();
        // public void LayoutComplete() => _obj.LayoutComplete();
        // public void OnBeginDrag(PointerEventData eventData) => _obj.OnBeginDrag(eventData);
        // public void OnDrag(PointerEventData eventData) => _obj.OnDrag(eventData);
        // public void OnEndDrag(PointerEventData eventData) => _obj.OnEndDrag(eventData);
        // public void OnInitializePotentialDrag(PointerEventData eventData) => _obj.OnInitializePotentialDrag(eventData);
        // public void OnScroll(PointerEventData data) => _obj.OnScroll(data);
        // public void Rebuild(CanvasUpdate executing) => _obj.Rebuild(executing);
        // public void SetLayoutHorizontal() => _obj.SetLayoutHorizontal();
        // public void SetLayoutVertical() => _obj.SetLayoutVertical();
        // public void StopMovement() => _obj.StopMovement();

        #endregion
    }

    public sealed class ReadOnlyScrollRect : ReadOnlyScrollRect<ScrollRect>
    {
        public ReadOnlyScrollRect(ScrollRect obj) : base(obj)
        {
        }
    }

    public static class ScrollRectExtensions
    {
        public static ReadOnlyScrollRect AsReadOnly(this ScrollRect self) => self.IsTrulyNull() ? null : new ReadOnlyScrollRect(self);
    }
}
#endif