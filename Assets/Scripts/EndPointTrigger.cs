
using UnityEngine;

public class EndPointTrigger : MonoBehaviour
{

    GameObject LevelManager;

    private void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
    }

}
