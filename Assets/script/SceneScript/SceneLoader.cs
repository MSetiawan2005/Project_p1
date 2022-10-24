using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public SceneProperties sceneProperties;
    public CharachterProperties charachterProperties;
    private void Awake()
    {
        foreach (GameObject gameObject in sceneProperties.objectsToEnable) {
            gameObject.SetActive(true);
        }
    }
}
