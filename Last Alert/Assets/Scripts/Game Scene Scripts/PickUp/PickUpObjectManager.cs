using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectManager : MonoBehaviour {
    private PickUp[] pickUpObjects;

    public void GetAllPickUps() {
        pickUpObjects = FindObjectsOfType<PickUp>();
    }

    //Pause all pickups
    public void PauseAll() {
        foreach (PickUp pickUp in pickUpObjects) {
            pickUp.Pause();
        }
    }

    //Unpause all pickups
    public void UnpauseAll() {
        foreach (PickUp pickUp in pickUpObjects) {
            pickUp.Unpause();
        }
    }
}