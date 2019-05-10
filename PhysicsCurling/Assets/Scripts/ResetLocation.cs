using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLocation : MonoBehaviour {
    
    public Player player;
    public TurnStart turn;
    public TurnCheck rock1;
    public TurnCheck rock2;
    public TurnCheck rock3;
    public Transform startingPosition;

    void OnTriggerEnter(Collider PlayerCol)
    {
        if(PlayerCol.gameObject.tag == "Player")
        {
            player.stopPushing();
            PlayerCol.GetComponent<Transform>().transform.position = startingPosition.position;
            Debug.Log("Restlocation");
            rock1.fault();
            rock2.fault();
            rock3.fault();
        }   
    }
}
