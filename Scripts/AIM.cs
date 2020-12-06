using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM : MonoBehaviour
{
    public Transform gun;
    private AIGun gunScript;
    private Transform thisObject;

    private Transform aimTarget;
    // Start is called before the first frame update
    void Start()
    {
        gunScript = gun.GetComponent<AIGun>();
        thisObject = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gunScript.target != null)
        {
            aimTarget = gunScript.target.transform;
        }
        else
        {
            aimTarget = null;
        }

        if(aimTarget != null)
        {
            thisObject.LookAt(aimTarget);
        }

    }
}
