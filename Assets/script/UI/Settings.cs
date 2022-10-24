using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown overallQuality;
    public TMP_Dropdown resolution;
    public Slider brightness;
    public TMP_Text text;
    bool isFullscreen = true;
    private void Awake()
    {
        List<TMP_Dropdown.OptionData> r_datas = new List<TMP_Dropdown.OptionData>();

        foreach (Resolution r in Screen.resolutions)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = r.width + "x" + r.height;
            r_datas.Add(data);            
        }
        overallQuality.SetValueWithoutNotify(5);

        resolution.AddOptions(r_datas);
        Screen.fullScreen = isFullscreen;
        resolution.SetValueWithoutNotify(Screen.resolutions.Length - 1);
    }

    public void OnOverallQualityChange(int val)
    {
        QualitySettings.SetQualityLevel(val);
    }

    public void OnBrightnessChanges()
    {
        // Screen.brightness = brightness.value;
        // Debug.Log(Screen.brightness + " / " + brightness.value);

        text.fontSize =  brightness.value;
    }

    public void OnFullScreen(bool isFullScreen)
    {


        if (isFullScreen)
        {

            Debug.Log("Fullscreen");
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Debug.Log("Not Fullscreen");
            Screen.fullScreenMode = FullScreenMode.Windowed;
            

        }
        this.isFullscreen = isFullScreen;
        Debug.Log(Screen.fullScreenMode);
        Debug.Log(Screen.fullScreen);

    }



    public void OnResolutionsChange(int val)
    {
        Screen.SetResolution(Screen.resolutions[val].width, Screen.resolutions[val].height, isFullscreen);
    }

}
