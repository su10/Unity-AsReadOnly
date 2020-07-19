using UnityEngine.Audio;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioMixerSnapshot : IReadOnlyObject
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

        public IReadOnlyAudioMixer audioMixer => (_obj.audioMixer == null) ? null : _obj.audioMixer.AsReadOnly();

        #endregion

        #region Public Methods

        // public void TransitionTo(float timeToReach) => _obj.TransitionTo(timeToReach);

        #endregion
    }

    public static class AudioMixerSnapshotExtensions
    {
        public static IReadOnlyAudioMixerSnapshot AsReadOnly(this AudioMixerSnapshot self) => new ReadOnlyAudioMixerSnapshot(self);
    }
}