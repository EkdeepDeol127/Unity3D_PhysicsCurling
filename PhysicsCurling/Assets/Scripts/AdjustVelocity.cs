using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustVelocity : MonoBehaviour {

    public GameObject AdjustMenu;
    public Player player;

	void Start ()
    {
        AdjustMenu.SetActive(false);
	}

    public void callAdjustMenu(string newText)
    {
        player.velocity = int.Parse(newText);
    }

    public void openMenu()
    {
        AdjustMenu.SetActive(true);
    }

    public void back()
    {
        AdjustMenu.SetActive(false);
    }
}
