using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundPlayer;
    private float playerSpeed = 5f;
    private float gravityValue = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
       controller = gameObject.GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (groundPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y = 0;
        }
        //Rotates player in the direction of movement
        if (move.magnitude > 0)
        {
            gameObject.transform.forward = move;
        }

        
    }
}
