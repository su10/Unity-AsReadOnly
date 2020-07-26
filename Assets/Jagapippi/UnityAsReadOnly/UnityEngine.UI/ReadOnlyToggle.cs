#if !UNITY_WSA
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyToggle
    {
        IReadOnlyToggleGroup group { get; }
        bool isOn { get; }
        // void GraphicUpdateComplete();
        // void LayoutComplete();
        // void OnPointerClick(PointerEventData eventData);
        // void OnSubmit(BaseEventData eventData);
        // void Rebuild(CanvasUpdate executing);
    }

    public class ReadOnlyToggle<T> : ReadOnlySelectable<T>, IReadOnlyToggle where T : Toggle
    {
        protected ReadOnlyToggle(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyToggleGroup group => _obj.group.AsReadOnly();
        IReadOnlyToggleGroup IReadOnlyToggle.group => this.group;
        public bool isOn => _obj.isOn;

        #endregion

        #region Public Methods

        // public void GraphicUpdateComplete() => _obj.GraphicUpdateComplete();
        // public void LayoutComplete() => _obj.LayoutComplete();
        // public void OnPointerClick(PointerEventData eventData) => _obj.OnPointerClick(eventData);
        // public void OnSubmit(BaseEventData eventData) => _obj.OnSubmit(eventData);
        // public void Rebuild(CanvasUpdate executing) => _obj.Rebuild(executing);

        #endregion
    }

    public sealed class ReadOnlyToggle : ReadOnlyToggle<Toggle>
    {
        public ReadOnlyToggle(Toggle obj) : base(obj)
        {
        }
    }

    public static class ToggleExtensions
    {
        public static ReadOnlyToggle AsReadOnly(this Toggle self) => self.IsTrulyNull() ? null : new ReadOnlyToggle(self);
    }
}
#endif