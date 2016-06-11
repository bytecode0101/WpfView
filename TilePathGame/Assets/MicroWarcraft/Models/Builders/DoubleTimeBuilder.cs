﻿namespace  Assets.MicroWarcraft.Models.Builders
{
    public class DoubleTimeBuilder : AbstractBuilder
    {
        public DoubleTimeBuilder()
        {
            TimeForEachStep = 200;
            PercentageBuiltAtEachStep = 5;
        }
    }
}
