using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Image[] inactive;

    private void Start()
    {
        CharachterProperties properties = Resources.Load<CharachterProperties>("CharachterData");
        for (int i = 0; i < inactive.Length; i++)
        {
            if (i < properties.level)
            {
                inactive[i].gameObject.SetActive(false);
            }
            else
            {
                inactive[i].gameObject.SetActive(true);
            }
        }

    }
}
