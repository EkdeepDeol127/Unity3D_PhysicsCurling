using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCheck : MonoBehaviour {
    public Points call;
    private int Amount = 5;

    void OnTriggerEnter(Collider Rock)
    {
        if (Rock.gameObject.tag == "Rock")
        {
            call.Score(Amount);
        }
    }

    void OnTriggerExit(Collider Rock)
    {
        if (Rock.gameObject.tag == "Rock")
        {
            call.Score(-Amount);
        }
    }
}
