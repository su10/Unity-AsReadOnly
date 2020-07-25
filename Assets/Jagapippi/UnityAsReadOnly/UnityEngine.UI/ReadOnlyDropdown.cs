using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyDropdown
    {
        IReadOnlyImage captionImage { get; }
        IReadOnlyText captionText { get; }
        IReadOnlyImage itemImage { get; }
        IReadOnlyText itemText { get; }
        // Dropdown.DropdownEvent onValueChanged { get; }
        List<ReadOnlyDropdown.OptionData> options { get; }
        IReadOnlyRectTransform template { get; }
        int value { get; }
        // void AddOptions(List<Dropdown.OptionData> options);
        // void AddOptions(List<string> options);
        // void AddOptions(List<Sprite> options);
        // void ClearOptions();
        // void Hide();
        // void OnCancel(BaseEventData eventData);
        // void OnPointerClick(PointerEventData eventData);
        // void OnSubmit(BaseEventData eventData);
        // void RefreshShownValue();
        // void Show();
    }

    public class ReadOnlyDropdown<T> : ReadOnlySelectable<T>, IReadOnlyDropdown where T : Dropdown
    {
        protected ReadOnlyDropdown(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyImage captionImage => _obj.captionImage.IsTrulyNull() ? null : _obj.captionImage.AsReadOnly();
        IReadOnlyImage IReadOnlyDropdown.captionImage => this.captionImage;
        public ReadOnlyText captionText => _obj.captionText.IsTrulyNull() ? null : _obj.captionText.AsReadOnly();
        IReadOnlyText IReadOnlyDropdown.captionText => this.captionText;
        public ReadOnlyImage itemImage => _obj.itemImage.IsTrulyNull() ? null : _obj.itemImage.AsReadOnly();
        IReadOnlyImage IReadOnlyDropdown.itemImage => this.itemImage;
        public ReadOnlyText itemText => _obj.itemText.IsTrulyNull() ? null : _obj.itemText.AsReadOnly();
        IReadOnlyText IReadOnlyDropdown.itemText => this.itemText;
        // public Dropdown.DropdownEvent onValueChanged => _obj.onValueChanged;
        public List<ReadOnlyDropdown.OptionData> options => _obj.options?.Select(o => o.AsReadOnly()).ToList();
        public ReadOnlyRectTransform template => _obj.template.IsTrulyNull() ? null : _obj.template.AsReadOnly();
        IReadOnlyRectTransform IReadOnlyDropdown.template => this.template;
        public int value => _obj.value;

        #endregion

        #region Public Methods

        // public void AddOptions(List<Dropdown.OptionData> options) => _obj.AddOptions(options);
        // public void AddOptions(List<string> options) => _obj.AddOptions(options);
        // public void AddOptions(List<Sprite> options) => _obj.AddOptions(options);
        // public void ClearOptions() => _obj.ClearOptions();
        // public void Hide() => _obj.Hide();
        // public void OnCancel(BaseEventData eventData) => _obj.OnCancel(eventData);
        // public void OnPointerClick(PointerEventData eventData) => _obj.OnPointerClick(eventData);
        // public void OnSubmit(BaseEventData eventData) => _obj.OnSubmit(eventData);
        // public void RefreshShownValue() => _obj.RefreshShownValue();
        // public void Show() => _obj.Show();

        #endregion
    }

    public sealed class ReadOnlyDropdown : ReadOnlyDropdown<Dropdown>
    {
        public ReadOnlyDropdown(Dropdown obj) : base(obj)
        {
        }

        public class OptionData
        {
            private readonly Dropdown.OptionData _data;

            public OptionData(Dropdown.OptionData data)
            {
                _data = data;
            }

            public string text => _data.text;
            public ReadOnlySprite image => _data.image.IsTrulyNull() ? null : _data.image.AsReadOnly();
        }
    }

    public static class DropdownExtensions
    {
        public static ReadOnlyDropdown AsReadOnly(this Dropdown self) => new ReadOnlyDropdown(self);
        public static ReadOnlyDropdown.OptionData AsReadOnly(this Dropdown.OptionData self) => new ReadOnlyDropdown.OptionData(self);
    }
}