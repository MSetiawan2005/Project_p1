using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPane;
    [SerializeField] private GameObject levelSelectPane;
    [SerializeField] private GameObject controlPane;
    [SerializeField] private GameObject optionPane;




    // Deprecated
    //public DeselectedCallback deselectedCallback;

    private void Awake()
    {
        mainMenuPane = GameObject.Find("MainMenu");
        levelSelectPane = GameObject.Find("LevelSelect");
        controlPane = GameObject.Find("Control");
        optionPane = GameObject.Find("Option");

 //       mainMenuPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);

    }

    public void SettingsOnClick()
    {
        mainMenuPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(true);

    }

    public void BackOnClick()
    {
        if (mainMenuPane != null) mainMenuPane.SetActive(!mainMenuPane.active);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);
    }

    public void StartOnClick()
    {
        mainMenuPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);
        levelSelectPane.SetActive(true);
    }

    public void ControlOnClick()
    {
        mainMenuPane.SetActive(false);
        optionPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(true);
    }

    public void ExitOnClick()
    {
        if (mainMenuPane != null) mainMenuPane.SetActive(false);
        Application.Quit();
    }

   // public delegate void DeselectedCallback();
}
