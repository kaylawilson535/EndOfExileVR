using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotcha : MonoBehaviour
{
    public GameObject chaser;
    Transform target;
    public float distanceToTarget;
    public float minimumDistance = 2f;

    private void Update()
    {
        {
            distanceToTarget = Vector3.Distance(chaser.transform.position, transform.position);
        }
        if (distanceToTarget < minimumDistance)
        {
            print("Ahhh!");
        }
    }
}
