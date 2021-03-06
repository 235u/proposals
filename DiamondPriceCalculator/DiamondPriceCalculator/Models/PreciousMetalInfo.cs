﻿using System.ComponentModel.DataAnnotations;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Models
{
    public sealed class PreciousMetalInfo
    {
        public PreciousMetalInfo(PreciousMetal metal, PreciousMetalFineness fineness)
        {
            PreciousMetal = metal;
            Fineness = fineness;
        }

        [Display(Name = "Metal")]
        public PreciousMetal PreciousMetal { get; private set; }

        [Display(Name = "Purity")]
        public PreciousMetalFineness Fineness { get; private set; }
    }
}
