using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject chaser;
    Transform target;
    public float distanceToTarget;
    public float minimumDistance = 2f;
    public float distanceStates = 6;
    public string AIStates;

    public GameObject RunningPrefab;
    public GameObject ScreamingPrefab;
    public GameObject ChillingPrefab;

    private float characterVelocity = 2f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;

    private void Update()
    {
        {
            distanceToTarget = Vector3.Distance(chaser.transform.position, transform.position);
            distanceStates = Mathf.Ceil(distanceToTarget);
        }
        switch(distanceStates)
        {
            case 1:
            case 2:
            case 3:
                AIStates = "Gotcha";
                Gotcha();
                break;
            case 4:
            case 5:
            case 6:
                AIStates = "ScreamRun";
                Run();
                break;
            case 7:
            case 8:
            case 9:
                AIStates = "Run";
                Run();
                break;
            default:
                AIStates = "Chill";
                Chill();
                break;
        }
        if (AIStates == "Run" || AIStates == "ScreamRun")
        {

            if (Time.time % 10 == 1)
                
            {
                movementDirection = new Vector2(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1)).normalized;
                movementPerSecond = movementDirection * characterVelocity;
            }

            //move enemy: 
            transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y,
            transform.position.z + (movementPerSecond.y * Time.deltaTime));

        }

    }

    private void Chill()
    {
        print("Chill Expression");
        RunningPrefab.SetActive(false);
        ScreamingPrefab.SetActive(false);
        ChillingPrefab.SetActive(true);
    }


    private void Run()
    {
        print("Running");

        RunningPrefab.SetActive(true);
        ScreamingPrefab.SetActive(false);
        ChillingPrefab.SetActive(false);
    
        if(AIStates == "ScreamRun")
        {
            RunningPrefab.SetActive(false);
            ScreamingPrefab.SetActive(true);
            ChillingPrefab.SetActive(false);
            print("Screaming Audio");
        }
    }

    private void Gotcha()
    {
        RunningPrefab.SetActive(false);
        ScreamingPrefab.SetActive(false);
        ChillingPrefab.SetActive(false);
        print("Boom");
    }
}
