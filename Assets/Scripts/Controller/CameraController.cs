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
        offset = new Vector3(player.position.x,player.position.y+1, player.position.z-3);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.position + offset;
    }
}
