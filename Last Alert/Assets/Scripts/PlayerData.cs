using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//data structure to hold data
[System.Serializable]
public class PlayerData
{
    public float[] position;

    public float timer;

    //constructor
    public PlayerData(Transform player){
        this.position = new float[3];
        this.position[0] = player.position.x;
        this.position[1] = player.position.y;
        this.position[2] = player.position.z;

        this.timer = 0;
    }

}
