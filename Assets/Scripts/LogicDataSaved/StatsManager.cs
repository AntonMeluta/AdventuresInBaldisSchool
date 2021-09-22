using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatsManager
{
    public static string KeyBestScore;
    public static int bestScore;

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
}
