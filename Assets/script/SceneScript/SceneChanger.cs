using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneLoader))]
public class SceneChanger : MonoBehaviour
{
    [SerializeField] SceneProperties sceneProperties;
    [SerializeField] LoadingScreen loadingScreen;

    private void Awake()
    {
        sceneProperties = GetComponent<SceneLoader>().sceneProperties;
    }

    private void Start()
    {
        sceneProperties.sceneToChange = GetComponent<SceneLoader>().charachterProperties.currentScene;
    }

    public void ChangeSceneIndex(int newSceneIndex)
    {
        sceneProperties.sceneToChange = newSceneIndex;
    }

    public void ChangeScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation loadedScene = SceneManager.LoadSceneAsync(sceneProperties.sceneToChange);
        GetComponent<SceneLoader>().charachterProperties.currentScene = sceneProperties.sceneToChange;
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine(loadingScreen.OpenLoadingScreen());
        while (!loadedScene.isDone)
        {
            yield return null;
            StartCoroutine(loadingScreen.CloseLoadingScreen());
        }
    }
}
