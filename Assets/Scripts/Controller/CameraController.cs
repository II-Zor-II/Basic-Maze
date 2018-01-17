using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 offset;
    private Transform player;
    private Transform board;
    private Camera cam;
    private int rows,col;
	void Start () {
        cam = Camera.main;
        rows = GameObject.Find("Game Manager").GetComponent<GameManager>().rows;
        col = GameObject.Find("Game Manager").GetComponent<GameManager>().col;
        board = GameObject.FindGameObjectWithTag("MazeBoard").transform;

	}
	
	void LateUpdate () {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (GameObject.FindGameObjectWithTag("Player")) {
            offset = new Vector3(board.position.x, board.position.y + 4, board.position.z - 3);
            cam.transform.position = player.position + offset;
        }
        else
        {
            SetCameraToBoardOverview();
        }
    }

    void SetCameraToBoardOverview()
    {
        cam.transform.position = new Vector3(rows/2, col, -rows/2);
    }
}
