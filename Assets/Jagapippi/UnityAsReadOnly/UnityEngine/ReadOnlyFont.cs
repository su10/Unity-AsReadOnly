using UnityEngine;

namespace Jagapippi.UnityAsReadOnly
{
    public interface IReadOnlyFont
    {
        int ascent { get; }
        CharacterInfo[] characterInfo { get; }
        bool dynamic { get; }
        string[] fontNames { get; }
        int fontSize { get; }
        int lineHeight { get; }
        IReadOnlyMaterial material { get; }
        bool GetCharacterInfo(char ch, out CharacterInfo info, int size, FontStyle style);
        bool GetCharacterInfo(char ch, out CharacterInfo info, int size);
        bool GetCharacterInfo(char ch, out CharacterInfo info);
        bool HasCharacter(char c);
        // void RequestCharactersInTexture(string characters, int size, FontStyle style);
        // void RequestCharactersInTexture(string characters, int size);
        // void RequestCharactersInTexture(string characters);
    }

    public sealed class ReadOnlyFont : ReadOnlyObject<Font>, IReadOnlyFont
    {
        public ReadOnlyFont(Font obj) : base(obj)
        {
        }

        #region Properties

        public int ascent => _obj.ascent;
        public CharacterInfo[] characterInfo => _obj.characterInfo;
        public bool dynamic => _obj.dynamic;
        public string[] fontNames => _obj.fontNames;
        public int fontSize => _obj.fontSize;
        public int lineHeight => _obj.lineHeight;
        public ReadOnlyMaterial material => _obj.material.AsReadOnly();
        IReadOnlyMaterial IReadOnlyFont.material => this.material;

        #endregion

        #region Public Methods

        public bool GetCharacterInfo(char ch, out CharacterInfo info, int size, FontStyle style) => _obj.GetCharacterInfo(ch, out info, size, style);
        public bool GetCharacterInfo(char ch, out CharacterInfo info, int size) => _obj.GetCharacterInfo(ch, out info, size);
        public bool GetCharacterInfo(char ch, out CharacterInfo info) => _obj.GetCharacterInfo(ch, out info);
        public bool HasCharacter(char c) => _obj.HasCharacter(c);
        // public void RequestCharactersInTexture(string characters, int size, FontStyle style) => _obj.RequestCharactersInTexture(characters, size, style);
        // public void RequestCharactersInTexture(string characters, int size) => _obj.RequestCharactersInTexture(characters, size);
        // public void RequestCharactersInTexture(string characters) => _obj.RequestCharactersInTexture(characters);

        #endregion
    }

    public static class FontExtensions
    {
        public static ReadOnlyFont AsReadOnly(this Font self) => self.IsTrulyNull() ? null : new ReadOnlyFont(self);
    }
}