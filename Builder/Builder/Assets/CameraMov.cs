using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour {

    public Transform player;
    public GameObject cube;
    public Transform target;
    
    Vector3 offset;

    void Start()
    {
        if (player != null) offset = transform.position - player.position;
    }

    void Update () {
        if (player != null) transform.position = player.position + offset;
        cube.transform.position = target.transform.position; 
    }
}
