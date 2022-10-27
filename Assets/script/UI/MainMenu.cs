using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPane;
    [SerializeField] private GameObject levelSelectPane;
    [SerializeField] private GameObject controlPane;
    [SerializeField] private GameObject optionPane;
    [SerializeField] private GameObject creditPane;
    [SerializeField] private CharachterProperties properties;
    [SerializeField] private int buttonToChange;




    // Deprecated
    //public DeselectedCallback deselectedCallback;

    private void Awake()
    {
        mainMenuPane = GameObject.Find("MainMenu");
        levelSelectPane = GameObject.Find("LevelSelect");
        controlPane = GameObject.Find("Control");
        optionPane = GameObject.Find("Option");
        creditPane = GameObject.Find("Credit");

 //       mainMenuPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);
        creditPane.SetActive(false);

    }


    public void ChangeButton(int buttonToChange)
    {
        // pop up
        this.buttonToChange = buttonToChange;
    }

    public void ChangeOnWalkLeftButton(int newButton)
    {
        if(buttonToChange == 0)
        {
            properties.walkLeft = newButton;
        }else if(buttonToChange == 1)
        {
            properties.walkRight = newButton;
        }else if(buttonToChange == 2)
        {
            properties.jump = newButton;
        }else if (buttonToChange == 3)
        {
            properties.interact = newButton;
        }else if(buttonToChange == 4)
        {
            properties.pause = newButton;
        }

        SaveSystemLoader.SaveData(properties);
    }

    public void SettingsOnClick()
    {
        mainMenuPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        creditPane.SetActive(false);
        optionPane.SetActive(true);
        

    }

    public void BackOnClick()
    {
        if (mainMenuPane != null) mainMenuPane.SetActive(!mainMenuPane.active);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);
        creditPane.SetActive(false);

    }

    public void StartOnClick()
    {
        mainMenuPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);
        creditPane.SetActive(false);

        levelSelectPane.SetActive(true);
    }

    public void ControlOnClick()
    {
        mainMenuPane.SetActive(false);
        optionPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(true);
        creditPane.SetActive(false);

    }

    public void Credit()
    {
        mainMenuPane.SetActive(false);
        optionPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        creditPane.SetActive(true);
    }
    public void ExitOnClick()
    {
        if (mainMenuPane != null) mainMenuPane.SetActive(false);
        Application.Quit();
    }



   // public delegate void DeselectedCallback();
}
