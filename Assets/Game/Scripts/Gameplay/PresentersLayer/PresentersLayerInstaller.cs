using Game.Scripts.Gameplay.PresentersLayer.Ships;
using Game.Scripts.Gameplay.PresentersLayer.Wind;
using Zenject;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class PresentersLayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerPresenter>().AsSingle();
            Container.BindInterfacesTo<WindPresenter>().AsSingle();
        }
    }
}