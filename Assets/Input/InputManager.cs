using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PauseManager pauseManager;

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!pauseManager.isPaused)
            {
                pauseManager.PauseGame();
            }
            else
            {
                pauseManager.UnpauseGame();
            }
        }
    }

    public void OptionOneButton(InputAction.CallbackContext context)
    {
        
    }
}
