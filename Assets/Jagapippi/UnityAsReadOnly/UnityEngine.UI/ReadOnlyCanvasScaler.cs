﻿#if !UNITY_WSA
using UnityEngine;
using UnityEngine.UI;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyCanvasScaler
    {
        float defaultSpriteDPI { get; }
        float dynamicPixelsPerUnit { get; }
        float fallbackScreenDPI { get; }
        float matchWidthOrHeight { get; }
        CanvasScaler.Unit physicalUnit { get; }
        float referencePixelsPerUnit { get; }
        Vector2 referenceResolution { get; }
        float scaleFactor { get; }
        CanvasScaler.ScreenMatchMode screenMatchMode { get; }
        CanvasScaler.ScaleMode uiScaleMode { get; }
    }

    public abstract class ReadOnlyCanvasScaler<T> : ReadOnlyUIBehaviour<T>, IReadOnlyCanvasScaler where T : CanvasScaler
    {
        protected ReadOnlyCanvasScaler(T obj) : base(obj)
        {
        }

        #region Properties

        public float defaultSpriteDPI => _obj.defaultSpriteDPI;
        public float dynamicPixelsPerUnit => _obj.dynamicPixelsPerUnit;
        public float fallbackScreenDPI => _obj.fallbackScreenDPI;
        public float matchWidthOrHeight => _obj.matchWidthOrHeight;
        public CanvasScaler.Unit physicalUnit => _obj.physicalUnit;
        public float referencePixelsPerUnit => _obj.referencePixelsPerUnit;
        public Vector2 referenceResolution => _obj.referenceResolution;
        public float scaleFactor => _obj.scaleFactor;
        public CanvasScaler.ScreenMatchMode screenMatchMode => _obj.screenMatchMode;
        public CanvasScaler.ScaleMode uiScaleMode => _obj.uiScaleMode;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyCanvasScaler : ReadOnlyCanvasScaler<CanvasScaler>
    {
        public ReadOnlyCanvasScaler(CanvasScaler obj) : base(obj)
        {
        }
    }

    public static class CanvasScalerExtensions
    {
        public static ReadOnlyCanvasScaler AsReadOnly(this CanvasScaler self) => self.IsTrulyNull() ? null : new ReadOnlyCanvasScaler(self);
    }
}
#endif