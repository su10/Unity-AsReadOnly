using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Jagapippi.UnityAsReadOnly.Tests
{
    public class TypeExtensionsTest
    {
        [Test]
        public void GetConstraints_struct()
        {
            var method = typeof(ConstraintsTest_struct).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("struct", method.GetGenericArguments().First().GetConstraints());
        }

        private class ConstraintsTest_struct
        {
            public void StructConstraint<T>() where T : struct
            {
            }
        }

        [Test]
        public void GetConstraints_class()
        {
            var method = typeof(ConstraintsTest_class).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("class", method.GetGenericArguments().First().GetConstraints());
        }

        private class ConstraintsTest_class
        {
            public void ClassConstraint<T>() where T : class
            {
            }
        }

        [Test]
        public void GetConstraints_new()
        {
            var method = typeof(ConstraintsTest_new).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("new()", method.GetGenericArguments().First().GetConstraints());
        }

        private class ConstraintsTest_new
        {
            public void ParameterlessConstructorConstraint<T>() where T : new()
            {
            }
        }

        [Test]
        public void GetConstraints_baseclass()
        {
            var method = typeof(ConstraintsTest_baseclass).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("TestBaseClass", method.GetGenericArguments().First().GetConstraints());
        }

        private class ConstraintsTest_baseclass
        {
            public void BaseClassConstraint<T>() where T : TestBaseClass
            {
            }
        }

        private class TestBaseClass
        {
        }

        [Test]
        public void GetConstraints_interface()
        {
            var method = typeof(ConstraintsTest_interface).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("ITestInterface", method.GetGenericArguments().First().GetConstraints());
        }

        private class ConstraintsTest_interface
        {
            public void InterfaceConstraint<T>() where T : ITestInterface
            {
            }
        }

        private class ITestInterface
        {
        }

        [Test]
        public void GetConstraints_baseclass_new()
        {
            var method = typeof(ConstraintsTest_baseclass_new).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("TestBaseClass, new()", method.GetGenericArguments().First().GetConstraints());
        }

        private class ConstraintsTest_baseclass_new
        {
            public void BaseClassAndParameterlessConstructorConstraint<T>() where T : TestBaseClass, new()
            {
            }
        }

        [Test]
        public void GetConstraints_interface_new()
        {
            var method = typeof(ConstraintsTest_interface_new).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("ITestInterface, new()", method.GetGenericArguments().First().GetConstraints());
        }

        private class ConstraintsTest_interface_new
        {
            public void InterfaceAndParameterlessConstructorConstraint<T>() where T : ITestInterface, new()
            {
            }
        }

        [Test]
        public void GetConstraints_T()
        {
            var method = typeof(ConstraintsTest_T).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("T1", method.GetGenericArguments()[1].GetConstraints());
        }

        private class ConstraintsTest_T
        {
            public void TConstraint<T1, T2>() where T1 : class where T2 : T1
            {
            }
        }

        [Test]
        public void GetConstraints_baseclass_T()
        {
            var method = typeof(ConstraintsTest_baseclass_T).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("TestBaseClass, T1", method.GetGenericArguments()[1].GetConstraints());
        }

        private class ConstraintsTest_baseclass_T
        {
            public void InterfaceAndTConstraint<T1, T2>() where T1 : class where T2 : TestBaseClass, T1
            {
            }
        }

        [Test]
        public void GetConstraints_interface_T()
        {
            var method = typeof(ConstraintsTest_interface_T).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("ITestInterface, T1", method.GetGenericArguments()[1].GetConstraints());
        }

        private class ConstraintsTest_interface_T
        {
            public void InterfaceAndTConstraint<T1, T2>() where T1 : class where T2 : ITestInterface, T1
            {
            }
        }

        [Test]
        public void GetConstraints_T1_T2()
        {
            var method = typeof(ConstraintsTest_T1_T2).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).First();
            Assert.AreEqual("T1, T2", method.GetGenericArguments()[2].GetConstraints());
        }

        private class ConstraintsTest_T1_T2
        {
            public void T1AndT2Constraint<T1, T2, T3>() where T1 : class where T2 : T1 where T3 : T1, T2
            {
            }
        }
    }
}