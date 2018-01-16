using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

    private GameObject GameOverCollider;
    private int rows, col;
    private void Awake()
    {
        rows = FindObjectOfType<GameManager>().rows;
        col = FindObjectOfType<GameManager>().col;
    }

    // Use this for initialization
    void Start () {
        GameOverCollider = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameOverCollider.name = "GameOverCollider";
        GameOverCollider.transform.localScale = new Vector3(rows+4, 0.1f, col+4);
        GameOverCollider.GetComponent<MeshFilter>().mesh.Clear();
        GameOverCollider.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-4, gameObject.transform.position.z);
        GameOverCollider.GetComponent<Collider>().isTrigger = true;
        GameOverCollider.AddComponent<OnTriggerEnterDestroy>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(GameOverCollider.transform.position, GameOverCollider.transform.localScale);
    }

}
