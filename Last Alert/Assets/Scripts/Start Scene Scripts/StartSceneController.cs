using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour {
    //Game state
    public StartState startState;

    //References
    //UI controller reference
    //Setting reference
    //etc. etc..


    // Start is called before the first frame update
    void Start() {
        ChangeStartState(StartState.STARTMENU);
    }

    // Update is called once per frame
    void Update() {
        if (startState == StartState.STARTMENU) {

            //Example code of scene switching to make sure it works
            if (Input.GetKeyDown(KeyCode.J)) {
                SceneController.SwitchToGameScene();
            }

        } else if (startState == StartState.SETTINGMENU) {

        } else if (startState == StartState.CUTSCENE) {

        }
    }

    //Actions which need to be done on the change state call
    public void ChangeStartState(StartState newStartState) {
        if (startState == StartState.STARTMENU) {

        } else if (startState == StartState.SETTINGMENU) {

        } else if (startState == StartState.CUTSCENE) {

        }
        //Change state
        startState = newStartState;
    }
}

//Start scene states
public enum StartState {
    STARTMENU,
    SETTINGMENU,
    CUTSCENE
}