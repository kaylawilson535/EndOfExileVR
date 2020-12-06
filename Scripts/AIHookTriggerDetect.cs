using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHookTriggerDetect : MonoBehaviour
{
    private Transform thisParent;
    private AIGun gunScript;

    public GameObject myShield;
    // Start is called before the first frame update
    void Start()
    {
        
        thisParent = transform.parent;
        gunScript = thisParent.GetComponent<AIGun>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shield" && other.name != myShield.transform.name) //
        {
            gunScript.timePassed = 0;
            gunScript.AIState = "Reeling";
        }

        if (other.tag == "hookable")
        {
            gunScript.isHooked = true;
        }
    }
}
