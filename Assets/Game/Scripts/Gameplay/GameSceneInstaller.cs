using Game.Scripts.Gameplay.DataLayer;
using Game.Scripts.Gameplay.PresentersLayer;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<DataLayerInstaller>();
            Container.Install<PresentersLayerInstaller>();
            Container.BindInterfacesTo<GameManager>().AsSingle();
        }
    }
}