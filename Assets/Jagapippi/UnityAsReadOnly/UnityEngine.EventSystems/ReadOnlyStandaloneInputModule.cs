using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyStandaloneInputModule
    {
        string cancelButton { get; }
        bool forceModuleActive { get; }
        string horizontalAxis { get; }
        float inputActionsPerSecond { get; }
        float repeatDelay { get; }
        string submitButton { get; }
        string verticalAxis { get; }
        // void ActivateModule();
        // void DeactivateModule();
        bool IsModuleSupported();
        // void Process();
        bool ShouldActivateModule();
        // void UpdateModule();
    }

    public class ReadOnlyStandaloneInputModule<T> : ReadOnlyPointerInputModule<T>, IReadOnlyStandaloneInputModule where T : StandaloneInputModule
    {
        protected ReadOnlyStandaloneInputModule(T obj) : base(obj)
        {
        }

        #region Properties

        public string cancelButton => _obj.cancelButton;
        public bool forceModuleActive => _obj.forceModuleActive;
        public string horizontalAxis => _obj.horizontalAxis;
        public float inputActionsPerSecond => _obj.inputActionsPerSecond;
        public float repeatDelay => _obj.repeatDelay;
        public string submitButton => _obj.submitButton;
        public string verticalAxis => _obj.verticalAxis;

        #endregion

        #region Public Methods

        // public void ActivateModule() => _obj.ActivateModule();
        // public void DeactivateModule() => _obj.DeactivateModule();
        public override bool IsModuleSupported() => _obj.IsModuleSupported();
        // public void Process() => _obj.Process();
        public override bool ShouldActivateModule() => _obj.ShouldActivateModule();
        // public void UpdateModule() => _obj.UpdateModule();

        #endregion
    }

    public sealed class ReadOnlyStandaloneInputModule : ReadOnlyStandaloneInputModule<StandaloneInputModule>
    {
        public ReadOnlyStandaloneInputModule(StandaloneInputModule obj) : base(obj)
        {
        }
    }

    public static class StandaloneInputModuleExtensions
    {
        public static ReadOnlyStandaloneInputModule AsReadOnly(this StandaloneInputModule self) => self.IsTrulyNull() ? null : new ReadOnlyStandaloneInputModule(self);
    }
}