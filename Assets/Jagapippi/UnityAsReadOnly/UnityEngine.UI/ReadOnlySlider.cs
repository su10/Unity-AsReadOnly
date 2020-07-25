using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlySlider
    {
        Slider.Direction direction { get; }
        IReadOnlyRectTransform fillRect { get; }
        IReadOnlyRectTransform handleRect { get; }
        float maxValue { get; }
        float minValue { get; }
        float normalizedValue { get; }
        // Slider.SliderEvent onValueChanged { get; }
        float value { get; }
        bool wholeNumbers { get; }
        IReadOnlySelectable FindSelectableOnDown();
        IReadOnlySelectable FindSelectableOnLeft();
        IReadOnlySelectable FindSelectableOnRight();
        IReadOnlySelectable FindSelectableOnUp();
        // void GraphicUpdateComplete();
        // void LayoutComplete();
        // void OnDrag(PointerEventData eventData);
        // void OnInitializePotentialDrag(PointerEventData eventData);
        // void OnMove(AxisEventData eventData);
        // void OnPointerDown(PointerEventData eventData);
        // void Rebuild(CanvasUpdate executing);
        // void SetDirection(Slider.Direction direction, bool includeRectLayouts);
    }

    public class ReadOnlySlider<T> : ReadOnlySelectable<T>, IReadOnlySlider where T : Slider
    {
        protected ReadOnlySlider(T obj) : base(obj)
        {
        }

        #region Properties

        public Slider.Direction direction => _obj.direction;
        public ReadOnlyRectTransform fillRect => _obj.fillRect.IsTrulyNull() ? null : _obj.fillRect.AsReadOnly();
        IReadOnlyRectTransform IReadOnlySlider.fillRect => this.fillRect;
        public ReadOnlyRectTransform handleRect => _obj.handleRect.IsTrulyNull() ? null : _obj.handleRect.AsReadOnly();
        IReadOnlyRectTransform IReadOnlySlider.handleRect => this.handleRect;
        public float maxValue => _obj.maxValue;
        public float minValue => _obj.minValue;
        public float normalizedValue => _obj.normalizedValue;
        // public Slider.SliderEvent onValueChanged => _obj.onValueChanged;
        public float value => _obj.value;
        public bool wholeNumbers => _obj.wholeNumbers;

        #endregion

        #region Public Methods

        public override ReadOnlySelectable FindSelectableOnDown()
        {
            var selectable = _obj.FindSelectableOnDown();
            return selectable.IsTrulyNull() ? null : selectable.AsReadOnly();
        }

        IReadOnlySelectable IReadOnlySlider.FindSelectableOnDown() => this.FindSelectableOnDown();

        public override ReadOnlySelectable FindSelectableOnLeft()
        {
            var selectable = _obj.FindSelectableOnLeft();
            return selectable.IsTrulyNull() ? null : selectable.AsReadOnly();
        }

        IReadOnlySelectable IReadOnlySlider.FindSelectableOnLeft() => this.FindSelectableOnLeft();

        public override ReadOnlySelectable FindSelectableOnRight()
        {
            var selectable = _obj.FindSelectableOnRight();
            return selectable.IsTrulyNull() ? null : selectable.AsReadOnly();
        }

        IReadOnlySelectable IReadOnlySlider.FindSelectableOnRight() => this.FindSelectableOnRight();

        public override ReadOnlySelectable FindSelectableOnUp()
        {
            var selectable = _obj.FindSelectableOnUp();
            return selectable.IsTrulyNull() ? null : selectable.AsReadOnly();
        }

        IReadOnlySelectable IReadOnlySlider.FindSelectableOnUp() => this.FindSelectableOnUp();

        // public void GraphicUpdateComplete() => _obj.GraphicUpdateComplete();
        // public void LayoutComplete() => _obj.LayoutComplete();
        // public void OnDrag(PointerEventData eventData) => _obj.OnDrag(eventData);
        // public void OnInitializePotentialDrag(PointerEventData eventData) => _obj.OnInitializePotentialDrag(eventData);
        // public void OnMove(AxisEventData eventData) => _obj.OnMove(eventData);
        // public void OnPointerDown(PointerEventData eventData) => _obj.OnPointerDown(eventData);
        // public void Rebuild(CanvasUpdate executing) => _obj.Rebuild(executing);
        // public void SetDirection(Slider.Direction direction, bool includeRectLayouts) => _obj.SetDirection(direction, includeRectLayouts);

        #endregion
    }

    public sealed class ReadOnlySlider : ReadOnlySlider<Slider>
    {
        public ReadOnlySlider(Slider obj) : base(obj)
        {
        }
    }

    public static class SliderExtensions
    {
        public static ReadOnlySlider AsReadOnly(this Slider self) => new ReadOnlySlider(self);
    }
}