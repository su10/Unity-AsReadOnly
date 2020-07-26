#if !UNITY_WSA
using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlySelectable
    {
        // AnimationTriggers animationTriggers { get; }
        IReadOnlyAnimator animator { get; }
        ColorBlock colors { get; }
        IReadOnlyImage image { get; }
        bool interactable { get; }
        Navigation navigation { get; }
        SpriteState spriteState { get; }
        IReadOnlyGraphic targetGraphic { get; }
        Selectable.Transition transition { get; }
        IReadOnlySelectable FindSelectable(Vector3 dir);
        IReadOnlySelectable FindSelectableOnDown();
        IReadOnlySelectable FindSelectableOnLeft();
        IReadOnlySelectable FindSelectableOnRight();
        IReadOnlySelectable FindSelectableOnUp();
        bool IsInteractable();
        // void OnDeselect(BaseEventData eventData);
        // void OnMove(AxisEventData eventData);
        // void OnPointerDown(PointerEventData eventData);
        // void OnPointerEnter(PointerEventData eventData);
        // void OnPointerExit(PointerEventData eventData);
        // void OnPointerUp(PointerEventData eventData);
        // void OnSelect(BaseEventData eventData);
        // void Select();
    }

    public class ReadOnlySelectable<T> : ReadOnlyUIBehaviour<T>, IReadOnlySelectable where T : Selectable
    {
        protected ReadOnlySelectable(T obj) : base(obj)
        {
        }

        #region Properties

        // public AnimationTriggers animationTriggers => _obj.animationTriggers;
        public ReadOnlyAnimator animator => _obj.animator.AsReadOnly();
        IReadOnlyAnimator IReadOnlySelectable.animator => this.animator;
        public ColorBlock colors => _obj.colors;
        public ReadOnlyImage image => _obj.image.AsReadOnly();
        IReadOnlyImage IReadOnlySelectable.image => this.image;
        public bool interactable => _obj.interactable;
        public Navigation navigation => _obj.navigation;
        public SpriteState spriteState => _obj.spriteState;
        public ReadOnlyGraphic targetGraphic => _obj.targetGraphic.AsReadOnly();
        IReadOnlyGraphic IReadOnlySelectable.targetGraphic => this.targetGraphic;
        public Selectable.Transition transition => _obj.transition;

        #endregion

        #region Public Methods

        public ReadOnlySelectable FindSelectable(Vector3 dir) => _obj.FindSelectable(dir).AsReadOnly();
        IReadOnlySelectable IReadOnlySelectable.FindSelectable(Vector3 dir) => this.FindSelectable(dir);
        public virtual ReadOnlySelectable FindSelectableOnDown() => _obj.FindSelectableOnDown().AsReadOnly();
        IReadOnlySelectable IReadOnlySelectable.FindSelectableOnDown() => this.FindSelectableOnDown();
        public virtual ReadOnlySelectable FindSelectableOnLeft() => _obj.FindSelectableOnLeft().AsReadOnly();
        IReadOnlySelectable IReadOnlySelectable.FindSelectableOnLeft() => this.FindSelectableOnLeft();
        public virtual ReadOnlySelectable FindSelectableOnRight() => _obj.FindSelectableOnRight().AsReadOnly();
        IReadOnlySelectable IReadOnlySelectable.FindSelectableOnRight() => this.FindSelectableOnRight();
        public virtual ReadOnlySelectable FindSelectableOnUp() => _obj.FindSelectableOnUp().AsReadOnly();
        IReadOnlySelectable IReadOnlySelectable.FindSelectableOnUp() => this.FindSelectableOnUp();
        public virtual bool IsInteractable() => _obj.IsInteractable();
        // public void OnDeselect(BaseEventData eventData) => _obj.OnDeselect(eventData);
        // public void OnMove(AxisEventData eventData) => _obj.OnMove(eventData);
        // public void OnPointerDown(PointerEventData eventData) => _obj.OnPointerDown(eventData);
        // public void OnPointerEnter(PointerEventData eventData) => _obj.OnPointerEnter(eventData);
        // public void OnPointerExit(PointerEventData eventData) => _obj.OnPointerExit(eventData);
        // public void OnPointerUp(PointerEventData eventData) => _obj.OnPointerUp(eventData);
        // public void OnSelect(BaseEventData eventData) => _obj.OnSelect(eventData);
        // public void Select() => _obj.Select();

        #endregion
    }

    public sealed class ReadOnlySelectable : ReadOnlySelectable<Selectable>
    {
        public ReadOnlySelectable(Selectable obj) : base(obj)
        {
        }
    }

    public static class SelectableExtensions
    {
        public static ReadOnlySelectable AsReadOnly(this Selectable self) => self.IsTrulyNull() ? null : new ReadOnlySelectable(self);
    }
}
#endif