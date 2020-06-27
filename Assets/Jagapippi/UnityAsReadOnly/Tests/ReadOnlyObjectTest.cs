using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

namespace Jagapippi.UnityAsReadOnly.Tests
{
    public class ReadOnlyObjectTest
    {
        [Test]
        public void ObjectEqualsNull()
        {
            Object obj = null;

            Assert.IsFalse(obj);
            Assert.IsTrue(obj == null);
            Assert.IsFalse(obj != null);
            Assert.IsTrue(ReferenceEquals(obj, null));

            obj = new Object();

            // NOTE: This is Unity's intended implementation..
            Assert.IsFalse(obj);
            Assert.IsTrue(obj == null);
            Assert.IsFalse(obj != null);
            Assert.IsTrue(obj.Equals(null));
            Assert.IsFalse(ReferenceEquals(obj, null));
        }

        [Test]
        public void ObjectEqualsOther()
        {
            var obj1 = new Object();
            var obj2 = new Object();

            Assert.IsTrue(obj1 == obj2);
            Assert.IsFalse(obj1 != obj2);
            Assert.IsTrue(obj1.Equals(obj2));
            Assert.IsFalse(ReferenceEquals(obj1, obj2));
        }

        [Test]
        public void ObjectEqualsSame()
        {
            var obj1 = new Object();
            var obj2 = obj1;

            Assert.IsTrue(obj1 == obj2);
            Assert.IsFalse(obj1 != obj2);
            Assert.IsTrue(obj1.Equals(obj2));
            Assert.IsTrue(ReferenceEquals(obj1, obj2));
        }

        [Test]
        public void ReadOnlyObjectEqualsNull()
        {
            ReadOnlyObject obj = null;

            Assert.IsFalse(obj);
            Assert.IsTrue(obj == null);
            Assert.IsFalse(obj != null);
            Assert.IsTrue(ReferenceEquals(obj, null));

            obj = new ReadOnlyObject(new Object());

            // NOTE: This is Unity's intended implementation..
            Assert.IsFalse(obj);
            Assert.IsTrue(obj == null);
            Assert.IsFalse(obj != null);
            Assert.IsTrue(obj.Equals(null));
            Assert.IsFalse(ReferenceEquals(obj, null));
        }

        [Test]
        public void ReadOnlyObjectEqualsOther()
        {
            var obj1 = new ReadOnlyObject(new Object());
            var obj2 = new ReadOnlyObject(new Object());

            Assert.IsTrue(obj1 == obj2);
            Assert.IsFalse(obj1 != obj2);
            Assert.IsTrue(obj1.Equals(obj2));
            Assert.IsFalse(ReferenceEquals(obj1, obj2));
        }

        [Test]
        public void ReadOnlyObjectEqualsSame()
        {
            var obj1 = new ReadOnlyObject(new Object());
            var obj2 = obj1;

            Assert.IsTrue(obj1 == obj2);
            Assert.IsFalse(obj1 != obj2);
            Assert.IsTrue(obj1.Equals(obj2));
            Assert.IsTrue(ReferenceEquals(obj1, obj2));
        }

        [Test]
        public void ReadOnlyObjectEqualsSameObject()
        {
            var obj = new Object();
            var obj1 = new ReadOnlyObject(obj);
            var obj2 = new ReadOnlyObject(obj);

            Assert.IsTrue(obj1 == obj2);
            Assert.IsFalse(obj1 != obj2);
            Assert.IsTrue(obj1.Equals(obj2));
            Assert.IsFalse(ReferenceEquals(obj1, obj2));
        }
    }
}