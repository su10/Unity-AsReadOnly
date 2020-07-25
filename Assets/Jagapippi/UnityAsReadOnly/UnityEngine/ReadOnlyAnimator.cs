using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyAnimator
    {
        Vector3 angularVelocity { get; }
        bool applyRootMotion { get; }
        Avatar avatar { get; }
        Vector3 bodyPosition { get; }
        Quaternion bodyRotation { get; }
        AnimatorCullingMode cullingMode { get; }
        Vector3 deltaPosition { get; }
        Quaternion deltaRotation { get; }
        float feetPivotActive { get; }
        bool fireEvents { get; }
        float gravityWeight { get; }
        bool hasBoundPlayables { get; }
        bool hasRootMotion { get; }
        bool hasTransformHierarchy { get; }
        float humanScale { get; }
        bool isHuman { get; }
        bool isInitialized { get; }
        bool isMatchingTarget { get; }
        bool isOptimizable { get; }
        bool keepAnimatorControllerStateOnDisable { get; }
        int layerCount { get; }
        bool layersAffectMassCenter { get; }
        float leftFeetBottomHeight { get; }
        bool logWarnings { get; }
        int parameterCount { get; }
        AnimatorControllerParameter[] parameters { get; }
        Vector3 pivotPosition { get; }
        float pivotWeight { get; }
        PlayableGraph playableGraph { get; }
        float playbackTime { get; }
        AnimatorRecorderMode recorderMode { get; }
        float recorderStartTime { get; }
        float recorderStopTime { get; }
        float rightFeetBottomHeight { get; }
        Vector3 rootPosition { get; }
        Quaternion rootRotation { get; }
        IReadOnlyRuntimeAnimatorController runtimeAnimatorController { get; }
        float speed { get; }
        bool stabilizeFeet { get; }
        Vector3 targetPosition { get; }
        Quaternion targetRotation { get; }
        AnimatorUpdateMode updateMode { get; }
        Vector3 velocity { get; }
        // void ApplyBuiltinRootMotion();
        // void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset);
        // void CrossFade(string stateName, float normalizedTransitionDuration, int layer);
        // void CrossFade(string stateName, float normalizedTransitionDuration);
        // void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset, float normalizedTransitionTime);
        // void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset, float normalizedTransitionTime);
        // void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset);
        // void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer);
        // void CrossFade(int stateHashName, float normalizedTransitionDuration);
        // void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration);
        // void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer);
        // void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset);
        // void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset, float normalizedTransitionTime);
        // void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset);
        // void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer);
        // void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration);
        // void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset, float normalizedTransitionTime);
        AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex);
        // T GetBehaviour<T>() where T : StateMachineBehaviour;
        // T[] GetBehaviours<T>() where T : StateMachineBehaviour;
        // StateMachineBehaviour[] GetBehaviours(int fullPathHash, int layerIndex);
        IReadOnlyTransform GetBoneTransform(HumanBodyBones humanBoneId);
        bool GetBool(string name);
        bool GetBool(int id);
        ReadOnlyAnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex);
        void GetCurrentAnimatorClipInfo(int layerIndex, List<ReadOnlyAnimatorClipInfo> clips);
        int GetCurrentAnimatorClipInfoCount(int layerIndex);
        AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex);
        float GetFloat(string name);
        float GetFloat(int id);
        Vector3 GetIKHintPosition(AvatarIKHint hint);
        float GetIKHintPositionWeight(AvatarIKHint hint);
        Vector3 GetIKPosition(AvatarIKGoal goal);
        float GetIKPositionWeight(AvatarIKGoal goal);
        Quaternion GetIKRotation(AvatarIKGoal goal);
        float GetIKRotationWeight(AvatarIKGoal goal);
        int GetInteger(string name);
        int GetInteger(int id);
        int GetLayerIndex(string layerName);
        string GetLayerName(int layerIndex);
        float GetLayerWeight(int layerIndex);
        ReadOnlyAnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex);
        void GetNextAnimatorClipInfo(int layerIndex, List<ReadOnlyAnimatorClipInfo> clips);
        int GetNextAnimatorClipInfoCount(int layerIndex);
        AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex);
        AnimatorControllerParameter GetParameter(int index);
        bool HasState(int layerIndex, int stateID);
        // void InterruptMatchTarget();
        // void InterruptMatchTarget(bool completeMatch);
        bool IsInTransition(int layerIndex);
        bool IsParameterControlledByCurve(string name);
        bool IsParameterControlledByCurve(int id);
        // void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime);
        // void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime);
        // void Play(string stateName, int layer);
        // void Play(string stateName);
        // void Play(string stateName, int layer, float normalizedTime);
        // void Play(int stateNameHash, int layer, float normalizedTime);
        // void Play(int stateNameHash, int layer);
        // void Play(int stateNameHash);
        // void PlayInFixedTime(string stateName, int layer);
        // void PlayInFixedTime(string stateName);
        // void PlayInFixedTime(string stateName, int layer, float fixedTime);
        // void PlayInFixedTime(int stateNameHash, int layer, float fixedTime);
        // void PlayInFixedTime(int stateNameHash, int layer);
        // void PlayInFixedTime(int stateNameHash);
        // void Rebind();
        // void ResetTrigger(string name);
        // void ResetTrigger(int id);
        // void SetBoneLocalRotation(HumanBodyBones humanBoneId, Quaternion rotation);
        // void SetBool(string name, bool value);
        // void SetBool(int id, bool value);
        // void SetFloat(string name, float value);
        // void SetFloat(string name, float value, float dampTime, float deltaTime);
        // void SetFloat(int id, float value);
        // void SetFloat(int id, float value, float dampTime, float deltaTime);
        // void SetIKHintPosition(AvatarIKHint hint, Vector3 hintPosition);
        // void SetIKHintPositionWeight(AvatarIKHint hint, float value);
        // void SetIKPosition(AvatarIKGoal goal, Vector3 goalPosition);
        // void SetIKPositionWeight(AvatarIKGoal goal, float value);
        // void SetIKRotation(AvatarIKGoal goal, Quaternion goalRotation);
        // void SetIKRotationWeight(AvatarIKGoal goal, float value);
        // void SetInteger(string name, int value);
        // void SetInteger(int id, int value);
        // void SetLayerWeight(int layerIndex, float weight);
        // void SetLookAtPosition(Vector3 lookAtPosition);
        // void SetLookAtWeight(float weight);
        // void SetLookAtWeight(float weight, float bodyWeight);
        // void SetLookAtWeight(float weight, float bodyWeight, float headWeight);
        // void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight);
        // void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight);
        // void SetTarget(AvatarTarget targetIndex, float targetNormalizedTime);
        // void SetTrigger(string name);
        // void SetTrigger(int id);
        // void StartPlayback();
        // void StartRecording(int frameCount);
        // void StopPlayback();
        // void StopRecording();
        // void Update(float deltaTime);
        // void WriteDefaultValues();
    }

    public class ReadOnlyAnimator<T> : ReadOnlyBehaviour<T>, IReadOnlyAnimator where T : Animator
    {
        protected ReadOnlyAnimator(T obj) : base(obj)
        {
        }

        #region Properties

        public Vector3 angularVelocity => _obj.angularVelocity;
        public bool applyRootMotion => _obj.applyRootMotion;
        public Avatar avatar => _obj.avatar;
        public Vector3 bodyPosition => _obj.bodyPosition;
        public Quaternion bodyRotation => _obj.bodyRotation;
        public AnimatorCullingMode cullingMode => _obj.cullingMode;
        public Vector3 deltaPosition => _obj.deltaPosition;
        public Quaternion deltaRotation => _obj.deltaRotation;
        public float feetPivotActive => _obj.feetPivotActive;
        public bool fireEvents => _obj.fireEvents;
        public float gravityWeight => _obj.gravityWeight;
        public bool hasBoundPlayables => _obj.hasBoundPlayables;
        public bool hasRootMotion => _obj.hasRootMotion;
        public bool hasTransformHierarchy => _obj.hasTransformHierarchy;
        public float humanScale => _obj.humanScale;
        public bool isHuman => _obj.isHuman;
        public bool isInitialized => _obj.isInitialized;
        public bool isMatchingTarget => _obj.isMatchingTarget;
        public bool isOptimizable => _obj.isOptimizable;
        public bool keepAnimatorControllerStateOnDisable => _obj.keepAnimatorControllerStateOnDisable;
        public int layerCount => _obj.layerCount;
        public bool layersAffectMassCenter => _obj.layersAffectMassCenter;
        public float leftFeetBottomHeight => _obj.leftFeetBottomHeight;
        public bool logWarnings => _obj.logWarnings;
        public int parameterCount => _obj.parameterCount;
        public AnimatorControllerParameter[] parameters => _obj.parameters;
        public Vector3 pivotPosition => _obj.pivotPosition;
        public float pivotWeight => _obj.pivotWeight;
        public PlayableGraph playableGraph => _obj.playableGraph;
        public float playbackTime => _obj.playbackTime;
        public AnimatorRecorderMode recorderMode => _obj.recorderMode;
        public float recorderStartTime => _obj.recorderStartTime;
        public float recorderStopTime => _obj.recorderStopTime;
        public float rightFeetBottomHeight => _obj.rightFeetBottomHeight;
        public Vector3 rootPosition => _obj.rootPosition;
        public Quaternion rootRotation => _obj.rootRotation;
        public ReadOnlyRuntimeAnimatorController runtimeAnimatorController => _obj.runtimeAnimatorController.AsReadOnly();
        IReadOnlyRuntimeAnimatorController IReadOnlyAnimator.runtimeAnimatorController => this.runtimeAnimatorController;
        public float speed => _obj.speed;
        public bool stabilizeFeet => _obj.stabilizeFeet;
        public Vector3 targetPosition => _obj.targetPosition;
        public Quaternion targetRotation => _obj.targetRotation;
        public AnimatorUpdateMode updateMode => _obj.updateMode;
        public Vector3 velocity => _obj.velocity;

        #endregion

        #region Public Methods

        // public void ApplyBuiltinRootMotion() => _obj.ApplyBuiltinRootMotion();
        // public void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset) => _obj.CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset);
        // public void CrossFade(string stateName, float normalizedTransitionDuration, int layer) => _obj.CrossFade(stateName, normalizedTransitionDuration, layer);
        // public void CrossFade(string stateName, float normalizedTransitionDuration) => _obj.CrossFade(stateName, normalizedTransitionDuration);
        // public void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset, float normalizedTransitionTime) => _obj.CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
        // public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset, float normalizedTransitionTime) => _obj.CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
        // public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset) => _obj.CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset);
        // public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer) => _obj.CrossFade(stateHashName, normalizedTransitionDuration, layer);
        // public void CrossFade(int stateHashName, float normalizedTransitionDuration) => _obj.CrossFade(stateHashName, normalizedTransitionDuration);
        // public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration) => _obj.CrossFadeInFixedTime(stateName, fixedTransitionDuration);
        // public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer) => _obj.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer);
        // public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset) => _obj.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer, fixedTimeOffset);
        // public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset, float normalizedTransitionTime) => _obj.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
        // public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset) => _obj.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset);
        // public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer) => _obj.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer);
        // public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration) => _obj.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration);
        // public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset, float normalizedTransitionTime) => _obj.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
        public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex) => _obj.GetAnimatorTransitionInfo(layerIndex);
        // public T GetBehaviour<T>() where T : StateMachineBehaviour => _obj.GetBehaviour<T>();
        // public T[] GetBehaviours<T>() where T : StateMachineBehaviour => _obj.GetBehaviours<T>();
        // public StateMachineBehaviour[] GetBehaviours(int fullPathHash, int layerIndex) => _obj.GetBehaviours(fullPathHash, layerIndex);
        public ReadOnlyTransform GetBoneTransform(HumanBodyBones humanBoneId) => _obj.GetBoneTransform(humanBoneId).AsReadOnly();
        IReadOnlyTransform IReadOnlyAnimator.GetBoneTransform(HumanBodyBones humanBoneId) => this.GetBoneTransform(humanBoneId);
        public bool GetBool(string name) => _obj.GetBool(name);
        public bool GetBool(int id) => _obj.GetBool(id);
        public ReadOnlyAnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex) => _obj.GetCurrentAnimatorClipInfo(layerIndex).Select(c => c.AsReadOnly()).ToArray();

        public void GetCurrentAnimatorClipInfo(int layerIndex, List<ReadOnlyAnimatorClipInfo> clips)
        {
            var list = new List<AnimatorClipInfo>();
            _obj.GetCurrentAnimatorClipInfo(layerIndex, list);
            clips.AddRange(list.Select(clip => clip.AsReadOnly()));
        }

        public int GetCurrentAnimatorClipInfoCount(int layerIndex) => _obj.GetCurrentAnimatorClipInfoCount(layerIndex);
        public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex) => _obj.GetCurrentAnimatorStateInfo(layerIndex);
        public float GetFloat(string name) => _obj.GetFloat(name);
        public float GetFloat(int id) => _obj.GetFloat(id);
        public Vector3 GetIKHintPosition(AvatarIKHint hint) => _obj.GetIKHintPosition(hint);
        public float GetIKHintPositionWeight(AvatarIKHint hint) => _obj.GetIKHintPositionWeight(hint);
        public Vector3 GetIKPosition(AvatarIKGoal goal) => _obj.GetIKPosition(goal);
        public float GetIKPositionWeight(AvatarIKGoal goal) => _obj.GetIKPositionWeight(goal);
        public Quaternion GetIKRotation(AvatarIKGoal goal) => _obj.GetIKRotation(goal);
        public float GetIKRotationWeight(AvatarIKGoal goal) => _obj.GetIKRotationWeight(goal);
        public int GetInteger(string name) => _obj.GetInteger(name);
        public int GetInteger(int id) => _obj.GetInteger(id);
        public int GetLayerIndex(string layerName) => _obj.GetLayerIndex(layerName);
        public string GetLayerName(int layerIndex) => _obj.GetLayerName(layerIndex);
        public float GetLayerWeight(int layerIndex) => _obj.GetLayerWeight(layerIndex);
        public ReadOnlyAnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex) => _obj.GetNextAnimatorClipInfo(layerIndex).Select(c => c.AsReadOnly()).ToArray();

        public void GetNextAnimatorClipInfo(int layerIndex, List<ReadOnlyAnimatorClipInfo> clips)
        {
            var list = new List<AnimatorClipInfo>();
            _obj.GetNextAnimatorClipInfo(layerIndex, list);
            clips.AddRange(list.Select(clip => clip.AsReadOnly()));
        }

        public int GetNextAnimatorClipInfoCount(int layerIndex) => _obj.GetNextAnimatorClipInfoCount(layerIndex);
        public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex) => _obj.GetNextAnimatorStateInfo(layerIndex);
        public AnimatorControllerParameter GetParameter(int index) => _obj.GetParameter(index);
        public bool HasState(int layerIndex, int stateID) => _obj.HasState(layerIndex, stateID);
        // public void InterruptMatchTarget() => _obj.InterruptMatchTarget();
        // public void InterruptMatchTarget(bool completeMatch) => _obj.InterruptMatchTarget(completeMatch);
        public bool IsInTransition(int layerIndex) => _obj.IsInTransition(layerIndex);
        public bool IsParameterControlledByCurve(string name) => _obj.IsParameterControlledByCurve(name);
        public bool IsParameterControlledByCurve(int id) => _obj.IsParameterControlledByCurve(id);
        // public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime) => _obj.MatchTarget(matchPosition, matchRotation, targetBodyPart, weightMask, startNormalizedTime);
        // public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime) => _obj.MatchTarget(matchPosition, matchRotation, targetBodyPart, weightMask, startNormalizedTime, targetNormalizedTime);
        // public void Play(string stateName, int layer) => _obj.Play(stateName, layer);
        // public void Play(string stateName) => _obj.Play(stateName);
        // public void Play(string stateName, int layer, float normalizedTime) => _obj.Play(stateName, layer, normalizedTime);
        // public void Play(int stateNameHash, int layer, float normalizedTime) => _obj.Play(stateNameHash, layer, normalizedTime);
        // public void Play(int stateNameHash, int layer) => _obj.Play(stateNameHash, layer);
        // public void Play(int stateNameHash) => _obj.Play(stateNameHash);
        // public void PlayInFixedTime(string stateName, int layer) => _obj.PlayInFixedTime(stateName, layer);
        // public void PlayInFixedTime(string stateName) => _obj.PlayInFixedTime(stateName);
        // public void PlayInFixedTime(string stateName, int layer, float fixedTime) => _obj.PlayInFixedTime(stateName, layer, fixedTime);
        // public void PlayInFixedTime(int stateNameHash, int layer, float fixedTime) => _obj.PlayInFixedTime(stateNameHash, layer, fixedTime);
        // public void PlayInFixedTime(int stateNameHash, int layer) => _obj.PlayInFixedTime(stateNameHash, layer);
        // public void PlayInFixedTime(int stateNameHash) => _obj.PlayInFixedTime(stateNameHash);
        // public void Rebind() => _obj.Rebind();
        // public void ResetTrigger(string name) => _obj.ResetTrigger(name);
        // public void ResetTrigger(int id) => _obj.ResetTrigger(id);
        // public void SetBoneLocalRotation(HumanBodyBones humanBoneId, Quaternion rotation) => _obj.SetBoneLocalRotation(humanBoneId, rotation);
        // public void SetBool(string name, bool value) => _obj.SetBool(name, value);
        // public void SetBool(int id, bool value) => _obj.SetBool(id, value);
        // public void SetFloat(string name, float value) => _obj.SetFloat(name, value);
        // public void SetFloat(string name, float value, float dampTime, float deltaTime) => _obj.SetFloat(name, value, dampTime, deltaTime);
        // public void SetFloat(int id, float value) => _obj.SetFloat(id, value);
        // public void SetFloat(int id, float value, float dampTime, float deltaTime) => _obj.SetFloat(id, value, dampTime, deltaTime);
        // public void SetIKHintPosition(AvatarIKHint hint, Vector3 hintPosition) => _obj.SetIKHintPosition(hint, hintPosition);
        // public void SetIKHintPositionWeight(AvatarIKHint hint, float value) => _obj.SetIKHintPositionWeight(hint, value);
        // public void SetIKPosition(AvatarIKGoal goal, Vector3 goalPosition) => _obj.SetIKPosition(goal, goalPosition);
        // public void SetIKPositionWeight(AvatarIKGoal goal, float value) => _obj.SetIKPositionWeight(goal, value);
        // public void SetIKRotation(AvatarIKGoal goal, Quaternion goalRotation) => _obj.SetIKRotation(goal, goalRotation);
        // public void SetIKRotationWeight(AvatarIKGoal goal, float value) => _obj.SetIKRotationWeight(goal, value);
        // public void SetInteger(string name, int value) => _obj.SetInteger(name, value);
        // public void SetInteger(int id, int value) => _obj.SetInteger(id, value);
        // public void SetLayerWeight(int layerIndex, float weight) => _obj.SetLayerWeight(layerIndex, weight);
        // public void SetLookAtPosition(Vector3 lookAtPosition) => _obj.SetLookAtPosition(lookAtPosition);
        // public void SetLookAtWeight(float weight) => _obj.SetLookAtWeight(weight);
        // public void SetLookAtWeight(float weight, float bodyWeight) => _obj.SetLookAtWeight(weight, bodyWeight);
        // public void SetLookAtWeight(float weight, float bodyWeight, float headWeight) => _obj.SetLookAtWeight(weight, bodyWeight, headWeight);
        // public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight) => _obj.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight);
        // public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight) => _obj.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
        // public void SetTarget(AvatarTarget targetIndex, float targetNormalizedTime) => _obj.SetTarget(targetIndex, targetNormalizedTime);
        // public void SetTrigger(string name) => _obj.SetTrigger(name);
        // public void SetTrigger(int id) => _obj.SetTrigger(id);
        // public void StartPlayback() => _obj.StartPlayback();
        // public void StartRecording(int frameCount) => _obj.StartRecording(frameCount);
        // public void StopPlayback() => _obj.StopPlayback();
        // public void StopRecording() => _obj.StopRecording();
        // public void Update(float deltaTime) => _obj.Update(deltaTime);
        // public void WriteDefaultValues() => _obj.WriteDefaultValues();

        #endregion
    }

    public sealed class ReadOnlyAnimator : ReadOnlyAnimator<Animator>
    {
        public ReadOnlyAnimator(Animator obj) : base(obj)
        {
        }
    }

    public static class AnimatorExtensions
    {
        public static ReadOnlyAnimator AsReadOnly(this Animator self) => self.IsTrulyNull() ? null : new ReadOnlyAnimator(self);
    }
}