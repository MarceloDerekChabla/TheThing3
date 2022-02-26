using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "ScriptableObjects/ScoreInfo", fileName = "New ScoreInfo")]
public class ScoreInfo : ScriptableObject
{
    public int numberGuessedRight;
    public int numberGuessedRightHighScore;
    public int allTimeotalnumberGuessedRight;
    public int allTimeotalnumberGuessedWrong;

    public void CalculateWinScores(TMP_Text text)
    {
        numberGuessedRight += 1;
        allTimeotalnumberGuessedRight += 1;

        text.text = "You got " + numberGuessedRight + " correct guesses in a row!";

        if (numberGuessedRight > numberGuessedRightHighScore)
        {
            text.text = "New High Score! You got " + numberGuessedRight + " correct guesses in a row!";
        }
    }

    public void CalculateLoseScores()
    {
        numberGuessedRight = 0;
        allTimeotalnumberGuessedWrong += 1;
    }
}