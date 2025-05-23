using Game.Scripts.Infrastructure.Loading;
using Game.Scripts.Infrastructure.SceneManagement;
using Zenject;

namespace Game.Scripts.Infrastructure.Installers
{
    public class BootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingScreen>().FromComponentInHierarchy(true).AsSingle();
            Container.BindInterfacesAndSelfTo<SceneManagerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ServiceInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimerService.TimerService>().AsSingle();
        }
    }
}