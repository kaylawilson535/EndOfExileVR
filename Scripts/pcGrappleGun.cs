using UnityEngine;

public class pcGrappleGun : MonoBehaviour
{
  
    public GameObject grappleGunTip;
    private LineRenderer laserLine;
    public static bool isOut = false;
    public bool isHooked = false;

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
           isOut = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isOut = false;
        }

        if (isOut)
        {
            Shoot();
        }
        if (!isOut)
        {
            ReelIn();
        }

        if (isHooked)
        {
            transform.tag = "hooked";
            
        }
        else
        {
            transform.tag = "unhooked";
        }
    }


    private void ReelIn()
    {
        float speed = 1f;
        transform.position = Vector3.MoveTowards(transform.position, grappleGunTip.transform.position, speed);
    }

    private void Shoot()
    {
        float speed = 10 * Time.deltaTime;
       transform.position += grappleGunTip.transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary")
        {
            Debug.Log("Working");
        }
    }
}
