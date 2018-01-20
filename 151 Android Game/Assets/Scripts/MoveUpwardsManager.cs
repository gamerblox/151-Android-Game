using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpwardsManager : MonoBehaviour {

    //var for player speed
    public float speed;
    public float acceleration;
	
	void Update ()
    {
        //moves the player up forever
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        speed += acceleration;

    }

    public void Died()
    {
        acceleration = 0;
        speed = 0;

    }

}
