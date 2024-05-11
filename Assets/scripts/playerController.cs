using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int speed;
    private Rigidbody rb;
    public float rotationSpeed = 10;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementDir = new Vector3(horizontal, 0, vertical);

        if (movementDir == Vector3.zero)
        {
            Debug.Log("No input");
            return;
        }

        rb.velocity = movementDir * speed;

        var rotationDirection = Quaternion.LookRotation(movementDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime);
        
    }
}
