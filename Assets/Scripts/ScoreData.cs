using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData 
{
    public int bestScore;
    public int lastScore;

    public ScoreData( )
    {
        bestScore = GameManager.Instance.GetBestScore();
        lastScore = GameManager.Instance.GetLastScore();
    }

}
