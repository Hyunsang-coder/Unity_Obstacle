using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;

    Vector3 angle;

    void Update()
    {
        angle = new Vector3(xAngle, yAngle, zAngle) *Time.deltaTime;
        transform.Rotate(angle);
    }
}
