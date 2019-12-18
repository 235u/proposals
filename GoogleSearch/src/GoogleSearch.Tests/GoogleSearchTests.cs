using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleSearch
{
    [TestClass]
    public class GoogleSearchTests
    {
        private const string Query = "Jed Fagan";
        private const int LinkCount = 2;

        private static async Task<SearchResult> FindLinksAsync(ILinkSearch implementation)
        {
            var stopwatch = Stopwatch.StartNew();
            IEnumerable<string> links = await implementation.FindLinksAsync(Query, LinkCount);
            stopwatch.Stop();

            int actualLinkCount = links.Count();
            Assert.AreEqual(LinkCount, actualLinkCount);

            bool areValid = links.All(l => Uri.IsWellFormedUriString(l, UriKind.Absolute));
            Assert.IsTrue(areValid);

            return new SearchResult()
            {
                Links = links,
                Duration = stopwatch.Elapsed
            };
        }

        [TestMethod]
        public async Task FindLinksAsync_GoogleCustomSearch()
        {
            using (var customSearch = new GoogleCustomSearch())
            {
                await FindLinksAsync(customSearch);
            }
        }

        [TestMethod]
        public async Task FindLinksAsync_GoogleWebSearch()
        {
            var webSearch = new GoogleWebSearch();
            await FindLinksAsync(webSearch);
        }

        [TestMethod]
        public async Task FindLinksAsync_ImplementationComparison()
        {
            SearchResult customSearchResult = null;
            using (var customSearch = new GoogleCustomSearch())
            {
                customSearchResult = await FindLinksAsync(customSearch);
            }

            var webSearch = new GoogleWebSearch();
            SearchResult webSearchResult = await FindLinksAsync(webSearch);

            bool customSearchIsFaster = customSearchResult.Duration < webSearchResult.Duration;
            Assert.IsFalse(customSearchIsFaster);

            bool resultSetsAreEqual = customSearchResult.Links.SequenceEqual(webSearchResult.Links);
            Assert.IsFalse(resultSetsAreEqual);

            IEnumerable<string> intersectingLinks = customSearchResult.Links.Intersect(webSearchResult.Links);
            bool resultSetsDoIntersect = intersectingLinks.Any();
            Assert.IsTrue(resultSetsDoIntersect);
        }

        private class SearchResult
        {
            public IEnumerable<string> Links { get; set; }

            public TimeSpan Duration { get; set; }
        }
    }
}