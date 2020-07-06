using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        List<Shirt> _shirts;

        [SetUp]
        public void SetUp()
        {
            _shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Yellow - Medium", Size.Medium, Color.Yellow),
                new Shirt(Guid.NewGuid(), "White - Medium", Size.Medium, Color.White),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
                new Shirt(Guid.NewGuid(), "Blue - Small", Size.Small, Color.Blue),
                new Shirt(Guid.NewGuid(), "White - Small", Size.Small, Color.White),
                new Shirt(Guid.NewGuid(), "White - Large", Size.Large, Color.White),
            };
        }

        [Test]
        public void Test_AnySize_AnyColor()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(8, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_AnySize_OneColor()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Blue }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(2, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_AnySize_MultipleColors()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Black, Color.White }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(4, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_OneSize_AnyColor()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(3, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_OneSize_OneColor()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small },
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(1, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_OneSize_MultipleColors()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Medium },
                Colors = new List<Color> { Color.Black, Color.White }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(2, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_MultipleSizes_AnyColor()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small, Size.Medium }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(6, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_MultipleSizes_OneColor()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small, Size.Medium },
                Colors = new List<Color> { Color.White }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(2, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_MultipleSizes_MultipleColors()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small, Size.Medium },
                Colors = new List<Color> { Color.Black, Color.White }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(3, results.Shirts.Count);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }
    }
}
