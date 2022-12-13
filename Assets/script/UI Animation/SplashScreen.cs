using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public Image image;
    public Image background;
    public float speed;
    public Color32 color;

    private void Start()
    {
        CharachterProperties charachterProperties = Resources.Load<CharachterProperties>("CharachterData");
        if (charachterProperties.hasShowSplashScreen)
        {
            Destroy(background.gameObject);
        }
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeBackground()
    {
        byte a = 255;
        while (a > 0)
        {

            if (a - (byte)(Time.deltaTime * speed) < 0)
            {
                a = 0;
            }
            else
            {
                a -= (byte)(Time.deltaTime * speed);

            }
            background.color = new Color32(0, 0, 0, a);
            yield return new WaitForSeconds(0.01f);
        }
        CharachterProperties charachterProperties = Resources.Load<CharachterProperties>("CharachterData");
        charachterProperties.hasShowSplashScreen = true;
        yield return null;
        Destroy(background.gameObject);
    }

    public IEnumerator FadeOut()
    {
        this.gameObject.SetActive(true);
        byte a = 255;
        while (a > 0)
        {

            if (a - (byte)(Time.deltaTime * speed) < 0)
            {
                a = 0;
            }
            else
            {
                a -= (byte)(Time.deltaTime * speed);

            }
            image.color = new Color32(255, 255, 255, a);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FadeBackground());
    }

    public IEnumerator FadeIn()
    {
        this.gameObject.SetActive(true);
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
            image.color = new Color32(255, 255, 255, a);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
        yield return null;

    }
}
