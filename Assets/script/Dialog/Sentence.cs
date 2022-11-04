using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sentence", menuName = "ScriptableObjects/Sentence", order = 3)]
public class Sentence : ScriptableObject
{
    public string characterName;
    [TextArea]
    public string sentence;
    public bool isDoingAction;
    public SentenceAction action;
    public Sprite[] images;
}

public enum SentenceAction
{
    PopUpImage,
    PopUpMultipleImage,
    CloseDialog,
    PassOne,
    PassTwo,
    PassThree,

}
