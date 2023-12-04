using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    private Rigidbody2D rb;
    Vector3 rotationVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (target.transform.position.x > transform.position.x)
        {
            rotationVector.y = 180;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        else if (target.transform.position.x < transform.position.x)
        {
            rotationVector.y = 0;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
}
