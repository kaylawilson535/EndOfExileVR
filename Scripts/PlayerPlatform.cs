using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    //Reference "this" once in start
    private Transform movingPlatform;

    //Energy vars
    private int energyRate;
    //_vars
    private float currentEnergy;

    //Step vars
    public float stepEnergyNeeded;
    public float platformSpeed;
    public int stepTime;
    //_vars
    private int currentStep;
    private bool isStepping;
    private IEnumerator stepCoroutine;

    //Fluid vars
    public Vector3 fluidStartingPos;
    public Transform fluid;
    public Transform fluidHolder;

    public MiniGameManager miniGameManager;
    private int endValue;

    void Start()
    {
        isStepping = false;
        energyRate = 0;
        stepEnergyNeeded = 3000f;
        stepTime = 1;
        movingPlatform = transform;
        fluidStartingPos = fluidHolder.transform.position;
        endValue = 8;
    }

    private void FixedUpdate()
    {
        //Debug.Log("Current Energy: " + currentEnergy);
        //Debug.Log("Current energy left ratio: " + Vector3.up * 1.2f * (currentEnergy / stepEnergyNeeded));
        //Debug.Log("Current world position of fluid: " + fluid.transform.position);
        //Debug.Log("Current energy rate: " + energyRate);

        FillEnergyCapsule();

        if (isStepping)
        {
            MovePlatform();
            //Debug.Log("Seen");
        }
        if(currentStep > endValue)
        {
            miniGameManager.EndGame();
        }
    }

    public int CurrentStep()
    {
        return currentStep;
    }

    private void MovePlatform()
    {
        fluidStartingPos = fluidHolder.transform.position;
        movingPlatform.Translate(platformSpeed * Vector3.up * Time.deltaTime, Space.World); //This will run based on a coroutine and var named stepTime
    }

    private void FillEnergyCapsule() //Moves the fluid go up, increases the current energy by the energy rate, checks stepping condition
    {
        currentEnergy += energyRate;
        fluid.transform.position = new Vector3(fluidStartingPos.x, (fluidStartingPos.y + (1.25f * (currentEnergy / stepEnergyNeeded))), fluidStartingPos.z);

        if (currentEnergy > stepEnergyNeeded)
        {
            StepUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hookable")
        {
            energyRate += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "hookable")
        {
            energyRate -= 1;
        }
    }

    private void StepUp() //Resets energy capsule visually and numerically, uses step coroutine to move platform for (stepTime) number of seconds
    {
        currentEnergy = 0;
        currentStep += 1;
        isStepping = true;
        fluidStartingPos.y += 1.0f;
        stepCoroutine = WaitForStep(stepTime);
        StartCoroutine(stepCoroutine);
    }
    private IEnumerator WaitForStep(float waitTime) //Sets isStepping to false after (stepTime) number of seconds which ends the movement of platform
    {
        yield return new WaitForSeconds(waitTime);
        isStepping = false;
    }
}
