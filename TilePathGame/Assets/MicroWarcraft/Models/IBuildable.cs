using Assets.MicroWarcraft.Models.Events;

namespace  Assets.MicroWarcraft.Models
{
    public interface IBuildable
    {
        event BuildingComplete BuildingComplete;
        int PercentageBuilt { get; set; }
        void StartBuilding();
        void Ready(int percentage);
    }
}
