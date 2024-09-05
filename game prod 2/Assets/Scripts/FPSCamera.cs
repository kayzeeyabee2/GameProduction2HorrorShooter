using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public Transform player;
    private float mouseSens = 2f;
    private  float camVertRot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSens;
        float inputY = Input.GetAxis("Mouse Y") * mouseSens;

        camVertRot -= inputY;//Negative input because inorder for the camera to rotate up it becomes a negative value
        camVertRot = Mathf.Clamp(camVertRot, -90, 90);
        transform.localEulerAngles = Vector3.right * camVertRot;

        player.Rotate(Vector3.up * inputX);
    }
}
