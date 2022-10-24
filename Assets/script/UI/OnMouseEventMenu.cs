using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OnMouseEventMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Color32 textNormalColor;
    [SerializeField] private Color32 textSelectedColor;
    private bool isSelected;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseOver()
    {


        Debug.Log("Hover");
    }

    private void OnMouseExit()
    {
        if (isSelected)
            return;
        if (text != null) text.color = textNormalColor;
        Debug.Log("Exit");

    }

    private void OnMouseDown()
    {
        if (text != null)
            return;
        
        text.color = textSelectedColor;
        Debug.Log("Clicked");

    }

    public void Deselected()
    {
        if (text != null)
            return;

        Debug.Log("Callback Success");
        text.color = textNormalColor;
        isSelected = false;

    }
}
