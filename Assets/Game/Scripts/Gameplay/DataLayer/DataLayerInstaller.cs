using Zenject;

namespace Game.Scripts.Gameplay.DataLayer
{
    public class DataLayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerDataProvider>().AsSingle();
        }
    }
}