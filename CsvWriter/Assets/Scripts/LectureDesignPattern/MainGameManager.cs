using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{

    private int _currentScore;
    public static MainGameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AdjustScore(int num)
    {
        _currentScore = _currentScore + num;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Score = " + _currentScore);
    }
}
