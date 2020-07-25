using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyTouchScreenKeyboard
    {
        bool active { get; }
        bool canGetSelection { get; }
        bool canSetSelection { get; }
        int characterLimit { get; }
        RangeInt selection { get; }
        TouchScreenKeyboard.Status status { get; }
        int targetDisplay { get; }
        string text { get; }
        TouchScreenKeyboardType type { get; }
    }

    public class ReadOnlyTouchScreenKeyboard<T> : IReadOnlyTouchScreenKeyboard where T : TouchScreenKeyboard
    {
        protected internal readonly TouchScreenKeyboard _obj;

        public ReadOnlyTouchScreenKeyboard(T obj)
        {
            _obj = obj;
        }

        #region Properties

        public bool active => _obj.active;
        public bool canGetSelection => _obj.canGetSelection;
        public bool canSetSelection => _obj.canSetSelection;
        public int characterLimit => _obj.characterLimit;
        public RangeInt selection => _obj.selection;
        public TouchScreenKeyboard.Status status => _obj.status;
        public int targetDisplay => _obj.targetDisplay;
        public string text => _obj.text;
        public TouchScreenKeyboardType type => _obj.type;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyTouchScreenKeyboard : ReadOnlyTouchScreenKeyboard<TouchScreenKeyboard>
    {
        public ReadOnlyTouchScreenKeyboard(TouchScreenKeyboard obj) : base(obj)
        {
        }
    }

    public static class TouchScreenKeyboardExtensions
    {
        public static ReadOnlyTouchScreenKeyboard AsReadOnly(this TouchScreenKeyboard self) => self.IsTrulyNull() ? null : new ReadOnlyTouchScreenKeyboard(self);
        internal static bool IsTrulyNull(this TouchScreenKeyboard self) => ReferenceEquals(self, null);
    }
}