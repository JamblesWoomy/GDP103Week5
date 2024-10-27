using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTutorial : MonoBehaviour
{
    public LayerMask layermask;
    public GameObject particleSystem;
    public float fireRate;
    public float fireTimer;
    float nextFire;

    RaycastHit hitInfo;

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        nextFire = 1 / fireRate;
    }

    public void Fire()
    {
        Debug.Log("Jiggy");
        if (fireTimer > nextFire)
        {
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
            if (Physics.Raycast(ray, out RaycastHit hitinfo, 20f, layermask))
            {
            Debug.Log("Hit Something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
            Instantiate(particleSystem, hitinfo.point, Quaternion.identity);
            }
            else
            {
                Debug.Log("Hit Nothing");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
            }
            fireTimer = 0;
        }
    }
}