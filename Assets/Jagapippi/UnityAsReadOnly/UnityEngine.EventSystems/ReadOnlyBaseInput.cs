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

        public virtual Vector2 compositionCursorPos => _obj.compositionCursorPos;
        public virtual string compositionString => _obj.compositionString;
        public virtual IMECompositionMode imeCompositionMode => _obj.imeCompositionMode;
        public virtual Vector2 mousePosition => _obj.mousePosition;
        public virtual bool mousePresent => _obj.mousePresent;
        public virtual Vector2 mouseScrollDelta => _obj.mouseScrollDelta;
        public virtual int touchCount => _obj.touchCount;
        public virtual bool touchSupported => _obj.touchSupported;

        #endregion

        #region Public Methods

        public virtual float GetAxisRaw(string axisName) => _obj.GetAxisRaw(axisName);
        public virtual bool GetButtonDown(string buttonName) => _obj.GetButtonDown(buttonName);
        public virtual bool GetMouseButton(int button) => _obj.GetMouseButton(button);
        public virtual bool GetMouseButtonDown(int button) => _obj.GetMouseButtonDown(button);
        public virtual bool GetMouseButtonUp(int button) => _obj.GetMouseButtonUp(button);
        public virtual Touch GetTouch(int index) => _obj.GetTouch(index);

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