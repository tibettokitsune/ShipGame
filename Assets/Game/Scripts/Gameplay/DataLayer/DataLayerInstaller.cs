using Game.Scripts.Gameplay.DataLayer.Wind;
using Zenject;

namespace Game.Scripts.Gameplay.DataLayer
{
    public class DataLayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WindDataProvider>().AsSingle();
        }
    }
}