using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingAnimation : MonoBehaviour
{
    [SerializeField] private float maxRight;
    [SerializeField] private float maxLeft;
    [SerializeField] private float currentValue;
    [SerializeField] private float speed;
    [SerializeField] private RectTransform rectTransform;
    bool right = true;
    private void Awake()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if(right)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + Time.deltaTime * speed, rectTransform.anchoredPosition.y);
            if(rectTransform.anchoredPosition.x > maxRight) right = !right;
           
        }
        else
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - Time.deltaTime * speed, rectTransform.anchoredPosition.y);
            if (rectTransform.anchoredPosition.x < maxLeft) right = !right;
        }
    }
}
