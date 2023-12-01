using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace AppInfrastructure
{
    public class SceneLoader : SingletonPersistent<SceneLoader>
    {   
        /// <summary>
        /// Gets a scene name and loads it into game. 
        /// </summary>
        /// <param name="sceneName"></param>
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
