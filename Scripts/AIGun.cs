using System;
using UnityEngine;

public class AIGun : MonoBehaviour
{
    public string AIState;
    private string newAIState;


    public GameObject grappleGunTip;
    public GameObject grappleHook;


    private LineRenderer laserLine;
    public static bool isOut = false;

    public static bool isShooting = false;
    public static bool isReeling = false;

    public bool isHooked = false;

    public bool isTargeting = false;

    private int targetNumber;
    public GameObject target;

    public float timePassed;
    private float idleDelay;


    public GameObject[] cubes;
    private bool isMissed;

    

    private void Awake()
    {
        AIState = "Targeting";
        idleDelay = 1;
        //laserLine = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (newAIState != AIState)
        {
            newAIState = AIState;
          //  Debug.Log(AIState);
        }

        switch (AIState)
        {
            case "Shooting":
                ShootState();
                break;

            case "Reeling":
                ReelInState();
                break;

            case "Targeting":
                TargetState();
                break;
            case "Idling":
                IdleState();
                break;
        }

        CheckHook();
    }
    private void CheckHook()
    {
        if (isHooked)
        {
            grappleHook.tag = "hooked";
        }
        else
        {
            grappleHook.tag = "unhooked";
        }

    }
    private void IdleState()
    {
        
    }
    private void TargetState()
    {
        targetNumber = UnityEngine.Random.Range(0, 17);
        target = cubes[targetNumber];
        AIState = "Shooting";
    }
    private void ReelInState()
    {
        float speed = 1f;
        grappleHook.transform.position = Vector3.MoveTowards(grappleHook.transform.position, transform.position, speed);

        timePassed += Time.deltaTime;
        if (timePassed > idleDelay)
        {
            timePassed = 0;
            idleDelay = UnityEngine.Random.Range(2f, 3);
            AIState = "Targeting";
            isHooked = false;
        }

    }
    private void ShootState()
    {
        transform.LookAt(target.transform);
        float speed = 10 * Time.deltaTime;

        grappleHook.transform.position += grappleGunTip.transform.forward * speed;

        if (isHooked || isMissed)
        {
            AIState = "Reeling";
        }
        timePassed += Time.deltaTime;
        if (timePassed > idleDelay)
        {
            timePassed = 0;
            idleDelay = UnityEngine.Random.Range(2f, 3);
            AIState = "Reeling";
            isHooked = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary")
        {
            isMissed = true;
        }


        /*
        if (other.tag == "hookable")
        {
            AIState = "Idling";
        }*/
    }
}
