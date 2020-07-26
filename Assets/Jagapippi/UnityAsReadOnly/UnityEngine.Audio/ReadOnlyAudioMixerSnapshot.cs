using UnityEngine.Audio;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioMixerSnapshot
    {
        IReadOnlyAudioMixer audioMixer { get; }
        // void TransitionTo(float timeToReach);
    }

    public abstract class ReadOnlyAudioMixerSnapshot<T> : ReadOnlyObject<T>, IReadOnlyAudioMixerSnapshot where T : AudioMixerSnapshot
    {
        protected ReadOnlyAudioMixerSnapshot(T obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyAudioMixer audioMixer => _obj.audioMixer.AsReadOnly();
        IReadOnlyAudioMixer IReadOnlyAudioMixerSnapshot.audioMixer => this.audioMixer;

        #endregion

        #region Public Methods

        // public void TransitionTo(float timeToReach) => _obj.TransitionTo(timeToReach);

        #endregion
    }

    public sealed class ReadOnlyAudioMixerSnapshot : ReadOnlyAudioMixerSnapshot<AudioMixerSnapshot>
    {
        public ReadOnlyAudioMixerSnapshot(AudioMixerSnapshot obj) : base(obj)
        {
        }
    }

    public static class AudioMixerSnapshotExtensions
    {
        public static ReadOnlyAudioMixerSnapshot AsReadOnly(this AudioMixerSnapshot self) => self.IsTrulyNull() ? null : new ReadOnlyAudioMixerSnapshot(self);
    }
}