using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;
    public float laneDistance = 1.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targerPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targerPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        { 
            targerPosition += Vector3.right * laneDistance;
        }

        //transform.position = targerPosition;
        transform.position = Vector3.Lerp(transform.position, targerPosition, 60 * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
