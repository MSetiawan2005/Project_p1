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
        CharachterProperties c = Resources.Load<CharachterProperties>("CharachterData");

        if (this.name == "TutorialOne" && c.hasPassedTutorialOne)
        {
            Destroy(this.gameObject);
        }
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
                case SentenceAction.PassOne:
                    Resources.Load<CharachterProperties>("CharachterData").hasPassedTutorialOne = true;
                    SaveSystemLoader.SaveData(Resources.Load<CharachterProperties>("CharachterData"));
                    break;
                case SentenceAction.PassTwo:
                    Resources.Load<CharachterProperties>("CharachterData").hasPassedTutorialTwo = true;
                    SaveSystemLoader.SaveData(Resources.Load<CharachterProperties>("CharachterData"));
                    break;
                case SentenceAction.PassThree:
                    Resources.Load<CharachterProperties>("CharachterData").hasPassedTutorialThree = true;
                    SaveSystemLoader.SaveData(Resources.Load<CharachterProperties>("CharachterData"));
                    break;

            }
        }
        return false;
    }
}
