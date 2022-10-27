using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharachterData", menuName = "ScriptableObjects/CharachterProperties", order = 1)]
public class CharachterProperties : ScriptableObject
{
    public int level;
    public int walkLeft;
    public int walkRight;
    public int interact;
    public int jump;
    public int pause;

}
