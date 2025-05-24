using System.Collections.Generic;
using Game.Scripts.Infrastructure.Loading;
using Game.Scripts.Infrastructure.SceneManagement;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Infrastructure
{
    public class ServiceInitializer : IInitializable
    {
        [Inject] private ISceneManagerService _sceneManagerService;
        [Inject] private LoadingScreen _screen;
        private readonly IEnumerable<IAsyncInitializable> _services;

        public ServiceInitializer(IEnumerable<IAsyncInitializable> services)
        {
            _services = services;
        }

        public async void Initialize()
        {
            Debug.Log("Start services initialization");
            using var loading = _screen.Show();
            foreach (var service in _services)
            {
                await service.InitializeAsync();
            }
            Debug.Log("Finish services initialization");
            
            await _sceneManagerService.LoadScene("Game", SceneLayer.GameStage, true);
        }
    }
}