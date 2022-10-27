using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData { 

    public int level;
    public int walkLeft;
    public int walkRight;
    public int interact;
    public int jump;
    public int pause;

    public SaveData(CharachterProperties properties)
    {
        this.level = properties.level;
        this.walkLeft = properties.walkLeft;
        this.walkRight = properties.walkRight;
        this.interact = properties.interact;
        this.jump = properties.jump;
        this.pause = properties.pause;
    }
}
