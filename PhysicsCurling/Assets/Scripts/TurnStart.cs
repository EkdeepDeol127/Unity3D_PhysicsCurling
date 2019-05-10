using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnStart : MonoBehaviour
{
    public Text TurnText;
    private int turn = 0;

    void Start()
    {
        TurnText.text = "Turn: " + turn;
    }

    public void Turn()
    {
            turn++;
            TurnText.text = "Turn: " + turn;
    }
}