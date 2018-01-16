using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBoardController : MonoBehaviour {

    private Vector3 prevPosition;

    public int rotateBackSpeed = 1;

    private float x, y, z;

    void Start () {	
	}

	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0)) {
            prevPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0)){
            gameObject.transform.Rotate(new Vector3((Input.mousePosition - prevPosition).x,0,0));
            prevPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(1))
        {
            prevPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            gameObject.transform.Rotate(new Vector3(0, (prevPosition - Input.mousePosition).x, 0));
            prevPosition = Input.mousePosition;
        }
    }

    bool OnDefaultPosition()
    {
        if (gameObject.transform.eulerAngles.x != 0 ||
            gameObject.transform.eulerAngles.y != 0 ||
            gameObject.transform.eulerAngles.z != 0) {
            return false;
        }
        return true;
    }

}
