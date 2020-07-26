#if !UNITY_WSA
using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyPointerInputModule
    {
        bool IsPointerOverGameObject(int pointerId);
        string ToString();
    }

    public class ReadOnlyPointerInputModule<T> : ReadOnlyBaseInputModule<T>, IReadOnlyPointerInputModule where T : PointerInputModule
    {
        protected ReadOnlyPointerInputModule(T obj) : base(obj)
        {
        }

        #region Properties

        #endregion

        #region Public Methods

        public override bool IsPointerOverGameObject(int pointerId) => _obj.IsPointerOverGameObject(pointerId);
        public override string ToString() => _obj.ToString();

        #endregion
    }

    public sealed class ReadOnlyPointerInputModule : ReadOnlyPointerInputModule<PointerInputModule>
    {
        public ReadOnlyPointerInputModule(PointerInputModule obj) : base(obj)
        {
        }
    }

    public static class PointerInputModuleExtensions
    {
        public static ReadOnlyPointerInputModule AsReadOnly(this PointerInputModule self) => self.IsTrulyNull() ? null : new ReadOnlyPointerInputModule(self);
    }
}
#endif