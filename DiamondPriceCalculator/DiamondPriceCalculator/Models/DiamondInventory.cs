using System;
using System.Collections.Generic;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Models
{
    public sealed class DiamondInventory : List<DiamondInfo>
    {
        private static readonly Random Random = new Random();

        private DiamondInventory()
        {
        }

        public static DiamondInventory Create()
        {
            var inventory = new DiamondInventory();

            var shapes = (IEnumerable<DiamondShape>)Enum.GetValues(typeof(DiamondShape));
            var shapeLottery = new Lottery<DiamondShape>(shapes);

            var cuts = (IEnumerable<DiamondCut>)Enum.GetValues(typeof(DiamondCut));
            var cutLottery = new Lottery<DiamondCut>(cuts);

            var colors = (IEnumerable<DiamondColor>)Enum.GetValues(typeof(DiamondColor));
            var colorLottery = new Lottery<DiamondColor>(colors);
            
            var clarities = (IEnumerable<DiamondClarity>)Enum.GetValues(typeof(DiamondClarity));
            var clarityLottery = new Lottery<DiamondClarity>(clarities);

            for (int counter = 0; counter < 100; counter++)
            {
                var diamond = new DiamondInfo()
                {
                    Shape = shapeLottery.Next(),
                    PriceInDirhams = NextDecimal(maxValue: 10_000),
                    WeightInCarats = NextDecimal(maxValue: 10),
                    Cut = cutLottery.Next(),
                    Color = colorLottery.Next(),
                    Clarity = clarityLottery.Next()
                };

                inventory.Add(diamond);
            }

            return inventory;
        }

        private static decimal NextDecimal(int maxValue)
        {
            var value = Convert.ToDecimal(Random.NextDouble() * maxValue);
            return Math.Round(value, decimals: 2);
        }

        private class Lottery<T>
        {
            private const string PoolEmptyMessage = "The element pool is empty.";

            private readonly Random _random = new Random();
            private readonly List<T> _elementPool;

            public Lottery(IEnumerable<T> elements)
            {
                _elementPool = new List<T>(elements);
            }

            public T Next()
            {
                if (_elementPool.Count == 0)
                {
                    throw new InvalidOperationException(PoolEmptyMessage);
                }

                int index = _random.Next(maxValue: _elementPool.Count);
                return _elementPool[index];
            }
        }
    }
}
