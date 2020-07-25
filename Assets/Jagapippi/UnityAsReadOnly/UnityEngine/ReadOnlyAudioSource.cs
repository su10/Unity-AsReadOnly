using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAudioSource
    {
        bool bypassEffects { get; }
        bool bypassListenerEffects { get; }
        bool bypassReverbZones { get; }
        IReadOnlyAudioClip clip { get; }
        float dopplerLevel { get; }
        bool ignoreListenerPause { get; }
        bool ignoreListenerVolume { get; }
        bool isPlaying { get; }
        bool isVirtual { get; }
        bool loop { get; }
        float maxDistance { get; }
        float minDistance { get; }
        bool mute { get; }
        IReadOnlyAudioMixerGroup outputAudioMixerGroup { get; }
        float panStereo { get; }
        float pitch { get; }
        bool playOnAwake { get; }
        int priority { get; }
        float reverbZoneMix { get; }
        AudioRolloffMode rolloffMode { get; }
        float spatialBlend { get; }
        bool spatialize { get; }
        bool spatializePostEffects { get; }
        float spread { get; }
        float time { get; }
        int timeSamples { get; }
        AudioVelocityUpdateMode velocityUpdateMode { get; }
        float volume { get; }
        bool GetAmbisonicDecoderFloat(int index, out float value);
        IReadOnlyAnimationCurve GetCustomCurve(AudioSourceCurveType type);
        void GetOutputData(float[] samples, int channel);
        bool GetSpatializerFloat(int index, out float value);
        void GetSpectrumData(float[] samples, int channel, FFTWindow window);
        // void Pause();
        // void Play(ulong delay);
        // void Play();
        // void PlayDelayed(float delay);
        // void PlayOneShot(AudioClip clip);
        // void PlayOneShot(AudioClip clip, float volumeScale);
        // void PlayScheduled(double time);
        // bool SetAmbisonicDecoderFloat(int index, float value);
        // void SetCustomCurve(AudioSourceCurveType type, AnimationCurve curve);
        // void SetScheduledEndTime(double time);
        // void SetScheduledStartTime(double time);
        // bool SetSpatializerFloat(int index, float value);
        // void Stop();
        // void UnPause();
    }

    public sealed class ReadOnlyAudioSource : ReadOnlyBehaviour<AudioSource>, IReadOnlyAudioSource
    {
        public ReadOnlyAudioSource(AudioSource obj) : base(obj)
        {
        }

        #region Properties

        public bool bypassEffects => _obj.bypassEffects;
        public bool bypassListenerEffects => _obj.bypassListenerEffects;
        public bool bypassReverbZones => _obj.bypassReverbZones;
        public ReadOnlyAudioClip clip => _obj.clip.AsReadOnly();
        IReadOnlyAudioClip IReadOnlyAudioSource.clip => this.clip;
        public float dopplerLevel => _obj.dopplerLevel;
        public bool ignoreListenerPause => _obj.ignoreListenerPause;
        public bool ignoreListenerVolume => _obj.ignoreListenerVolume;
        public bool isPlaying => _obj.isPlaying;
        public bool isVirtual => _obj.isVirtual;
        public bool loop => _obj.loop;
        public float maxDistance => _obj.maxDistance;
        public float minDistance => _obj.minDistance;
        public bool mute => _obj.mute;
        public ReadOnlyAudioMixerGroup outputAudioMixerGroup => _obj.outputAudioMixerGroup.AsReadOnly();
        IReadOnlyAudioMixerGroup IReadOnlyAudioSource.outputAudioMixerGroup => this.outputAudioMixerGroup;
        public float panStereo => _obj.panStereo;
        public float pitch => _obj.pitch;
        public bool playOnAwake => _obj.playOnAwake;
        public int priority => _obj.priority;
        public float reverbZoneMix => _obj.reverbZoneMix;
        public AudioRolloffMode rolloffMode => _obj.rolloffMode;
        public float spatialBlend => _obj.spatialBlend;
        public bool spatialize => _obj.spatialize;
        public bool spatializePostEffects => _obj.spatializePostEffects;
        public float spread => _obj.spread;
        public float time => _obj.time;
        public int timeSamples => _obj.timeSamples;
        public AudioVelocityUpdateMode velocityUpdateMode => _obj.velocityUpdateMode;
        public float volume => _obj.volume;

        #endregion

        #region Public Methods

        public bool GetAmbisonicDecoderFloat(int index, out float value) => _obj.GetAmbisonicDecoderFloat(index, out value);
        public ReadOnlyAnimationCurve GetCustomCurve(AudioSourceCurveType type) => _obj.GetCustomCurve(type).AsReadOnly();
        IReadOnlyAnimationCurve IReadOnlyAudioSource.GetCustomCurve(AudioSourceCurveType type) => this.GetCustomCurve(type);
        public void GetOutputData(float[] samples, int channel) => _obj.GetOutputData(samples, channel);
        public bool GetSpatializerFloat(int index, out float value) => _obj.GetSpatializerFloat(index, out value);
        public void GetSpectrumData(float[] samples, int channel, FFTWindow window) => _obj.GetSpectrumData(samples, channel, window);
        // public void Pause() => _obj.Pause();
        // public void Play(ulong delay) => _obj.Play(delay);
        // public void Play() => _obj.Play();
        // public void PlayDelayed(float delay) => _obj.PlayDelayed(delay);
        // public void PlayOneShot(AudioClip clip) => _obj.PlayOneShot(clip);
        // public void PlayOneShot(AudioClip clip, float volumeScale) => _obj.PlayOneShot(clip, volumeScale);
        // public void PlayScheduled(double time) => _obj.PlayScheduled(time);
        // public bool SetAmbisonicDecoderFloat(int index, float value) => _obj.SetAmbisonicDecoderFloat(index, value);
        // public void SetCustomCurve(AudioSourceCurveType type, AnimationCurve curve) => _obj.SetCustomCurve(type, curve);
        // public void SetScheduledEndTime(double time) => _obj.SetScheduledEndTime(time);
        // public void SetScheduledStartTime(double time) => _obj.SetScheduledStartTime(time);
        // public bool SetSpatializerFloat(int index, float value) => _obj.SetSpatializerFloat(index, value);
        // public void Stop() => _obj.Stop();
        // public void UnPause() => _obj.UnPause();

        #endregion
    }

    public static class AudioSourceExtensions
    {
        public static ReadOnlyAudioSource AsReadOnly(this AudioSource self) => self.IsTrulyNull() ? null : new ReadOnlyAudioSource(self);
    }
}