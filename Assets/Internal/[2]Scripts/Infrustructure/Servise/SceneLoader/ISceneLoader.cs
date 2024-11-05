using System;

namespace Infrustructure.Service.SceneLoader
{
    public interface ISceneLoader
    {
        public void LoadScene(string  sceneName, Action onLoaded = null);
    }
}
