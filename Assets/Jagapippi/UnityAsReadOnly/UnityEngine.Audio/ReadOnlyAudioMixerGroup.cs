using UnityEngine.Audio;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioMixerGroup
    {
        IReadOnlyAudioMixer audioMixer { get; }
    }

    public sealed class ReadOnlyAudioMixerGroup : ReadOnlyObject<AudioMixerGroup>, IReadOnlyAudioMixerGroup
    {
        public ReadOnlyAudioMixerGroup(AudioMixerGroup obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyAudioMixer audioMixer => (_obj.audioMixer == null) ? null : _obj.audioMixer.AsReadOnly();
        IReadOnlyAudioMixer IReadOnlyAudioMixerGroup.audioMixer => this.audioMixer;

        #endregion

        #region Public Methods

        #endregion
    }

    public static class AudioMixerGroupExtensions
    {
        public static ReadOnlyAudioMixerGroup AsReadOnly(this AudioMixerGroup self) => new ReadOnlyAudioMixerGroup(self);
    }
}