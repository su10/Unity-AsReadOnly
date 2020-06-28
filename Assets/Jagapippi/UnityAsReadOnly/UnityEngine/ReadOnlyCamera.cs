﻿using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace Jagapippi.UnityAsReadOnly
{
    public class ReadOnlyCamera : ReadOnlyBehaviour<Camera>
    {
        public ReadOnlyCamera(Camera obj) : base(obj)
        {
        }

        #region Properties

        public RenderTexture activeTexture => _obj.activeTexture;
        public RenderingPath actualRenderingPath => _obj.actualRenderingPath;
        public bool allowDynamicResolution => _obj.allowDynamicResolution;
        public bool allowHDR => _obj.allowHDR;
        public bool allowMSAA => _obj.allowMSAA;
        public bool areVRStereoViewMatricesWithinSingleCullTolerance => _obj.areVRStereoViewMatricesWithinSingleCullTolerance;
        public float aspect => _obj.aspect;
        public Color backgroundColor => _obj.backgroundColor;
        public Matrix4x4 cameraToWorldMatrix => _obj.cameraToWorldMatrix;
        public CameraType cameraType => _obj.cameraType;
        public CameraClearFlags clearFlags => _obj.clearFlags;
        public bool clearStencilAfterLightingPass => _obj.clearStencilAfterLightingPass;
        public int commandBufferCount => _obj.commandBufferCount;
        public int cullingMask => _obj.cullingMask;
        public Matrix4x4 cullingMatrix => _obj.cullingMatrix;
        public float depth => _obj.depth;
        public DepthTextureMode depthTextureMode => _obj.depthTextureMode;
        public int eventMask => _obj.eventMask;
        public float farClipPlane => _obj.farClipPlane;
        public float fieldOfView => _obj.fieldOfView;
        public float focalLength => _obj.focalLength;
        public bool forceIntoRenderTexture => _obj.forceIntoRenderTexture;
        public Camera.GateFitMode gateFit => _obj.gateFit;
        public float[] layerCullDistances => _obj.layerCullDistances;
        public bool layerCullSpherical => _obj.layerCullSpherical;
        public Vector2 lensShift => _obj.lensShift;
        public float nearClipPlane => _obj.nearClipPlane;
        public Matrix4x4 nonJitteredProjectionMatrix => _obj.nonJitteredProjectionMatrix;
        public OpaqueSortMode opaqueSortMode => _obj.opaqueSortMode;
        public bool orthographic => _obj.orthographic;
        public float orthographicSize => _obj.orthographicSize;
        public int pixelHeight => _obj.pixelHeight;
        public Rect pixelRect => _obj.pixelRect;
        public int pixelWidth => _obj.pixelWidth;
        public Matrix4x4 previousViewProjectionMatrix => _obj.previousViewProjectionMatrix;
        public Matrix4x4 projectionMatrix => _obj.projectionMatrix;
        public Rect rect => _obj.rect;
        public RenderingPath renderingPath => _obj.renderingPath;
        public int scaledPixelHeight => _obj.scaledPixelHeight;
        public int scaledPixelWidth => _obj.scaledPixelWidth;
        public Scene scene => _obj.scene;
        public Vector2 sensorSize => _obj.sensorSize;
        public Camera.MonoOrStereoscopicEye stereoActiveEye => _obj.stereoActiveEye;
        public float stereoConvergence => _obj.stereoConvergence;
        public bool stereoEnabled => _obj.stereoEnabled;
        public float stereoSeparation => _obj.stereoSeparation;
        public StereoTargetEyeMask stereoTargetEye => _obj.stereoTargetEye;
        public int targetDisplay => _obj.targetDisplay;
        public RenderTexture targetTexture => _obj.targetTexture;
        public Vector3 transparencySortAxis => _obj.transparencySortAxis;
        public TransparencySortMode transparencySortMode => _obj.transparencySortMode;
        public bool useJitteredProjectionMatrixForTransparentRendering => _obj.useJitteredProjectionMatrixForTransparentRendering;
        public bool useOcclusionCulling => _obj.useOcclusionCulling;
        public bool usePhysicalProperties => _obj.usePhysicalProperties;
        public Vector3 velocity => _obj.velocity;
        public Matrix4x4 worldToCameraMatrix => _obj.worldToCameraMatrix;

        #endregion

        #region Public Methods

        // public void AddCommandBuffer(CameraEvent evt, CommandBuffer buffer) => _obj.AddCommandBuffer(evt, buffer);
        // public void AddCommandBufferAsync(CameraEvent evt, CommandBuffer buffer, ComputeQueueType queueType) => _obj.AddCommandBufferAsync(evt, buffer, queueType);
        public void CalculateFrustumCorners(Rect viewport, float z, Camera.MonoOrStereoscopicEye eye, Vector3[] outCorners) => _obj.CalculateFrustumCorners(viewport, z, eye, outCorners);
        public Matrix4x4 CalculateObliqueMatrix(Vector4 clipPlane) => _obj.CalculateObliqueMatrix(clipPlane);
        // public void CopyFrom(Camera other) => _obj.CopyFrom(other);
        // public void CopyStereoDeviceProjectionMatrixToNonJittered(Camera.StereoscopicEye eye) => _obj.CopyStereoDeviceProjectionMatrixToNonJittered(eye);
        public CommandBuffer[] GetCommandBuffers(CameraEvent evt) => _obj.GetCommandBuffers(evt);
        public Matrix4x4 GetStereoNonJitteredProjectionMatrix(Camera.StereoscopicEye eye) => _obj.GetStereoNonJitteredProjectionMatrix(eye);
        public Matrix4x4 GetStereoProjectionMatrix(Camera.StereoscopicEye eye) => _obj.GetStereoProjectionMatrix(eye);
        public Matrix4x4 GetStereoViewMatrix(Camera.StereoscopicEye eye) => _obj.GetStereoViewMatrix(eye);
        // public void RemoveAllCommandBuffers() => _obj.RemoveAllCommandBuffers();
        // public void RemoveCommandBuffer(CameraEvent evt, CommandBuffer buffer) => _obj.RemoveCommandBuffer(evt, buffer);
        // public void RemoveCommandBuffers(CameraEvent evt) => _obj.RemoveCommandBuffers(evt);
        // public void Render() => _obj.Render();
        // public void RenderDontRestore() => _obj.RenderDontRestore();
        // public bool RenderToCubemap(Cubemap cubemap, int faceMask) => _obj.RenderToCubemap(cubemap, faceMask);
        // public bool RenderToCubemap(Cubemap cubemap) => _obj.RenderToCubemap(cubemap);
        // public bool RenderToCubemap(RenderTexture cubemap, int faceMask) => _obj.RenderToCubemap(cubemap, faceMask);
        // public bool RenderToCubemap(RenderTexture cubemap) => _obj.RenderToCubemap(cubemap);
        // public bool RenderToCubemap(RenderTexture cubemap, int faceMask, Camera.MonoOrStereoscopicEye stereoEye) => _obj.RenderToCubemap(cubemap, faceMask, stereoEye);
        // public void RenderWithShader(Shader shader, string replacementTag) => _obj.RenderWithShader(shader, replacementTag);
        // public void Reset() => _obj.Reset();
        // public void ResetAspect() => _obj.ResetAspect();
        // public void ResetCullingMatrix() => _obj.ResetCullingMatrix();
        // public void ResetProjectionMatrix() => _obj.ResetProjectionMatrix();
        // public void ResetReplacementShader() => _obj.ResetReplacementShader();
        // public void ResetStereoProjectionMatrices() => _obj.ResetStereoProjectionMatrices();
        // public void ResetStereoViewMatrices() => _obj.ResetStereoViewMatrices();
        // public void ResetTransparencySortSettings() => _obj.ResetTransparencySortSettings();
        // public void ResetWorldToCameraMatrix() => _obj.ResetWorldToCameraMatrix();
        public Ray ScreenPointToRay(Vector3 pos, Camera.MonoOrStereoscopicEye eye) => _obj.ScreenPointToRay(pos, eye);
        public Ray ScreenPointToRay(Vector3 pos) => _obj.ScreenPointToRay(pos);
        public Vector3 ScreenToViewportPoint(Vector3 position) => _obj.ScreenToViewportPoint(position);
        public Vector3 ScreenToWorldPoint(Vector3 position, Camera.MonoOrStereoscopicEye eye) => _obj.ScreenToWorldPoint(position, eye);
        public Vector3 ScreenToWorldPoint(Vector3 position) => _obj.ScreenToWorldPoint(position);
        // public void SetReplacementShader(Shader shader, string replacementTag) => _obj.SetReplacementShader(shader, replacementTag);
        // public void SetStereoProjectionMatrix(Camera.StereoscopicEye eye, Matrix4x4 matrix) => _obj.SetStereoProjectionMatrix(eye, matrix);
        // public void SetStereoViewMatrix(Camera.StereoscopicEye eye, Matrix4x4 matrix) => _obj.SetStereoViewMatrix(eye, matrix);
        // public void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depthBuffer) => _obj.SetTargetBuffers(colorBuffer, depthBuffer);
        // public void SetTargetBuffers(RenderBuffer[] colorBuffer, RenderBuffer depthBuffer) => _obj.SetTargetBuffers(colorBuffer, depthBuffer);
        public Ray ViewportPointToRay(Vector3 pos, Camera.MonoOrStereoscopicEye eye) => _obj.ViewportPointToRay(pos, eye);
        public Ray ViewportPointToRay(Vector3 pos) => _obj.ViewportPointToRay(pos);
        public Vector3 ViewportToScreenPoint(Vector3 position) => _obj.ViewportToScreenPoint(position);
        public Vector3 ViewportToWorldPoint(Vector3 position, Camera.MonoOrStereoscopicEye eye) => _obj.ViewportToWorldPoint(position, eye);
        public Vector3 ViewportToWorldPoint(Vector3 position) => _obj.ViewportToWorldPoint(position);
        public Vector3 WorldToScreenPoint(Vector3 position, Camera.MonoOrStereoscopicEye eye) => _obj.WorldToScreenPoint(position, eye);
        public Vector3 WorldToScreenPoint(Vector3 position) => _obj.WorldToScreenPoint(position);
        public Vector3 WorldToViewportPoint(Vector3 position, Camera.MonoOrStereoscopicEye eye) => _obj.WorldToViewportPoint(position, eye);
        public Vector3 WorldToViewportPoint(Vector3 position) => _obj.WorldToViewportPoint(position);

        #endregion
    }

    public static class CameraExtensions
    {
        public static ReadOnlyCamera AsReadOnly(this Camera self) => new ReadOnlyCamera(self);
    }
}