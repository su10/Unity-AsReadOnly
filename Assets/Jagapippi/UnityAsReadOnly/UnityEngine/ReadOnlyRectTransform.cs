using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyRectTransform
    {
        Vector2 anchoredPosition { get; }
        Vector3 anchoredPosition3D { get; }
        Vector2 anchorMax { get; }
        Vector2 anchorMin { get; }
        Vector2 offsetMax { get; }
        Vector2 offsetMin { get; }
        Vector2 pivot { get; }
        Rect rect { get; }
        Vector2 sizeDelta { get; }
        // void ForceUpdateRectTransforms();
        void GetLocalCorners(Vector3[] fourCornersArray);
        void GetWorldCorners(Vector3[] fourCornersArray);
        // void SetInsetAndSizeFromParentEdge(RectTransform.Edge edge, float inset, float size);
        // void SetSizeWithCurrentAnchors(RectTransform.Axis axis, float size);
    }

    public sealed class ReadOnlyRectTransform : ReadOnlyTransform<RectTransform>, IReadOnlyRectTransform
    {
        public ReadOnlyRectTransform(RectTransform obj) : base(obj)
        {
        }

        #region Properties

        public Vector2 anchoredPosition => _obj.anchoredPosition;
        public Vector3 anchoredPosition3D => _obj.anchoredPosition3D;
        public Vector2 anchorMax => _obj.anchorMax;
        public Vector2 anchorMin => _obj.anchorMin;
        public Vector2 offsetMax => _obj.offsetMax;
        public Vector2 offsetMin => _obj.offsetMin;
        public Vector2 pivot => _obj.pivot;
        public Rect rect => _obj.rect;
        public Vector2 sizeDelta => _obj.sizeDelta;

        #endregion

        #region Public Methods

        // public void ForceUpdateRectTransforms() => _obj.ForceUpdateRectTransforms();
        public void GetLocalCorners(Vector3[] fourCornersArray) => _obj.GetLocalCorners(fourCornersArray);
        public void GetWorldCorners(Vector3[] fourCornersArray) => _obj.GetWorldCorners(fourCornersArray);
        // public void SetInsetAndSizeFromParentEdge(RectTransform.Edge edge, float inset, float size) => _obj.SetInsetAndSizeFromParentEdge(edge, inset, size);
        // public void SetSizeWithCurrentAnchors(RectTransform.Axis axis, float size) => _obj.SetSizeWithCurrentAnchors(axis, size);

        #endregion
    }

    public static class RectTransformExtensions
    {
        public static ReadOnlyRectTransform AsReadOnly(this RectTransform self) => new ReadOnlyRectTransform(self);
    }
}