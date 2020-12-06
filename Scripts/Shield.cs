using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform[] shieldPos;
    public Transform myShield;
    private Transform thisArm;
    private float timePassed;
    private float idleDelay;
    private int randomIndex;
    public Transform center;

    // Start is called before the first frame update
    void Start()
    {
        idleDelay = UnityEngine.Random.Range(2, 6);
        thisArm = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisArm.LookAt(myShield);
        Look();
    }

    private void Look()
    {
        timePassed += Time.deltaTime;

        if (timePassed > idleDelay)
        {
         //   Debug.Log("Working");
            timePassed = 0;
            idleDelay = UnityEngine.Random.Range(2, 6);
            newShieldLoc();
            
        }
    }

    private void newShieldLoc()
    {
        randomIndex = UnityEngine.Random.Range(0, shieldPos.Length);
      //  Debug.Log("index: " + randomIndex + " pos at index: " + shieldPos[randomIndex].position);
        myShield.position = shieldPos[randomIndex].position;
        myShield.LookAt(center);
    }
}
