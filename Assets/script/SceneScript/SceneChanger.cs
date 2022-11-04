using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] LoadingScreen loadingScreen;
    public CharachterProperties charachterProperties { get; private set; }
    bool isLoaded;

    private void Start()
    {
        loadingScreen = GameObject.Find("Loading").GetComponent<LoadingScreen>();
        charachterProperties = Resources.Load<CharachterProperties>("CharachterData");
        loadingScreen.gameObject.SetActive(false);
    }

    public void ChangeScene(int sceneIndex)
    {
        if(sceneIndex <= charachterProperties.level )
        {
            loadingScreen.gameObject.SetActive(true);

            StartCoroutine(LoadingScreen(sceneIndex));
        }

    }

    public void BackToMainMenu()
    {
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine(LoadingScreen(0));
    }

    IEnumerator LoadingScreen(int sceneIndex)
    {
        while (loadingScreen.imageFilled.fillAmount < 1)
        {
            loadingScreen.imageFilled.fillAmount += Time.deltaTime / 5;
            yield return null;
        }
        StartCoroutine(LoadScene(sceneIndex));
    }

    public void NextLevel(int sceneIndex)
    {
        if (sceneIndex+1 > 3)
        {
            BackToMainMenu();
            return;
        }
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine(LoadingScreen(sceneIndex + 1));
    }

    IEnumerator LoadScene(int sceneIndex)
    {

        AsyncOperation loadedScene = SceneManager.LoadSceneAsync(sceneIndex);
        Debug.Log("Masuk");
        if(charachterProperties.level < sceneIndex)
        {
            charachterProperties.level = sceneIndex;
            SaveSystemLoader.SaveData(charachterProperties);
        }


        //StartCoroutine(loadingScreen.OpenLoadingScreen());
        while (!loadedScene.isDone)
        {
            yield return null;
            //StartCoroutine(loadingScreen.CloseLoadingScreen());
        }
    }
}
