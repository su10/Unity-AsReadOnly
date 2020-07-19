using UnityEngine.Audio;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioMixerGroup : IReadOnlyObject
    {
        IReadOnlyAudioMixer audioMixer { get; }
    }

    public sealed class ReadOnlyAudioMixerGroup : ReadOnlyObject<AudioMixerGroup>, IReadOnlyAudioMixerGroup
    {
        public ReadOnlyAudioMixerGroup(AudioMixerGroup obj) : base(obj)
        {
        }

        #region Properties

        public IReadOnlyAudioMixer audioMixer => (_obj.audioMixer == null) ? null : _obj.audioMixer.AsReadOnly();

        #endregion

        #region Public Methods

        #endregion
    }

    public static class AudioMixerGroupExtensions
    {
        public static IReadOnlyAudioMixerGroup AsReadOnly(this AudioMixerGroup self) => new ReadOnlyAudioMixerGroup(self);
    }
}