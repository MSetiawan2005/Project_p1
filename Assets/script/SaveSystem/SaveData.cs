using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData { 

    public int level;
    public int walkLeft;
    public int walkRight;
    public int interact;
    public int jump;
    public int pause;
    public bool hasPassedTutorialOne;
    public bool hasPassedTutorialTwo;
    public bool hasPassedTutorialThree;

    public SaveData(CharachterProperties properties)
    {
        this.level = properties.level;
        this.walkLeft = properties.walkLeft;
        this.walkRight = properties.walkRight;
        this.interact = properties.interact;
        this.jump = properties.jump;
        this.pause = properties.pause;
        this.hasPassedTutorialOne = properties.hasPassedTutorialOne;
        this.hasPassedTutorialTwo = properties.hasPassedTutorialTwo;
        this.hasPassedTutorialThree = properties.hasPassedTutorialThree;

    }
}
