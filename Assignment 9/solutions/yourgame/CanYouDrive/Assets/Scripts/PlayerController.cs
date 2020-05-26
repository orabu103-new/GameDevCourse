using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player controlls
    private CharacterController controller;
    private Vector3 direction;
    public float speed = 3f;

    //move left and right variables
    private int DesiredLane = 1;//0 - left, 1 - middle, 2 - right
    public float LaneDistance = 4; // distance between two lanes
    public float MoveToSidesSpeed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime * speed);
        //calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (DesiredLane == 0)
        {
            targetPosition += Vector3.left * LaneDistance;
        }
        else if (DesiredLane == 2)
        {
            targetPosition += Vector3.right * LaneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, MoveToSidesSpeed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        direction.z = speed;

        //get info on which lane we should be in.
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            DesiredLane++;
            if (DesiredLane == 3) DesiredLane = 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DesiredLane--;
            if (DesiredLane == -1) DesiredLane = 0;
        }
    }

}
