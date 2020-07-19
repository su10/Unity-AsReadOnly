using UnityEngine.EventSystems;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyPointerInputModule : IReadOnlyBaseInputModule
    {
        new bool IsPointerOverGameObject(int pointerId);
        new string ToString();
    }

    public class ReadOnlyPointerInputModule<T> : ReadOnlyBaseInputModule<T>, IReadOnlyPointerInputModule where T : PointerInputModule
    {
        protected ReadOnlyPointerInputModule(T obj) : base(obj)
        {
        }

        #region Properties

        #endregion

        #region Public Methods

        public new bool IsPointerOverGameObject(int pointerId) => _obj.IsPointerOverGameObject(pointerId);
        public new string ToString() => _obj.ToString();

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
        public static IReadOnlyPointerInputModule AsReadOnly(this PointerInputModule self) => new ReadOnlyPointerInputModule(self);
    }
}