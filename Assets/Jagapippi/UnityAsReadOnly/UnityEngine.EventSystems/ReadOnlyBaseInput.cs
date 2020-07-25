using UnityEngine;
using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyBaseInput
    {
        Vector2 compositionCursorPos { get; }
        string compositionString { get; }
        IMECompositionMode imeCompositionMode { get; }
        Vector2 mousePosition { get; }
        bool mousePresent { get; }
        Vector2 mouseScrollDelta { get; }
        int touchCount { get; }
        bool touchSupported { get; }
        float GetAxisRaw(string axisName);
        bool GetButtonDown(string buttonName);
        bool GetMouseButton(int button);
        bool GetMouseButtonDown(int button);
        bool GetMouseButtonUp(int button);
        Touch GetTouch(int index);
    }

    public class ReadOnlyBaseInput<T> : ReadOnlyUIBehaviour<T>, IReadOnlyBaseInput where T : BaseInput
    {
        protected ReadOnlyBaseInput(T obj) : base(obj)
        {
        }

        #region Properties

        public Vector2 compositionCursorPos => _obj.compositionCursorPos;
        public string compositionString => _obj.compositionString;
        public IMECompositionMode imeCompositionMode => _obj.imeCompositionMode;
        public Vector2 mousePosition => _obj.mousePosition;
        public bool mousePresent => _obj.mousePresent;
        public Vector2 mouseScrollDelta => _obj.mouseScrollDelta;
        public int touchCount => _obj.touchCount;
        public bool touchSupported => _obj.touchSupported;

        #endregion

        #region Public Methods

        public float GetAxisRaw(string axisName) => _obj.GetAxisRaw(axisName);
        public bool GetButtonDown(string buttonName) => _obj.GetButtonDown(buttonName);
        public bool GetMouseButton(int button) => _obj.GetMouseButton(button);
        public bool GetMouseButtonDown(int button) => _obj.GetMouseButtonDown(button);
        public bool GetMouseButtonUp(int button) => _obj.GetMouseButtonUp(button);
        public Touch GetTouch(int index) => _obj.GetTouch(index);

        #endregion
    }

    public sealed class ReadOnlyBaseInput : ReadOnlyBaseInput<BaseInput>
    {
        public ReadOnlyBaseInput(BaseInput obj) : base(obj)
        {
        }
    }

    public static class BaseInputExtensions
    {
        public static ReadOnlyBaseInput AsReadOnly(this BaseInput self) => self.IsTrulyNull() ? null : new ReadOnlyBaseInput(self);
    }
}