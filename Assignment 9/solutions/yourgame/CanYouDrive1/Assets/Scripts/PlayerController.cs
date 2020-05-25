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
    private int DesiredLane = 1;//0,-1,-2 - left, 1 - middle, 2,3 - right
    public float LaneDistance = 4; // distance between two lanes
    public float MoveToSidesSpeed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    private void Update()
    {
        direction.z = speed;

        //get info on which lane we should be in.
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("right move");
            DesiredLane++;
            if (DesiredLane == 4)
            {
                Debug.Log("reset right");
                DesiredLane = 3;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("left move");
            DesiredLane--;
            if (DesiredLane == -3)
            {
                Debug.Log("reset left");
                DesiredLane = -2;
            }
        }
    }
    private void FixedUpdate()
    {
        LaneDistance = 19;
        controller.Move(direction * Time.fixedDeltaTime * speed);
        //calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (DesiredLane == 0)
        {
            //Debug.Log(DesiredLane);
            targetPosition += Vector3.left * LaneDistance;
            Debug.Log(targetPosition);
        }
        else if (DesiredLane == -1)
        {
            LaneDistance = 20;
            //Debug.Log(DesiredLane);
            targetPosition += Vector3.left * LaneDistance;
            targetPosition += Vector3.left * LaneDistance;
            Debug.Log(targetPosition);
        }
        else if (DesiredLane == -2)
        {
            //Debug.Log(DesiredLane);
            targetPosition += Vector3.left * LaneDistance;
            targetPosition += Vector3.left * LaneDistance;
            targetPosition += Vector3.left * LaneDistance;
            Debug.Log(targetPosition);
        }
        else if (DesiredLane == 2)
        {
            LaneDistance = 21;
            //Debug.Log(DesiredLane);
            targetPosition += Vector3.right * LaneDistance;
            Debug.Log(targetPosition);
        }
        else if (DesiredLane == 3)
        {
            //Debug.Log(DesiredLane);
            targetPosition += Vector3.right * LaneDistance;
            targetPosition += Vector3.right * LaneDistance;
            Debug.Log(targetPosition);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, MoveToSidesSpeed * Time.fixedDeltaTime);
    }

}
