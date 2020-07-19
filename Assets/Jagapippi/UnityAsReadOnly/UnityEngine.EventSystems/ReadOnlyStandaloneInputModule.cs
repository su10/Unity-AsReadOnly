using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyStandaloneInputModule : IReadOnlyPointerInputModule
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
        new bool IsModuleSupported();
        // void Process();
        new bool ShouldActivateModule();
        // void UpdateModule();
    }

    public sealed class ReadOnlyStandaloneInputModule : ReadOnlyPointerInputModule<StandaloneInputModule>, IReadOnlyStandaloneInputModule
    {
        public ReadOnlyStandaloneInputModule(StandaloneInputModule obj) : base(obj)
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
        public new bool IsModuleSupported() => _obj.IsModuleSupported();
        // public void Process() => _obj.Process();
        public new bool ShouldActivateModule() => _obj.ShouldActivateModule();
        // public void UpdateModule() => _obj.UpdateModule();

        #endregion
    }

    public static class StandaloneInputModuleExtensions
    {
        public static IReadOnlyStandaloneInputModule AsReadOnly(this StandaloneInputModule self) => new ReadOnlyStandaloneInputModule(self);
    }
}