﻿using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyBaseInputModule : IReadOnlyUIBehaviour
    {
        IReadOnlyBaseInput input { get; }
        IReadOnlyBaseInput inputOverride { get; }
        // void ActivateModule();
        // void DeactivateModule();
        bool IsModuleSupported();
        bool IsPointerOverGameObject(int pointerId);
        // void Process();
        bool ShouldActivateModule();
        // void UpdateModule();
    }

    public class ReadOnlyBaseInputModule<T> : ReadOnlyUIBehaviour<T>, IReadOnlyBaseInputModule where T : BaseInputModule
    {
        protected ReadOnlyBaseInputModule(T obj) : base(obj)
        {
        }

        #region Properties

        public IReadOnlyBaseInput input => (_obj.input == null) ? null : _obj.input.AsReadOnly();
        public IReadOnlyBaseInput inputOverride => (_obj.inputOverride == null) ? null : _obj.inputOverride.AsReadOnly();

        #endregion

        #region Public Methods

        // public void ActivateModule() => _obj.ActivateModule();
        // public void DeactivateModule() => _obj.DeactivateModule();
        public bool IsModuleSupported() => _obj.IsModuleSupported();
        public bool IsPointerOverGameObject(int pointerId) => _obj.IsPointerOverGameObject(pointerId);
        // public void Process() => _obj.Process();
        public bool ShouldActivateModule() => _obj.ShouldActivateModule();
        // public void UpdateModule() => _obj.UpdateModule();

        #endregion
    }

    public sealed class ReadOnlyBaseInputModule : ReadOnlyBaseInputModule<BaseInputModule>
    {
        public ReadOnlyBaseInputModule(BaseInputModule obj) : base(obj)
        {
        }
    }

    public static class BaseInputModuleExtensions
    {
        public static IReadOnlyBaseInputModule AsReadOnly(this BaseInputModule self) => new ReadOnlyBaseInputModule(self);
    }
}