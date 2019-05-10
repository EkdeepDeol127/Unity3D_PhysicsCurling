using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    public Text ScoreText;
    private int amount = 0;
    
    void Start () {
        ScoreText.text = "Score: " + amount;
    }

    public void Score(int RingPoints)
    {
        amount += RingPoints;
    }

    public void PrintScore()
    {
        ScoreText.text = "Score: " + amount;
    }
}
