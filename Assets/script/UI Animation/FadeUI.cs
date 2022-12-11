using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    [SerializeField] private byte thresholdFadeIn;
    [SerializeField] private byte thresholdFadeOut;
    [SerializeField] private float speed;
    [SerializeField] private byte currentValue;

    [SerializeField] private Image levelBackground;
    [SerializeField] private Sprite[] spriteLevelBackgrounds;
    [SerializeField] private Image[] selector;

    private int levelTemp = 1;

    private void Awake()
    {
        levelBackground = this.GetComponent<Image>();
        currentValue = thresholdFadeIn;


        for (int i = 0; i < selector.Length; i++)
        {
            if (0 == i) selector[i].gameObject.SetActive(true);
            else selector[i].gameObject.SetActive(false);
        }
    }

    public void LevelSelect(int level)
    {
        if (level == levelTemp)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneChanger>().ChangeSceneOnClick(level);
            return;
        }

        for (int i = 0; i < selector.Length; i++)
        {
            if (level - 1 == i) selector[i].gameObject.SetActive(true);
            else selector[i].gameObject.SetActive(false);
        }

        if (levelTemp != 0)
        {
            StopAllCoroutines();
            StartCoroutine(levelBackground.GetComponent<FadeUI>().
                FadeOut(levelBackground, spriteLevelBackgrounds[level - 1])
                );
        }

        levelTemp = level;

    }

    public IEnumerator FadeIn(Image image)
    {
        byte a = currentValue;
        while (a < thresholdFadeIn)
        {

            if (a + (byte)(Time.deltaTime * speed) > thresholdFadeIn)
            {
                a = thresholdFadeIn;
            }
            else
            {
                a += (byte)(Time.deltaTime * speed);

            }
            currentValue = a;
            image.color = new Color32(a, a, a, 255);
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    public IEnumerator FadeOut(Image from, Sprite toChange)
    {
        byte a;
        a = currentValue;
        while (a > thresholdFadeOut)
        {

            if (a - (byte)(Time.deltaTime * speed) < thresholdFadeOut)
            {
                a = thresholdFadeOut;
            }
            else
            {
                a -= (byte)(Time.deltaTime * speed);

            }
            currentValue = a;
            from.color = new Color32(a, a, a, 255);
            yield return new WaitForSeconds(0.01f);
        }
        from.sprite = toChange;
        
        StartCoroutine(FadeIn(from));
        yield return null;
    }
}
