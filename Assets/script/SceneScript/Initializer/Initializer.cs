using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initializer : MonoBehaviour
{
    public GameObject LoadingPrefab;
    [SerializeField] private Toggle audioMaster;
    [SerializeField] private Toggle sfx;
    [SerializeField] private Toggle bgm;
    [SerializeField] private CharachterProperties properties;
    [SerializeField] private SoundController audioController;

    private void Awake()
    {
        LoadingPrefab = Resources.Load("Loading") as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        GameObject loading = GameObject.Instantiate(LoadingPrefab, canvas.transform);
        loading.name = "Loading";
        loading.SetActive(true);
        audioController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        properties = Resources.Load<CharachterProperties>("CharachterData");
        audioMaster.isOn = properties.audioMaster;
        bgm.isOn = properties.bgm;
        sfx.isOn = properties.sfx;
/*        fullscreen.isOn = properties.isFullscreen;*/


        if (GetComponent<SceneChanger>() == null)
            gameObject.AddComponent<SceneChanger>();

        if (canvas.GetComponent<OnMouseEventMenu>() == null)
            canvas.AddComponent<OnMouseEventMenu>();

        if (player.GetComponent<DialogLoader>() == null)
        {
            player.AddComponent<DialogLoader>();
        }


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
/*        properties.isFullscreen = fullscreen.isOn;*/
    }


}
