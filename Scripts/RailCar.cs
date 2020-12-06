using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailCar : MonoBehaviour
{
    [SerializeField] Canvas canvasToToggle;
    private Animator _animator = null;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter()
    {
       // if (!canvasToToggle.gameObject.activeSelf)
       // {
            canvasToToggle.gameObject.SetActive(true);
            OpenDoor();
       // }
    }

    void OnTriggerExit()
    {
        if (canvasToToggle.gameObject.activeSelf)
        {
            canvasToToggle.gameObject.SetActive(false);
            CloseDoor();
        }
    }
    void OpenDoor()
    {
        _animator.SetBool("isOpen", true);
    }
    void CloseDoor()
    {
        _animator.SetBool("isOpen", false);
    }
}
