using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfReferenceScript : MonoBehaviour
{
    public static Transform that;
   
    void Start()
    {
        that = this.gameObject.transform;
    }
}
