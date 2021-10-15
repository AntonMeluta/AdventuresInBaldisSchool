using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatsManager
{
    private static string KeyBestScore = "BestScoreSandboxMode";
    private static string Key�omplexityGame = "�omplexityGame";

    private static int bestScore;
    private static int �omplexityGame;

    public static int BestScore
    {
        get
        {
            return bestScore;
        }
    }

    public static int ComplexityGame
    {
        get
        {
            return �omplexityGame;
        }
    }

    public static void SaveResult(int currentScore)
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(KeyBestScore, bestScore);
        }
    }

    public static void LoadResult()
    {
        bestScore = PlayerPrefs.GetInt(KeyBestScore, 0);
    }


    public static void Save�omplexityValue(int value)
    {
        �omplexityGame = value;
        PlayerPrefs.SetInt(Key�omplexityGame, �omplexityGame);
    }

    public static void Load�omplexityValue()
    {
        int defaultValue = 3;
        �omplexityGame = PlayerPrefs.GetInt(Key�omplexityGame, defaultValue);
    }
}
