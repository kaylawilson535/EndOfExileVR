using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParenting : MonoBehaviour
{
    public GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = rightHand.transform.position;
       // if(//something == null){
           //something
       // }

    }
    
}
