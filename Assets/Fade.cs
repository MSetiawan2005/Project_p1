using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fade : MonoBehaviour
{
    TextMeshProUGUI[] text;
    [SerializeField] private float speed;
    private void Start()
    {
        CharachterProperties a = Resources.Load("CharachterData") as CharachterProperties;

        if (a.hasShowTimeLine)
        {
            Destroy(this.gameObject);
        }
        text = GetComponentsInChildren<TextMeshProUGUI>();
        FadeText(0);
    }

    public void FadeText(int i)
    {
        if(i > text.Length - 1)
        {
            CharachterProperties a = Resources.Load("CharachterData") as CharachterProperties;

            a.hasShowTimeLine = true;
            Destroy(this.gameObject);

            return;
        }
        StartCoroutine(gogo(0,i));
    }

    IEnumerator gogo(byte a, int i)
    {
        while(a < 255)
        {
            
            if (a +(byte)(Time.deltaTime * speed) > 255)
            {
                a = 255;
            }
            else
            {
                a += (byte)(Time.deltaTime * speed);

            }
            text[i].color = new Color32(255, 255, 255, a);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2.5f);
        FadeText(i + 1);
    }
}
