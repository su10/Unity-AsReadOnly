using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyInputField
    {
        char asteriskChar { get; }
        float caretBlinkRate { get; }
        Color caretColor { get; }
        int caretPosition { get; }
        int caretWidth { get; }
        int characterLimit { get; }
        InputField.CharacterValidation characterValidation { get; }
        InputField.ContentType contentType { get; }
        bool customCaretColor { get; }
        float flexibleHeight { get; }
        float flexibleWidth { get; }
        InputField.InputType inputType { get; }
        bool isFocused { get; }
        TouchScreenKeyboardType keyboardType { get; }
        int layoutPriority { get; }
        InputField.LineType lineType { get; }
        float minHeight { get; }
        float minWidth { get; }
        bool multiLine { get; }
        // InputField.SubmitEvent onEndEdit { get; }
        // InputField.OnValidateInput onValidateInput { get; }
        // InputField.OnChangeEvent onValueChanged { get; }
        IReadOnlyGraphic placeholder { get; }
        float preferredHeight { get; }
        float preferredWidth { get; }
        bool readOnly { get; }
        int selectionAnchorPosition { get; }
        Color selectionColor { get; }
        int selectionFocusPosition { get; }
        bool shouldHideMobileInput { get; }
        string text { get; }
        IReadOnlyText textComponent { get; }
        IReadOnlyTouchScreenKeyboard touchScreenKeyboard { get; }
        bool wasCanceled { get; }
        // void ActivateInputField();
        // void CalculateLayoutInputHorizontal();
        // void CalculateLayoutInputVertical();
        // void DeactivateInputField();
        // void ForceLabelUpdate();
        // void GraphicUpdateComplete();
        // void LayoutComplete();
        // void MoveTextEnd(bool shift);
        // void MoveTextStart(bool shift);
        // void OnBeginDrag(PointerEventData eventData);
        // void OnDeselect(BaseEventData eventData);
        // void OnDrag(PointerEventData eventData);
        // void OnEndDrag(PointerEventData eventData);
        // void OnPointerClick(PointerEventData eventData);
        // void OnPointerDown(PointerEventData eventData);
        // void OnSelect(BaseEventData eventData);
        // void OnSubmit(BaseEventData eventData);
        // void OnUpdateSelected(BaseEventData eventData);
        // void ProcessEvent(Event e);
        // void Rebuild(CanvasUpdate update);
    }

    public class ReadOnlyInputField<T> : ReadOnlySelectable<T>, IReadOnlyInputField where T : InputField
    {
        protected ReadOnlyInputField(T obj) : base(obj)
        {
        }

        #region Properties

        public char asteriskChar => _obj.asteriskChar;
        public float caretBlinkRate => _obj.caretBlinkRate;
        public Color caretColor => _obj.caretColor;
        public int caretPosition => _obj.caretPosition;
        public int caretWidth => _obj.caretWidth;
        public int characterLimit => _obj.characterLimit;
        public InputField.CharacterValidation characterValidation => _obj.characterValidation;
        public InputField.ContentType contentType => _obj.contentType;
        public bool customCaretColor => _obj.customCaretColor;
        public virtual float flexibleHeight => _obj.flexibleHeight;
        public virtual float flexibleWidth => _obj.flexibleWidth;
        public InputField.InputType inputType => _obj.inputType;
        public bool isFocused => _obj.isFocused;
        public TouchScreenKeyboardType keyboardType => _obj.keyboardType;
        public virtual int layoutPriority => _obj.layoutPriority;
        public InputField.LineType lineType => _obj.lineType;
        public virtual float minHeight => _obj.minHeight;
        public virtual float minWidth => _obj.minWidth;
        public bool multiLine => _obj.multiLine;
        public InputField.SubmitEvent onEndEdit => _obj.onEndEdit;
        public InputField.OnValidateInput onValidateInput => _obj.onValidateInput;
        public InputField.OnChangeEvent onValueChanged => _obj.onValueChanged;
        public ReadOnlyGraphic placeholder => _obj.placeholder.AsReadOnly();
        IReadOnlyGraphic IReadOnlyInputField.placeholder => this.placeholder;
        public virtual float preferredHeight => _obj.preferredHeight;
        public virtual float preferredWidth => _obj.preferredWidth;
        public bool readOnly => _obj.readOnly;
        public int selectionAnchorPosition => _obj.selectionAnchorPosition;
        public Color selectionColor => _obj.selectionColor;
        public int selectionFocusPosition => _obj.selectionFocusPosition;
        public bool shouldHideMobileInput => _obj.shouldHideMobileInput;
        public string text => _obj.text;
        public ReadOnlyText textComponent => _obj.textComponent.AsReadOnly();
        IReadOnlyText IReadOnlyInputField.textComponent => this.textComponent;
        public ReadOnlyTouchScreenKeyboard touchScreenKeyboard => _obj.touchScreenKeyboard?.AsReadOnly();
        IReadOnlyTouchScreenKeyboard IReadOnlyInputField.touchScreenKeyboard => this.touchScreenKeyboard;
        public bool wasCanceled => _obj.wasCanceled;

        #endregion

        #region Public Methods

        // public void ActivateInputField() => _obj.ActivateInputField();
        // public void CalculateLayoutInputHorizontal() => _obj.CalculateLayoutInputHorizontal();
        // public void CalculateLayoutInputVertical() => _obj.CalculateLayoutInputVertical();
        // public void DeactivateInputField() => _obj.DeactivateInputField();
        // public void ForceLabelUpdate() => _obj.ForceLabelUpdate();
        // public void GraphicUpdateComplete() => _obj.GraphicUpdateComplete();
        // public void LayoutComplete() => _obj.LayoutComplete();
        // public void MoveTextEnd(bool shift) => _obj.MoveTextEnd(shift);
        // public void MoveTextStart(bool shift) => _obj.MoveTextStart(shift);
        // public void OnBeginDrag(PointerEventData eventData) => _obj.OnBeginDrag(eventData);
        // public void OnDeselect(BaseEventData eventData) => _obj.OnDeselect(eventData);
        // public void OnDrag(PointerEventData eventData) => _obj.OnDrag(eventData);
        // public void OnEndDrag(PointerEventData eventData) => _obj.OnEndDrag(eventData);
        // public void OnPointerClick(PointerEventData eventData) => _obj.OnPointerClick(eventData);
        // public void OnPointerDown(PointerEventData eventData) => _obj.OnPointerDown(eventData);
        // public void OnSelect(BaseEventData eventData) => _obj.OnSelect(eventData);
        // public void OnSubmit(BaseEventData eventData) => _obj.OnSubmit(eventData);
        // public void OnUpdateSelected(BaseEventData eventData) => _obj.OnUpdateSelected(eventData);
        // public void ProcessEvent(Event e) => _obj.ProcessEvent(e);
        // public void Rebuild(CanvasUpdate update) => _obj.Rebuild(update);

        #endregion
    }

    public sealed class ReadOnlyInputField : ReadOnlyInputField<InputField>
    {
        public ReadOnlyInputField(InputField obj) : base(obj)
        {
        }
    }

    public static class InputFieldExtensions
    {
        public static ReadOnlyInputField AsReadOnly(this InputField self) => self.IsTrulyNull() ? null : new ReadOnlyInputField(self);
    }
}