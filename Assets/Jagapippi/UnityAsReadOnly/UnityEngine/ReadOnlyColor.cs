using System;
using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyColor : IEquatable<Color>, IEquatable<ReadOnlyColor>
    {
        private readonly Color _color;

        public ReadOnlyColor(float r, float g, float b, float a)
        {
            _color = new Color(r, g, b, a);
        }

        public ReadOnlyColor(float r, float g, float b)
        {
            _color = new Color(r, g, b);
        }

        public ReadOnlyColor(Color color)
        {
            _color = color;
        }

        #region Properties

        public float r => _color.r;
        public float g => _color.g;
        public float b => _color.b;
        public float a => _color.a;
        public float this[int index] => _color[index];
        public ReadOnlyColor gamma => _color.gamma.AsReadOnly();
        public float grayscale => _color.grayscale;
        public ReadOnlyColor linear => _color.linear.AsReadOnly();
        public float maxColorComponent => _color.maxColorComponent;

        #endregion

        #region Public Methods

        public bool Equals(Color other) => (_color == other);
        public bool Equals(ReadOnlyColor other) => (_color == other._color);

        public override bool Equals(object other)
        {
            if (other is Color color) return (_color == color);
            if (other is ReadOnlyColor readOnlyColor) return (_color == readOnlyColor._color);
            return false;
        }

        public override int GetHashCode() => _color.GetHashCode();
        public override string ToString() => _color.ToString();
        public string ToString(string format) => _color.ToString(format);

        #endregion

        #region Operators

        public static Color operator +(ReadOnlyColor a, Color b) => (a._color + b);
        public static Color operator -(ReadOnlyColor a, Color b) => (a._color - b);
        public static Color operator *(ReadOnlyColor a, Color b) => (a._color * b);
        public static Color operator *(ReadOnlyColor a, float b) => (a._color * b);
        public static Color operator *(float b, ReadOnlyColor a) => (b * a._color);
        public static Color operator /(ReadOnlyColor a, float b) => (a._color / b);
        public static bool operator ==(ReadOnlyColor lhs, Color rhs) => (lhs._color == rhs);
        public static bool operator !=(ReadOnlyColor lhs, Color rhs) => !(lhs == rhs);

        #endregion

        public static implicit operator ReadOnlyColor(Color c) => new ReadOnlyColor(c);
        public static implicit operator Color(ReadOnlyColor c) => c._color;
    }

    public static class ColorExtensions
    {
        public static ReadOnlyColor AsReadOnly(this Color self) => new ReadOnlyColor(self);
    }
}