using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    //  public GameObject hookPrefab;
    public GameObject grappleGunTip;
    private LineRenderer laserLine;
    public static bool isOut = false;
    public bool isHooked = false;
    public Transform myShield;
    public bool isFrozen;

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isFrozen)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0)
            {
                isOut = true;
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) <= 0)
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

        if (isFrozen)
        {
            if(OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Three))
            {
                isFrozen = false;
            }
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
       // Debug.Log("hook hit tag: " + other.tag + " hit name: " + other.name + " my shield name: " + myShield.name);

        if (other.tag == "shield" && other.name != myShield.name) //
        {
            isFrozen = true;
        }
    }
}
