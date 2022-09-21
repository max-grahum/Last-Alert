using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//data structure to hold data
[System.Serializable]
public class PlayerData
{
    public float[] position;
    public bool saveExists;

    public float timer;

    //constructor
    public PlayerData(Transform player, bool saveExists)
    {
        this.position = new float[3];
        this.saveExists = true;

        if (player != null)
        {
            this.position[0] = player.position.x;
            this.position[1] = player.position.y;
            this.position[2] = player.position.z;

        }
        else
        {
            this.position[0] = 0.0f;
            this.position[1] = 0.0f;
            this.position[2] = 0.0f;
        }
        this.timer = 0;
    }

}
