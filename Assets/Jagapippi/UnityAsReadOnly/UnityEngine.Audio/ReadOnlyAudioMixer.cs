using System.Linq;
using UnityEngine.Audio;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioMixer : IReadOnlyObject
    {
        IReadOnlyAudioMixerGroup outputAudioMixerGroup { get; }
        AudioMixerUpdateMode updateMode { get; }
        // bool ClearFloat(string name);
        IReadOnlyAudioMixerGroup[] FindMatchingGroups(string subPath);
        IReadOnlyAudioMixerSnapshot FindSnapshot(string name);
        bool GetFloat(string name, out float value);
        // bool SetFloat(string name, float value);
        // void TransitionToSnapshots(AudioMixerSnapshot[] snapshots, float[] weights, float timeToReach);
    }

    public sealed class ReadOnlyAudioMixer : ReadOnlyObject<AudioMixer>, IReadOnlyAudioMixer
    {
        public ReadOnlyAudioMixer(AudioMixer obj) : base(obj)
        {
        }

        #region Properties

        public IReadOnlyAudioMixerGroup outputAudioMixerGroup => (_obj.outputAudioMixerGroup == null) ? null : _obj.outputAudioMixerGroup.AsReadOnly();
        public AudioMixerUpdateMode updateMode => _obj.updateMode;

        #endregion

        #region Public Methods

        // public bool ClearFloat(string name) => _obj.ClearFloat(name);

        public IReadOnlyAudioMixerGroup[] FindMatchingGroups(string subPath)
        {
            var mixerGroups = _obj.FindMatchingGroups(subPath);
            return (mixerGroups == null) ? null : mixerGroups.Select(g => g.AsReadOnly()).ToArray();
        }

        public IReadOnlyAudioMixerSnapshot FindSnapshot(string name)
        {
            var snapshot = _obj.FindSnapshot(name);
            return (snapshot == null) ? null : snapshot.AsReadOnly();
        }

        public bool GetFloat(string name, out float value) => _obj.GetFloat(name, out value);
        // public bool SetFloat(string name, float value) => _obj.SetFloat(name, value);
        // public void TransitionToSnapshots(AudioMixerSnapshot[] snapshots, float[] weights, float timeToReach) => _obj.TransitionToSnapshots(snapshots, weights, timeToReach);

        #endregion
    }

    public static class AudioMixerExtensions
    {
        public static IReadOnlyAudioMixer AsReadOnly(this AudioMixer self) => new ReadOnlyAudioMixer(self);
    }
}