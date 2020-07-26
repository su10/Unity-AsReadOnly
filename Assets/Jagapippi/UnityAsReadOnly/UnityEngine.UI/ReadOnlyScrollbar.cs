#if !UNITY_WSA
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyScrollbar
    {
        Scrollbar.Direction direction { get; }
        IReadOnlyRectTransform handleRect { get; }
        int numberOfSteps { get; }
        // Scrollbar.ScrollEvent onValueChanged { get; }
        float size { get; }
        float value { get; }
        IReadOnlySelectable FindSelectableOnDown();
        IReadOnlySelectable FindSelectableOnLeft();
        IReadOnlySelectable FindSelectableOnRight();
        IReadOnlySelectable FindSelectableOnUp();
        // void GraphicUpdateComplete();
        // void LayoutComplete();
        // void OnBeginDrag(PointerEventData eventData);
        // void OnDrag(PointerEventData eventData);
        // void OnInitializePotentialDrag(PointerEventData eventData);
        // void OnMove(AxisEventData eventData);
        // void OnPointerDown(PointerEventData eventData);
        // void OnPointerUp(PointerEventData eventData);
        // void Rebuild(CanvasUpdate executing);
        // void SetDirection(Scrollbar.Direction direction, bool includeRectLayouts);
    }

    public class ReadOnlyScrollbar<T> : ReadOnlySelectable<T>, IReadOnlyScrollbar where T : Scrollbar
    {
        protected ReadOnlyScrollbar(T obj) : base(obj)
        {
        }

        #region Properties

        public Scrollbar.Direction direction => _obj.direction;
        public ReadOnlyRectTransform handleRect => _obj.handleRect.AsReadOnly();
        IReadOnlyRectTransform IReadOnlyScrollbar.handleRect => this.handleRect;
        public int numberOfSteps => _obj.numberOfSteps;
        // public Scrollbar.ScrollEvent onValueChanged => _obj.onValueChanged;
        public float size => _obj.size;
        public float value => _obj.value;

        #endregion

        #region Public Methods

        public override ReadOnlySelectable FindSelectableOnDown() => _obj.FindSelectableOnDown().AsReadOnly();
        IReadOnlySelectable IReadOnlyScrollbar.FindSelectableOnDown() => this.FindSelectableOnDown();
        public override ReadOnlySelectable FindSelectableOnLeft() => _obj.FindSelectableOnLeft().AsReadOnly();
        IReadOnlySelectable IReadOnlyScrollbar.FindSelectableOnLeft() => this.FindSelectableOnLeft();
        public override ReadOnlySelectable FindSelectableOnRight() => _obj.FindSelectableOnRight().AsReadOnly();
        IReadOnlySelectable IReadOnlyScrollbar.FindSelectableOnRight() => this.FindSelectableOnRight();
        public override ReadOnlySelectable FindSelectableOnUp() => _obj.FindSelectableOnUp().AsReadOnly();
        IReadOnlySelectable IReadOnlyScrollbar.FindSelectableOnUp() => this.FindSelectableOnUp();
        // public void GraphicUpdateComplete() => _obj.GraphicUpdateComplete();
        // public void LayoutComplete() => _obj.LayoutComplete();
        // public void OnBeginDrag(PointerEventData eventData) => _obj.OnBeginDrag(eventData);
        // public void OnDrag(PointerEventData eventData) => _obj.OnDrag(eventData);
        // public void OnInitializePotentialDrag(PointerEventData eventData) => _obj.OnInitializePotentialDrag(eventData);
        // public void OnMove(AxisEventData eventData) => _obj.OnMove(eventData);
        // public void OnPointerDown(PointerEventData eventData) => _obj.OnPointerDown(eventData);
        // public void OnPointerUp(PointerEventData eventData) => _obj.OnPointerUp(eventData);
        // public void Rebuild(CanvasUpdate executing) => _obj.Rebuild(executing);
        // public void SetDirection(Scrollbar.Direction direction, bool includeRectLayouts) => _obj.SetDirection(direction, includeRectLayouts);

        #endregion
    }

    public sealed class ReadOnlyScrollbar : ReadOnlyScrollbar<Scrollbar>
    {
        public ReadOnlyScrollbar(Scrollbar obj) : base(obj)
        {
        }
    }

    public static class ScrollbarExtensions
    {
        public static ReadOnlyScrollbar AsReadOnly(this Scrollbar self) => self.IsTrulyNull() ? null : new ReadOnlyScrollbar(self);
    }
}
#endif