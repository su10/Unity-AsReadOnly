#if !UNITY_WSA
using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyBaseInputModule
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

    public abstract class ReadOnlyBaseInputModule<T> : ReadOnlyUIBehaviour<T>, IReadOnlyBaseInputModule where T : BaseInputModule
    {
        protected ReadOnlyBaseInputModule(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyBaseInput input => _obj.input.AsReadOnly();
        IReadOnlyBaseInput IReadOnlyBaseInputModule.input => this.input;
        public ReadOnlyBaseInput inputOverride => _obj.inputOverride.AsReadOnly();
        IReadOnlyBaseInput IReadOnlyBaseInputModule.inputOverride => this.inputOverride;

        #endregion

        #region Public Methods

        // public void ActivateModule() => _obj.ActivateModule();
        // public void DeactivateModule() => _obj.DeactivateModule();
        public virtual bool IsModuleSupported() => _obj.IsModuleSupported();
        public virtual bool IsPointerOverGameObject(int pointerId) => _obj.IsPointerOverGameObject(pointerId);
        // public void Process() => _obj.Process();
        public virtual bool ShouldActivateModule() => _obj.ShouldActivateModule();
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
        public static ReadOnlyBaseInputModule AsReadOnly(this BaseInputModule self) => self.IsTrulyNull() ? null : new ReadOnlyBaseInputModule(self);
    }
}
#endif