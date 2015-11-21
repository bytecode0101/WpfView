using MyWarcraft.Models.Capabilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWarcraft.Models;

namespace MyWarcraft
{
    public class BuildingHealingCapability : AbstractBuildingCapability
    {
        public BuildingHealingCapability()
        {
            Description = "Building can Heal";
            Name = "BuildingHeal";
        }
        public override AbstractBuildable CreateComponent()
        {
            throw new NotImplementedException();
        }
    }
}