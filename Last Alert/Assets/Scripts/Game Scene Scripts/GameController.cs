using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Game state
    public GameState gameState;

    //References
    public PlayerController playerControllerRef;
    //public PickUpController pickUpControllerRef;

    //Start is called before the first frame update
    void Start() {
        //ChangeGameState(GameState.STARTMENU);
        ChangeGameState(GameState.GAME);
    }

    //Update is called once per frame
    void Update() {
        if (gameState == GameState.STARTMENU) {

        } else if (gameState == GameState.SETTINGMENU) {

        } else if (gameState == GameState.CUTSCENE) {

        } else if (gameState == GameState.TUTORIAL) {
            playerControllerRef.MovePlayer();
            playerControllerRef.MoveCamera();

        } else if (gameState == GameState.GAME) {
            playerControllerRef.MovePlayer();
            playerControllerRef.MoveCamera();
            //pickUpControllerRef.TryMoveObject();

            //Example of teleporting the player
            if (Input.GetKey(KeyCode.L)) {
                playerControllerRef.SetLocation(new Vector3(0, 0, 0));
                playerControllerRef.SetCameraAngle(new Vector2(0, 0));
            }


            //Example code of scene switching to make sure it works
            if (Input.GetKeyDown(KeyCode.J)) {
                SceneController.SwitchToStartScene();
            }

        } else if (gameState == GameState.FINISHMENU) {

        }
    }

    //Actions which need to be done on the change state call
    public void ChangeGameState(GameState newGameState) {
        if (newGameState == GameState.STARTMENU) {
            MouseController.UnlockMouse();
        } else if (newGameState == GameState.SETTINGMENU) {
            MouseController.UnlockMouse();
            PauseGame();
        } else if (newGameState == GameState.CUTSCENE) {
        } else if (newGameState == GameState.TUTORIAL) {
            MouseController.LockMouse();
        } else if (newGameState == GameState.GAME) {
            MouseController.LockMouse();
        } else if (newGameState == GameState.FINISHMENU) {
            MouseController.UnlockMouse();
        }
        //Change state
        gameState = newGameState;
    }

    private void PauseGame() {
        //Pauses objects
    }
}

//Game scene states
public enum GameState {
    STARTMENU,
    SETTINGMENU,
    CUTSCENE,
    TUTORIAL,
    GAME,
    FINISHMENU
}