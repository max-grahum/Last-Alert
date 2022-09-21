using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Game state
    public GameState gameState;

    //References
    public PlayerController playerControllerRef;
    public PickUpController pickUpControllerRef;
    public WinController winControllerRef;
    public ItemManager itemManagerRef; //Manages all pickup objects in the scene

    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject settingsUI;
    public GameObject gameWinScreen;
    public GameObject gameOverScreen;

    //Start is called before the first frame update
    void Start() {
        itemManagerRef.GetAllPickUps();
        ChangeGameState(GameState.GAME);
    }

    //Update is called once per frame
    void Update() {
        if (gameState == GameState.PAUSEMENU) {
            //Unpause game
            if (Input.GetKeyDown(KeyboardController.pauseKey)) {
                UnpauseGame();
            }

        } else if (gameState == GameState.SETTINGMENU) {
            //Unpause game
            if (Input.GetKeyDown(KeyboardController.pauseKey)) {
                UnpauseGame();
            }

        } else if (gameState == GameState.CUTSCENE) {
            
        } else if (gameState == GameState.GAME) {
            //Move player
            playerControllerRef.MovePlayer();
            playerControllerRef.MoveCamera();

            //Object pick up
            pickUpControllerRef.TryMoveObject();

            //Pause game
            if (Input.GetKeyDown(KeyboardController.pauseKey)) {
                PauseGame();
            }

            //Check for win
            if (winControllerRef.CheckForWin()) {
                GameWon();
            }


            //Example of teleporting the player
            if (Input.GetKey(KeyCode.L)) {
                playerControllerRef.SetLocation(new Vector3(0, 0, 0));
                playerControllerRef.SetCameraAngle(new Vector2(0, 180));
            }

            //Example code of scene switching to make sure it works
            if (Input.GetKeyDown(KeyCode.J)) {
                SceneController.SwitchToStartScene();
            }

        } else if (gameState == GameState.GAMEWIN) {
            pickUpControllerRef.DropObject(true);

        } else if (gameState == GameState.GAMEOVER) {
            pickUpControllerRef.DropObject(true);
        }
    }

    //Actions which need to be done on the change state call
    public void ChangeGameState(GameState newGameState) {
        //BEFORE CHANGE
        if (gameState == GameState.PAUSEMENU) {

        } else if (gameState == GameState.SETTINGMENU) {

        } else if (gameState == GameState.CUTSCENE) {
            
        } else if (gameState == GameState.GAME) {

        } else if (newGameState == GameState.GAMEWIN) {
            
        } else if (newGameState == GameState.GAMEOVER) {
            
        }

        //CHANGE
        gameState = newGameState;

        //AFTER CHANGE
        if (newGameState == GameState.PAUSEMENU) {
            HideAllScreens();
            pauseScreen.SetActive(true);
            MouseController.UnlockMouse();
        } else if (newGameState == GameState.SETTINGMENU) {
            HideAllScreens();
            settingsUI.SetActive(true);
            MouseController.UnlockMouse();
        } else if (newGameState == GameState.CUTSCENE) {
            
        } else if (newGameState == GameState.GAME) {
            HideAllScreens();
            MouseController.LockMouse();
        } else if (newGameState == GameState.GAMEWIN) {
            MouseController.UnlockMouse();
            HideAllScreens();
            gameWinScreen.SetActive(true);
        } else if (newGameState == GameState.GAMEOVER) {
            MouseController.UnlockMouse();
            HideAllScreens();
            gameOverScreen.SetActive(true);
        }
    }
    
    private void HideAllScreens() {
        pauseScreen.SetActive(false);
        settingsUI.SetActive(false);
        gameWinScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    //Pause functions
    public void PauseGame() {
        ChangeGameState(GameState.PAUSEMENU);
        itemManagerRef.PauseAll();
    }

    public void UnpauseGame() {
        ChangeGameState(GameState.GAME);
        itemManagerRef.UnpauseAll();
    }

    //Resume Button
    public void ResumeGame() {
        UnpauseGame();
    }

    //Settings Button
    public void OpenSettings() {
        ChangeGameState(GameState.SETTINGMENU);
    }

    //temporary button to return to pause menu for testing
    public void CloseSettings() {
        ChangeGameState(GameState.PAUSEMENU);
    }

    //Exit Button
    public void Exit() {
        SceneController.SwitchToStartScene();
    }

    private void GameWon() {
        ChangeGameState(GameState.GAMEWIN);
    }

    public void GameOver() {
        ChangeGameState(GameState.GAMEOVER);
    }

    public void saveData(){
        playerControllerRef.savePlayer();
    }

    public void loadData(){
        playerControllerRef.loadPlayer();

        if(playerControllerRef != null){
            print("SaveExists data loading...");
            PlayerData data = SaveSystem.load();
            if(data == null){
                SaveSystem.save(playerControllerRef.transform, false);
                data = SaveSystem.load();
            }
            
            bool yeet = data.saveExists;
        }
    }
}

//Game scene states
public enum GameState {
    PAUSEMENU,
    SETTINGMENU,
    CUTSCENE,
    GAME,
    GAMEWIN,
    GAMEOVER
}