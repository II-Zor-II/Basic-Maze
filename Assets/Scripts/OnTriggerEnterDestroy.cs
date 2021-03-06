﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDestroy : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            GameObject.Find("Game Manager").GetComponent<GameManager>().playerInstantiated = false;
        }
    }
}
