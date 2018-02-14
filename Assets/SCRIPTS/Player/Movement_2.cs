using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_2 : MonoBehaviour {
    public float speed = 6;
    public float jumpSpeed = 15;
    public float gravity = 10;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        if(controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        Debug.Log(controller.isGrounded);
	}
}
