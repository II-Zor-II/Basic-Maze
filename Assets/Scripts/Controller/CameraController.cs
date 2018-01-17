using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 offset;
    private Transform player;
    private Transform board;
    private Camera cam;
    private int rows;
	void Start () {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        board = GameObject.FindGameObjectWithTag("MazeBoard").transform;
        rows = GameObject.Find("Game Manager").GetComponent<GameManager>().rows;
        cam.rect = new Rect(0,0,rows/2,1);
	}
	

	void LateUpdate () {
        offset = new Vector3(board.position.x,board.position.y + 4, board.position.z - 3);
        if (player != null) {
            transform.position = player.position + offset;
        }
        else
        {
            transform.position = new Vector3(board.position.x, board.position.y + 4, board.position.z);
        }
    }
}
