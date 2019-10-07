using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Models
{
    public sealed class RingPriceInfo
    {
        [DisplayFormat(DataFormatString = "F2")]
        public static readonly Dictionary<PreciousMetalInfo, decimal> MetalPriceAdditions =
            new Dictionary<PreciousMetalInfo, decimal>()
            {
                [new PreciousMetalInfo(PreciousMetal.Gold, PreciousMetalFineness.TwentyTwoKarat)] = 1000M,
                [new PreciousMetalInfo(PreciousMetal.Gold, PreciousMetalFineness.TwentyKarat)] = 750M,
                [new PreciousMetalInfo(PreciousMetal.Gold, PreciousMetalFineness.EighteenKarat)] = 500M,
                [new PreciousMetalInfo(PreciousMetal.Gold, PreciousMetalFineness.FourteenKarat)] = 250M,
                [new PreciousMetalInfo(PreciousMetal.WhiteGold, PreciousMetalFineness.TwentyTwoKarat)] = 2000M,
                [new PreciousMetalInfo(PreciousMetal.WhiteGold, PreciousMetalFineness.TwentyKarat)] = 1750M,
                [new PreciousMetalInfo(PreciousMetal.WhiteGold, PreciousMetalFineness.EighteenKarat)] = 1500M,
                [new PreciousMetalInfo(PreciousMetal.WhiteGold, PreciousMetalFineness.FourteenKarat)] = 1250M,
                [new PreciousMetalInfo(PreciousMetal.Platinum, PreciousMetalFineness.TwentyTwoKarat)] = 3000M,
                [new PreciousMetalInfo(PreciousMetal.Platinum, PreciousMetalFineness.TwentyKarat)] = 2750M,
                [new PreciousMetalInfo(PreciousMetal.Platinum, PreciousMetalFineness.EighteenKarat)] = 2500M,
                [new PreciousMetalInfo(PreciousMetal.Platinum, PreciousMetalFineness.FourteenKarat)] = 2250M
            };

        [DisplayFormat(DataFormatString = "F2")]
        public static readonly Dictionary<RingType, decimal> TypePriceAdditions =
            new Dictionary<RingType, decimal>()
            {
                [RingType.WithSideStones] = 2000M,
                [RingType.WithoutSideStones] = 1000M
            };
    }
}
