using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyGridLayout
    {
        Vector3 cellGap { get; }
        GridLayout.CellLayout cellLayout { get; }
        Vector3 cellSize { get; }
        GridLayout.CellSwizzle cellSwizzle { get; }
        Vector3 CellToLocal(Vector3Int cellPosition);
        Vector3 CellToLocalInterpolated(Vector3 cellPosition);
        Vector3 CellToWorld(Vector3Int cellPosition);
        Bounds GetBoundsLocal(Vector3Int cellPosition);
        Bounds GetBoundsLocal(Vector3 origin, Vector3 size);
        Vector3 GetLayoutCellCenter();
        Vector3Int LocalToCell(Vector3 localPosition);
        Vector3 LocalToCellInterpolated(Vector3 localPosition);
        Vector3 LocalToWorld(Vector3 localPosition);
        Vector3Int WorldToCell(Vector3 worldPosition);
        Vector3 WorldToLocal(Vector3 worldPosition);
    }

    public class ReadOnlyGridLayout<T> : ReadOnlyBehaviour<T>, IReadOnlyGridLayout where T : GridLayout
    {
        protected ReadOnlyGridLayout(T obj) : base(obj)
        {
        }

        #region Properties

        public Vector3 cellGap => _obj.cellGap;
        public GridLayout.CellLayout cellLayout => _obj.cellLayout;
        public Vector3 cellSize => _obj.cellSize;
        public GridLayout.CellSwizzle cellSwizzle => _obj.cellSwizzle;

        #endregion

        #region Public Methods

        public Vector3 CellToLocal(Vector3Int cellPosition) => _obj.CellToLocal(cellPosition);
        public Vector3 CellToLocalInterpolated(Vector3 cellPosition) => _obj.CellToLocalInterpolated(cellPosition);
        public Vector3 CellToWorld(Vector3Int cellPosition) => _obj.CellToWorld(cellPosition);
        public Bounds GetBoundsLocal(Vector3Int cellPosition) => _obj.GetBoundsLocal(cellPosition);
        public Bounds GetBoundsLocal(Vector3 origin, Vector3 size) => _obj.GetBoundsLocal(origin, size);
        public Vector3 GetLayoutCellCenter() => _obj.GetLayoutCellCenter();
        public Vector3Int LocalToCell(Vector3 localPosition) => _obj.LocalToCell(localPosition);
        public Vector3 LocalToCellInterpolated(Vector3 localPosition) => _obj.LocalToCellInterpolated(localPosition);
        public Vector3 LocalToWorld(Vector3 localPosition) => _obj.LocalToWorld(localPosition);
        public Vector3Int WorldToCell(Vector3 worldPosition) => _obj.WorldToCell(worldPosition);
        public Vector3 WorldToLocal(Vector3 worldPosition) => _obj.WorldToLocal(worldPosition);

        #endregion
    }

    public sealed class ReadOnlyGridLayout : ReadOnlyGridLayout<GridLayout>
    {
        public ReadOnlyGridLayout(GridLayout obj) : base(obj)
        {
        }
    }

    public static class GridLayoutExtensions
    {
        public static ReadOnlyGridLayout AsReadOnly(this GridLayout self) => self.IsTrulyNull() ? null : new ReadOnlyGridLayout(self);
    }
}