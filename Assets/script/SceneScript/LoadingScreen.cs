using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Sprite[] loadingscreens;
    [SerializeField] Image image;
    
    private void Start()
    {
        image = GetComponent<Image>();
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
