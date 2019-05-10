using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCheck : MonoBehaviour
{
    public GameObject outline;
    public TurnStart callTurnStart;
    public TurnCheck OtherRock;
    public TurnCheck SecOtherRock;
    public AdjustVelocity ChangeVelocity;
    public Points callPoints;
    private bool IfStop = true;
    private bool once = false;
    private bool overLine = false;
    private float timer = 0f;
    private Rigidbody rb;
    private float gravity = 9.81f;
    private float dynamicFriction;
    private float RockForce;
    private float DeAccelerationOfRock;
    private float displacementPrediction;
    private Component rock;
    private float rockWeight;
    private Transform startingPosition;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        dynamicFriction = rb.mass;
        outline.SetActive(false);
    }

    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Player")
        {
            IfStop = false;
            overLine = false;
            OtherRock.InMotion();
            SecOtherRock.InMotion();
            if (once == false)
            {
                callTurnStart.Turn();
                rock = this.gameObject.GetComponent<Component>();
                rockWeight = this.gameObject.GetComponent<Rigidbody>().mass;
                Debug.Log("Using Rock " + rock.name);
                Debug.Log(this.gameObject.name + " weighs " + rockWeight + "kg");
                once = true;
            }
        }
    }

    void OnTriggerEnter(Collider faultLine)
    {
        if (faultLine.gameObject.tag == "ReleaseLine")
        {
            overLine = true;
            Debug.Log("Over FaultLine");
        }
    }

    void Update()
    {
        if (IfStop == false)
        {
            checkStop();
        }

        if (IfStop == false)
        {
            RockForce = gravity * rockWeight * dynamicFriction;
            DeAccelerationOfRock = (RockForce / rockWeight) * -1.0f;
            displacementPrediction = (-1.0f * (rock.GetComponent<Rigidbody>().velocity.z * rock.GetComponent<Rigidbody>().velocity.z)) / (2 * DeAccelerationOfRock);
            Debug.Log("rock velocity: " + rock.GetComponent<Rigidbody>().velocity.z);
            Debug.Log("Prediciting Rock will stop in: " + displacementPrediction + "m");
            outline.SetActive(true);
            Prediction(displacementPrediction);
        }
    }

    void checkStop()
    {
        if (rb.velocity == Vector3.zero && overLine == true)
        {
            IfStop = true;
            outline.SetActive(false);
            OtherRock.InMotion();
            SecOtherRock.InMotion();
            callPoints.PrintScore();
            ChangeVelocity.openMenu();
            Debug.Log("Stopped");
        }

        if (rb.velocity == Vector3.zero && overLine == false)
        {
            IfStop = true;
            outline.SetActive(false);
            OtherRock.InMotion();
            SecOtherRock.InMotion();
        }
    }

    public void InMotion()//right now if we hit another rock it will stop all rocks and prevent collision, then you have to reupdate score if collision
    {
        if(OtherRock.IfStop == false || SecOtherRock.IfStop == false)//basiclly if any other rock in motion then freeze
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("Freeze!");
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Debug.Log("UnFreeze");
        }
    }

    public void fault()
    {
        if(IfStop == false && overLine == true)
        {
            rb.velocity = Vector3.zero;
            IfStop = true;
            OtherRock.InMotion();
            SecOtherRock.InMotion();
            ChangeVelocity.openMenu();
            outline.SetActive(false);
            this.gameObject.SetActive(false);
            Debug.Log("Disable " + rock.name);
        }
    }

    void Prediction(float rockPrediction)
    {
        outline.transform.position = new Vector3(rock.transform.position.x, rock.transform.position.y, rock.transform.position.z + rockPrediction);
    }
}