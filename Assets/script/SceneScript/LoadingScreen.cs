using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Sprite[] loadingscreens;
    public Image image;
    public Image imageFilled;
    public float speed;
    public Color32 color;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public IEnumerator FadeIn()
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
            image.color = new Color32(0, 0, 0, a);
            yield return new WaitForSeconds(0.01f);
        }
        this.gameObject.SetActive(false);

        yield return null;

    }




    //public IEnumerator OpenLoadingScreen()
    //{
    //    int max = loadingscreens.Length;
    //    int i = 0;
    //    while(i < max)
    //    {
    //        image.sprite = loadingscreens[i++];
    //        yield return new WaitForSecondsRealtime(2f);
    //    }
    //}

    //public IEnumerator CloseLoadingScreen()
    //{
    //    int max = 0;
    //    int i = loadingscreens.Length-1;
    //    while (i >= max)
    //    {
    //        image.sprite = loadingscreens[i--];
    //        yield return new WaitForSecondsRealtime(2f);
    //        this.gameObject.SetActive(false);
    //    }
    //}

    private void OnEnable()
    {
        image = GetComponent<Image>();
    }
}
