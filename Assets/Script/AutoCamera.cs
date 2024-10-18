using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{
    Transform p;
    public int xCamera;
    public int yCamera;
    public int zCamera;
    void Start()
    {
        p = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = p.position + new Vector3(xCamera, yCamera, zCamera);
    }
}
