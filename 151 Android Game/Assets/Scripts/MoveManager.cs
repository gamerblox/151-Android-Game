using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

    GameObject player;
    Animator anim;

    //game design
    private int currentLane;
    
    //mouse position
    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 touchPos;
    private Touch touch;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();

        currentLane = 0;

    }

    void Update()
    {
        float moveHorizontal;
        float moveVertical; 
        // Check if user touches screen
        if (Input.GetButtonDown("Fire1"))
        {
            // get the x and y coordinates of screen touch
            startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            endPos = startPos;
            // set movement to 0
            moveHorizontal = 0.0f;
            moveVertical = 0.0f;

        }
        // Check if user removes finger from screen
        if (Input.GetButtonUp("Fire1"))
        {
            // get last finger touch coordinates
            endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            // set movement to end touch minus begin touch for both x and y axis
            moveHorizontal = endPos.x - startPos.x;
            moveVertical = endPos.y - startPos.y;
            // create movement variable
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            MoveDirection(movement);

        }

    }

    void MoveDirection(Vector3 movement)
    {
        if (movement.x > 0)
        {
            Debug.Log("Right");
            if (currentLane < 1)
            {
                currentLane++;

            }

        }

        if (movement.x < 0)
        {
            Debug.Log("Left");
            if (currentLane > -1)
            {
                currentLane--;

            }

        }

        if (movement.z > 0)
        {
            Debug.Log("Up");

        }

        anim.SetInteger("movement", currentLane);

    }

}
