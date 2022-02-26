using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameState gameState {get; private set;}
    public float introTime;
    public float lookingTime;
    public float choosingTime;
    public float intermissionTime;
    [SerializeField] GameObject endPanel;
    [SerializeField] Animator animator;
    [SerializeField] TMP_Text text;
    [SerializeField] FaceGenerator faceGenerator;

    // Start is called before the first frame update
    void Start()
    {
        StartIntroTimer();
    }

    public void StartIntroTimer()
    {
        StartCoroutine(IntroTimer());
    }

    IEnumerator IntroTimer()
    {
        gameState = GameState.INTRO;
        text.text = "Look at this picture. Memorize their face or else we might lose it all.";
        faceGenerator.GenerateRandomFace();
        yield return new WaitForSeconds(introTime - 1f);
        text.text = " ";
        FadeOut();
        yield return new WaitForSeconds(introTime);
        StartLookingTimer();
    }

    public void StartLookingTimer()
    {
        StartCoroutine(LookingTimer());
    }

    IEnumerator LookingTimer()
    {
        gameState = GameState.LOOKING;
        yield return new WaitForSeconds(lookingTime);
        StartIntermissionTimer();
    }

    public void StartIntermissionTimer()
    {
        StartCoroutine(IntermissionTimer());
    }

    IEnumerator IntermissionTimer()
    {
        gameState = GameState.INTERMISSION;
        FadeIn();
        yield return new WaitForSeconds(1f);
        text.text = "Choose the right person! 2 out of 3 of them are imposters.";
        faceGenerator.GenerateSavedFaces();
        yield return new WaitForSeconds(intermissionTime - 1);
        text.text = " ";
        FadeOut();
        yield return new WaitForSeconds(1);
        StartChoosingTimer();
    }

    public void StartChoosingTimer()
    {
        StartCoroutine(ChoosingTimer());
    }

    IEnumerator ChoosingTimer()
    {
        gameState = GameState.CHOOSING;
        yield return new WaitForSeconds(choosingTime);
        gameState = GameState.END;
        ShowEndPanel();
    }

    public void CheckForAnswer(int chosenAnswer)
    {
        StopCoroutine(ChoosingTimer());
        if (chosenAnswer == faceGenerator.correctAnswer)
        {
            Debug.Log("correct!");
        }
        else
        {
            Debug.Log("Dumb bitch!");
        }
        gameState = GameState.END;
        ShowEndPanel();
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
    }

    public void FadeIn()
    {
        animator.Play("FadeIn");
    }

    public void FadeOut()
    {
        animator.Play("FadeOut");
    }
}

public enum GameState
{
    INTRO,
    LOOKING,
    INTERMISSION,
    CHOOSING,
    END
}