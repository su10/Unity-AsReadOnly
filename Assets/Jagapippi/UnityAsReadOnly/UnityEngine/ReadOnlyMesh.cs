using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyMesh
    {
        Matrix4x4[] bindposes { get; }
        int blendShapeCount { get; }
        BoneWeight[] boneWeights { get; }
        Bounds bounds { get; }
        Color[] colors { get; }
        Color32[] colors32 { get; }
        IndexFormat indexFormat { get; }
        bool isReadable { get; }
        Vector3[] normals { get; }
        int subMeshCount { get; }
        Vector4[] tangents { get; }
        int[] triangles { get; }
        Vector2[] uv { get; }
        Vector2[] uv2 { get; }
        Vector2[] uv3 { get; }
        Vector2[] uv4 { get; }
        Vector2[] uv5 { get; }
        Vector2[] uv6 { get; }
        Vector2[] uv7 { get; }
        Vector2[] uv8 { get; }
        int vertexBufferCount { get; }
        int vertexCount { get; }
        Vector3[] vertices { get; }
        // void AddBlendShapeFrame(string shapeName, float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents);
        // void Clear(bool keepVertexLayout);
        // void Clear();
        // void ClearBlendShapes();
        void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices, bool hasLightmapData);
        void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices);
        void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes);
        void CombineMeshes(CombineInstance[] combine);
        uint GetBaseVertex(int submesh);
        void GetBindposes(List<Matrix4x4> bindposes);
        int GetBlendShapeFrameCount(int shapeIndex);
        void GetBlendShapeFrameVertices(int shapeIndex, int frameIndex, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents);
        float GetBlendShapeFrameWeight(int shapeIndex, int frameIndex);
        int GetBlendShapeIndex(string blendShapeName);
        string GetBlendShapeName(int shapeIndex);
        void GetBoneWeights(List<BoneWeight> boneWeights);
        void GetColors(List<Color> colors);
        void GetColors(List<Color32> colors);
        uint GetIndexCount(int submesh);
        uint GetIndexStart(int submesh);
        int[] GetIndices(int submesh);
        int[] GetIndices(int submesh, bool applyBaseVertex);
        void GetIndices(List<int> indices, int submesh);
        void GetIndices(List<int> indices, int submesh, bool applyBaseVertex);
        IntPtr GetNativeIndexBufferPtr();
        IntPtr GetNativeVertexBufferPtr(int index);
        void GetNormals(List<Vector3> normals);
        void GetTangents(List<Vector4> tangents);
        MeshTopology GetTopology(int submesh);
        int[] GetTriangles(int submesh);
        int[] GetTriangles(int submesh, bool applyBaseVertex);
        void GetTriangles(List<int> triangles, int submesh);
        void GetTriangles(List<int> triangles, int submesh, bool applyBaseVertex);
        float GetUVDistributionMetric(int uvSetIndex);
        void GetUVs(int channel, List<Vector2> uvs);
        void GetUVs(int channel, List<Vector3> uvs);
        void GetUVs(int channel, List<Vector4> uvs);
        void GetVertices(List<Vector3> vertices);
        // void MarkDynamic();
        // void RecalculateBounds();
        // void RecalculateNormals();
        // void RecalculateTangents();
        // void SetColors(List<Color> inColors);
        // void SetColors(List<Color32> inColors);
        // void SetIndices(int[] indices, MeshTopology topology, int submesh);
        // void SetIndices(int[] indices, MeshTopology topology, int submesh, bool calculateBounds);
        // void SetIndices(int[] indices, MeshTopology topology, int submesh, bool calculateBounds, int baseVertex);
        // void SetNormals(List<Vector3> inNormals);
        // void SetTangents(List<Vector4> inTangents);
        // void SetTriangles(int[] triangles, int submesh);
        // void SetTriangles(int[] triangles, int submesh, bool calculateBounds);
        // void SetTriangles(int[] triangles, int submesh, bool calculateBounds, int baseVertex);
        // void SetTriangles(List<int> triangles, int submesh);
        // void SetTriangles(List<int> triangles, int submesh, bool calculateBounds);
        // void SetTriangles(List<int> triangles, int submesh, bool calculateBounds, int baseVertex);
        // void SetUVs(int channel, List<Vector2> uvs);
        // void SetUVs(int channel, List<Vector3> uvs);
        // void SetUVs(int channel, List<Vector4> uvs);
        // void SetVertices(List<Vector3> inVertices);
        // void UploadMeshData(bool markNoLongerReadable);
    }

    public sealed class ReadOnlyMesh : ReadOnlyObject<Mesh>, IReadOnlyMesh
    {
        public ReadOnlyMesh(Mesh obj) : base(obj)
        {
        }

        #region Properties

        public Matrix4x4[] bindposes => _obj.bindposes;
        public int blendShapeCount => _obj.blendShapeCount;
        public BoneWeight[] boneWeights => _obj.boneWeights;
        public Bounds bounds => _obj.bounds;
        public Color[] colors => _obj.colors;
        public Color32[] colors32 => _obj.colors32;
        public IndexFormat indexFormat => _obj.indexFormat;
        public bool isReadable => _obj.isReadable;
        public Vector3[] normals => _obj.normals;
        public int subMeshCount => _obj.subMeshCount;
        public Vector4[] tangents => _obj.tangents;
        public int[] triangles => _obj.triangles;
        public Vector2[] uv => _obj.uv;
        public Vector2[] uv2 => _obj.uv2;
        public Vector2[] uv3 => _obj.uv3;
        public Vector2[] uv4 => _obj.uv4;
        public Vector2[] uv5 => _obj.uv5;
        public Vector2[] uv6 => _obj.uv6;
        public Vector2[] uv7 => _obj.uv7;
        public Vector2[] uv8 => _obj.uv8;
        public int vertexBufferCount => _obj.vertexBufferCount;
        public int vertexCount => _obj.vertexCount;
        public Vector3[] vertices => _obj.vertices;

        #endregion

        #region Public Methods

        // public void AddBlendShapeFrame(string shapeName, float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents) => _obj.AddBlendShapeFrame(shapeName, frameWeight, deltaVertices, deltaNormals, deltaTangents);
        // public void Clear(bool keepVertexLayout) => _obj.Clear(keepVertexLayout);
        // public void Clear() => _obj.Clear();
        // public void ClearBlendShapes() => _obj.ClearBlendShapes();
        public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices, bool hasLightmapData) => _obj.CombineMeshes(combine, mergeSubMeshes, useMatrices, hasLightmapData);
        public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices) => _obj.CombineMeshes(combine, mergeSubMeshes, useMatrices);
        public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes) => _obj.CombineMeshes(combine, mergeSubMeshes);
        public void CombineMeshes(CombineInstance[] combine) => _obj.CombineMeshes(combine);
        public uint GetBaseVertex(int submesh) => _obj.GetBaseVertex(submesh);
        public void GetBindposes(List<Matrix4x4> bindposes) => _obj.GetBindposes(bindposes);
        public int GetBlendShapeFrameCount(int shapeIndex) => _obj.GetBlendShapeFrameCount(shapeIndex);
        public void GetBlendShapeFrameVertices(int shapeIndex, int frameIndex, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents) => _obj.GetBlendShapeFrameVertices(shapeIndex, frameIndex, deltaVertices, deltaNormals, deltaTangents);
        public float GetBlendShapeFrameWeight(int shapeIndex, int frameIndex) => _obj.GetBlendShapeFrameWeight(shapeIndex, frameIndex);
        public int GetBlendShapeIndex(string blendShapeName) => _obj.GetBlendShapeIndex(blendShapeName);
        public string GetBlendShapeName(int shapeIndex) => _obj.GetBlendShapeName(shapeIndex);
        public void GetBoneWeights(List<BoneWeight> boneWeights) => _obj.GetBoneWeights(boneWeights);
        public void GetColors(List<Color> colors) => _obj.GetColors(colors);
        public void GetColors(List<Color32> colors) => _obj.GetColors(colors);
        public uint GetIndexCount(int submesh) => _obj.GetIndexCount(submesh);
        public uint GetIndexStart(int submesh) => _obj.GetIndexStart(submesh);
        public int[] GetIndices(int submesh) => _obj.GetIndices(submesh);
        public int[] GetIndices(int submesh, bool applyBaseVertex) => _obj.GetIndices(submesh, applyBaseVertex);
        public void GetIndices(List<int> indices, int submesh) => _obj.GetIndices(indices, submesh);
        public void GetIndices(List<int> indices, int submesh, bool applyBaseVertex) => _obj.GetIndices(indices, submesh, applyBaseVertex);
        public IntPtr GetNativeIndexBufferPtr() => _obj.GetNativeIndexBufferPtr();
        public IntPtr GetNativeVertexBufferPtr(int index) => _obj.GetNativeVertexBufferPtr(index);
        public void GetNormals(List<Vector3> normals) => _obj.GetNormals(normals);
        public void GetTangents(List<Vector4> tangents) => _obj.GetTangents(tangents);
        public MeshTopology GetTopology(int submesh) => _obj.GetTopology(submesh);
        public int[] GetTriangles(int submesh) => _obj.GetTriangles(submesh);
        public int[] GetTriangles(int submesh, bool applyBaseVertex) => _obj.GetTriangles(submesh, applyBaseVertex);
        public void GetTriangles(List<int> triangles, int submesh) => _obj.GetTriangles(triangles, submesh);
        public void GetTriangles(List<int> triangles, int submesh, bool applyBaseVertex) => _obj.GetTriangles(triangles, submesh, applyBaseVertex);
        public float GetUVDistributionMetric(int uvSetIndex) => _obj.GetUVDistributionMetric(uvSetIndex);
        public void GetUVs(int channel, List<Vector2> uvs) => _obj.GetUVs(channel, uvs);
        public void GetUVs(int channel, List<Vector3> uvs) => _obj.GetUVs(channel, uvs);
        public void GetUVs(int channel, List<Vector4> uvs) => _obj.GetUVs(channel, uvs);
        public void GetVertices(List<Vector3> vertices) => _obj.GetVertices(vertices);
        // public void MarkDynamic() => _obj.MarkDynamic();
        // public void RecalculateBounds() => _obj.RecalculateBounds();
        // public void RecalculateNormals() => _obj.RecalculateNormals();
        // public void RecalculateTangents() => _obj.RecalculateTangents();
        // public void SetColors(List<Color> inColors) => _obj.SetColors(inColors);
        // public void SetColors(List<Color32> inColors) => _obj.SetColors(inColors);
        // public void SetIndices(int[] indices, MeshTopology topology, int submesh) => _obj.SetIndices(indices, topology, submesh);
        // public void SetIndices(int[] indices, MeshTopology topology, int submesh, bool calculateBounds) => _obj.SetIndices(indices, topology, submesh, calculateBounds);
        // public void SetIndices(int[] indices, MeshTopology topology, int submesh, bool calculateBounds, int baseVertex) => _obj.SetIndices(indices, topology, submesh, calculateBounds, baseVertex);
        // public void SetNormals(List<Vector3> inNormals) => _obj.SetNormals(inNormals);
        // public void SetTangents(List<Vector4> inTangents) => _obj.SetTangents(inTangents);
        // public void SetTriangles(int[] triangles, int submesh) => _obj.SetTriangles(triangles, submesh);
        // public void SetTriangles(int[] triangles, int submesh, bool calculateBounds) => _obj.SetTriangles(triangles, submesh, calculateBounds);
        // public void SetTriangles(int[] triangles, int submesh, bool calculateBounds, int baseVertex) => _obj.SetTriangles(triangles, submesh, calculateBounds, baseVertex);
        // public void SetTriangles(List<int> triangles, int submesh) => _obj.SetTriangles(triangles, submesh);
        // public void SetTriangles(List<int> triangles, int submesh, bool calculateBounds) => _obj.SetTriangles(triangles, submesh, calculateBounds);
        // public void SetTriangles(List<int> triangles, int submesh, bool calculateBounds, int baseVertex) => _obj.SetTriangles(triangles, submesh, calculateBounds, baseVertex);
        // public void SetUVs(int channel, List<Vector2> uvs) => _obj.SetUVs(channel, uvs);
        // public void SetUVs(int channel, List<Vector3> uvs) => _obj.SetUVs(channel, uvs);
        // public void SetUVs(int channel, List<Vector4> uvs) => _obj.SetUVs(channel, uvs);
        // public void SetVertices(List<Vector3> inVertices) => _obj.SetVertices(inVertices);
        // public void UploadMeshData(bool markNoLongerReadable) => _obj.UploadMeshData(markNoLongerReadable);

        #endregion
    }

    public static class MeshExtensions
    {
        public static ReadOnlyMesh AsReadOnly(this Mesh self) => self.IsTrulyNull() ? null : new ReadOnlyMesh(self);
    }
}