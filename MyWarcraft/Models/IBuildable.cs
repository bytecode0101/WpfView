using MyWarcraft.Models.Events;
using MyWarcraft.Models.Units;

namespace MyWarcraft.Models
{
    public interface IBuildable
    {
        event BuildingComplete BuildingComplete;
        int PercentageBuilt { get; set; }
        Point Position { get; set; }
        void StartBuilding();
        void Ready(int percentage);
        void TakeHit(AbstractUnit attacker, int power);
    }
}
