using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatsManager
{
    public static string KeyBestScore;
    public static string Key—omplexityGame;

    public static int bestScore;
    public static int ÒomplexityGame;

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


    public static void Save—omplexityValue(int value)
    {
        ÒomplexityGame = value;
        PlayerPrefs.SetInt(Key—omplexityGame, ÒomplexityGame);
    }

    public static void Load—omplexityValue()
    {
        int defaultValue = 3;
        ÒomplexityGame = PlayerPrefs.GetInt(Key—omplexityGame, defaultValue);
    }
}
