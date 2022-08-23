using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Game state
    public GameState gameState;

    //References
    public PlayerController playerControllerRef;

    // Start is called before the first frame update
    void Start() {
        //ChangeGameState(GameState.STARTMENU);
        ChangeGameState(GameState.GAME);
    }

    // Update is called once per frame
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

            //example of teleporting the player
            if (Input.GetKey(KeyCode.L)) {
                playerControllerRef.SetLocation(new Vector3(0, 0, 0));
                playerControllerRef.SetCameraAngle(new Vector2(0, 0));
            }

        } else if (gameState == GameState.FINISHMENU) {

        }
    }

    public void ChangeGameState(GameState newGameState) {
        if (gameState == GameState.STARTMENU) {
            playerControllerRef.UnlockMouse();
        } else if (gameState == GameState.SETTINGMENU) {
            playerControllerRef.UnlockMouse();
            PauseGame();
        } else if (gameState == GameState.CUTSCENE) {
        } else if (gameState == GameState.TUTORIAL) {
            playerControllerRef.LockMouse();
        } else if (gameState == GameState.GAME) {
            playerControllerRef.LockMouse();
        } else if (gameState == GameState.FINISHMENU) {
            playerControllerRef.UnlockMouse();
        }
        gameState = newGameState;
    }

    private void PauseGame() {
        //Pauses objects
    }
}

public enum GameState {
    STARTMENU,
    SETTINGMENU,
    CUTSCENE,
    TUTORIAL,
    GAME,
    FINISHMENU
}