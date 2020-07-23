using UnityEngine.Audio;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioMixerSnapshot
    {
        IReadOnlyAudioMixer audioMixer { get; }
        // void TransitionTo(float timeToReach);
    }

    public sealed class ReadOnlyAudioMixerSnapshot : ReadOnlyObject<AudioMixerSnapshot>, IReadOnlyAudioMixerSnapshot
    {
        public ReadOnlyAudioMixerSnapshot(AudioMixerSnapshot obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyAudioMixer audioMixer => _obj.audioMixer.IsTrulyNull() ? null : _obj.audioMixer.AsReadOnly();
        IReadOnlyAudioMixer IReadOnlyAudioMixerSnapshot.audioMixer => this.audioMixer;

        #endregion

        #region Public Methods

        // public void TransitionTo(float timeToReach) => _obj.TransitionTo(timeToReach);

        #endregion
    }

    public static class AudioMixerSnapshotExtensions
    {
        public static ReadOnlyAudioMixerSnapshot AsReadOnly(this AudioMixerSnapshot self) => new ReadOnlyAudioMixerSnapshot(self);
    }
}