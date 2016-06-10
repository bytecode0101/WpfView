using Microsoft.Practices.Prism.Mvvm;
using MyWarcraft.Models;

namespace MyWarcraft.ViewModels
{
    public class PlayerBaseViewModel : BindableBase
    {
        private PlayerBase playerBase;
        public BoardViewModel BoardVM { get; set; }

        public PlayerBase PlayerBase
        {
            get
            {
                return playerBase;
            }

            set
            {
                SetProperty(ref this.playerBase, value);
            }
        }

        public PlayerBaseViewModel()
        {
            playerBase = new PlayerBase();
            BoardVM = new BoardViewModel(playerBase.Components);
        }
    }
}
