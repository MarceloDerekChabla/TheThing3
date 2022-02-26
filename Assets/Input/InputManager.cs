using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PauseManager pauseManager;
    public GameManager gameManager;
    public int chosenAnswer {get; private set;}

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

    public void OptionLeftButton(InputAction.CallbackContext context)
    {
        if (context.performed && gameManager.gameState == GameState.CHOOSING)
        {
            chosenAnswer = 0;
            gameManager.CheckForAnswer(chosenAnswer);
        }
    }

    public void OptionMiddleButton(InputAction.CallbackContext context)
    {
        if (context.performed && gameManager.gameState == GameState.CHOOSING)
        {
            chosenAnswer = 1;
            gameManager.CheckForAnswer(chosenAnswer);
        }
    }

    public void OptionRightButton(InputAction.CallbackContext context)
    {
        if (context.performed && gameManager.gameState == GameState.CHOOSING)
        {
            chosenAnswer = 2;
            gameManager.CheckForAnswer(chosenAnswer);
        }
    }
}
