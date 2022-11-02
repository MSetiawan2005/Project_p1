using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] TextMeshProUGUI sentence;
    [SerializeField] GameObject DialogPane;
    [SerializeField] int index;
    [SerializeField] DialogProperties dialog;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Dialog" && Input.GetKeyDown(KeyCode.E))
        {
            sentence.text = "";
            characterName.text = "";
            DialogPane.SetActive(true);
            dialog = collision.GetComponent<DialogProperties>();
            Talk();
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
        index++;
    }

    void EndTalk()
    {
        DialogPane.SetActive(false);
        index = 0;
        dialog = null;
    }
}
