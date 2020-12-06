using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldMover : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform thisGO;
    public Transform myShield;
    public Transform[] shieldPos;
    public Transform center;

    int left = 0;
    int right = 1;
    int up = 2;
    int off = 3;

    void Start()
    {
        thisGO = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myShield.LookAt(center);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shieldDetect")
        {
            Debug.Log("hitting detect");
            moveShield(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        {
            defaultShield();
        }
    }

    private void defaultShield()
    {
        Debug.Log("turning off shield");
        myShield.position = shieldPos[off].transform.position;
    }

    private void moveShield(Collider other)
    {
        switch (other.name)
        {
            case "leftDetect":
               // Debug.Log("hitLeft");
                myShield.position = shieldPos[left].transform.position;
                break;

            case "rightDetect":
              //  Debug.Log("hitLeft");
                myShield.position = shieldPos[right].transform.position;
                break;

            case "upDetect":
                myShield.position = shieldPos[up].transform.position;
                break;
        }

    }
}
