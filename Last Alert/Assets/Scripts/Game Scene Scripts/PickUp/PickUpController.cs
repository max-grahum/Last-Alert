using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    public bool holdingObject = false;
    public float pickUpDistance = 5;

    public GameObject objectHolderRef;
    public GameObject cameraRef;

    private PickUp objectRef;

    public void TryMoveObject() {
        //Check if no objects are held
        if (holdingObject == false) {
            //Check if the players wants to pick up an object
            PickUpObject();
        } else {
            //Move object
            MoveObject();
            //Check if the player wants to drop the object
            PutDownObject();
        }
    }

    private void PickUpObject() {
        //Check if key is pressed
        if (Input.GetKeyDown(KeyboardController.objectPickUpKey)) {
            //See if there is a object in front of the player
            if (Physics.Raycast(cameraRef.transform.position, cameraRef.transform.TransformDirection(Vector3.forward), out RaycastHit hit, pickUpDistance)) {
                //Check if the object has the pick up tag
                PickUp tempPickUp = hit.collider.GetComponent<PickUp>();
                if (tempPickUp != null) {
                    holdingObject = true;
                    objectRef = tempPickUp;
                    objectRef.held = true;
                    //Set the objects parent to the holder object
                    objectRef.transform.parent = objectHolderRef.transform;
                    //Disable the physics on the object if any
                    Rigidbody rigidbody = objectRef.rigidbodyRef;
                    if (rigidbody != null) {
                        rigidbody.isKinematic = true;
                    }
                }
            }
        }
    }

    private void MoveObject() {

    }

    private void PutDownObject() {
        //Check if key is pressed
        if (Input.GetKeyDown(KeyboardController.objectPickUpKey)) {
            ReleaseObject();
            holdingObject = false;
        }
    }

    private void ReleaseObject() {
        //Release object from holder
        objectRef.transform.parent = null;
        //Enable the physics on the object if any
        Rigidbody rigidbody = objectRef.rigidbodyRef;
        if (rigidbody != null) {
            rigidbody.isKinematic = false;
        }
        objectRef.held = false;
    }

    public void DropObject(bool dropAtStart) {
        //Check if holding an object
        if (holdingObject == true) {
            holdingObject = false;
            //Drop at start location
            if (dropAtStart == true) {
                //Release object from holder
                objectRef.transform.parent = null;
                //Set to start location
                objectRef.ResetPickUp();
                //Update held reference
                objectRef.held = false;
            } else { //Drop at current location
                ReleaseObject();
            }
        }
    }
}