#if !UNITY_WSA
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyButton
    {
        // Button.ButtonClickedEvent onClick { get; }
        // void OnPointerClick(PointerEventData eventData);
        // void OnSubmit(BaseEventData eventData);
    }

    public abstract class ReadOnlyButton<T> : ReadOnlySelectable<T>, IReadOnlyButton where T : Button
    {
        protected ReadOnlyButton(T obj) : base(obj)
        {
        }

        #region Properties

        // public Button.ButtonClickedEvent onClick => _obj.onClick;

        #endregion

        #region Public Methods

        // public void OnPointerClick(PointerEventData eventData) => _obj.OnPointerClick(eventData);
        // public void OnSubmit(BaseEventData eventData) => _obj.OnSubmit(eventData);

        #endregion
    }

    public sealed class ReadOnlyButton : ReadOnlyButton<Button>
    {
        public ReadOnlyButton(Button obj) : base(obj)
        {
        }
    }

    public static class ButtonExtensions
    {
        public static ReadOnlyButton AsReadOnly(this Button self) => self.IsTrulyNull() ? null : new ReadOnlyButton(self);
    }
}
#endif