using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Flare : MonoBehaviour
{
    Rigidbody rb;
    private float launchForce = 10f;
    public Light flare;
    private float flareTime = 6;
    // Start is called before the first frame update
    void Start()
    {
        flare.enabled = true;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);     
    }

    void Update()
    {
        launchForce = 0;
        
        flareLife();
    }

    void flareLife()
    {
        flareTime -= Time.deltaTime;
        Debug.Log(flareTime);

        if (flareTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
   
}
