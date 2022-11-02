using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogProperties : MonoBehaviour
{
    public Sentence[] sentences;
    public Image image;

    private void Start()
    {
/*        image = GameObject.Find("Dialog").GetComponent<Image>();*/
    }

    public bool DoSentenceAction(int i)
    {
        if (sentences[i].isDoingAction)
        {
            switch (sentences[i].action)
            {
                case SentenceAction.PopUpImage:
                    image.sprite = sentences[i].images[0];
                    break;
                case SentenceAction.CloseDialog:
                    return true;
                case SentenceAction.PopUpMultipleImage:
                    foreach(Sprite sprite in sentences[i].images)
                    {
                        image.sprite = sprite;
                        // Interval
                    }
                    break;
            }
        }
        return false;
    }
}
