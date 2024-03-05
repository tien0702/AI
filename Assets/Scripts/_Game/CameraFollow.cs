using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _target;
    [SerializeField] private float xAxis, yAxis, zAxis;

    private void Awake()
    {
        /*xAxis = transform.position.x;
        yAxis = transform.position.y;
        zAxis = transform.position.z;*/
    }

    private void Update()
    {
        transform.position = new Vector3(_target.position.x + xAxis, _target.position.y + yAxis, _target.position.z + zAxis);
    }
}
