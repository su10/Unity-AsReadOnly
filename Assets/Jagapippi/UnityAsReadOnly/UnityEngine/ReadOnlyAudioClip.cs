using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioClip : IReadOnlyObject
    {
        bool ambisonic { get; }
        int channels { get; }
        int frequency { get; }
        float length { get; }
        bool loadInBackground { get; }
        AudioDataLoadState loadState { get; }
        AudioClipLoadType loadType { get; }
        bool preloadAudioData { get; }
        int samples { get; }
        bool GetData(float[] data, int offsetSamples);
        // bool LoadAudioData();
        // bool SetData(float[] data, int offsetSamples);
        // bool UnloadAudioData();
    }

    public sealed class ReadOnlyAudioClip : ReadOnlyObject<AudioClip>, IReadOnlyAudioClip
    {
        public ReadOnlyAudioClip(AudioClip obj) : base(obj)
        {
        }

        #region Properties

        public bool ambisonic => _obj.ambisonic;
        public int channels => _obj.channels;
        public int frequency => _obj.frequency;
        public float length => _obj.length;
        public bool loadInBackground => _obj.loadInBackground;
        public AudioDataLoadState loadState => _obj.loadState;
        public AudioClipLoadType loadType => _obj.loadType;
        public bool preloadAudioData => _obj.preloadAudioData;
        public int samples => _obj.samples;

        #endregion

        #region Public Methods

        public bool GetData(float[] data, int offsetSamples) => _obj.GetData(data, offsetSamples);
        // public bool LoadAudioData() => _obj.LoadAudioData();
        // public bool SetData(float[] data, int offsetSamples) => _obj.SetData(data, offsetSamples);
        // public bool UnloadAudioData() => _obj.UnloadAudioData();

        #endregion
    }

    public static class AudioClipExtensions
    {
        public static IReadOnlyAudioClip AsReadOnly(this AudioClip self) => new ReadOnlyAudioClip(self);
    }
}