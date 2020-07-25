using System.Collections.Generic;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlySprite
    {
        IReadOnlyTexture2D associatedAlphaSplitTexture { get; }
        Vector4 border { get; }
        Bounds bounds { get; }
        bool packed { get; }
        SpritePackingMode packingMode { get; }
        SpritePackingRotation packingRotation { get; }
        Vector2 pivot { get; }
        float pixelsPerUnit { get; }
        Rect rect { get; }
        IReadOnlyTexture2D texture { get; }
        Rect textureRect { get; }
        Vector2 textureRectOffset { get; }
        ushort[] triangles { get; }
        Vector2[] uv { get; }
        Vector2[] vertices { get; }
        int GetPhysicsShape(int shapeIdx, List<Vector2> physicsShape);
        int GetPhysicsShapeCount();
        int GetPhysicsShapePointCount(int shapeIdx);
        // void OverrideGeometry(Vector2[] vertices, ushort[] triangles);
        // void OverridePhysicsShape(IList<Vector2[]> physicsShapes);
    }

    public sealed class ReadOnlySprite : ReadOnlyObject<Sprite>, IReadOnlySprite
    {
        public ReadOnlySprite(Sprite obj) : base(obj)
        {
        }

        #region Properties

        public ReadOnlyTexture2D associatedAlphaSplitTexture => _obj.associatedAlphaSplitTexture.AsReadOnly();
        IReadOnlyTexture2D IReadOnlySprite.associatedAlphaSplitTexture => this.associatedAlphaSplitTexture;
        public Vector4 border => _obj.border;
        public Bounds bounds => _obj.bounds;
        public bool packed => _obj.packed;
        public SpritePackingMode packingMode => _obj.packingMode;
        public SpritePackingRotation packingRotation => _obj.packingRotation;
        public Vector2 pivot => _obj.pivot;
        public float pixelsPerUnit => _obj.pixelsPerUnit;
        public Rect rect => _obj.rect;
        public ReadOnlyTexture2D texture => _obj.texture.AsReadOnly();
        IReadOnlyTexture2D IReadOnlySprite.texture => this.texture;
        public Rect textureRect => _obj.textureRect;
        public Vector2 textureRectOffset => _obj.textureRectOffset;
        public ushort[] triangles => _obj.triangles;
        public Vector2[] uv => _obj.uv;
        public Vector2[] vertices => _obj.vertices;

        #endregion

        #region Public Methods

        public int GetPhysicsShape(int shapeIdx, List<Vector2> physicsShape) => _obj.GetPhysicsShape(shapeIdx, physicsShape);
        public int GetPhysicsShapeCount() => _obj.GetPhysicsShapeCount();
        public int GetPhysicsShapePointCount(int shapeIdx) => _obj.GetPhysicsShapePointCount(shapeIdx);
        // public void OverrideGeometry(Vector2[] vertices, ushort[] triangles) => _obj.OverrideGeometry(vertices, triangles);
        // public void OverridePhysicsShape(IList<Vector2[]> physicsShapes) => _obj.OverridePhysicsShape(physicsShapes);

        #endregion
    }

    public static class SpriteExtensions
    {
        public static ReadOnlySprite AsReadOnly(this Sprite self) => self.IsTrulyNull() ? null : new ReadOnlySprite(self);
    }
}