using System;
using Assets.MicroWarcraft.Models;
using Assets.MicroWarcraft.Utils;

namespace Assets.MicroWarcraft.ViewModels
{
    public class PlayerBaseViewModel : Utils.BindableBase
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
                playerBase = value;
            }
        }

        public PlayerBaseViewModel()
        {
            playerBase = new PlayerBase();
            BoardVM = new BoardViewModel(playerBase.Components);
        }
    }
}
