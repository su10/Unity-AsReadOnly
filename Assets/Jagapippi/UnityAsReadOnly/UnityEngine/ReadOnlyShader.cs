using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyShader : IReadOnlyObject
    {
        bool isSupported { get; }
        int maximumLOD { get; }
        int renderQueue { get; }
    }

    public sealed class ReadOnlyShader : ReadOnlyObject<Shader>, IReadOnlyShader
    {
        public ReadOnlyShader(Shader obj) : base(obj)
        {
        }

        #region Properties

        public bool isSupported => _obj.isSupported;
        public int maximumLOD => _obj.maximumLOD;
        public int renderQueue => _obj.renderQueue;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class ShaderExtensions
    {
        public static IReadOnlyShader AsReadOnly(this Shader self) => new ReadOnlyShader(self);
    }
}