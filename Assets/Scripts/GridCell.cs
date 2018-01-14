
using UnityEngine;

public class GridCell : MonoBehaviour{

    public bool visited = false;

    public GameObject northWall;
    public GameObject eastWall;
    public GameObject southWall;
    public GameObject westWall;

    public GameObject floor;

    public int rowIndex = 0;
    public int colIndex = 0;

    private void Awake()
    {
        CreateFloor();
        CreateWalls();
    }

    void CreateFloor()
    {
        floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.transform.localScale = new Vector3(1, 0.01f, 1);
        floor.transform.SetParent(gameObject.transform);
        //floor.GetComponent<Renderer>().material.color = Color.clear;
    }

    void CreateWalls()
    {
        AddNorthWalls();
        AddWestWalls();
    }

    public void AddNorthWalls()
    {
        northWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        northWall.GetComponent<Renderer>().material.color = Color.red;
        northWall.transform.localScale = new Vector3(0.1f, 0.5f, 1);
        northWall.transform.SetParent(gameObject.transform);
        northWall.transform.position = new Vector3(-0.5f, 0, 0);
    }

    public void AddSouthWall()
    {
        //Debug.Log("Adding South Wall");
        southWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        southWall.GetComponent<Renderer>().material.color = Color.red;
        southWall.transform.localScale = new Vector3(0.1f, 0.5f, 1);
        southWall.transform.SetParent(gameObject.transform);
        southWall.transform.position = new Vector3(0.5f, 0, 0);
    }

    public void AddWestWalls() {
        westWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        westWall.GetComponent<Renderer>().material.color = Color.red;
        westWall.transform.localScale = new Vector3(1, 0.5f, 0.1f);
        westWall.transform.SetParent(gameObject.transform);
        westWall.transform.position = new Vector3(0, 0, -0.5f);
    }

    public void AddEastWall()
    {
        eastWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        eastWall.GetComponent<Renderer>().material.color = Color.red;
        eastWall.transform.localScale = new Vector3(1, 0.5f, 0.1f);
        eastWall.transform.SetParent(gameObject.transform);
        eastWall.transform.position = new Vector3(0, 0, 0.5f);
    }

    public void DestroyWall(string direction)
    {
        switch (direction) {
            case "north":
                Destroy(this.northWall);
                break;
            case "east":
                Destroy(this.eastWall);
                break;
            case "south":
                Destroy(this.southWall);
                break;
            case "west":
                Destroy(this.westWall);
                break;
            default:
                Debug.Log("Incorrect Direction");
                break;
        }
    }
}
