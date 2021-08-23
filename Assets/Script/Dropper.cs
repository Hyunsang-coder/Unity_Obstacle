using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public int timeToWait = 3;
    public float timer;

    MeshRenderer meshRenderer;
    Rigidbody rigid;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigid = GetComponent<Rigidbody>();

        meshRenderer.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToWait)
        {
            meshRenderer.enabled = true;
            rigid.useGravity = true;

        }
    }

}
