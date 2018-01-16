using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 offset;
    private Transform player;
    private Transform board;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        board = GameObject.FindGameObjectWithTag("MazeBoard").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        offset = new Vector3(board.position.x,board.position.y + 4, board.position.z - 3);
        if (player != null) {
            transform.position = player.position + offset;
            transform.rotation = Quaternion.Euler(board.eulerAngles.x + 50, 0, 0);
        }
        else
        {
            transform.position = new Vector3(board.position.x, board.position.y + 4, board.position.z);
        }
    }
}
