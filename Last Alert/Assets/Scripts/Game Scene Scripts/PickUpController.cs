using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    public bool holdingObject = false;
    public string pickUpObjectTag = "Moveble";
    public float pickUpDistance = 5;

    public GameObject objectHolderRef;
    public GameObject cameraRef;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void TryMoveObject() {
        //Check if no objects are held
        if (holdingObject == false) {
            //Check if the players wants to pick up an object
            PickUpObject();
        } else {
            //Move object
            MoveObject();
            //Check if the player wants to drop the object
            DropObject();
        }
    }

    private void PickUpObject() {
        //Check if key is pressed
        if (Input.GetKeyDown(KeyboardController.objectPickUpKey)) {
            //See if there is a object in front of the player
            RaycastHit hit;
            if (Physics.Raycast(cameraRef.transform.position, cameraRef.transform.TransformDirection(Vector3.forward), out hit, pickUpDistance)) {
                //Check if the object has the pick up tag
                if (hit.transform.tag == pickUpObjectTag) {
                    holdingObject = true;
                    //Set the objects parent to the holder object
                    hit.transform.parent = objectHolderRef.transform;
                    //Disable the physics on the object if any
                    Rigidbody rigidbody = hit.transform.GetComponent<Rigidbody>();
                    if (rigidbody != null) {
                        rigidbody.isKinematic = true;
                    }
                }
            }
        }
    }

    private void MoveObject() {

    }

    private void DropObject() {
        //Check if key is pressed
        if (Input.GetKeyDown(KeyboardController.objectPickUpKey)) {
            //Release object from holder
            Transform movingObject = objectHolderRef.transform.GetChild(0);
            movingObject.parent = null;
            //Enable the physics on the object if any
            Rigidbody rigidbody = movingObject.GetComponent<Rigidbody>();
            if (rigidbody != null) {
                rigidbody.isKinematic = false;
            }
            holdingObject = false;
        }
    }
}