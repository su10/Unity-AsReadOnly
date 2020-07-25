using UnityEngine;
using UnityEngine.Video;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyVideoPlayer
    {
        VideoAspectRatio aspectRatio { get; }
        VideoAudioOutputMode audioOutputMode { get; }
        ushort audioTrackCount { get; }
        bool canSetDirectAudioVolume { get; }
        bool canSetPlaybackSpeed { get; }
        bool canSetSkipOnDrop { get; }
        bool canSetTime { get; }
        bool canSetTimeSource { get; }
        bool canStep { get; }
        VideoClip clip { get; }
        double clockTime { get; }
        ushort controlledAudioTrackCount { get; }
        double externalReferenceTime { get; }
        long frame { get; }
        ulong frameCount { get; }
        float frameRate { get; }
        uint height { get; }
        bool isLooping { get; }
        bool isPaused { get; }
        bool isPlaying { get; }
        bool isPrepared { get; }
        double length { get; }
        uint pixelAspectRatioDenominator { get; }
        uint pixelAspectRatioNumerator { get; }
        float playbackSpeed { get; }
        bool playOnAwake { get; }
        VideoRenderMode renderMode { get; }
        bool sendFrameReadyEvents { get; }
        bool skipOnDrop { get; }
        VideoSource source { get; }
        IReadOnlyCamera targetCamera { get; }
        Video3DLayout targetCamera3DLayout { get; }
        float targetCameraAlpha { get; }
        string targetMaterialProperty { get; }
        IReadOnlyRenderer targetMaterialRenderer { get; }
        RenderTexture targetTexture { get; }
        Texture texture { get; }
        double time { get; }
        VideoTimeReference timeReference { get; }
        VideoTimeSource timeSource { get; }
        string url { get; }
        bool waitForFirstFrame { get; }
        uint width { get; }
        // void EnableAudioTrack(ushort trackIndex, bool enabled);
        ushort GetAudioChannelCount(ushort trackIndex);
        string GetAudioLanguageCode(ushort trackIndex);
        uint GetAudioSampleRate(ushort trackIndex);
        bool GetDirectAudioMute(ushort trackIndex);
        float GetDirectAudioVolume(ushort trackIndex);
        IReadOnlyAudioSource GetTargetAudioSource(ushort trackIndex);
        bool IsAudioTrackEnabled(ushort trackIndex);
        // void Pause();
        // void Play();
        // void Prepare();
        // void SetDirectAudioMute(ushort trackIndex, bool mute);
        // void SetDirectAudioVolume(ushort trackIndex, float volume);
        // void SetTargetAudioSource(ushort trackIndex, AudioSource source);
        // void StepForward();
        // void Stop();
    }

    public sealed class ReadOnlyVideoPlayer : ReadOnlyBehaviour<VideoPlayer>, IReadOnlyVideoPlayer
    {
        public ReadOnlyVideoPlayer(VideoPlayer obj) : base(obj)
        {
        }

        #region Properties

        public VideoAspectRatio aspectRatio => _obj.aspectRatio;
        public VideoAudioOutputMode audioOutputMode => _obj.audioOutputMode;
        public ushort audioTrackCount => _obj.audioTrackCount;
        public bool canSetDirectAudioVolume => _obj.canSetDirectAudioVolume;
        public bool canSetPlaybackSpeed => _obj.canSetPlaybackSpeed;
        public bool canSetSkipOnDrop => _obj.canSetSkipOnDrop;
        public bool canSetTime => _obj.canSetTime;
        public bool canSetTimeSource => _obj.canSetTimeSource;
        public bool canStep => _obj.canStep;
        public VideoClip clip => _obj.clip;
        public double clockTime => _obj.clockTime;
        public ushort controlledAudioTrackCount => _obj.controlledAudioTrackCount;
        public double externalReferenceTime => _obj.externalReferenceTime;
        public long frame => _obj.frame;
        public ulong frameCount => _obj.frameCount;
        public float frameRate => _obj.frameRate;
        public uint height => _obj.height;
        public bool isLooping => _obj.isLooping;
        public bool isPaused => _obj.isPaused;
        public bool isPlaying => _obj.isPlaying;
        public bool isPrepared => _obj.isPrepared;
        public double length => _obj.length;
        public uint pixelAspectRatioDenominator => _obj.pixelAspectRatioDenominator;
        public uint pixelAspectRatioNumerator => _obj.pixelAspectRatioNumerator;
        public float playbackSpeed => _obj.playbackSpeed;
        public bool playOnAwake => _obj.playOnAwake;
        public VideoRenderMode renderMode => _obj.renderMode;
        public bool sendFrameReadyEvents => _obj.sendFrameReadyEvents;
        public bool skipOnDrop => _obj.skipOnDrop;
        public VideoSource source => _obj.source;
        public ReadOnlyCamera targetCamera => _obj.targetCamera.AsReadOnly();
        IReadOnlyCamera IReadOnlyVideoPlayer.targetCamera => this.targetCamera;
        public Video3DLayout targetCamera3DLayout => _obj.targetCamera3DLayout;
        public float targetCameraAlpha => _obj.targetCameraAlpha;
        public string targetMaterialProperty => _obj.targetMaterialProperty;
        public ReadOnlyRenderer targetMaterialRenderer => _obj.targetMaterialRenderer.AsReadOnly();
        IReadOnlyRenderer IReadOnlyVideoPlayer.targetMaterialRenderer => this.targetMaterialRenderer;
        public RenderTexture targetTexture => _obj.targetTexture;
        public Texture texture => _obj.texture;
        public double time => _obj.time;
        public VideoTimeReference timeReference => _obj.timeReference;
        public VideoTimeSource timeSource => _obj.timeSource;
        public string url => _obj.url;
        public bool waitForFirstFrame => _obj.waitForFirstFrame;
        public uint width => _obj.width;

        #endregion

        #region Public Methods

        // public void EnableAudioTrack(ushort trackIndex, bool enabled) => _obj.EnableAudioTrack(trackIndex, enabled);
        public ushort GetAudioChannelCount(ushort trackIndex) => _obj.GetAudioChannelCount(trackIndex);
        public string GetAudioLanguageCode(ushort trackIndex) => _obj.GetAudioLanguageCode(trackIndex);
        public uint GetAudioSampleRate(ushort trackIndex) => _obj.GetAudioSampleRate(trackIndex);
        public bool GetDirectAudioMute(ushort trackIndex) => _obj.GetDirectAudioMute(trackIndex);
        public float GetDirectAudioVolume(ushort trackIndex) => _obj.GetDirectAudioVolume(trackIndex);
        public ReadOnlyAudioSource GetTargetAudioSource(ushort trackIndex) => _obj.GetTargetAudioSource(trackIndex).AsReadOnly();
        IReadOnlyAudioSource IReadOnlyVideoPlayer.GetTargetAudioSource(ushort trackIndex) => this.GetTargetAudioSource(trackIndex);
        public bool IsAudioTrackEnabled(ushort trackIndex) => _obj.IsAudioTrackEnabled(trackIndex);
        // public void Pause() => _obj.Pause();
        // public void Play() => _obj.Play();
        // public void Prepare() => _obj.Prepare();
        // public void SetDirectAudioMute(ushort trackIndex, bool mute) => _obj.SetDirectAudioMute(trackIndex, mute);
        // public void SetDirectAudioVolume(ushort trackIndex, float volume) => _obj.SetDirectAudioVolume(trackIndex, volume);
        // public void SetTargetAudioSource(ushort trackIndex, AudioSource source) => _obj.SetTargetAudioSource(trackIndex, source);
        // public void StepForward() => _obj.StepForward();
        // public void Stop() => _obj.Stop();

        #endregion
    }

    public static class VideoPlayerExtensions
    {
        public static ReadOnlyVideoPlayer AsReadOnly(this VideoPlayer self) => self.IsTrulyNull() ? null : new ReadOnlyVideoPlayer(self);
    }
}