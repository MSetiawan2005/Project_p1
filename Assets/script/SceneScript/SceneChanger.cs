using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] LoadingScreen loadingScreen;
    public CharachterProperties charachterProperties { get; private set; }
    bool isLoaded;
    [SerializeField] private float speed;

    private void Start()
    {
        speed = 250;
        loadingScreen = GameObject.Find("Loading").GetComponent<LoadingScreen>();
        charachterProperties = Resources.Load<CharachterProperties>("CharachterData");
        loadingScreen.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>().PlayBGM(SceneManager.GetActiveScene().buildIndex);
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            loadingScreen.gameObject.SetActive(true);
            StartCoroutine( loadingScreen.FadeIn());
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        if(sceneIndex <= charachterProperties.level )
        {
            
            loadingScreen.gameObject.SetActive(true);
            StartCoroutine(LoadingScreen(sceneIndex, true));
        }
    }

    public void ChangeSceneOnClick(int sceneIndex)
    {
        if (sceneIndex <= charachterProperties.level)
        {

            loadingScreen.gameObject.SetActive(true);
            StartCoroutine(LoadingScreen(sceneIndex, false));
        }
    }

    public void RestartData()
    {
        charachterProperties.hasPassedTutorialOne = false;
        charachterProperties.level = 1;
        charachterProperties.hasShowTimeLine = false;
    }

    public void BackToMainMenu()
    {
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine(LoadingScreen(0, false));
    }

    IEnumerator LoadingScreen(int sceneIndex, bool isInGame)
    {
        if (!isInGame)
        {
            loadingScreen.image.color = loadingScreen.color;
            while (loadingScreen.imageFilled.fillAmount < 1)
            {
                loadingScreen.imageFilled.fillAmount += Time.deltaTime / 5;
                yield return null;
            }
        }
        else
        {
            byte a = 0;
            while (a < 255)
            {

                if (a + (byte)(Time.deltaTime * speed) > 255)
                {
                    a = 255;
                }
                else
                {
                    a += (byte)(Time.deltaTime * speed);

                }
                loadingScreen.image.color = new Color32(0, 0, 0, a);
                yield return new WaitForSeconds(0.01f);
            }
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
        StartCoroutine(LoadingScreen(sceneIndex + 1, true));
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
