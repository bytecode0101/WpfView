using MyWarcraft.Models.Buildings;
using MyWarcraft.ViewModels;
using NUnit.Framework;

namespace TestTheGame
{
    [TestFixture]
    public class TestCapabilities
    {
        private PlayerBaseViewModel PlayerBaseVM;

        [SetUp]
        public void SetUp()
        {
            PlayerBaseVM = new PlayerBaseViewModel();
        }

        [Test]
        public void TestPlayerBaseComponents()
        {
            Assert.AreEqual(2, PlayerBaseVM.PlayerBase.Components.Count);
        }

        [Test]
        public void TestBuildildingAFarm()
        {
            PlayerBaseVM.BoardVM.SelectedComponent = PlayerBaseVM.BoardVM.ComponentVMs[0];
            Assert.AreEqual(2, PlayerBaseVM.BoardVM.ComponentVMs.Count, "There should be only two components at startup!");
            PlayerBaseVM.BoardVM.ComponentVMs[0].Click.Execute(null);
            Assert.NotNull(PlayerBaseVM.BoardVM.SelectedComponent);
            PlayerBaseVM.BoardVM.SelectedComponent.UnitsCapabilitiesVMs[0].StartBuilding.Execute(null);
            Assert.AreEqual(3, PlayerBaseVM.BoardVM.ComponentVMs.Count, "There should be 3 components now!");
        }
    }
}
