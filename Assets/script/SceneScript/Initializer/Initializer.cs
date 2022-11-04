using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initializer : MonoBehaviour
{
    public GameObject LoadingPrefab;
    private void Awake()
    {
        LoadingPrefab = Resources.Load("Loading") as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        GameObject loading = GameObject.Instantiate(LoadingPrefab, canvas.transform);
        loading.name = "Loading";
        loading.SetActive(true);

        GameObject player = GameObject.FindGameObjectWithTag("Player");



        if (GetComponent<SceneChanger>() == null)
            gameObject.AddComponent<SceneChanger>();

        if (canvas.GetComponent<OnMouseEventMenu>() == null)
            canvas.AddComponent<OnMouseEventMenu>();

        if (player.GetComponent<DialogLoader>() == null)
        {
            player.AddComponent<DialogLoader>();
        }

    }


}
