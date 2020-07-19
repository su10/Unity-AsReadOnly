using System.Collections.Generic;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMaterial : IReadOnlyObject
    {
        Color color { get; }
        bool doubleSidedGI { get; }
        bool enableInstancing { get; }
        MaterialGlobalIlluminationFlags globalIlluminationFlags { get; }
        Texture mainTexture { get; }
        Vector2 mainTextureOffset { get; }
        Vector2 mainTextureScale { get; }
        int passCount { get; }
        int renderQueue { get; }
        IReadOnlyShader shader { get; }
        string[] shaderKeywords { get; }
        // void CopyPropertiesFromMaterial(Material mat);
        // void DisableKeyword(string keyword);
        // void EnableKeyword(string keyword);
        int FindPass(string passName);
        Color GetColor(string name);
        Color GetColor(int nameID);
        Color[] GetColorArray(string name);
        Color[] GetColorArray(int nameID);
        void GetColorArray(string name, List<Color> values);
        void GetColorArray(int nameID, List<Color> values);
        float GetFloat(string name);
        float GetFloat(int nameID);
        float[] GetFloatArray(string name);
        float[] GetFloatArray(int nameID);
        void GetFloatArray(string name, List<float> values);
        void GetFloatArray(int nameID, List<float> values);
        int GetInt(string name);
        int GetInt(int nameID);
        Matrix4x4 GetMatrix(string name);
        Matrix4x4 GetMatrix(int nameID);
        Matrix4x4[] GetMatrixArray(string name);
        Matrix4x4[] GetMatrixArray(int nameID);
        void GetMatrixArray(string name, List<Matrix4x4> values);
        void GetMatrixArray(int nameID, List<Matrix4x4> values);
        string GetPassName(int pass);
        bool GetShaderPassEnabled(string passName);
        string GetTag(string tag, bool searchFallbacks, string defaultValue);
        string GetTag(string tag, bool searchFallbacks);
        Texture GetTexture(string name);
        Texture GetTexture(int nameID);
        Vector2 GetTextureOffset(string name);
        Vector2 GetTextureOffset(int nameID);
        int[] GetTexturePropertyNameIDs();
        void GetTexturePropertyNameIDs(List<int> outNames);
        string[] GetTexturePropertyNames();
        void GetTexturePropertyNames(List<string> outNames);
        Vector2 GetTextureScale(string name);
        Vector2 GetTextureScale(int nameID);
        Vector4 GetVector(string name);
        Vector4 GetVector(int nameID);
        Vector4[] GetVectorArray(string name);
        Vector4[] GetVectorArray(int nameID);
        void GetVectorArray(string name, List<Vector4> values);
        void GetVectorArray(int nameID, List<Vector4> values);
        bool HasProperty(int nameID);
        bool HasProperty(string name);
        bool IsKeywordEnabled(string keyword);
        // void Lerp(Material start, Material end, float t);
        // void SetBuffer(string name, ComputeBuffer value);
        // void SetBuffer(int nameID, ComputeBuffer value);
        // void SetColor(string name, Color value);
        // void SetColor(int nameID, Color value);
        // void SetColorArray(string name, List<Color> values);
        // void SetColorArray(int nameID, List<Color> values);
        // void SetColorArray(string name, Color[] values);
        // void SetColorArray(int nameID, Color[] values);
        // void SetFloat(string name, float value);
        // void SetFloat(int nameID, float value);
        // void SetFloatArray(string name, List<float> values);
        // void SetFloatArray(int nameID, List<float> values);
        // void SetFloatArray(string name, float[] values);
        // void SetFloatArray(int nameID, float[] values);
        // void SetInt(string name, int value);
        // void SetInt(int nameID, int value);
        // void SetMatrix(string name, Matrix4x4 value);
        // void SetMatrix(int nameID, Matrix4x4 value);
        // void SetMatrixArray(string name, List<Matrix4x4> values);
        // void SetMatrixArray(int nameID, List<Matrix4x4> values);
        // void SetMatrixArray(string name, Matrix4x4[] values);
        // void SetMatrixArray(int nameID, Matrix4x4[] values);
        // void SetOverrideTag(string tag, string val);
        // bool SetPass(int pass);
        // void SetShaderPassEnabled(string passName, bool enabled);
        // void SetTexture(string name, Texture value);
        // void SetTexture(int nameID, Texture value);
        // void SetTextureOffset(string name, Vector2 value);
        // void SetTextureOffset(int nameID, Vector2 value);
        // void SetTextureScale(string name, Vector2 value);
        // void SetTextureScale(int nameID, Vector2 value);
        // void SetVector(string name, Vector4 value);
        // void SetVector(int nameID, Vector4 value);
        // void SetVectorArray(string name, List<Vector4> values);
        // void SetVectorArray(int nameID, List<Vector4> values);
        // void SetVectorArray(string name, Vector4[] values);
        // void SetVectorArray(int nameID, Vector4[] values);
    }

    public sealed class ReadOnlyMaterial : ReadOnlyObject<Material>, IReadOnlyMaterial
    {
        public ReadOnlyMaterial(Material obj) : base(obj)
        {
        }

        #region Properties

        public Color color => _obj.color;
        public bool doubleSidedGI => _obj.doubleSidedGI;
        public bool enableInstancing => _obj.enableInstancing;
        public MaterialGlobalIlluminationFlags globalIlluminationFlags => _obj.globalIlluminationFlags;
        public Texture mainTexture => _obj.mainTexture;
        public Vector2 mainTextureOffset => _obj.mainTextureOffset;
        public Vector2 mainTextureScale => _obj.mainTextureScale;
        public int passCount => _obj.passCount;
        public int renderQueue => _obj.renderQueue;
        public IReadOnlyShader shader => (_obj.shader == null) ? null : _obj.shader.AsReadOnly();
        public string[] shaderKeywords => _obj.shaderKeywords;

        #endregion

        #region Public Methods

        // public void CopyPropertiesFromMaterial(Material mat) => _obj.CopyPropertiesFromMaterial(mat);
        // public void DisableKeyword(string keyword) => _obj.DisableKeyword(keyword);
        // public void EnableKeyword(string keyword) => _obj.EnableKeyword(keyword);
        public int FindPass(string passName) => _obj.FindPass(passName);
        public Color GetColor(string name) => _obj.GetColor(name);
        public Color GetColor(int nameID) => _obj.GetColor(nameID);
        public Color[] GetColorArray(string name) => _obj.GetColorArray(name);
        public Color[] GetColorArray(int nameID) => _obj.GetColorArray(nameID);
        public void GetColorArray(string name, List<Color> values) => _obj.GetColorArray(name, values);
        public void GetColorArray(int nameID, List<Color> values) => _obj.GetColorArray(nameID, values);
        public float GetFloat(string name) => _obj.GetFloat(name);
        public float GetFloat(int nameID) => _obj.GetFloat(nameID);
        public float[] GetFloatArray(string name) => _obj.GetFloatArray(name);
        public float[] GetFloatArray(int nameID) => _obj.GetFloatArray(nameID);
        public void GetFloatArray(string name, List<float> values) => _obj.GetFloatArray(name, values);
        public void GetFloatArray(int nameID, List<float> values) => _obj.GetFloatArray(nameID, values);
        public int GetInt(string name) => _obj.GetInt(name);
        public int GetInt(int nameID) => _obj.GetInt(nameID);
        public Matrix4x4 GetMatrix(string name) => _obj.GetMatrix(name);
        public Matrix4x4 GetMatrix(int nameID) => _obj.GetMatrix(nameID);
        public Matrix4x4[] GetMatrixArray(string name) => _obj.GetMatrixArray(name);
        public Matrix4x4[] GetMatrixArray(int nameID) => _obj.GetMatrixArray(nameID);
        public void GetMatrixArray(string name, List<Matrix4x4> values) => _obj.GetMatrixArray(name, values);
        public void GetMatrixArray(int nameID, List<Matrix4x4> values) => _obj.GetMatrixArray(nameID, values);
        public string GetPassName(int pass) => _obj.GetPassName(pass);
        public bool GetShaderPassEnabled(string passName) => _obj.GetShaderPassEnabled(passName);
        public string GetTag(string tag, bool searchFallbacks, string defaultValue) => _obj.GetTag(tag, searchFallbacks, defaultValue);
        public string GetTag(string tag, bool searchFallbacks) => _obj.GetTag(tag, searchFallbacks);
        public Texture GetTexture(string name) => _obj.GetTexture(name);
        public Texture GetTexture(int nameID) => _obj.GetTexture(nameID);
        public Vector2 GetTextureOffset(string name) => _obj.GetTextureOffset(name);
        public Vector2 GetTextureOffset(int nameID) => _obj.GetTextureOffset(nameID);
        public int[] GetTexturePropertyNameIDs() => _obj.GetTexturePropertyNameIDs();
        public void GetTexturePropertyNameIDs(List<int> outNames) => _obj.GetTexturePropertyNameIDs(outNames);
        public string[] GetTexturePropertyNames() => _obj.GetTexturePropertyNames();
        public void GetTexturePropertyNames(List<string> outNames) => _obj.GetTexturePropertyNames(outNames);
        public Vector2 GetTextureScale(string name) => _obj.GetTextureScale(name);
        public Vector2 GetTextureScale(int nameID) => _obj.GetTextureScale(nameID);
        public Vector4 GetVector(string name) => _obj.GetVector(name);
        public Vector4 GetVector(int nameID) => _obj.GetVector(nameID);
        public Vector4[] GetVectorArray(string name) => _obj.GetVectorArray(name);
        public Vector4[] GetVectorArray(int nameID) => _obj.GetVectorArray(nameID);
        public void GetVectorArray(string name, List<Vector4> values) => _obj.GetVectorArray(name, values);
        public void GetVectorArray(int nameID, List<Vector4> values) => _obj.GetVectorArray(nameID, values);
        public bool HasProperty(int nameID) => _obj.HasProperty(nameID);
        public bool HasProperty(string name) => _obj.HasProperty(name);
        public bool IsKeywordEnabled(string keyword) => _obj.IsKeywordEnabled(keyword);
        // public void Lerp(Material start, Material end, float t) => _obj.Lerp(start, end, t);
        // public void SetBuffer(string name, ComputeBuffer value) => _obj.SetBuffer(name, value);
        // public void SetBuffer(int nameID, ComputeBuffer value) => _obj.SetBuffer(nameID, value);
        // public void SetColor(string name, Color value) => _obj.SetColor(name, value);
        // public void SetColor(int nameID, Color value) => _obj.SetColor(nameID, value);
        // public void SetColorArray(string name, List<Color> values) => _obj.SetColorArray(name, values);
        // public void SetColorArray(int nameID, List<Color> values) => _obj.SetColorArray(nameID, values);
        // public void SetColorArray(string name, Color[] values) => _obj.SetColorArray(name, values);
        // public void SetColorArray(int nameID, Color[] values) => _obj.SetColorArray(nameID, values);
        // public void SetFloat(string name, float value) => _obj.SetFloat(name, value);
        // public void SetFloat(int nameID, float value) => _obj.SetFloat(nameID, value);
        // public void SetFloatArray(string name, List<float> values) => _obj.SetFloatArray(name, values);
        // public void SetFloatArray(int nameID, List<float> values) => _obj.SetFloatArray(nameID, values);
        // public void SetFloatArray(string name, float[] values) => _obj.SetFloatArray(name, values);
        // public void SetFloatArray(int nameID, float[] values) => _obj.SetFloatArray(nameID, values);
        // public void SetInt(string name, int value) => _obj.SetInt(name, value);
        // public void SetInt(int nameID, int value) => _obj.SetInt(nameID, value);
        // public void SetMatrix(string name, Matrix4x4 value) => _obj.SetMatrix(name, value);
        // public void SetMatrix(int nameID, Matrix4x4 value) => _obj.SetMatrix(nameID, value);
        // public void SetMatrixArray(string name, List<Matrix4x4> values) => _obj.SetMatrixArray(name, values);
        // public void SetMatrixArray(int nameID, List<Matrix4x4> values) => _obj.SetMatrixArray(nameID, values);
        // public void SetMatrixArray(string name, Matrix4x4[] values) => _obj.SetMatrixArray(name, values);
        // public void SetMatrixArray(int nameID, Matrix4x4[] values) => _obj.SetMatrixArray(nameID, values);
        // public void SetOverrideTag(string tag, string val) => _obj.SetOverrideTag(tag, val);
        // public bool SetPass(int pass) => _obj.SetPass(pass);
        // public void SetShaderPassEnabled(string passName, bool enabled) => _obj.SetShaderPassEnabled(passName, enabled);
        // public void SetTexture(string name, Texture value) => _obj.SetTexture(name, value);
        // public void SetTexture(int nameID, Texture value) => _obj.SetTexture(nameID, value);
        // public void SetTextureOffset(string name, Vector2 value) => _obj.SetTextureOffset(name, value);
        // public void SetTextureOffset(int nameID, Vector2 value) => _obj.SetTextureOffset(nameID, value);
        // public void SetTextureScale(string name, Vector2 value) => _obj.SetTextureScale(name, value);
        // public void SetTextureScale(int nameID, Vector2 value) => _obj.SetTextureScale(nameID, value);
        // public void SetVector(string name, Vector4 value) => _obj.SetVector(name, value);
        // public void SetVector(int nameID, Vector4 value) => _obj.SetVector(nameID, value);
        // public void SetVectorArray(string name, List<Vector4> values) => _obj.SetVectorArray(name, values);
        // public void SetVectorArray(int nameID, List<Vector4> values) => _obj.SetVectorArray(nameID, values);
        // public void SetVectorArray(string name, Vector4[] values) => _obj.SetVectorArray(name, values);
        // public void SetVectorArray(int nameID, Vector4[] values) => _obj.SetVectorArray(nameID, values);

        #endregion
    }

    public static class MaterialExtensions
    {
        public static IReadOnlyMaterial AsReadOnly(this Material self) => new ReadOnlyMaterial(self);
    }
}