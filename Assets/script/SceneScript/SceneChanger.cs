using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] LoadingScreen loadingScreen;
    [SerializeField] CharachterProperties charachterProperties;

    public void ChangeScene(int sceneIndex)
    {
        if(sceneIndex + 1 <= charachterProperties.level ) 
            StartCoroutine(LoadScene(sceneIndex));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        AsyncOperation loadedScene = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.gameObject.SetActive(true);
        //StartCoroutine(loadingScreen.OpenLoadingScreen());
        while (!loadedScene.isDone)
        {
            yield return null;
            loadingScreen.gameObject.SetActive(false);
            //StartCoroutine(loadingScreen.CloseLoadingScreen());
        }
    }
}
