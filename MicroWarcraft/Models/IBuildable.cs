using MyWarcraft.Models.Events;

namespace MyWarcraft.Models
{
    public interface IBuildable
    {
        event BuildingComplete BuildingComplete;
        int PercentageBuilt { get; set; }
        void StartBuilding();
        void Ready(int percentage);
    }
}
