using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPane;
    [SerializeField] private GameObject levelSelectPane;
    [SerializeField] private GameObject controlPane;
    [SerializeField] private GameObject optionPane;
    [SerializeField] private GameObject creditPane;
    [SerializeField] private Image levelBackground;
    [SerializeField] private CharachterProperties properties;
    [SerializeField] private int buttonToChange;
    [SerializeField] private Toggle audioMaster;
    [SerializeField] private Toggle sfx;
    [SerializeField] private Toggle bgm;
    [SerializeField] private Toggle fullscreen;
    [SerializeField] private SoundController audioController;
    [SerializeField] GameObject[] inactive;


    // Deprecated
    //public DeselectedCallback deselectedCallback;

    private void Awake()
    {
       
        levelBackground = GameObject.Find("LevelBackground").GetComponent<Image>();
        mainMenuPane = GameObject.Find("MainMenu");
        levelSelectPane = GameObject.Find("LevelSelect");
        controlPane = GameObject.Find("Control");
        optionPane = GameObject.Find("Option");
        creditPane = GameObject.Find("Credit");
        properties = Resources.Load<CharachterProperties>("CharachterData");
        audioController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();


        for (int i = 0; i < inactive.Length; i++)
        {
            if(i < properties.level)
            {
                inactive[i].SetActive(false);
            }
            else
            {
                inactive[i].SetActive(true);
            }
        }

        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);
        creditPane.SetActive(false);
        levelBackground.gameObject.SetActive(false);

        audioMaster.isOn = properties.audioMaster;
        bgm.isOn = properties.bgm;
        sfx.isOn = properties.sfx;
        fullscreen.isOn = properties.isFullscreen;

        Screen.SetResolution(Screen.resolutions[Screen.resolutions.Length-1].width, Screen.resolutions[Screen.resolutions.Length - 1].height, properties.isFullscreen);

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

        audioController.PlaySFX(SFX.Button_Click);
    }

    public void BackOnClick()
    {
        if (mainMenuPane != null) mainMenuPane.SetActive(!mainMenuPane.active);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);
        creditPane.SetActive(false);
        levelBackground.gameObject.SetActive(false);
        audioController.PlaySFX(SFX.Button_Click);

    }

    public void StartOnClick()
    {
        mainMenuPane.SetActive(false);
        controlPane.SetActive(false);
        optionPane.SetActive(false);
        creditPane.SetActive(false);
        levelBackground.gameObject.SetActive(true);
        audioController.PlaySFX(SFX.Button_Click);

        levelSelectPane.SetActive(true);
    }

    public void ControlOnClick()
    {
        mainMenuPane.SetActive(false);
        optionPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(true);
        creditPane.SetActive(false);
        audioController.PlaySFX(SFX.Button_Click);

    }

    public void Credit()
    {
        mainMenuPane.SetActive(false);
        optionPane.SetActive(false);
        levelSelectPane.SetActive(false);
        controlPane.SetActive(false);
        creditPane.SetActive(true);
        audioController.PlaySFX(SFX.Button_Click);

    }
    public void ExitOnClick()
    {
        if (mainMenuPane != null) mainMenuPane.SetActive(false);
        Application.Quit();
    }

    public void OnAudioMaster()
    {
        properties.audioMaster = audioMaster.isOn;
        sfx.interactable = audioMaster.isOn;
        bgm.interactable = audioMaster.isOn;
        if (!audioMaster.isOn) audioController.MasterMuteOption(!audioMaster.isOn);
        else
        {
            audioController.SFXMuteOption(!sfx.isOn);
            audioController.BGMMuteOption(!bgm.isOn);

        }
    }

    public void OnSFX()
    {
        properties.sfx = sfx.isOn;
        audioController.SFXMuteOption(!sfx.isOn);
    }

    public void OnBGM()
    {
        properties.bgm = bgm.isOn;
        audioController.BGMMuteOption(!bgm.isOn);
    }

    public void OnFullscreen()
    {
        properties.isFullscreen = fullscreen.isOn;
    }


    // public delegate void DeselectedCallback();
}
