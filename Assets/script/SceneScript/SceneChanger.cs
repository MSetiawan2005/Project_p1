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

    public void NextLevel(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex + 1));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        AsyncOperation loadedScene = SceneManager.LoadSceneAsync(sceneIndex);
        if(charachterProperties.level < sceneIndex)
        {
            charachterProperties.level = sceneIndex;
            SaveSystemLoader.SaveData(charachterProperties);
        }

        loadingScreen.gameObject.SetActive(true);
        //StartCoroutine(loadingScreen.OpenLoadingScreen());
        while (!loadedScene.isDone)
        {
            loadingScreen.imageFilled.fillAmount += (Time.deltaTime / 5);
            yield return null;
            loadingScreen.gameObject.SetActive(false);
            //StartCoroutine(loadingScreen.CloseLoadingScreen());
        }
    }
}
