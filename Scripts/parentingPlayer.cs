using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentingPlayer : MonoBehaviour
{
    public Transform playerPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent == null)
        {
            transform.parent = playerPlatform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
