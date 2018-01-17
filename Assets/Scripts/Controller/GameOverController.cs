
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
        float gridHypotenuse = Mathf.Sqrt(Mathf.Pow(rows,2)+Mathf.Pow(col,2));
        GameOverCollider = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameOverCollider.name = "GameOverCollider";
        GameOverCollider.transform.localScale = new Vector3(rows*4+5, 0.1f, col*4+5);
        GameOverCollider.transform.localPosition = new Vector3(GameOverCollider.transform.position.x+rows/2, GameOverCollider.transform.position.y - gridHypotenuse, GameOverCollider.transform.position.z+col/2);

        GameOverCollider.GetComponent<MeshFilter>().mesh.Clear();
        GameOverCollider.GetComponent<Collider>().isTrigger = true;
        GameOverCollider.AddComponent<OnTriggerEnterDestroy>();

        GameOverCollider.AddComponent<GizmoDrawer>();
    }

    private void LateUpdate()
    {
        GameOverCollider.transform.rotation = new Quaternion(0,GameObject.FindGameObjectWithTag("MazeBoard").transform.rotation.y,0, GameObject.FindGameObjectWithTag("MazeBoard").transform.rotation.w);
    }

}
