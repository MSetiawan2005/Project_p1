using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneProperties", order = 1)]
public class SceneProperties : ScriptableObject
{
    public int sceneToChange;
    public GameObject[] objectsToEnable;
}
