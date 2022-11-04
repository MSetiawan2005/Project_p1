using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] TextMeshProUGUI sentence;
    [SerializeField] GameObject DialogPane;
    [SerializeField] int index;
    [SerializeField] DialogProperties dialog;
    [SerializeField] bool isTalking;


    private void Start()
    {
        DialogPane = GameObject.Find("DialogPane");
        sentence = GameObject.Find("DialogText").GetComponent<TextMeshProUGUI>();
        characterName = GameObject.Find("CharacterNameText").GetComponent<TextMeshProUGUI>();
        GameObject.Find("NextSentence").GetComponent<Button>().onClick.AddListener(Talk);
        DialogPane.SetActive(false);
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Dialog")
        {
            DialogPane.SetActive(true);
            dialog = collision.GetComponent<DialogProperties>();
            if (!isTalking)
            {
                isTalking = true;
                sentence.text = "";
                characterName.text = "";
                Talk();
            }
        }
    }

    public void Talk()
    {

        if (index >= dialog.sentences.Length)
        {
            EndTalk();
            return;
        }
        characterName.text = dialog.sentences[index].characterName;
        sentence.text = dialog.sentences[index].sentence;
        dialog.DoSentenceAction(index);
        index++;
    }

    void EndTalk()
    {
        DialogPane.SetActive(false);
        isTalking = false;
        index = 0;
        Destroy(dialog.gameObject);
        dialog = null;
    }
}
