using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject flare;
    public Transform _camera;

    public int ammo;
    private int fireForce = 2;
    private float upwardForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        

        GameObject projectile = Instantiate(flare, firepoint.position, _camera.rotation);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 force = _camera.transform.forward * fireForce + transform.up * upwardForce;
        rb.AddForce(force,ForceMode.Impulse);
    }
}
