using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyToggleGroup
    {
        bool allowSwitchOff { get; }
        IEnumerable<IReadOnlyToggle> ActiveToggles();
        bool AnyTogglesOn();
        // void NotifyToggleOn(Toggle toggle);
        // void RegisterToggle(Toggle toggle);
        // void SetAllTogglesOff();
        // void UnregisterToggle(Toggle toggle);
    }

    public class ReadOnlyToggleGroup<T> : ReadOnlyUIBehaviour<T>, IReadOnlyToggleGroup where T : ToggleGroup
    {
        protected ReadOnlyToggleGroup(T obj) : base(obj)
        {
        }

        #region Properties

        public bool allowSwitchOff => _obj.allowSwitchOff;

        #endregion

        #region Public Methods

        public IEnumerable<ReadOnlyToggle> ActiveToggles() => _obj.ActiveToggles().Select(t => t.AsReadOnly());
        IEnumerable<IReadOnlyToggle> IReadOnlyToggleGroup.ActiveToggles() => this.ActiveToggles();
        public bool AnyTogglesOn() => _obj.AnyTogglesOn();
        // public void NotifyToggleOn(Toggle toggle) => _obj.NotifyToggleOn(toggle);
        // public void RegisterToggle(Toggle toggle) => _obj.RegisterToggle(toggle);
        // public void SetAllTogglesOff() => _obj.SetAllTogglesOff();
        // public void UnregisterToggle(Toggle toggle) => _obj.UnregisterToggle(toggle);

        #endregion
    }

    public sealed class ReadOnlyToggleGroup : ReadOnlyToggleGroup<ToggleGroup>
    {
        public ReadOnlyToggleGroup(ToggleGroup obj) : base(obj)
        {
        }
    }

    public static class ToggleGroupExtensions
    {
        public static ReadOnlyToggleGroup AsReadOnly(this ToggleGroup self) => new ReadOnlyToggleGroup(self);
    }
}