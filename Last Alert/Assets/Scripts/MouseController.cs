using UnityEngine;

public class MouseController {
    
    //Locks mouse to screen
    public static void LockMouse() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Unlocks mouse from screen
    public static void UnlockMouse() {
        Cursor.lockState = CursorLockMode.None;
    }
}