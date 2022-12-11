using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OnMouseEventMenu : MonoBehaviour
{
    public GameObject pausePane { get; private set; }
    public GameObject settingPane { get; private set; }


    private void Start()
    {
        pausePane = GameObject.Find("PausePane");
        settingPane = GameObject.Find("SettingPane");

        Button resume = GameObject.Find("Resume").GetComponent<Button>();
        if (resume == null)
        {
            Debug.Log("Please add Button Component to UI Object named with Resume ");
        }

        Button retry = GameObject.Find("Retry").GetComponent<Button>();
        if (retry == null)
        {
            Debug.Log("Please add Button Component to UI Object named with Retry ");
        }

        Button setting = GameObject.Find("Setting").GetComponent<Button>();
        if (setting == null)
        {
            Debug.Log("Please add Button Component to UI Object named with Setting ");
        }

        Button mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
        if (mainMenu == null)
        {
            Debug.Log("Please add Button Component to UI Object named with MainMenu ");
        }

        Button backSetting = GameObject.Find("BackSettingPane").GetComponent<Button>();
        if (backSetting == null)
        {
            Debug.Log("Please add Button Component to UI Object named with BackSettingPane ");
        }

//        Button restart = GameObject.Find("Restart").GetComponent<Button>();
//        if (restart == null)
//        {
//            Debug.Log("Please add Button Component to UI Object named with Back ");
//        }


        resume.GetComponent<Button>().onClick.AddListener(ResumeOnClick);
        retry.GetComponent<Button>().onClick.AddListener(RetryOnClick);
        setting.GetComponent<Button>().onClick.AddListener(SettingOnClick);
        mainMenu.GetComponent<Button>().onClick.AddListener(MainMenuOnClick);
        backSetting.GetComponent<Button>().onClick.AddListener(BackOnClick);
 //       restart.GetComponent<Button>().onClick.AddListener(RestartOnClick);

        pausePane.SetActive(false);
        settingPane.SetActive(false);
    }

    public void Pause()
    {
        pausePane.SetActive(!pausePane.active);

    }

    public void ResumeOnClick()
    {
        pausePane.SetActive(false);
        Time.timeScale = (Time.timeScale + 1) % 2;
    }

    public void RetryOnClick()
    {
        Time.timeScale = (Time.timeScale + 1) % 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartInTime(float time)
    {
        Invoke("RestartOnClick", time);

    }

    public void SettingOnClick()
    {
        settingPane.SetActive(true);
    }
    public void MainMenuOnClick()
    {
        Time.timeScale = (Time.timeScale + 1) % 2;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneChanger>().BackToMainMenu();
    }

    public void BackOnClick()
    {
        settingPane.SetActive(false);
    }


}
