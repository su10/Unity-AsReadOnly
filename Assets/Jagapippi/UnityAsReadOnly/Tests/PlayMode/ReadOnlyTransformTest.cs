using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Jagapippi.UnityAsReadOnly.Tests
{
    public class ReadOnlyTransformTest
    {
        private Transform _transform;

        [SetUp]
        public void SetUp()
        {
            if (_transform) Object.Destroy(_transform.gameObject);
            _transform = new GameObject("ReadOnlyTransformTest").transform;
        }

        [Test]
        public void TransformEqualsNull()
        {
            Transform transform = null;

            Assert.IsFalse(transform);
            Assert.IsTrue(transform == null);
            Assert.IsFalse(transform != null);
            Assert.IsTrue(ReferenceEquals(transform, null));

            transform = _transform;

            Assert.IsTrue(transform);
            Assert.IsFalse(transform == null);
            Assert.IsTrue(transform != null);
            Assert.IsFalse(transform.Equals(null));
            Assert.IsFalse(ReferenceEquals(transform, null));
        }

        [Test]
        public void TransformEqualsOther()
        {
            var transform1 = new GameObject("LHS").transform;
            var transform2 = new GameObject("RHS").transform;

            Assert.IsFalse(transform1 == transform2);
            Assert.IsTrue(transform1 != transform2);
            Assert.IsFalse(transform1.Equals(transform2));
            Assert.IsFalse(ReferenceEquals(transform1, transform2));
        }

        [Test]
        public void TransformEqualsSame()
        {
            var transform1 = _transform;
            var transform2 = transform1;

            Assert.IsTrue(transform1 == transform2);
            Assert.IsFalse(transform1 != transform2);
            Assert.IsTrue(transform1.Equals(transform2));
            Assert.IsTrue(ReferenceEquals(transform1, transform2));
        }

        [UnityTest]
        public IEnumerator TransformDestroy()
        {
            Object.Destroy(_transform.gameObject);

            Assert.IsTrue(_transform);
            Assert.IsFalse(_transform == null);
            Assert.IsTrue(_transform != null);
            Assert.IsFalse(_transform.Equals(null));

            yield return null;

            Assert.IsFalse(_transform);
            Assert.IsTrue(_transform == null);
            Assert.IsFalse(_transform != null);
            Assert.IsTrue(_transform.Equals(null));
        }

        [Test]
        public void ReadOnlyTransformEqualsNull()
        {
            ReadOnlyTransform transform = null;

            Assert.IsFalse(transform);
            Assert.IsTrue(transform == null);
            Assert.IsFalse(transform != null);
            Assert.IsTrue(ReferenceEquals(transform, null));

            transform = (ReadOnlyTransform) _transform.AsReadOnly();

            Assert.IsTrue(transform);
            Assert.IsFalse(transform == null);
            Assert.IsTrue(transform != null);
            Assert.IsFalse(transform.Equals(null));
            Assert.IsFalse(ReferenceEquals(transform, null));
        }

        [Test]
        public void ReadOnlyTransformEqualsOther()
        {
            var go1 = new GameObject("LHS");
            var go2 = new GameObject("RHS");
            var transform1 = (ReadOnlyTransform) go1.transform.AsReadOnly();
            var transform2 = (ReadOnlyTransform) go2.transform.AsReadOnly();

            Assert.IsFalse(transform1 == transform2);
            Assert.IsTrue(transform1 != transform2);
            Assert.IsFalse(transform1.Equals(transform2));
            Assert.IsFalse(ReferenceEquals(transform1, transform2));

            Object.Destroy(go1);
            Object.Destroy(go2);
        }

        [Test]
        public void ReadOnlyTransformEqualsSame()
        {
            var transform1 = (ReadOnlyTransform) _transform.AsReadOnly();

            Assert.IsTrue(transform1 == _transform);
            Assert.IsFalse(transform1 != _transform);
            Assert.IsTrue(transform1.Equals(_transform));
            Assert.IsFalse(ReferenceEquals(transform1, _transform));

            var transform2 = transform1;

            Assert.IsTrue(transform1 == transform2);
            Assert.IsFalse(transform1 != transform2);
            Assert.IsTrue(transform1.Equals(transform2));
            Assert.IsTrue(ReferenceEquals(transform1, transform2));

            transform2 = (ReadOnlyTransform) _transform.AsReadOnly();
            Assert.IsTrue(transform1 == transform2);
            Assert.IsFalse(transform1 != transform2);
            Assert.IsTrue(transform1.Equals(transform2));
            Assert.IsFalse(ReferenceEquals(transform1, transform2));
        }

        [UnityTest]
        public IEnumerator ReadOnlyTransformDestroy()
        {
            var transform = (ReadOnlyTransform) _transform.AsReadOnly();
            Object.Destroy(_transform.gameObject);

            Assert.IsTrue(transform);
            Assert.IsFalse(transform == null);
            Assert.IsTrue(transform != null);
            Assert.IsFalse(transform.Equals(null));

            yield return null;

            Assert.IsFalse(transform);
            Assert.IsTrue(transform == null);
            Assert.IsFalse(transform != null);
            Assert.IsTrue(transform.Equals(null));
        }
    }
}