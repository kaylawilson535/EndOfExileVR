using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Canvas canvasToToggleOn;
    [SerializeField] Canvas canvasToToggleOff;

    public void ToggleCanvas()
    {
        print("button pressed");
        canvasToToggleOn.gameObject.SetActive(true);
        canvasToToggleOff.gameObject.SetActive(false);
    }
}
