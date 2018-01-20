using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Transform target;
    public float yPosOffset;

    void LateUpdate()
    {
        if (target)
        {
            //gets only the y position of target and sets camera position to it, including target y offset
            Vector3 fixedTarget = new Vector3(0, target.position.y - yPosOffset, 0);
            transform.position = fixedTarget + new Vector3(0, 0, -10);

        }

    }

}
