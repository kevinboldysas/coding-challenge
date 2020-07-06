using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // I could have added intermediate data structures here to improve performance however the brief indicated that 100ms was adequate for the performance test.
            // On my PC, the performance test runs in 40ms, so instead I spent more time beefing up the unit tests.
        }

        public SearchResults Search(SearchOptions options)
        {
            var shirts = _shirts.Where(s => (!options.Sizes.Any() || options.Sizes.Select(s => s.Id).Contains(s.Size.Id))
                                        && (!options.Colors.Any() || options.Colors.Select(c => c.Id).Contains(s.Color.Id))).ToList();
            var sizeCounts = new List<SizeCount>(Size.All.Count);
            var colorCounts = new List<ColorCount>(Color.All.Count);

            foreach (var size in Size.All)
            {
                var sizeCount = shirts.Count(c => c.Size.Id == size.Id
                    && (!options.Sizes.Any() || options.Sizes.Select(s => s.Id).Contains(c.Size.Id)));

                sizeCounts.Add(new SizeCount
                {
                    Size = size,
                    Count = sizeCount
                });
            }

            foreach (var color in Color.All)
            {
                var colorCount = shirts.Count(c => c.Color.Id == color.Id
                    && (!options.Sizes.Any() || options.Sizes.Select(s => s.Id).Contains(c.Size.Id)));

                colorCounts.Add(new ColorCount
                {
                    Color = color,
                    Count = colorCount
                });
            }

            return new SearchResults
            {
                Shirts = shirts,
                SizeCounts = sizeCounts,
                ColorCounts = colorCounts
            };
        }
    }
}