using System;
using ArraySample.Service;
using NUnit.Framework;

namespace ArraySampleTests
{
    public class ArrayReverseTests
    {
        private IProductService _mockProductService;

        [SetUp]
        public void Setup()
        {
            _mockProductService = new ProductService();
        }

        [Test]
        public void Reverse_SingleItemArray_ReturnsSameArray()
        {
            var array = new[] { 1 };

            var actual = _mockProductService.ReverseArray(array);

            CollectionAssert.AreEqual(array, actual);
        }

        [TestCase(new[] { 1, 2 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 1 })]
        [TestCase(new[] { 4, 3, 2, 1 }, new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 3, 4, 1, 2 }, new[] { 2, 1, 4, 3 })]
        public void Reverse_ArrayWithItems_ReturnsReversedArray(int[] array, int[] expected)
        {
            var actual = _mockProductService.ReverseArray(array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Reverse_EmptyArray_ReturnsEmptyArray()
        {
            var array = new int[]{};

            var actual = _mockProductService.ReverseArray(array);

            CollectionAssert.AreEqual(array, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, -1)]
        [TestCase(new[] { 1, 2, 3, 4}, 0)]
        [TestCase(new[] { 1, 2, 3, 4 }, 5)]
        public void DeleteFromArray_PositionOutsideOfArray_ThrowsArgumentOutOfRangeException(int[] array, int position)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _mockProductService.DeleteFromArray(array, position));
        }

        [TestCase(new[] {1,2,3,4,5}, 1, new[] {2,3,4,5})]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, new[] { 1, 2, 3, 4 })]
        public void DeleteFromArray_PositionInArray_ReturnsPositionRemovedFromArray(int[] array, int position, int[] expected)
        {
            var actual = _mockProductService.DeleteFromArray(array, position);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}