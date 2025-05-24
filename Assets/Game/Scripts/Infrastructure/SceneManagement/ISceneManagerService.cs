using System.Threading.Tasks;

namespace Game.Scripts.Infrastructure.SceneManagement
{
    public enum SceneLayer
    {
        GameStage
    }

    public interface ISceneManagerService
    {
        Task LoadScene(string sceneName, SceneLayer layer, bool isActivateAfterLoad = false);
    }
}