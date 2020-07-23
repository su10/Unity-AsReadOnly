using System.Text;

namespace Jagapippi.UnityAsReadOnly
{
    public static class CodeTemplate
    {
        private const string Usings = "#USINGS#";
        private const string Namespace = "#NAMESPACE#";
        private const string ClassName = "#CLASSNAME#";
        private const string BaseClassName = "#BASECLASSNAME#";
        private const string Interface = "#INTERFACE#";
        private const string Properties = "#PROPERTIES#";
        private const string Methods = "#METHODS#";

        private static readonly string SimpleClass = $@"{Usings}
namespace {Namespace}
{{
    public interface IReadOnly{ClassName}
    {{
{Interface}    }}

    public sealed class ReadOnly{ClassName} : IReadOnly{ClassName}
    {{
        private readonly {ClassName} _obj;

        public ReadOnly{ClassName}({ClassName} obj)
        {{
            _obj = obj;
        }}

        #region Properties

{Properties}        #endregion

        #region Public Methods

{Methods}        #endregion
    }}

    public static class {ClassName}Extensions
    {{
        public static IReadOnly{ClassName} AsReadOnly(this {ClassName} self) => new ReadOnly{ClassName}(self);
    }}
}}";

        public static string FormatSimpleClass(
            string usingSection,
            string @namespace,
            string className,
            string interfaceSection,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return new StringBuilder().Append(SimpleClass)
                .Replace(Usings, usingSection)
                .Replace(Namespace, @namespace)
                .Replace(ClassName, className)
                .Replace(Interface, interfaceSection)
                .Replace(Properties, propertiesSection)
                .Replace(Methods, publicMethodSection)
                .ToString();
        }

        private static readonly string DerivedClass = $@"{Usings}
namespace {Namespace}
{{
    public interface IReadOnly{ClassName}
    {{
{Interface}    }}

    public sealed class ReadOnly{ClassName} : ReadOnly{BaseClassName}<{ClassName}>, IReadOnly{ClassName}
    {{
        public ReadOnly{ClassName}({ClassName} obj) : base(obj)
        {{
        }}

        #region Properties

{Properties}        #endregion

        #region Public Methods

{Methods}        #endregion
    }}

    public static class {ClassName}Extensions
    {{
        public static IReadOnly{ClassName} AsReadOnly(this {ClassName} self) => new ReadOnly{ClassName}(self);
    }}
}}";

        public static string FormatDerivedClass(
            string usingSection,
            string @namespace,
            string className,
            string baseClassName,
            string interfaceSection,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return new StringBuilder().Append(DerivedClass)
                .Replace(Usings, usingSection)
                .Replace(Namespace, @namespace)
                .Replace(ClassName, className)
                .Replace(BaseClassName, baseClassName)
                .Replace(Interface, interfaceSection)
                .Replace(Properties, propertiesSection)
                .Replace(Methods, publicMethodSection)
                .ToString();
        }

        private static readonly string InheritableClass = $@"{Usings}
namespace {Namespace}
{{
    public interface IReadOnly{ClassName}
    {{
{Interface}    }}

    public class ReadOnly{ClassName}<T> : ReadOnly{BaseClassName}<T>, IReadOnly{ClassName} where T : {ClassName}
    {{
        protected ReadOnly{ClassName}(T obj) : base(obj)
        {{
        }}

        #region Properties

{Properties}        #endregion

        #region Public Methods

{Methods}        #endregion
    }}

    public sealed class ReadOnly{ClassName} : ReadOnly{ClassName}<{ClassName}>
    {{
        public ReadOnly{ClassName}({ClassName} obj) : base(obj)
        {{
        }}
    }}

    public static class {ClassName}Extensions
    {{
        public static IReadOnly{ClassName} AsReadOnly(this {ClassName} self) => new ReadOnly{ClassName}(self);
    }}
}}";

        public static string FormatInheritableClass(
            string usingSection,
            string @namespace,
            string className,
            string baseClassName,
            string interfaceSection,
            string propertiesSection,
            string publicMethodSection
        )
        {
            return new StringBuilder().Append(InheritableClass)
                .Replace(Usings, usingSection)
                .Replace(Namespace, @namespace)
                .Replace(ClassName, className)
                .Replace(BaseClassName, baseClassName)
                .Replace(Interface, interfaceSection)
                .Replace(Properties, propertiesSection)
                .Replace(Methods, publicMethodSection)
                .ToString();
        }
    }
}