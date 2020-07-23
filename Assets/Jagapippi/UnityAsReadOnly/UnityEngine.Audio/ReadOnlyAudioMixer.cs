using System.Linq;
using UnityEngine.Audio;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioMixer
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

        public ReadOnlyAudioMixerGroup outputAudioMixerGroup => (_obj.outputAudioMixerGroup == null) ? null : _obj.outputAudioMixerGroup.AsReadOnly();
        IReadOnlyAudioMixerGroup IReadOnlyAudioMixer.outputAudioMixerGroup => this.outputAudioMixerGroup;
        public AudioMixerUpdateMode updateMode => _obj.updateMode;

        #endregion

        #region Public Methods

        // public bool ClearFloat(string name) => _obj.ClearFloat(name);

        public ReadOnlyAudioMixerGroup[] FindMatchingGroups(string subPath)
        {
            var mixerGroups = _obj.FindMatchingGroups(subPath);
            return (mixerGroups == null) ? null : mixerGroups.Select(g => g.AsReadOnly()).ToArray();
        }

        IReadOnlyAudioMixerGroup[] IReadOnlyAudioMixer.FindMatchingGroups(string subPath) => this.FindMatchingGroups(subPath);

        public ReadOnlyAudioMixerSnapshot FindSnapshot(string name)
        {
            var snapshot = _obj.FindSnapshot(name);
            return (snapshot == null) ? null : snapshot.AsReadOnly();
        }

        IReadOnlyAudioMixerSnapshot IReadOnlyAudioMixer.FindSnapshot(string name) => this.FindSnapshot(name);

        public bool GetFloat(string name, out float value) => _obj.GetFloat(name, out value);
        // public bool SetFloat(string name, float value) => _obj.SetFloat(name, value);
        // public void TransitionToSnapshots(AudioMixerSnapshot[] snapshots, float[] weights, float timeToReach) => _obj.TransitionToSnapshots(snapshots, weights, timeToReach);

        #endregion
    }

    public static class AudioMixerExtensions
    {
        public static ReadOnlyAudioMixer AsReadOnly(this AudioMixer self) => new ReadOnlyAudioMixer(self);
    }
}