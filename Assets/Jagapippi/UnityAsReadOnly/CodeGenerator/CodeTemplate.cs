namespace Jagapippi.UnityAsReadOnly
{
    public static class CodeTemplate
    {
        public const string SimpleClass = @"{0}
namespace {1}
{{
    public class ReadOnly{2} : ReadOnly{3}<{2}>
    {{
        public ReadOnly{2}({2} obj) : base(obj)
        {{
        }}

        #region Properties

{4}
        #endregion

        #region Public Methods

{5}
        #endregion
    }}

    public static class {2}Extensions
    {{
        public static ReadOnly{2} AsReadOnly(this {2} self) => new ReadOnly{2}(self);
    }}
}}";

        public static string FormatSimpleClass(
            string usingSection,
            string @namespace,
            string className,
            string baseClassName,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return string.Format(SimpleClass, usingSection, @namespace, className, baseClassName, propertiesSection, publicMethodSection);
        }

        public const string ClassWithInterface = @"{0}
namespace {1}
{{
    public interface IReadOnly{2} : IReadOnly{3}
    {{
{4}    }}

    public class ReadOnly{2} : ReadOnly{3}<{2}>, IReadOnly{2}
    {{
        public ReadOnly{2}({2} obj) : base(obj)
        {{
        }}

        #region Properties

{5}
        #endregion

        #region Public Methods

{6}
        #endregion
    }}

    public static class {2}Extensions
    {{
        public static ReadOnly{2} AsReadOnly(this {2} self) => new ReadOnly{2}(self);
    }}
}}";

        public static string FormatClassWithInterface(
            string usingSection,
            string @namespace,
            string className,
            string baseClassName,
            string interfaceSection,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return string.Format(ClassWithInterface, usingSection, @namespace, className, baseClassName, interfaceSection, propertiesSection, publicMethodSection);
        }

        public const string GenericClass = @"{0}
namespace {1}
{{
    public interface IReadOnly{2} : IReadOnly{3}
    {{
{4}    }}

    public class ReadOnly{2}<T> : ReadOnly{3}<T>, IReadOnly{2} where T : {2}
    {{
        protected ReadOnly{2}(T obj) : base(obj)
        {{
        }}

        #region Properties

{5}
        #endregion

        #region Public Methods

{6}
        #endregion
    }}

    public class ReadOnly{2} : ReadOnly{2}<{2}>
    {{
        public ReadOnly{2}({2} obj) : base(obj)
        {{
        }}
    }}

    public static class {2}Extensions
    {{
        public static ReadOnly{2} AsReadOnly(this {2} self) => new ReadOnly{2}(self);
    }}
}}";

        public static string FormatGenericClass(
            string usingSection,
            string @namespace,
            string className,
            string baseClassName,
            string interfaceSection,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return string.Format(GenericClass, usingSection, @namespace, className, baseClassName, interfaceSection, propertiesSection, publicMethodSection);
        }
    }
}