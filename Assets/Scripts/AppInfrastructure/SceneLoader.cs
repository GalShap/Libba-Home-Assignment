using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace AppInfrastructure
{
    public class SceneLoader : SingletonPersistent<SceneLoader>
    {
        public void LoadScene(string sceneName)
        {
            try
            {
                SceneManager.LoadScene(sceneName);
            }
            catch (Exception sceneLoadException)
            {
                Debug.LogError(sceneLoadException);
            }
        }
    }
}
