namespace Jagapippi.UnityAsReadOnly
{
    public static class CodeTemplate
    {
        public const string SimpleClass = @"{0}
namespace Jagapippi.UnityAsReadOnly
{{
    public class ReadOnly{1} : ReadOnly{2}<{1}>
    {{
        public ReadOnly{1}({1} obj) : base(obj)
        {{
        }}

        #region Properties

{3}
        #endregion

        #region Public Methods

{4}
        #endregion
    }}

    public static class {1}Extensions
    {{
        public static ReadOnly{1} AsReadOnly(this {1} self) => new ReadOnly{1}(self);
    }}
}}
";

        public static string FormatSimpleClass(
            string usingSection,
            string className,
            string baseClassName,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return string.Format(SimpleClass, usingSection, className, baseClassName, propertiesSection, publicMethodSection);
        }

        public const string ClassWithInterface = @"{0}
namespace Jagapippi.UnityAsReadOnly
{{
    public interface IReadOnly{1} : IReadOnly{2}
    {{
{3}
    }}

    public class ReadOnly{1} : ReadOnly{2}<{1}>, IReadOnly{1}
    {{
        public ReadOnly{1}({1} obj) : base(obj)
        {{
        }}

        #region Properties

{4}
        #endregion

        #region Public Methods

{5}
        #endregion
    }}

    public static class {1}Extensions
    {{
        public static ReadOnly{1} AsReadOnly(this {1} self) => new ReadOnly{1}(self);
    }}
}}
";

        public static string FormatClassWithInterface(
            string usingSection,
            string className,
            string baseClassName,
            string interfaceSection,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return string.Format(ClassWithInterface, usingSection, className, baseClassName, interfaceSection, propertiesSection, publicMethodSection);
        }

        public const string GenericClass = @"{0}
namespace Jagapippi.UnityAsReadOnly
{{
    public interface IReadOnly{1} : IReadOnly{2}
    {{
{3}
    }}

    public class ReadOnly{1}<T> : ReadOnly{2}<T> where T : {1}
    {{
        protected ReadOnly{1}(T obj) : base(obj)
        {{
        }}

        #region Properties

{4}
        #endregion

        #region Public Methods

{5}
        #endregion
    }}

    public class ReadOnly{1} : ReadOnly{1}<{1}>
    {{
        public ReadOnly{1}({1} obj) : base(obj)
        {{
        }}
    }}

    public static class {1}Extensions
    {{
        public static ReadOnly{1} AsReadOnly(this {1} self) => new ReadOnly{1}(self);
    }}
}}
";

        public static string FormatGenericClass(
            string usingSection,
            string className,
            string baseClassName,
            string interfaceSection,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return string.Format(GenericClass, usingSection, className, baseClassName, interfaceSection, propertiesSection, publicMethodSection);
        }
    }
}