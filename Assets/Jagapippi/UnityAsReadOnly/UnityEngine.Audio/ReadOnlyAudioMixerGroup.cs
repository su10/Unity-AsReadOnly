using UnityEngine.Audio;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioMixerGroup
    {
        IReadOnlyAudioMixer audioMixer { get; }
    }

    public class ReadOnlyAudioMixerGroup<T> : ReadOnlyObject<T>, IReadOnlyAudioMixerGroup where T : AudioMixerGroup
    {
        protected ReadOnlyAudioMixerGroup(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyAudioMixer audioMixer => _obj.audioMixer.IsTrulyNull() ? null : _obj.audioMixer.AsReadOnly();
        IReadOnlyAudioMixer IReadOnlyAudioMixerGroup.audioMixer => this.audioMixer;

        #endregion

        #region Public Methods

        #endregion
    }

    public sealed class ReadOnlyAudioMixerGroup : ReadOnlyAudioMixerGroup<AudioMixerGroup>
    {
        public ReadOnlyAudioMixerGroup(AudioMixerGroup obj) : base(obj)
        {
        }
    }

    public static class AudioMixerGroupExtensions
    {
        public static ReadOnlyAudioMixerGroup AsReadOnly(this AudioMixerGroup self) => new ReadOnlyAudioMixerGroup(self);
    }
}