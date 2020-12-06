using System;
using System.Collections;
using UnityEngine;

public class Hookable : MonoBehaviour
{
    private GameObject hookedGO;
    private GameObject hookPrefab;
    public float energySupply;
    private Transform thisCube;
    private bool isDepleting;
    public Vector3 spawnLocation;
    public float startingEnergy;

    public float energyDepletionRate;
    private float energyRatio;

    private float maxTime;
    private float newTime;

    private bool isAIDropping;

    public GameObject[] guns;
    public Guns[] gunScripts;
    private GrappleGun MainGunScript;
    private AIGun AIgun1Script;
    private AIGun AIgun2Script;
    private AIGun AIgun3Script;
    private AIGun AIgun4Script;
    private AIGun AIgun5Script;

    private int whichGun;

    private bool _isHooked;

    public Transform defaultParent;

    private bool isWandering;



    // private GameObject hookedPrefab;

    void Awake()
    {//must change everything to an array
        MainGunScript = guns[0].GetComponent<GrappleGun>();
        AIgun1Script = guns[1].GetComponent<AIGun>();
        AIgun2Script = guns[2].GetComponent<AIGun>();
        AIgun3Script = guns[3].GetComponent<AIGun>();
        AIgun4Script = guns[4].GetComponent<AIGun>();
        AIgun5Script = guns[5].GetComponent<AIGun>();




        _isHooked = false;
        isAIDropping = false;
        maxTime = UnityEngine.Random.Range(4, 6);

        if (thisCube == null) { thisCube = transform; }

        spawnLocation = thisCube.transform.position;

        Respawn();
    }
    private void Respawn()
    {
        isWandering = true;
        thisCube.localScale = new Vector3(1, 1, 1);
        energySupply = startingEnergy;
        if (isDepleting)
        {
            isDepleting = false;
        }

        if (thisCube.transform.position != spawnLocation)
        {
            thisCube.transform.position = spawnLocation;
        }
    }
    private void FixedUpdate()
    {
        // Debug.Log("Current Energy: " + currentEnergy);
        // Debug.Log("less than zero");

        CubeAttacher();
        MakeRandomAction();
        DrainEnergy();
        DropObject();
        Wander();

        if(thisCube.position.y  <= -20)
        {
            Respawn();
        }

        if (energySupply <= 0)
        {
            Respawn();
        }
    }

    private void Wander()
    {
        //TODO AI to make the cubes move around
    }

    private void DrainEnergy()
    {
        //Debug.Log("isDepleting " + isDepleting); //saying false even when cube is touching
        // Debug.Log("!GrappleGun.isHooked " + GrappleGun.isHooked); 

        if (isDepleting && !_isHooked)
        {
            energySupply -= energyDepletionRate;
            energyRatio = energySupply / startingEnergy;
            thisCube.localScale = energyRatio * new Vector3(1.01f, 1.01f, 1.01f);
        }
    }

    private void CubeAttacher()
    {
        if (_isHooked == true && hookedGO != null && hookPrefab != null)
        {
            hookedGO.transform.position = hookPrefab.transform.position;
        }
    }

    private void MakeRandomAction()
    {
        newTime += Time.deltaTime;
        if (newTime > maxTime)
        {
            newTime = 0;
            maxTime = UnityEngine.Random.Range(1, 7);
            //execute random function once
        }
    }

    private void DropObject()
    {

        //if Input.GetMouseButtonDown(1))
        if ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0 ) || isAIDropping)
        { //needs other reference
            switch (whichGun)
            {
                case 0:
                    if (MainGunScript.isHooked == true)
                    {
                        MainGunScript.isHooked = false;
                    }
                    break;

                case 1:
                    if (AIgun1Script.isHooked == true)
                    {
                        AIgun1Script.isHooked = false;
                    }
                    break;
                case 2:
                    if (AIgun2Script.isHooked == true)
                    {
                        AIgun2Script.isHooked = false;
                    }
                    break;
                case 3:
                    if (AIgun3Script.isHooked == true)
                    {
                        AIgun3Script.isHooked = false;
                    }
                    break;
                case 4: 
                    if (AIgun4Script.isHooked == true)
                    {
                        AIgun4Script.isHooked = false;
                    }
                    break;
                case 5:
                    if (AIgun5Script.isHooked == true)
                    {
                        AIgun5Script.isHooked = false;
                    }
                    break;
            }
            if (isAIDropping)
            {
                isAIDropping = false;
            }
            if (_isHooked)
            {
                _isHooked = false;
            }
            if (hookedGO != null)
            {
                hookedGO.transform.parent = defaultParent;
                var hooked_Rigidbody = hookedGO.GetComponent<Rigidbody>();
                hooked_Rigidbody.isKinematic = false;
                hookedGO = null;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        /* if(other.tag != "Untagged")
         {
             Debug.Log(other.tag);
         } */
     //   Debug.Log(other.name);

        if (other.tag == "unhooked")
        {
            other.tag = "hooked";
            GrabPickup(other);
            SetIsHooked(other);
        }
        if (other.tag == "player platform")
        {
            isDepleting = true;
        }
        if (other.tag == "AIGun")
        {
            isAIDropping = true;
        }

    }

    private void SetIsHooked(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "GrappleHook":
                MainGunScript.isHooked = true;
                whichGun = 0;
                //      Debug.Log("Seen");
                break;

            case "AIGrapple1":
                    AIgun1Script.isHooked = true;
                whichGun = 1;          
                break;
            case "AIgrapple2":
                AIgun1Script.isHooked = true;
                whichGun = 2;
                break;
            case "AIgrapple3":
                AIgun1Script.isHooked = true;
                whichGun = 3;
                break;
            case "AIgrapple4":
                AIgun1Script.isHooked = true;
                whichGun = 4;
                break;
            case "AIGrapple5":
                AIgun1Script.isHooked = true;
                whichGun = 5;
                break;
        }
    }
    private void GrabPickup(Collider other)
    {

        if (!_isHooked)
        {
            _isHooked = true;
            isWandering = false;
       //     Debug.Log(hookedGO);
            if (hookedGO == null)
            {

                hookedGO = gameObject;
                var hooked_Rigidbody = hookedGO.GetComponent<Rigidbody>();
                hooked_Rigidbody.isKinematic = true;

                hookPrefab = other.gameObject;
                hookedGO.transform.parent = hookPrefab.transform;
            }
        }
    }
}

