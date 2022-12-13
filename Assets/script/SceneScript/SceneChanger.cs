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
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        speed = 250;
        loadingScreen = GameObject.Find("Loading").GetComponent<LoadingScreen>();
        charachterProperties = Resources.Load<CharachterProperties>("CharachterData");
        loadingScreen.gameObject.SetActive(false);
        if(sceneIndex == 0)
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>().PlayBGM(0);

        else if (sceneIndex == 9)
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>().PlayBGM(3);

        else
            GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>().PlayBGM((sceneIndex % 2)+1);



        if (sceneIndex != 0)
        {
            loadingScreen.gameObject.SetActive(true);
            StartCoroutine( loadingScreen.FadeIn());
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        if(sceneIndex <= charachterProperties.level || sceneIndex == 9)
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
        if (sceneIndex+1 > 6)
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
        if(charachterProperties.level < sceneIndex && sceneIndex != 9)
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
